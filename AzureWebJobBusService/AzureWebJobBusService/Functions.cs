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

    public static void processservicebus(
   [ServiceBusTrigger("messages")]RemoteExecutionContext remoteExecutionContext,
   ILogger log)
    {
      log.LogInformation("===================Message Start========================");
      log.LogInformation(remoteExecutionContext.UserId.ToString());
      log.LogInformation("===================Message End========================");
    }
  }
}
