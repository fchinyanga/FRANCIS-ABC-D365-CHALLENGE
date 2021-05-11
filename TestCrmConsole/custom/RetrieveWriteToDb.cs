using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace RetrieveDataFromCrmDbAndWriteToCustomDb.custom
{
  public class RetrieveWriteToDb
  {
    public static void getContactRecords()
    {
      try
      {
        CrmServiceClient crmServiceClient = CRMConn.ConnectToCRM();
        if (crmServiceClient != null)
        {
          Console.WriteLine("=============");
          QueryExpression qe = new QueryExpression("contact");
          qe.ColumnSet = new ColumnSet("abc_clientage", "abc_joiningdate");
          EntityCollection enColl = crmServiceClient.RetrieveMultiple(qe);
          Console.WriteLine("The number of records is:\t" + enColl.Entities.Count.ToString());
          for (int i = 0; i < enColl.Entities.Count; i++)
          {
            if (enColl.Entities[i].Attributes.ContainsKey("abc_clientage"))
            {
              Console.WriteLine(enColl.Entities[i].Attributes["abc_clientage"]);
            }
          }
          Console.WriteLine("Retrieved all contacts");
        }
      }
      catch (Exception ex)
      {

        Console.WriteLine(ex.Message);
      }
    }
  }
}
