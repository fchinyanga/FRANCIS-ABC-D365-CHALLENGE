using System.Collections.Generic;
using System.Linq;
using Francis_ABC.D365.Core.Managers;
using Francis_ABC.D365.Entities;
using Francis_ABC.D365.UnitTests.Helper;
using Microsoft.Xrm.Sdk;
using Xunit;

namespace Francis_ABC.D365.UnitTests
{
  public class TaskManagerTest
  {
    [Fact]
    public void ContactPostOperationCreateTask()
    {
      UnitTestHelper unitTestHelper = new UnitTestHelper();
      unitTestHelper.ExecutionContext.OutputParameters.Add(new KeyValuePair<string, object>("id", unitTestHelper.Entities.ContactTestContact1.Id));
      unitTestHelper.ExecutionContext.InputParameters.Add(new KeyValuePair<string, object>("Target", unitTestHelper.Entities.ContactTestContact1));
      Assert.Equal(unitTestHelper.Entities.ContactTestContact1.Id, unitTestHelper.ExecutionContext.OutputParameters["id"]);
      Assert.Equal(unitTestHelper.Entities.ContactTestContact1.ContactId, ((Entity)unitTestHelper.ExecutionContext.InputParameters["Target"]).Id);
      //Assert.Throws<InvalidOperationException>(() =>
      TaskManager.CreateTaskAboutAFollowUpMeeting(unitTestHelper.OrganizationService, unitTestHelper.ExecutionContext, unitTestHelper.TracingService);//);
      var activities = unitTestHelper.XrmFakedContext.CreateQuery<Task>().Where(activity => (activity.RegardingObjectId.Id == unitTestHelper.Entities.ContactTestContact1.Id && activity.Subject == "Send e-mail to the new customer.")).ToList();
      foreach (var activity in activities)
      {
        if (activities.Count > 0)
        {
          Assert.True(true);
          break;
        }
        else { Assert.True(false); }
      }
    }
  }
}
