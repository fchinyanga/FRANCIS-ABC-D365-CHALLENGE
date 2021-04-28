using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureWebJobBusService
{
  // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
  class Program
  {
    // Please set the following connection strings in app.config for this WebJob to run:
    // AzureWebJobsDashboard and AzureWebJobsStorage
    static void Main()
    {
      var builder = new HostBuilder();
      var connString = "";
      builder.ConfigureWebJobs(b =>
       {
         b.AddAzureStorageCoreServices();
         b.AddServiceBus(c => c.ConnectionString = connString);
       });
      builder.ConfigureLogging((context, b) =>
      {
        b.AddConsole();
      });
      var host = builder.Build();
      using (host)
      {
        host.Run();
      }
    }
  }
}
