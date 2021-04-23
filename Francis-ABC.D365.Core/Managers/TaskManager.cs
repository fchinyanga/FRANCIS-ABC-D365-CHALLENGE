using System;
using Francis_ABC.D365.Entities;
using Microsoft.Xrm.Sdk;

namespace Francis_ABC.D365.Core.Managers
{
  public class TaskManager
  {

    public TaskManager()
    {
    }

    public static void CreateTaskAboutAFollowUpMeeting(IOrganizationService service, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
    {

      try
      {
        tracingService.Trace("Executing create Task Method");
        if (pluginExecutionContext.OutputParameters.Contains("id"))
        {
          Guid regardingobjectid = new Guid(pluginExecutionContext.OutputParameters["id"].ToString());
          Guid searchID = (Guid)((Entity)pluginExecutionContext.InputParameters["Target"]).Id;
          string regardingobjectidType = "contact";
          tracingService.Trace(searchID.ToString());
          Task followupTask = new Task
          {
            Subject = "Send e-mail to the new customer.",
            Description =
              "Follow up with the customer. Check if there are any new issues that need resolution.",
            ScheduledStart = DateTime.Now.AddDays(7),
            ScheduledEnd = DateTime.Now.AddDays(7),
            Category = pluginExecutionContext.PrimaryEntityName,
            RegardingObjectId =
          new EntityReference(regardingobjectidType, regardingobjectid)
          };
          tracingService.Trace("FollowupPlugin: Creating the task activity.");
          service.Create(followupTask);
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
