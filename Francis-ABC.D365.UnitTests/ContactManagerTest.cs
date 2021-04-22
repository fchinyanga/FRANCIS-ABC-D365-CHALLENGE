using System;
using System.Linq;
using Francis_ABC.D365.Plugins.Core.Managers;
using Francis_ABC.D365.Plugins.Entities;
using Francis_ABC.D365.UnitTests.Helper;
using Microsoft.Xrm.Sdk;
using Xunit;

namespace Francis_ABC.D365.UnitTests
{
  public class ContactManagerTest
  {
    [Fact]
    public void calculateClientAge()
    {
      int age = ContactManager.calculateAge(new System.DateTime(1992, 2, 29));
      Assert.Equal(29, age);
    }

    [Fact]
    public void testInvestmentUpdateNotification()
    {
      Contact contactPre = new Contact()
      {
        Id = new Guid("F128A4C8-966D-48AB-A63A-F44737CBDF04"),
        ContactId = new Guid("38AE02E7-2780-4E49-A851-3359B0697F0F"),
        Address1_Country = "GB",
        abc_CorporateClientName = "JJ",
        abc_IndividualClientName = "PJ",
        abc_ClientAge = 29,
        abc_InitialInvestment = new Money(1000),
        abc_InterestRate = 10,
        abc_InvestmentPeriod = 10,
      };

      Contact contactPost = new Contact()
      {
        Id = new Guid("F128A4C8-966D-48AB-A63A-F44737CBDF04"),
        ContactId = new Guid("38AE02E7-2780-4E49-A851-3359B0697F0F"),
        Address1_Country = "GB",
        abc_CorporateClientName = "JJ",
        abc_IndividualClientName = "PJ",
        abc_ClientAge = 29,
        abc_InitialInvestment = new Money(1000),
        abc_InterestRate = 14,
        abc_InvestmentPeriod = 10,
      };
      UnitTestHelper unitTestHelper = new UnitTestHelper();
      unitTestHelper.OrganizationService.Create(contactPre);
      unitTestHelper.OrganizationService.Update(contactPost);
      ContactManager.NotifyClientAboutChanges(unitTestHelper.OrganizationService, unitTestHelper.ExecutionContext, unitTestHelper.ServiceProvider, unitTestHelper.TracingService, contactPre, contactPost);
      var emails = unitTestHelper.XrmFakedContext.CreateQuery<Email>().Where(e => (e.Subject == "Investment Update Notification" && e.RegardingObjectId.Id == contactPre.ToEntityReference().Id)).ToList();
      if (emails.Count > 0)
      {
        Assert.True(true);
      }
      else { Assert.True(false); }
    }
  }

}
