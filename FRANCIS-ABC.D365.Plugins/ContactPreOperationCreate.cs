
namespace Francis_ABC.D365.Plugins
{
  using Francis_ABC.D365.Plugins.Core.Helpers.Create;
  using Francis_ABC.D365.Plugins.Core.Managers;
  using Francis_ABC.D365.Plugins.Entities;

  [CrmPluginRegistration(
    MessageNameEnum.Create,
    Contact.EntityLogicalName,
    StageEnum.PreOperation,
    ExecutionModeEnum.Synchronous,
    "",
    "Francis_ABC.D365.Plugins.ContactPreOperationCreate",
    1,
    IsolationModeEnum.Sandbox,
    Id = "53c1f0cc-0a36-ea11-a813-000d3ab3626x",
    Description = "Francis_ABC.D365.Plugins.ContactPreOperationCreate")]
  public class ContactPreOperationCreate : PluginBase
  {


    public ContactPreOperationCreate(string unsecure, string secure)
        : base(typeof(ContactPreOperationCreate))
    {
    }

    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
    {
      localContext.Trace($"Entered my method .Execute()");
      Contact contact = InputParameters.GetTarget(localContext.PluginExecutionContext).ToEntity<Contact>();
      ContactManager.SetValuesForReadOnlyFields(localContext.OrganizationService, localContext.TracingService, contact);
    }
  }

}
