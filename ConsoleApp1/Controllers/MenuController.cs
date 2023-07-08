using PharmacyApp.DAL;
using PharmacyApp.View.Menu;

namespace PharmacyApp.Controllers
{
    public class MenuController
    {
        private DbContext _db;
        public MenuController(DbContext db)
        {
            _db = db;
        }

        public MenuController()
        {
        }

        public void Navigate(string menuItem)
        {
            Console.Clear();
            switch (menuItem)
            {
                case "Работа с товарами":
                    CreateMenu(MedicamentsMenu.Items);
                    break;
                case "Работа с аптеками":
                    CreateMenu(PharmaciesMenu.Items);
                    break;
                case "Работа со складами":
                    CreateMenu(StoresMenu.Items);
                    break;
                case "Работа с партиями":
                    CreateMenu(ConsignmentsMenu.Items);
                    break;
                case "В главное меню":
                    CreateMenu(MainMenu.Items);
                    break;
                default:
                    PagesController pagesController = new(_db);
                    Navigate(pagesController.Navigate(menuItem));
                    pagesController.Dispose();
                    break;
            }
        }

        public void CreateMenu(List<string> items)
        {
            var menu = new Menu(new Point(Console.WindowWidth / 2 - items[0].Length / 2, Console.WindowHeight / 2 - items.Count() / 2), items);
            menu.Draw();
            Navigate(menu.WaitingForInput());
        }

        public int CreateDbMenu(List<string> items)
        {
            var menu = new Menu(new Point(Console.WindowWidth / 2 - items[0].Length / 2, Console.WindowHeight / 2 - items.Count() / 2), items);
            menu.Draw();
            return Convert.ToInt32(menu.WaitingForInput().Split(".")[0]);
        }
    }
}
