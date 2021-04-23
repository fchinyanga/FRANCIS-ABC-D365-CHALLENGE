using System;
using System.Linq;
using Francis_ABC.D365.Core.Managers;
using Francis_ABC.D365.Entities;
using Francis_ABC.D365.UnitTests.Helper;
using Microsoft.Xrm.Sdk;
using Xunit;

namespace Francis_ABC.D365.UnitTests
{
  public class EmailManagerTest
  {
    [Fact]
    public void SendEmailTest()
    {
      Contact contact = new Contact()
      {
        Id = new Guid("F128A4C8-966D-48AB-A63A-F44737CBDF04"),
        ContactId = new Guid("38AE02E7-2780-4E49-A851-3359B0697F0F"),
        Address1_Country = "GB",
        abc_CorporateClientName = "JJ",
        abc_IndividualClientName = "PJ",
        abc_ClientAge = 29,
        abc_InitialInvestment = new Money(1000),
        abc_InterestRate = 2,
        abc_InvestmentPeriod = 10,
      };

      UnitTestHelper unitTestHelper = new UnitTestHelper();
      unitTestHelper.OrganizationService.Create(contact);
      EmailManager.sendEmailFromTemplate(unitTestHelper.OrganizationService, contact, unitTestHelper.ExecutionContext, unitTestHelper.TracingService,
        contact.abc_InitialInvestment, contact.abc_InitialInvestment, (double)contact.abc_InterestRate, (double)contact.abc_InterestRate, contact.abc_InvestmentPeriod, contact.abc_InvestmentPeriod);
      var emails = unitTestHelper.XrmFakedContext.CreateQuery<Email>().Where(e => (e.Subject == "Investment Update Notification" && e.RegardingObjectId.Id == contact.ToEntityReference().Id)).ToList();
      if (emails.Count > 0)
      {
        Assert.True(true);
      }
      else { Assert.True(false); }
    }

  }
}
