﻿using PharmacyApp.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public static class MenuManager
    {        
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
                    MenuOperation(MedicamentsMenu.Items);
                    break;
                case "Работа с аптеками":
                    MenuOperation(PharmaciesMenu.Items);
                    break;
                case "Работа со складами":
                    MenuOperation(ConsignmentMenu.Items);
                    break;
                case "Работа с партиями":
                    MenuOperation(ConsignmentMenu.Items);
                    break;
                case "В главное меню":
                    MenuOperation(MainMenu.Items);
                    break;
                default:
                    Navigate(CommandManager.CommandSelection(menuItem));
                    break;
            }
        }

        public static void MenuOperation(List<string> items)
        {
            var menu = new Menu(new Point(Console.WindowWidth / 2 - items[0].Length / 2, Console.WindowHeight / 2 - items.Count() / 2), items);
            menu.Draw();
            Navigate(MenuManager.WaitingForInput(menu));
        }
    }
}
