using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.DAL.Repository;
using PharmacyApp.Menus;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Pages
{
    public class CreateStorePage: IPage
    {
        public string Create()
        {
            StoresRepository storeRepository = new StoresRepository();
            IRepository<Pharmacy> pharmRepository = new PharmaciesRepository();
            List<string> itemsMenu= new List<string>();

            List<Pharmacy> pharmacies = pharmRepository.GetAll();
            if(pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                return "В главное меню";
            }
            var sortedList = from p in pharmacies
                             orderby p.Id
                             select p;

            foreach (var pharmacy in sortedList)
            {
                itemsMenu.Add(pharmacy.Id + ". " + pharmacy.Name + " " + pharmacy.Address);
            }
            int pharmacyId = MenuController.CreateDbMenu(itemsMenu);
            Console.Clear();

            Console.WriteLine("Добавление склада в базу данных");
            Console.Write("Введите наименование: ");
            string? name = Utils.GetNameValue(50);
            if (name == "")
            {
                Console.Clear();
                Console.WriteLine("Не было введено наименование склада. Нажмите любую клавишу для продолжения");
                return "Работа со складами";
            }
            Store store = new Store(pharmacyId, name);

            storeRepository.Create(store);

            Console.WriteLine("Склад успешно добавлен.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");


            return "Работа со складами";
        }
    }
}
