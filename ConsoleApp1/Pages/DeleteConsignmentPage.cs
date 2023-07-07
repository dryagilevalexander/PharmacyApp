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
    public class DeleteConsignmentPage
    {
    public string Create()
        {
            List<ConsignmentViewModel> list = new List<ConsignmentViewModel>();
            StoresRepository storesRepository = new StoresRepository();
           // list = storesRepository.GetAllAndPharmacyInformation();

            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", "Id", "Name", "PharmacyName", "PharmacyAddress");
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            var sortedList = from p in list
                             orderby p.Id
                             select p;
          //  foreach (var store in sortedList)
          //  {
          //      Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", store.Id, store.Name, store.PharmacyName, store.PharmacyAddress);
          //  }
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));

            Console.Write("Введите Id склада для удаления: ");
            int id = Convert.ToInt32(Utils.GetValue(10));
            if (storesRepository.GetById(id).Count != 0)
            {
                storesRepository.Delete(id);
                Console.WriteLine("Склад с id={0} успешно удален", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Склад с id={0} не найден", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            return "Работа с партиями";
        }
    }
}
