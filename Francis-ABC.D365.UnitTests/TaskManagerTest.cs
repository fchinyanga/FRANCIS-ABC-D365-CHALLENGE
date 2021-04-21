using System.Collections.Generic;
using System.Linq;
using Francis_ABC.D365.Plugins.Core.Managers;
using Francis_ABC.D365.Plugins.Entities;
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
      TaskManager.CreateTaskAboutAFollowUpMeeting(unitTestHelper.OrganizationService, unitTestHelper.ExecutionContext, unitTestHelper.ServiceProvider, unitTestHelper.TracingService);//);
      var activities = unitTestHelper.XrmFakedContext.CreateQuery<Task>().ToList();
      Assert.Equal((object)1, activities.Count);
    }
  }
}
