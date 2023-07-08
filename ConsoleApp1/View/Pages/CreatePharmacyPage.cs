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
    public class CreatePharmacyPage : IPage
    {
        public string Create()
        {
            string menuName = "Работа с аптеками";
            Console.WriteLine("Добавление аптеки в базу данных (для отмены операции нажмите ESC)");
            Console.Write("Введите наименование: ");
            string result = Utils.GetNameValue(30);
            if (result == "AbortOperation") return menuName;
            string name = result;


            Console.Write("Введите адрес: ");
            result = Utils.GetAddressValue(50);
            if (result == "AbortOperation") return menuName;
            string address = result;

            Console.Write("Введите телефон: +");
            result = Utils.GetValue(11);
            if (result == "AbortOperation") return menuName;
            string phone = result;

            Pharmacy pharmacy = new Pharmacy(name, address, "+" + phone);

            PharmaciesRepository pharmRepository = new PharmaciesRepository();
            pharmRepository.Create(pharmacy);

            Console.WriteLine("Аптека успешно добавлена.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            return menuName;
        }
    }
}
