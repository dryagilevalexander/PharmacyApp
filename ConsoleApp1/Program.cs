using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.View.Menu;


namespace PharmacyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbContext db = DbContext.GetInstance();
            db.InitializeDb();
            new Router().CreateMenu(new MainMenuPage());
        }
    }
}




