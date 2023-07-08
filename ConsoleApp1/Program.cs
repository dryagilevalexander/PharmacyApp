using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.View.Menu;


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




