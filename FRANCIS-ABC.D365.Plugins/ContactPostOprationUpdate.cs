
namespace Francis_ABC.D365.Plugins
{

  using Francis_ABC.D365.Core.Managers;
  using Francis_ABC.D365.Entities;

  [CrmPluginRegistration(
    MessageNameEnum.Create,
    Contact.EntityLogicalName,
    StageEnum.PreOperation,
    ExecutionModeEnum.Synchronous,
    "",
    "Francis_ABC.D365.Plugins.ContactPostOperationUpdate",
    1,
    IsolationModeEnum.Sandbox,
    Id = "53c1f0cc-0a36-ea11-a813-000d3ab36169",
    Description = "Francis_ABC.D365.Plugins.ContactPostOperationUpdate")]
  public class ContactPostOperationUpdate : PluginBase
  {

    public ContactPostOperationUpdate(string unsecure, string secure)
        : base(typeof(ContactPreOperationCreate))
    {
    }

    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
    {
      localContext.Trace($"Entered my method Execute()");
      Contact contactPre = localContext.PluginExecutionContext.PreEntityImages["contactPostOperationUpdatePreImage"].ToEntity<Contact>();
      Contact contactPost = localContext.PluginExecutionContext.PostEntityImages["contactPostOperationUpdatePostImage"].ToEntity<Contact>();
      ContactManager.NotifyClientAboutChanges(localContext.OrganizationService, localContext.PluginExecutionContext, localContext.ServiceProvider, localContext.TracingService, contactPre, contactPost);
    }
  }

}
