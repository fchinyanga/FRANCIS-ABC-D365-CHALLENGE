using System;
using Microsoft.Xrm.Sdk;

namespace Francis_ABC.D365.Plugins.Core.Managers
{
  class TaskManager
  {

    public TaskManager()
    {
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
