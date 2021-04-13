using System;
using System.Activities;
using Francis_ABC_D365.Emailing;
using Francis_ABC_D365.Emailing.EmailTemplates;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;

namespace Francis_ABC.D365.Workflows.Workflows
{
  class RemindAClientWorkflow : CodeActivity
  {
    [Input("Client Name")]
    [RequiredArgument]
    [ReferenceTarget("abc_contact")]
    public InArgument<EntityReference> Contact { get; set; }
    protected override void Execute(CodeActivityContext context)
    {
      try
      {
        IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
        IOrganizationServiceFactory serviceFactory = context.GetExtension<IOrganizationServiceFactory>();
        IOrganizationService service = serviceFactory.CreateOrganizationService(workflowContext.InitiatingUserId);

        Guid contactId = this.Contact.Get(context).Id;
        Entity contactEntity = service.Retrieve("abc_contact", contactId, new ColumnSet("abc_corparateclientname", "emailaddress1"));

        String contactName = "";
        String emailAddress = ""; ;
        double investmentAmount = 0.0;
        double interestRate = 0.0;
        int investmentPeriod = 0;

        if (contactEntity.Contains("abc_corparateclientname"))
        {
          contactName = (String)contactEntity["abc_corparateclientname"];
        }
        if (contactEntity.Contains("abc_investmentamount"))
        {
          investmentAmount = (Double)contactEntity["abc_investmentamount"];
        }
        if (contactEntity.Contains("abc_interestrate"))
        {
          interestRate = (Double)contactEntity["abc_interestrate"];
        }
        if (contactEntity.Contains("abc_investmentperiod"))
        {
          investmentPeriod = (Int32)contactEntity["abc_investmentperiod"];
        }

        string emailBody = RemindAClientEmailTemplate.HtlStringBody(contactName, investmentAmount, investmentPeriod, interestRate);
        ABCEmailing abcEmailing = new ABCEmailing();
        abcEmailing.sendEmail(emailAddress, "Reminder about your ABC investment", emailBody);
      }
      catch (Exception ex)
      {
        throw new InvalidPluginExecutionException(ex.Message);
      }
    }
  }
}

