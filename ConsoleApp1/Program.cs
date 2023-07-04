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
            // DbManager dbManager = new DbManager();
            // string connectionString = dbManager.InitializeDb();
            var menu = new Menu(new Point(Console.WindowWidth / 2 - MenuManager.MainMenuItems[0].Length/2, Console.WindowHeight / 2 - MenuManager.MainMenuItems.Count()/2), MenuManager.MainMenuItems);
            menu.Draw();
            string nameMenuItem = "";
            nameMenuItem = MenuManager.WaitingForInput(menu);
            MenuManager.Navigate(nameMenuItem);
        }
    }
}




