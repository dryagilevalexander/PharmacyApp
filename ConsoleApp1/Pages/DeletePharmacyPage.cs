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
    public class DeletePharmacyPage: IPage
    {
    public string Create()
        {
            List<Pharmacy> list = new List<Pharmacy>();
            IRepository<Pharmacy> pharmRepository = new PharmaciesRepository();
            list = pharmRepository.GetAll();

            Console.WriteLine(new string('-', 15 + 30 + 50 + 12 + 4));
            Console.WriteLine("|{0,15}|{1,30}|{2,50}|{3,12}|", "Id", "Name", "Address","Phone");
            Console.WriteLine(new string('-', 15 + 30 + 50 + 12 + 4));
            var sortedList = from p in list 
                                orderby p.Id
                                select p;
            foreach (Pharmacy pharm in sortedList)
            {
                Console.WriteLine("|{0,15}|{1,30}|{2,50}|{3,12}|", pharm.Id, pharm.Name, pharm.Address, pharm.Phone);
            }
            Console.WriteLine(new string('-', 15 + 30 + 50 + 12 + 4));
            Console.Write("Введите Id аптеки для удаления: ");
            int id = Convert.ToInt32(Utils.GetValue(10));
            if (pharmRepository.GetById(id).Count != 0)
            {
                pharmRepository.Delete(id);
                Console.WriteLine("Аптека с id={0} успешно удалена", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Аптека с id={0} не найдена", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            return "Работа с аптеками";
        }
    }
}
