﻿using PharmacyApp.DAL;
using PharmacyApp.DAL.Repository;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Pages
{
    public class CreateMedicamentPage : IPage
    {
        public string Create()
        {
            string? name = "";
            Console.WriteLine("Добавление медикамента в базу данных (для отмены операции нажмите ESC)");

            Console.Write("Введите наименование: ");
            string result = Utils.GetNameValue(30);
            if (result == "AbortOperation") return "Работа с товарами";
            name = result;

            Console.Write("Введите целую часть цены медикамента: ");
            result = Utils.GetValue(5);
            if (result == "AbortOperation") return "Работа с товарами";
            string priceRub = result;

            Console.Write("Введите дробную часть цены медикамента: ");
            result = Utils.GetValue(2);
            if (result == "AbortOperation") return "Работа с товарами";
            string priceKop = result;

            Medicament medicament = new Medicament(name, decimal.Parse(priceRub + "," + priceKop));
            MedicamentsRepository medRepository = new MedicamentsRepository();
            medRepository.Create(medicament);

            Console.WriteLine("Наименование продукта: " + medicament.Name);
            Console.WriteLine("Цена продукта: " + medicament.Price);

            Console.WriteLine("Медикамент успешно добавлен.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            return "Работа с товарами";
        }
    }
}
