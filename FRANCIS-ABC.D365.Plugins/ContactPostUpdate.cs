using System;
using Francis_ABC_D365.Emailing;
using Francis_ABC_D365.Emailing.EmailTemplates;
using Microsoft.Xrm.Sdk;


namespace Francis_ABC.D365.Plugins.Plugins
{
  class Contact_Post_Create : IPlugin
  {
    public void Execute(IServiceProvider serviceProvider)
    {
      try
      {
        IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
        if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
        {
          ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
          IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
          IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
          if (context.MessageName.ToLower() != "update" && context.Stage != 40)
          {
            return;
          }
          Entity preImage = context.PreEntityImages["preImage"] as Entity;
          Entity postImage = context.PostEntityImages["postImage"] as Entity;
          String clientName = "";
          String emailAddress = "";
          Double prevAmountInvested = 0.0;
          Double newAmountInvested = 0.0;
          Double prevInterestRate = 0.0;
          Double newInterestRate = 0.0;
          int prevInvestmentPeriod = 0;
          int newInvestmentPeriod = 0;
          if (preImage == null || postImage == null)
          {
            return;
          }
          if (preImage.Contains("abc_clientype"))
          {
            //clientName = ((OptionSetValue)preImage["dnlb_semester"]).Value;
            clientName = (String)preImage["abc_clienttype"];
          }
          if (preImage.Contains("abc_emailaddress1"))
          {
            emailAddress = (String)preImage["abc_emailaddress1"];
          }
          if (preImage.Contains("abc_investmentamount") && postImage.Contains("abc_investmentamount"))
          {
            prevAmountInvested = (Double)preImage["abc_investmentamount"];
            newAmountInvested = (Double)postImage["abc_investmentamount"];
          }
          if (preImage.Contains("abc_investmenperiod") && postImage.Contains("abc_investmentperiod"))
          {
            prevInvestmentPeriod = (Int32)preImage["abc_investmenperiod"];
            newInvestmentPeriod = (Int32)postImage["abc_investmenperiod"];
          }
          if (preImage.Contains("abc_interestrate") && postImage.Contains("abc_interestrate"))
          {
            prevInterestRate = (Double)preImage["abc_interestrate"];
            newInterestRate = (Double)postImage["abc_interestrate"];
          }

          string emailBody = NotifyAClientEmailTemplate.HtlStringBody(clientName, prevAmountInvested, prevInvestmentPeriod, prevInterestRate,
            newAmountInvested, newInvestmentPeriod, newInterestRate);
          ABCEmailing abcEmailing = new ABCEmailing();
          abcEmailing.sendEmail(emailAddress, "Welcome to ABC", emailBody);
        }

      }
      catch (Exception ex)
      {
        throw new InvalidPluginExecutionException(ex.Message);
      }
    }
  }
}