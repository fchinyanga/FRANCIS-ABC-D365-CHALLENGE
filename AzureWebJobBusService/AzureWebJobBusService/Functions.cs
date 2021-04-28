using Francis_ABC.D365.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;

namespace AzureWebJobBusService
{
  public class Functions
  {
    // This function will get triggered/executed when a new message is written 
    // on an Azure Queue called queue.
    /*  public static void processservicebus(
      [ServiceBusTrigger("messages")]string myQueueItem,
      ILogger log)
      {
        log.LogInformation(myQueueItem);
      }*/

    public static void processServiceBus(
   [ServiceBusTrigger("messages")]RemoteExecutionContext remoteExecutionContext,
   ILogger log)
    {
      log.LogInformation("===================Message Start========================");
      Contact contact = ((Entity)remoteExecutionContext.InputParameters["Target"]).ToEntity<Contact>();
      log.LogInformation("==================Contact Details======================");
      log.LogInformation("Client Name:\t" + contact.abc_IndividualClientName == null && contact.abc_IndividualClientName == "" ? contact.abc_CorporateClientName : contact.abc_IndividualClientName);
      log.LogInformation("Joining Date\t" + contact.abc_JoiningDate.ToString());
      log.LogInformation("Maturity Date\t" + contact.abc_MaturityDate.ToString());
      log.LogInformation("Initial Investment\t" + contact.abc_InitialInvestment.Value.ToString());
      log.LogInformation("Investment Period\t" + contact.abc_InvestmentPeriod.ToString());
      log.LogInformation("Interest Rate\t" + contact.abc_InterestRate.ToString());
      log.LogInformation("Estimated Return \t" + contact.abc_EstimatedReturn.Value.ToString());
      log.LogInformation("===================Message End========================");
    }
  }
}
