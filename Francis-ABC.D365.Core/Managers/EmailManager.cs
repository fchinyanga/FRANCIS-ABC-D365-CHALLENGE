using System;
using Francis_ABC.D365.Entities;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Francis_ABC.D365.Core.Managers
{
  public class EmailManager
  {
    public static void sendEmailFromTemplate(IOrganizationService organizationService, Contact contact, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService,
            Money prevInvestment, Money newInvestment, double prevInterestRate, double newInterestRate, int? prevInvestmentPeriod,
    int? newInvestmentPeriod)
    {

      try
      {

        Guid templateId;
        ActivityParty fromParty = new ActivityParty
        {
          PartyId = new EntityReference(SystemUser.EntityLogicalName, pluginExecutionContext.UserId)
        };
        // Create the 'To:' activity party for the email
        ActivityParty toParty = new ActivityParty
        {
          PartyId = contact.ToEntityReference()
        };
        string clientName = "";
        if (contact.abc_IndividualClientName != null)
        {
          clientName = contact.abc_IndividualClientName;
        }
        if (contact.abc_CorporateClientName != null)
        {
          clientName = contact.abc_CorporateClientName;
        }
        Email email = new Email
        {
          To = new ActivityParty[] { toParty },
          From = new ActivityParty[] { fromParty },
          Subject = "Investment Update Notification",
          Description = HtlStringBody(clientName, (decimal)prevInvestment.Value, (int)prevInvestmentPeriod, prevInterestRate,
       (decimal)newInvestment.Value, (int)newInvestmentPeriod, newInterestRate),
          DirectionCode = true,
          RegardingObjectId = contact.ToEntityReference()


        };
        email.Id = organizationService.Create(email);

        var queryBuildInTemplates = new QueryExpression
        {
          EntityName = Template.EntityLogicalName,
          ColumnSet = new ColumnSet(Template.Fields.TemplateId, Template.Fields.TemplateTypeCode),
          Criteria = new FilterExpression()
        };

        queryBuildInTemplates.Criteria.AddCondition(Template.Fields.TemplateTypeCode,
            ConditionOperator.Equal, Contact.EntityLogicalName);
        EntityCollection templateEntityCollection = organizationService.RetrieveMultiple(queryBuildInTemplates);

        for (int i = 0; i < templateEntityCollection.TotalRecordCount; i++)
        {
          if (templateEntityCollection.Entities[1].Attributes[Template.Fields.Title].ToString().Trim() == "notificationemailtemplate")
          {
            templateId = (Guid)templateEntityCollection.Entities[0].Attributes[Template.Fields.TemplateId];
            var emailUsingTemplateReq = new SendEmailFromTemplateRequest
            {
              Target = email,
              TemplateId = templateId,
              RegardingId = (Guid)contact.Id,
              RegardingType = Contact.EntityLogicalName
            };
            //var emailUsingTemplateResp = (SendEmailFromTemplateResponse)organizationService.Execute(emailUsingTemplateReq);
            // email.Id = emailUsingTemplateResp.Id;
            if (!email.Id.Equals(Guid.Empty))
            {
            }
          }
          else
          {
            throw new ArgumentException("Standard Email Templates are missing");
          }
        }

      }
      catch (Exception)
      {

        throw;
      }
    }



    public static string HtlStringBody(string Name, decimal prevInvestmentAmount, int prevInvestmentPeriod, double prevInterestRate,
       decimal newInvestmentAmount, int newInvestmentPeriod, double newInterestRate)
    {
      string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
      string htmlTableEnd = "</table>";
      string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
      string htmlHeaderRowEnd = "</tr>";
      string htmlTrStart = "<tr style=\"color:#555555;\">";
      string htmlTrEnd = "</tr>";
      string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
      string htmlTdEnd = "</td>";

      string HtmlBody = "<h1>Dear " + Name + " </h1>" +
                             "<p>Your investment details have been modified.<br/>Please see the changes below:<br/>" +
                            "</p>";

      HtmlBody += htmlTableStart;
      HtmlBody += htmlHeaderRowStart;
      HtmlBody += htmlTdStart + "Field" + htmlTdEnd;
      HtmlBody += htmlTdStart + "Before" + htmlTdEnd;
      HtmlBody += htmlTdStart + "After" + htmlTdEnd;
      HtmlBody += htmlHeaderRowEnd;

      HtmlBody = HtmlBody + htmlTrStart;
      HtmlBody = HtmlBody + htmlTdStart + "Initial Investment" + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + prevInvestmentAmount.ToString("F") + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + newInvestmentAmount.ToString("F") + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTrEnd;

      HtmlBody = HtmlBody + htmlTrStart;
      HtmlBody = HtmlBody + htmlTdStart + "Interest Rate" + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + prevInterestRate + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + newInterestRate + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTrEnd;

      HtmlBody = HtmlBody + htmlTrStart;
      HtmlBody = HtmlBody + htmlTdStart + "Investment Period" + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + prevInvestmentPeriod + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTdStart + newInvestmentPeriod + htmlTdEnd;
      HtmlBody = HtmlBody + htmlTrEnd;
      HtmlBody += htmlTableEnd;

      HtmlBody += "<p>If you are not aware of these changes, please contact your Financial Advisor immediately.<br/>" +
                            "</p>";

      return HtmlBody;
    }

  }
}
