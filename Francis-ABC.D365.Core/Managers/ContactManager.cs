


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

    public static void SetValuesForReadOnlyFields(IOrganizationService organizationService, ITracingService tracingService, Contact contact)
    {
      contact.abc_Age = calculateAge(contact.abc_DateOfBirth);
      contact.abc_MaturityDate = calculateMaturityDate(contact.abc_JoiningDate, contact.abc_InvestmentPeriod);
      contact.abc_EstimatedReturn = calculateEstimatedReturn(contact.abc_JoiningDate, contact.abc_InitialInvestment, contact.abc_InterestRate, contact.abc_InvestmentPeriod);
      // contact.abc_StatusReason = OptionSetValue;
    }

    private static string calculateAge(DateTime? abc_DateOfBirth)
    {
      throw new NotImplementedException();
    }

    private static DateTime? calculateMaturityDate(DateTime? abc_JoiningDate, int? abc_InvestmentPeriod)
    {
      return new DateTime(DateTime.Now.Year + 100, DateTime.Now.Month, DateTime.Now.Day);
    }

    private static Money calculateEstimatedReturn(DateTime? abc_JoiningDate, Money abc_InitialInvestment, decimal? abc_InterestRate, int? abc_InvestmentPeriod)
    {
      return new Money(1000000);
    }

    public static void NotifyClientAboutChanges(IOrganizationService service, IServiceProvider serviceProvider, ITracingService tracingService, Contact contactPre, Contact contactPost)
    {
      if (EntityManager.HaveValuesChanged(contactPre, contactPost, Contact.Fields.abc_EstimatedReturn, Contact.Fields.abc_InitialInvestment, Contact.Fields.abc_InterestRate, Contact.Fields.abc_InvestmentPeriod))
      {
        tracingService.Trace("Copying contract for revised renewal.");
        tracingService.Trace("Completed contract copy for revised renewal.");
      }
    }

  }
}
