using System;
using RetrieveDataFromCrmDbAndWriteToCustomDb.custom;

namespace RetrieveDataFromCrmDbAndWriteToCustomDb
{

  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        RetrieveWriteToDb.getContactRecords();
        Console.Write("Doc found");
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
      }
    }
  }
}
