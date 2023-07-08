﻿using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.DAL.Repository;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Pages
{
    public class CreateConsignmentPage : IPage
    {
        public string Create()
        {
            MedicamentsRepository medicamentsRepository = new MedicamentsRepository();
            ConsignmentsRepository consignmentsRepository = new ConsignmentsRepository();
            StoresRepository storesRepository = new StoresRepository();
            PharmaciesRepository pharmRepository = new PharmaciesRepository();

            List<string> itemsPharmaciesMenu = new List<string>();

            List<Pharmacy> pharmacies = pharmRepository.GetAll();
            if (pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                return "В главное меню";
            }
            var pharmaciesSortedList = from p in pharmacies
                                       orderby p.Id
                                       select p;

            foreach (var pharmacyItem in pharmaciesSortedList)
            {
                itemsPharmaciesMenu.Add(pharmacyItem.Id + ". " + pharmacyItem.Name + " " + pharmacyItem.Address);
            }
            int pharmacyId = MenuController.CreateDbMenu(itemsPharmaciesMenu);
            Console.Clear();



            List<string> itemsStoresMenu = new List<string>();

            List<Store> stores = storesRepository.GetByParentId(pharmacyId);
            if (stores.Count == 0)
            {
                Console.WriteLine("Склады отсутствуют. Создайте хотя бы один склад!");
                return "В главное меню";
            }
            var storesSortedList = from p in stores
                                   orderby p.Id
                                   select p;

            foreach (var storeItem in storesSortedList)
            {
                itemsStoresMenu.Add(storeItem.Id + ". " + storeItem.Name);
            }
            int storeId = MenuController.CreateDbMenu(itemsStoresMenu);
            Console.Clear();




            Console.WriteLine("Добавление партии товара в базу данных (для отмены операции нажмите ESC)");

            List<string> itemsMedMenu = new List<string>();

            List<Medicament> medicaments = medicamentsRepository.GetAll();
            if (medicaments.Count == 0)
            {
                Console.WriteLine("Медикаменты отсутствуют. Создайте хотя бы один медикамент!");
                return "В главное меню";
            }
            var medicamentsSortedList = from p in medicaments
                                        orderby p.Id
                                        select p;

            foreach (var medicamentItem in medicamentsSortedList)
            {
                itemsMedMenu.Add(medicamentItem.Id + ". " + medicamentItem.Name);
            }
            int medicamentId = MenuController.CreateDbMenu(itemsMedMenu);
            Console.Clear();


            Console.Write("Введите количество: ");

            string result = Utils.GetValue(9);
            if (result == "AbortOperation") return "Работа с партиями";
            int countMed = Convert.ToInt32(result);

            Consignment consignment = new Consignment(medicamentId, storeId, countMed);

            consignmentsRepository.Create(consignment);

            Console.WriteLine("Партия успешно добавлена.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            return "Работа с партиями";
        }
    }
}