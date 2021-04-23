namespace Francis_ABC.D365.Core.Managers
{

  using System;
  using Francis_ABC.D365.Entities;
  using Microsoft.Xrm.Sdk;

  public class ContactManager
  {

    public ContactManager()
    {

    }

    public static void SetValuesForReadOnlyFieldsOnPreCreate(IOrganizationService organizationService, ITracingService tracingService, Contact contact)
    {
      contact.abc_ClientAge = calculateAge(contact.abc_DateOfBirth);
      contact.abc_StatusReasonEnum = Contact_abc_StatusReason.ActiveInForce;
      contact.abc_MaturityDate = calculateMaturityDate(contact.abc_JoiningDate, contact.abc_InvestmentPeriod);
      contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contact.abc_InterestRate, contact.abc_InvestmentPeriod);
      tracingService.Trace($"Entered my method .Execute() {contact.abc_ClientAge.ToString()}");
    }

    public static void SetValuesForReadOnlyFieldsOnPreUpdate(IOrganizationService organizationService, ITracingService tracingService, Contact contactPre, Contact contact)
    {

      if (contact.abc_DateOfBirth != null)
      {
        contact.abc_ClientAge = calculateAge(contact.abc_DateOfBirth);
      }

      if (contact.abc_JoiningDate != null && contact.abc_InvestmentPeriod != null)
      {
        contact.abc_MaturityDate = calculateMaturityDate(contact.abc_JoiningDate, contact.abc_InvestmentPeriod);
      }

      if (contact.abc_JoiningDate != null && contact.abc_InvestmentPeriod == null)
      {
        contact.abc_MaturityDate = calculateMaturityDate(contact.abc_JoiningDate, contactPre.abc_InvestmentPeriod);
      }

      if (contact.abc_JoiningDate == null && contact.abc_InvestmentPeriod != null)
      {
        contact.abc_MaturityDate = calculateMaturityDate(contactPre.abc_JoiningDate, contact.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod != null && contact.abc_InitialInvestment != null && contact.abc_InterestRate != null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contact.abc_InterestRate, contact.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod == null && contact.abc_InitialInvestment != null && contact.abc_InterestRate != null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contact.abc_InterestRate, contactPre.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod == null && contact.abc_InitialInvestment == null && contact.abc_InterestRate != null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contactPre.abc_InitialInvestment, contact.abc_InterestRate, contactPre.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod == null && contact.abc_InitialInvestment != null && contact.abc_InterestRate == null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contactPre.abc_InterestRate, contactPre.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod != null && contact.abc_InitialInvestment == null && contact.abc_InterestRate != null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contactPre.abc_InitialInvestment, contact.abc_InterestRate, contact.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod != null && contact.abc_InitialInvestment == null && contact.abc_InterestRate == null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contactPre.abc_InitialInvestment, contactPre.abc_InterestRate, contact.abc_InvestmentPeriod);
      }

      if (contact.abc_InvestmentPeriod != null && contact.abc_InitialInvestment != null && contact.abc_InterestRate == null)
      {
        contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_InitialInvestment, contactPre.abc_InterestRate, contact.abc_InvestmentPeriod);
      }

      contact.abc_StatusReasonEnum = Contact_abc_StatusReason.ActiveInForce;
      tracingService.Trace($"Entered my method .Execute() {contact.abc_ClientAge.ToString()}");
    }

    public static int calculateAge(DateTime? abc_DateOfBirth)
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
      return abc_JoiningDate?.AddMonths((int)abc_InvestmentPeriod);
    }

    private static Money calculateEstimatedReturn(Money abc_InitialInvestment, decimal? abc_InterestRate, int? abc_InvestmentPeriod)
    {
      decimal estimatedReturnAmount = abc_InitialInvestment.Value + (decimal)(abc_InterestRate * abc_InvestmentPeriod);
      return new Money(estimatedReturnAmount);
    }

    public static void NotifyClientAboutChanges(IOrganizationService service, IPluginExecutionContext pluginExecutionContext, IServiceProvider serviceProvider, ITracingService tracingService, Contact contactPre, Contact contactPost)
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
        EmailManager.sendEmailFromTemplate(service, contactPost, pluginExecutionContext, tracingService, prevInitialInvestment, newInitialInvestment,
          prevInterestRate, newInterestRate, prevInvestmentPeriod, newInvestmentPeriod);
      }

    }
  }
}
