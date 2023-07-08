using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.View.Pages;
using PharmacyApp.View.Menu;
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
            DbContext db = DbContext.getInstance();
            db.InitializeDb();
            TransitClass.DbContext = db;
            new MenuController().CreateMenu(MainMenu.Items);
        }
    }
}




