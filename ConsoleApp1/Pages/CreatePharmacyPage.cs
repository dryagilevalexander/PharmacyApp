using PharmacyApp.DAL;
using PharmacyApp.DAL.Repository;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Pages
{
    public class CreatePharmacyPage: IPage
    {
        public string Create()
        {

            string menuName = "Работа с аптеками";
            Console.WriteLine("Добавление аптеки в базу данных");
            Console.Write("Введите наименование: ");
            string? name = Utils.GetNameValue(50);
            if (name == "")
            {
                Console.Clear();
                Console.WriteLine("Не было введено наименование аптеки. Нажмите любую клавишу для продолжения");
                return menuName;
            }
            Console.Write("Введите адрес: ");
            string? address = Utils.GetAddressValue(100);
            if (address == "")
            {
                Console.Clear();
                Console.WriteLine("Не был введен адрес аптеки. Нажмите любую клавишу для продолжения");
                return menuName;
            }
            Console.Write("Введите телефон: +");
            string? phone = Utils.GetValue(11);
            if (phone == "")
            {
                Console.Clear();
                Console.WriteLine("Не был введен телефон аптеки. Нажмите любую клавишу для продолжения");
                return menuName;
            }

            Pharmacy pharmacy = new Pharmacy(name, address, "+" + phone);
            
            IRepository<Pharmacy> pharmRepository = new PharmaciesRepository();
            pharmRepository.Create(pharmacy);

            Console.WriteLine("Аптека успешно добавлена.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            return menuName;
        }
    }
}
