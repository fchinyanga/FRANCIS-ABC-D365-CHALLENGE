﻿namespace Francis_ABC.D365.Plugins.Core.Managers
{

  using System;
  using Francis_ABC.D365.Plugins.Entities;
  using Microsoft.Xrm.Sdk;

  public class ContactManager
  {

    public ContactManager()
    {

    }

    public static void SetValuesForReadOnlyFields(IOrganizationService organizationService, ITracingService tracingService, Contact contact)
    {
      contact.abc_ClientAge = calculateAge(contact.abc_DateOfBirth);
      contact.abc_StatusReasonEnum = Contact_abc_StatusReason.ActiveInForce;
      contact.abc_MaturityDate = calculateMaturityDate(contact.abc_JoiningDate, contact.abc_InvestmentPeriod);
      contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contact.abc_InterestRate, contact.abc_InvestmentPeriod);
      tracingService.Trace($"Entered my method .Execute() {contact.abc_ClientAge.ToString()}");
    }

    private static int calculateAge(DateTime? abc_DateOfBirth)
    {
      if (abc_DateOfBirth == null)
        return 0;
      var today = DateTime.Today;
      var age = today.Year - abc_DateOfBirth?.Year;
      if (abc_DateOfBirth?.Date > today.AddYears((int)-age)) age--;
      return (int)age;
    }

    private static DateTime? calculateMaturityDate(DateTime? abc_JoiningDate, int? abc_InvestmentPeriod)
    {
      return new DateTime((int)abc_JoiningDate?.Year, (int)abc_JoiningDate?.Month + (int)abc_InvestmentPeriod, (int)abc_JoiningDate?.Day);
    }

    private static Money calculateEstimatedReturn(Money abc_InitialInvestment, decimal? abc_InterestRate, int? abc_InvestmentPeriod)
    {
      decimal estimatedReturnAmount = abc_InitialInvestment.Value + (decimal)(abc_InterestRate * abc_InvestmentPeriod);
      return new Money(estimatedReturnAmount);
    }

    public static void NotifyClientAboutChanges(IOrganizationService service, LocalPluginContext context, IServiceProvider serviceProvider, ITracingService tracingService, Contact contactPre, Contact contactPost)
    {
      tracingService.Trace("Entered notify client email");
      if (EntityManager.HaveValuesChanged(contactPre, contactPost, Contact.Fields.abc_EstimatedReturn, Contact.Fields.abc_InitialInvestment, Contact.Fields.abc_InterestRate, Contact.Fields.abc_InvestmentPeriod))
      {
        double prevInterestRate = (double)contactPre.abc_InterestRate;
        double newInterestRate = (double)contactPost.abc_InterestRate;
        var prevInvestmentPeriod = contactPre.abc_InvestmentPeriod;
        var newInvestmentPeriod = contactPost.abc_InvestmentPeriod;
        Money prevInitialInvestment = contactPre.abc_InitialInvestment;
        Money newInitialInvestment = contactPost.abc_InitialInvestment;
        EmailManager.sendEmailFromTemplate(service, context, tracingService, prevInitialInvestment, newInitialInvestment,
          prevInterestRate, newInterestRate, prevInvestmentPeriod, newInvestmentPeriod);
      }

    }
  }
}