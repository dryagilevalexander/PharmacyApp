using PharmacyApp.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Controllers
{
    public static class MenuController
    {


        public static void Navigate(string menuItem)
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
                    Navigate(PagesController.RoutingPages(menuItem));
                    break;
            }
        }

        public static void CreateMenu(List<string> items)
        {
            var menu = new Menu(new Point(Console.WindowWidth / 2 - items[0].Length / 2, Console.WindowHeight / 2 - items.Count() / 2), items);
            menu.Draw();
            Navigate(menu.WaitingForInput());
        }
    }
}
