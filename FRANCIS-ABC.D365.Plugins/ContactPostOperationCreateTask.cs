namespace Francis_ABC.D365.Plugins
{
  using Francis_ABC.D365.Plugins.Core.Managers;
  using Francis_ABC.D365.Plugins.Entities;

  [CrmPluginRegistration(
    MessageNameEnum.Create,
    Contact.EntityLogicalName,
    StageEnum.PreOperation,
    ExecutionModeEnum.Synchronous,
    "",
    "Francis_ABC.D365.Plugins.ContactPostOperationCreateTask",
    1,
    IsolationModeEnum.Sandbox,
    Id = "53c1f0cc-0a36-ea11-a813-000d3ab3627s",
    Description = "Francis_ABC.D365.Plugins.ContactPostOperationCreateTask")]
  public class ContactPostOperationCreateTask : PluginBase
  {


    public ContactPostOperationCreateTask(string unsecure, string secure)
        : base(typeof(ContactPreOperationCreate))
    {
    }

    protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
    {
      localContext.Trace($"Entered my method create task .Execute()");
      TaskManager.CreateTaskAboutAFollowUpMeeting(localContext.OrganizationService, localContext.ServiceProvider, localContext.TracingService);
    }
  }

}

