using System;
using System.IO;
using AzureWebJobBusService.config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AzureWebJobBusService
{
  // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
  class Program
  {
    // Please set the following connection strings in app.config for this WebJob to run:
    // AzureWebJobsDashboard and AzureWebJobsStorage
    public IConfigurationRoot Configuration { get; set; }
    static void Main()
    {
      var settingsFilePath = "appsettings.json";
      var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(settingsFilePath, optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

      IServiceCollection services = new ServiceCollection();
      services.AddSingleton<ConfigSettings>(config.GetSection("ConfigSettings").Get<ConfigSettings>());

      var provider = services.BuildServiceProvider();
      var builder = new HostBuilder();
      builder.ConfigureWebJobs(b =>
        {
          b.AddAzureStorageCoreServices();
          b.AddServiceBus(c => c.ConnectionString = ConfigSettings.AzureWebJobsServiceBus);
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
