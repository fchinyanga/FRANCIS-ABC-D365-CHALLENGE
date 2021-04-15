


namespace Francis_ABC.D365.Plugins.Core.Managers
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

    private static string calculateAge(DateTime? abc_DateOfBirth)
    {
      if (abc_DateOfBirth == null)
        return "";
      var today = DateTime.Today;
      var age = today.Year - abc_DateOfBirth?.Year;
      if (abc_DateOfBirth?.Date > today.AddYears((int)-age)) age--;
      return age.ToString();
    }

    private static DateTime? calculateMaturityDate(DateTime? abc_JoiningDate, int? abc_InvestmentPeriod)
    {
      return new DateTime(DateTime.Now.Year + 100, DateTime.Now.Month, DateTime.Now.Day);
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

    public static void CreateTaskAboutAFollowUpMeeting(IOrganizationService service, IServiceProvider serviceProvider, ITracingService tracingService)
    {
      IPluginExecutionContext pluginExecutionContext = (IPluginExecutionContext)
    serviceProvider.GetService(typeof(IPluginExecutionContext));
      tracingService.Trace("Executing create Task Method");
      Entity followup = new Entity("task");
      followup["subject"] = "Send e-mail to the new customer.";
      followup["description"] =
          "Follow up with the customer. Check if there are any new issues that need resolution.";
      followup["scheduledstart"] = DateTime.Now.AddDays(7);
      followup["scheduledend"] = DateTime.Now.AddDays(7);
      followup["category"] = pluginExecutionContext.PrimaryEntityName;
      if (pluginExecutionContext.OutputParameters.Contains("id"))
      {
        Guid regardingobjectid = new Guid(pluginExecutionContext.OutputParameters["id"].ToString());
        Guid searchID = (Guid)((Entity)pluginExecutionContext.InputParameters["Target"]).Id;
        string regardingobjectidType = "contact";
        tracingService.Trace(searchID.ToString());

        followup["regardingobjectid"] =
        new EntityReference(regardingobjectidType, regardingobjectid);
      }
      tracingService.Trace("FollowupPlugin: Creating the task activity.");
      service.Create(followup);
    }



  }
}
