namespace Francis_ABC.D365.Plugins.Plugins
{
  using Francis_ABC.D365.Core.Helpers.Plugins.Update;
  using Francis_ABC.D365.Core.Managers;
  using Francis_ABC.D365.Entities;

  [CrmPluginRegistration(
    MessageNameEnum.Create,
    Contact.EntityLogicalName,
    StageEnum.PreOperation,
    ExecutionModeEnum.Synchronous,
    "",
    "Francis_ABC.D365.Plugins.ContactPreOperationUpdate",
    1,
    IsolationModeEnum.Sandbox,
    Id = "53c1f0cc-0a36-ea11-a813-000d3ab3926x",
    Description = "Francis_ABC.D365.Plugins.ContactPreOperationUpdate")]
  public class ContactPreOperationUpdate : PluginBase
  {


    public ContactPreOperationUpdate(string unsecure, string secure)
        : base(typeof(ContactPreOperationUpdate))
    {
    }

    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
    {
      localContext.Trace($"Entered my method .Execute()");
      Contact contact = InputParameters.GetTarget(localContext.PluginExecutionContext).ToEntity<Contact>();
      Contact contactPre = localContext.PluginExecutionContext.PreEntityImages["contactPreOperationUpdatePreImage"].ToEntity<Contact>();

      ContactManager.SetValuesForReadOnlyFieldsOnPreUpdate(localContext.OrganizationService, localContext.TracingService, contactPre, contact);
    }
  }
}
