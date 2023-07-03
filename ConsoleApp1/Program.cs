using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


namespace PharmacyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManager dbManager = new DbManager();
            string connectionString = dbManager.InitiateDb("MSSQLSERVER01", "PharmacyDb");
            dbManager.FillTestSet(connectionString);

        }

    }
}




