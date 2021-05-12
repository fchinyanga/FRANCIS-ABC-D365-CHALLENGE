using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;

namespace TestCrmConsole
{
  class Program
  {
    static void Main(string[] args)
    {

      try
      {
        #region dbConnection String for CRM and SQL Server

        string connectionString = @"AuthType=OAuth;Url=https://francissingularmsdynamics.crm4.dynamics.com;Username=francis@francissingularmsdynamics.onmicrosoft.com;Password=chihornfra@2021;AppID=852088a3-b6ac-430c-9f32-1273fdd9dc1f;RedirectUri=http://localhost;LoginPrompt=Auto;";
        CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);
        string createQuery = "ContactInsertCommand";
        string checkIfContactExist = "CheckIfContactExist";
        string updateContact = "ContactUpdateCommand";
        var datasource = @"CHINYANGAF\SQLEXPRESS";//your server
        var database = "crmonline"; //your database name


        //your connection string 
        string connStr = @"Data Source=" + datasource + ";Initial Catalog="
                    + database + ";Persist Security Info=True;Integrated Security = true";
        #endregion   

        #region Retrieve records from CRM and InsertTo SQL Server Db

        if (crmServiceClient.IsReady)
        {
          var watch = System.Diagnostics.Stopwatch.StartNew();
          Console.WriteLine("======================== Connection successful ===============================");
          QueryExpression query = new QueryExpression("contact");
          query.ColumnSet = new ColumnSet(true);
          query.Criteria = new FilterExpression();
          query.Criteria.AddCondition("abc_clientage", ConditionOperator.GreaterEqual, 0);

          EntityCollection enColl = crmServiceClient.RetrieveMultiple(query);
          Console.WriteLine("================ The number of records is: " + enColl.Entities.Count.ToString() + " ===================\n\n");

          Guid ContactId = new Guid();
          SqlConnection con = new SqlConnection(connStr);
          con.Open();
          for (int i = 0; i < enColl.Entities.Count; i++)
          {
            #region variables
            int? age = null, investmentPeriod = null, statusCode = 0, stateCode = 0;
            DateTime? dob = null, maturityDate = null, joiningDate = null;
            decimal? interesRate = null;
            string corporateCliName = "", individualCliName = "";
            Money initialInvestment = null, estimatedReturn = null;
            #endregion
            #region check columns
            var estReturn = enColl.Entities[i].Attributes.ContainsKey("abc_clientage") ? 10 : 200;
            Console.WriteLine("=========================== Record " + i.ToString() + " ===================================================");
            if (enColl.Entities[i].Attributes.ContainsKey("contactid"))
            {
              ContactId = (Guid)enColl.Entities[i].Attributes["contactid"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_clientage"))
            {
              age = (int)enColl.Entities[i].Attributes["abc_clientage"];
            }

            if (enColl.Entities[i].Attributes.ContainsKey("abc_estimatedreturn"))
            {
              estimatedReturn = (Money)enColl.Entities[i].Attributes["abc_estimatedreturn"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_corporateclientname"))
            {
              corporateCliName = (string)enColl.Entities[i].Attributes["abc_corporateclientname"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_individualclientname"))
            {
              individualCliName = (string)enColl.Entities[i].Attributes["abc_individualclientname"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_initialinvestment"))
            {
              initialInvestment = (Money)enColl.Entities[i].Attributes["abc_initialinvestment"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_interestrate"))
            {
              interesRate = (decimal)enColl.Entities[i].Attributes["abc_interestrate"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_investmentperiod"))
            {
              investmentPeriod = (int)enColl.Entities[i].Attributes["abc_investmentperiod"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_joiningdate"))
            {
              joiningDate = (DateTime)enColl.Entities[i].Attributes["abc_joiningdate"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_maturitydate"))
            {
              maturityDate = (DateTime)enColl.Entities[i].Attributes["abc_maturitydate"];
            }
            if (enColl.Entities[i].Attributes.ContainsKey("abc_dateofbirth"))
            {
              dob = (DateTime)enColl.Entities[i].Attributes["abc_dateofbirth"];
            }

            if (enColl.Entities[i].Attributes.ContainsKey("statuscode"))
            {
              statusCode = (int)((OptionSetValue)enColl.Entities[i].Attributes["statuscode"]).Value;
            }

            if (enColl.Entities[i].Attributes.ContainsKey("statecode"))
            {
              stateCode = (int)((OptionSetValue)enColl.Entities[i].Attributes["statecode"]).Value;
            }
            #endregion

            SqlCommand createCommand = new SqlCommand(createQuery, con);
            SqlCommand checkIfContactExistCommand = new SqlCommand(checkIfContactExist, con);
            SqlCommand upadteExistingContactCommand = new SqlCommand(updateContact, con);

            #region check if contact exist
            checkIfContactExistCommand.CommandType = CommandType.StoredProcedure;
            checkIfContactExistCommand.Parameters.AddWithValue("@ContactId", ContactId);
            var returnParameter = checkIfContactExistCommand.Parameters.Add("@Exist", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            checkIfContactExistCommand.ExecuteNonQuery();
            var result = returnParameter.Value;
            #endregion

            if ((int)result == 0)
            {
              #region create contact
              try
              {

                createCommand.CommandType = CommandType.StoredProcedure;
                createCommand.Parameters.AddWithValue("@ContactId", ContactId);
                createCommand.Parameters.AddWithValue("@abc_clientage", age);
                createCommand.Parameters.AddWithValue("@abc_dateofbirth", dob);
                createCommand.Parameters.AddWithValue("@abc_estimatedreturn", estimatedReturn?.Value);
                createCommand.Parameters.AddWithValue("@abc_initialinvestment", initialInvestment?.Value);
                createCommand.Parameters.AddWithValue("@abc_interestrate", interesRate);
                createCommand.Parameters.AddWithValue("@abc_investmentperiod", investmentPeriod);
                createCommand.Parameters.AddWithValue("@abc_joiningdate", joiningDate);
                createCommand.Parameters.AddWithValue("@abc_maturitydate", maturityDate);
                createCommand.Parameters.AddWithValue("@statuscode", statusCode);
                createCommand.Parameters.AddWithValue("@statecode", stateCode);
                createCommand.Parameters.AddWithValue("@abc_corporateclientname", corporateCliName);
                createCommand.Parameters.AddWithValue("@abc_individualclientname", individualCliName);
                createCommand.ExecuteNonQuery();
                Console.WriteLine($"Client age= {age}\t" +
                $"Estimated Return={estimatedReturn?.Value} \t" +
                $"Coorp Client Name= {corporateCliName}\t" +
                $"Ind Client Name={individualCliName}\t" +
                $"DOB={dob}\t" +
                $"Initial Invetment={initialInvestment?.Value}\t" +
                $"Interest Rate={interesRate}\t" +
                $"Investment Period={investmentPeriod}\t" +
                $"Joining Date= {joiningDate}\t" +
                $"Maturity Date={maturityDate}\t"
               );
              }
              catch (Exception ex)
              {
                Console.WriteLine("Record for \t" + ContactId + "\t was not recorded into the database because of \t" + ex.Message);
              }
              #endregion
            }
            else
            {
              #region update contact
              Console.WriteLine("\tContact with contactId\t" + ContactId + "\t already exist and will be updated");
              try
              {

                upadteExistingContactCommand.CommandType = CommandType.StoredProcedure;
                upadteExistingContactCommand.Parameters.AddWithValue("@ContactId", ContactId);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_clientage", age);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_dateofbirth", dob);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_estimatedreturn", estimatedReturn?.Value);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_initialinvestment", initialInvestment?.Value);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_interestrate", interesRate);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_investmentperiod", investmentPeriod);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_joiningdate", joiningDate);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_maturitydate", maturityDate);
                upadteExistingContactCommand.Parameters.AddWithValue("@Original_ContactId", ContactId);
                upadteExistingContactCommand.Parameters.AddWithValue("@statuscode", statusCode);
                upadteExistingContactCommand.Parameters.AddWithValue("@statecode", stateCode);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_corporateclientname", corporateCliName);
                upadteExistingContactCommand.Parameters.AddWithValue("@abc_individualclientname", individualCliName);

                upadteExistingContactCommand.ExecuteNonQuery();

              }
              catch (Exception ex)
              {
                Console.WriteLine("Record for \t" + ContactId + "\t was not updated into the database because of \t" + ex.Message);
              }
              #endregion
            }
            /*if (i == 2)
            {
              crmServiceClient.Delete("contact", ContactId);
            }*/
          }
          con.Close();
          watch.Stop();
          var elapsedMs = watch.ElapsedMilliseconds;
          Console.WriteLine("\n\n======== Retrieved and Write to database in: " + elapsedMs + "ms ==================");
        }
        else
        {
          Console.Write("Connection failed");
        }
        #endregion

      }
      catch (Exception ex)
      {
        Console.WriteLine("Exception caught - " + ex.Message);
      }
      Console.ReadKey();
    }
  }
}
