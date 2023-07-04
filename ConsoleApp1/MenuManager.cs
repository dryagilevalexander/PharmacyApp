using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public static class MenuManager
    {
        public static List<string> MainMenuItems = new List<string>()
            {
                "Работа с товарами",
                "Работа с аптеками",
                "Работа со складами",
                "Работа с партиями"
            };

        public static List<string> MedicamentsMenuItems = new List<string>()
            {
                "Создать товар",
                "Удалить товар",
                "В главное меню"
            };

        public static List<string> PharmaciesMenuItems = new List<string>()
            {
                "Создать аптеку",
                "Удалить аптеку",
                "В главное меню"
            };

        public static List<string> StoresMenuItems = new List<string>()
            {
                "Создать склад",
                "Удалить склад",
                "В главное меню"
            };

         public static List<string> ConsignmentMenuItems = new List<string>()
            {
                "Создать партию",
                "Удалить партию",
                "В главное меню"
            };  
        
        public static string WaitingForInput(Menu menu)
        {
            string nameMenuItem = "";

            while (nameMenuItem == "")
            {
                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        menu.Next();
                        break;
                    case ConsoleKey.UpArrow:
                        menu.Previous();
                        break;
                    case ConsoleKey.Enter:
                        nameMenuItem = menu.GetSelectedItem();
                        break;
                }
            }
            return nameMenuItem;
        }

        public static void Navigate(string menuItem)
        {
            Console.Clear();
            switch (menuItem)
            {
                case "Работа с товарами":
                    var menu = new Menu(new Point(10, 10), MenuManager.MedicamentsMenuItems);
                    menu.Draw();
                    Navigate(MenuManager.WaitingForInput(menu));
                    break;
                case "Работа с аптеками":
                    menu = new Menu(new Point(10, 10), MenuManager.PharmaciesMenuItems);
                    menu.Draw();
                    Navigate(MenuManager.WaitingForInput(menu));
                    break;
                case "Работа со складами":
                    menu = new Menu(new Point(10, 10), MenuManager.StoresMenuItems);
                    menu.Draw();
                    Navigate(MenuManager.WaitingForInput(menu));
                    break;
                case "Работа с партиями":
                    menu = new Menu(new Point(10, 10), MenuManager.StoresMenuItems);
                    menu.Draw();
                    Navigate(MenuManager.WaitingForInput(menu));
                    break;
                case "В главное меню":
                    menu = new Menu(new Point(10, 10), MenuManager.MainMenuItems);
                    menu.Draw();
                    Navigate(MenuManager.WaitingForInput(menu));
                    break;
                default:
                    Navigate(CommandManager.CommandSelection(menuItem));
                    break;
            }
        }
    }
}
