using System;
using Francis_ABC.D365.Plugins.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Francis_ABC.D365.Plugins.Core.Managers
{
  public class EmailManager
  {
    public static void sendEmailFromTemplate(IOrganizationService organizationService, LocalPluginContext localContext, ITracingService tracingService,
            Money previousInvestment, Money newInvestment, double previousInterestRate, double newInterestRate, int? previousInvestmentPeriod,
    int? newInvestmentPeriod)
    {
      Guid templateId;
      Entity email = new Entity("email");
      Entity currentContact = (Entity)localContext.PluginExecutionContext.InputParameters["Target"];
      Entity fromParty = new Entity("activityparty");
      Entity toParty = new Entity("activityparty");
      toParty["partyid"] = new EntityReference(Contact.EntityLogicalName, localContext.PluginExecutionContext.UserId);
      fromParty["partyid"] = new EntityReference("systemuser", localContext.PluginExecutionContext.UserId);
      email["from"] = new Entity[] { fromParty };
      email["to"] = new Entity[] { toParty };
      email["subject"] = "Investment Changed Notification";
      email["regardingobjectid"] = currentContact.Id;
      email["description"] = "Previous Investment" + previousInvestment + "" +
      "previousInvestment" + previousInvestment +
      "newInvestment" + newInvestment +
      "previousInterestRate" + previousInterestRate +
      "newInterestRate" + newInterestRate
      + "previousInvestmentPeriod" + previousInvestmentPeriod +
      "newInvestmentPeriod" + newInvestmentPeriod;
      Guid emailId = organizationService.Create(email);


      var queryBuildInTemplates = new QueryExpression
      {
        EntityName = "notificationemailtemplate",
        ColumnSet = new ColumnSet("templateid", "templatetypecode"),
        Criteria = new FilterExpression()
      };

      queryBuildInTemplates.Criteria.AddCondition("templatetypecode",
          ConditionOperator.Equal, "contact");
      EntityCollection templateEntityCollection = organizationService.RetrieveMultiple(queryBuildInTemplates);

      if (templateEntityCollection.Entities.Count > 0)
      {
        templateId = (Guid)templateEntityCollection.Entities[0].Attributes["templateid"];
      }
      else
      {
        throw new ArgumentException("Standard Email Templates are missing");
      }

      var emailUsingTemplateReq = new SendEmailFromTemplateRequest
      {
        Target = email,
        TemplateId = templateId,
        RegardingId = currentContact.Id,
        RegardingType = Contact.EntityLogicalName
      };
      var emailUsingTemplateResp = (SendEmailFromTemplateResponse)organizationService.Execute(emailUsingTemplateReq);
      emailId = emailUsingTemplateResp.Id;
      if (!emailId.Equals(Guid.Empty))
      {
      }
    }
  }
}
