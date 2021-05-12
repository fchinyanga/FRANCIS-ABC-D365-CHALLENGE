using System;
using Microsoft.Xrm.Tooling.Connector;

namespace RetrieveDataFromCrmDbAndWriteToCustomDb.custom
{
  public class CRMConn
  {
    public static CrmServiceClient ConnectToCRM()
    {
      CrmServiceClient crmServiceClient = null;
      try
      {
        string connectionString = @"AuthType=OAuth;Url=https://francissingularmsdynamics.crm4.dynamics.com;Username=francis@francissingularmsdynamics.onmicrosoft.com;Password=chihornfra@2021;AppID=852088a3-b6ac-430c-9f32-1273fdd9dc1f;RedirectUri=http://localhost;LoginPrompt=Auto;";
        crmServiceClient = new CrmServiceClient(connectionString);
        var strTest = crmServiceClient;
        if (crmServiceClient.IsReady)
        {
          Console.WriteLine("Connection successful");
        }
        else
        {
          Console.WriteLine("Connection failed");
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception caught - " + ex.Message);
      }
      return crmServiceClient;
    }
  }

}
