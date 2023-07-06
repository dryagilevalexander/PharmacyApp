using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.Menus;
using PharmacyApp.Pages;
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
            MenuController.CreateMenu(MainMenu.Items);
        }
    }
}




