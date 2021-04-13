using System;
using System.Activities;
using Francis_ABC_D365.Emailing;
using Francis_ABC_D365.Emailing.EmailTemplates;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;

namespace Francis_ABC.D365.Workflows.Workflows
{
  class WelcomeAClientWorkflow : CodeActivity
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
        String contactName, emailAddress;
        if (contactEntity.Contains("abc_corparateclientname"))
        {
          contactName = (String)contactEntity["abc_corparateclientname"];
          emailAddress = (String)contactEntity["emailddress1"];
          string emailBody = WelcomeAClientEmailTemplate.HtlStringBody(contactName, emailAddress);
          ABCEmailing abcEmailing = new ABCEmailing();
          abcEmailing.sendEmail(emailAddress, "Welcome to ABC", emailBody);
        }
        else
        {
          return;
        }
      }
      catch (Exception ex)
      {
        throw new InvalidPluginExecutionException(ex.Message);
      }
    }
  }
}
