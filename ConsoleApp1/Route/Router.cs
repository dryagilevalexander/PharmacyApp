using PharmacyApp.DAL;
using PharmacyApp.View.Menu;
using PharmacyApp.View.Pages;

namespace PharmacyApp.Controllers
{
    public class Router
    {
        public Router()
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
                case "Создать товар":
                    CreatePage(new CreateMedicamentPage());
                    break;
                case "Удалить товар":
                    CreatePage(new DeleteMedicamentPage());
                    break;
                case "Создать аптеку":
                    CreatePage(new CreatePharmacyPage());
                    break;
                case "Удалить аптеку":
                    CreatePage(new DeletePharmacyPage());
                    break;
                case "Товары в аптеке":
                    CreatePage(new MedInPharmacyPage());
                    break;
                case "Создать склад":
                    CreatePage(new CreateStorePage());
                    break;
                case "Удалить склад":
                    CreatePage(new DeleteStorePage());
                    break;
                case "Создать партию":
                    CreatePage(new CreateConsignmentPage());
                    break;
                case "Удалить партию":
                    CreatePage(new DeleteConsignmentPage());
                    break;
            }
        }

        public void CreatePage(IPage page)
        {
            string routerItem = page.Create();
            page.Dispose();
            Navigate(routerItem);
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
