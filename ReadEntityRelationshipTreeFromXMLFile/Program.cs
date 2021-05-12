using System;
using System.IO;
using System.Xml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xrm.Tooling.Connector;
using ReadEntityRelationshipTreeFromXMLFile.config;
using ReadEntityRelationshipTreeFromXMLFile.datatranscations;

namespace ReadEntityRelationshipTreeFromXMLFile
{
  class Program
  {
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    static void Main(string[] args)
    {
      var watch = System.Diagnostics.Stopwatch.StartNew();
      var settingsFilePath = "appsettings.json";
      var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(settingsFilePath, optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
      IServiceCollection services = new ServiceCollection();
      services.AddSingleton<ConfigSettings>(config.GetSection("ConfigSettings").Get<ConfigSettings>());

      try
      {
        log.Info("\n===============Programme started =====================");
        log.Info("\n===============Reading from xml file =====================");
        CrmServiceClient crmServiceClient = new CrmServiceClient(ConfigSettings.crmConnectionString);
        if (crmServiceClient.IsReady)
        {
          Console.WriteLine("======================== Connection successful ===============================");
          XmlReaderSettings settings = new XmlReaderSettings();
          settings.Async = true;
          using (XmlReader reader = XmlReader.Create(ConfigSettings.entityTreeFilePath, settings))
          {
            while (reader.Read())
            {
              switch (reader.NodeType)
              {
                case XmlNodeType.Element:
                  // Console.WriteLine("Start Element = {0}", reader.Name);
                  break;
                case XmlNodeType.Text:
                  var entityName = "" + reader.ReadContentAsString().Trim().ToString();
                  log.Info($"\n\tText Node = " + entityName);
                  if (entityName.Trim().Equals("Contact"))
                  {

                    Console.WriteLine("===============Retrive Contact from db================");
                    for (int i = 0; i < 500; i++)
                    {
                      ContactArchival.ArchiveContact(crmServiceClient, ConfigSettings.sqlServerDbConnectionString);
                    }
                  }
                  break;
                case XmlNodeType.EndElement:
                  // Console.WriteLine("====== End Element  {0} =======", reader.Name);
                  break;
                default:
                  // Console.WriteLine("Other node {0} with value {1}", reader.NodeType, reader.Value);
                  break;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {

        Console.WriteLine("Exception caught here " + ex.ToString());
      }
      //log.Error("\n\t\tError encountered", new IndexOutOfRangeException());
      watch.Stop();
      var elapsedMs = watch.ElapsedMilliseconds;
      log.Info("\n\n========Finished the whole process in : " + elapsedMs + "ms ==================");
      Console.ReadKey();
    }
  }
}
