using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PharmacyApp.DAL;

namespace PharmacyApp
{
    public static class Pages
    {
    public static string CreateMedicament()
        {
            string? name = "";
            string price = "";
            Console.WriteLine("Добавление медикамента в базу данных");
            Console.Write("Введите наименование: ");
            name = Console.ReadLine();
            if(name == "")
            {
                Console.Clear();
                Console.WriteLine("Не было введено название медикамента. Нажмите любую клавишу для продолжения");
                return "Работа с товарами";
            }


            Console.Write("Введите целую часть цены медикамента: ");
            string priceRub = Utils.GetValue(5);
            Console.Write("Введите дробную часть цены медикамента: ");
            string priceKop = Utils.GetValue(2);
            price = priceRub + "." + priceKop;

            Console.WriteLine("Наименование продукта: " + name);
            Console.WriteLine("Цена продукта: " + price);

            DbContext dbManager = TransitClass.DbContext;
            string command = "INSERT INTO [dbo].[Medicaments]([Name],[Price]) VALUES ('" + name + "','" + price + "')";
            dbManager.CommExecuteNonQuery(command);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            return "Работа с товарами";
        }
        public static string DeleteMedicament()
        {
            DbContext dbManager = TransitClass.DbContext;

            Console.WriteLine("Медикамент удален");
            return "Работа с товарами";
        }
        public static string CreatePharmacy()
        {
            Console.WriteLine("Аптека создана");
            return "Работа с аптеками";
        }

        public static string DeletePharmacy()
        {
            Console.WriteLine("Аптека удалена");
            return "Работа с аптеками";
        }

        public static string CreateStore()
        {
            Console.WriteLine("Склад создан");
            return "Работа со складами";
        }

        public static string DeleteStore()
        {
            Console.WriteLine("Склад удален");
            return "Работа со складами";
        }

        public static string CreateConsignment()
        {
            Console.WriteLine("Партия создана");
            return "Работа с партиями";
        }

        public static string DeleteConsignment()
        {
            Console.WriteLine("Партия удалена");
            return "Работа с партиями";
        }
    }
}
