using PharmacyApp.Controllers;
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
    public class MedInPharmacyPage : IPage
    {
        public string Create()
        {
            PharmaciesRepository pharmRepository = new();
            List<string> itemsMenu = new List<string>();

            List<Pharmacy> pharmacies = pharmRepository.GetAll();
            if (pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                return "В главное меню";
            }
            var sortedPharmaciesList = from p in pharmacies
                                       orderby p.Name
                                       select p;

            foreach (var pharmacy in sortedPharmaciesList)
            {
                itemsMenu.Add(pharmacy.Id + ". " + pharmacy.Name + " " + pharmacy.Address);
            }
            int pharmacyId = MenuController.CreateDbMenu(itemsMenu);
            Console.Clear();

            ConsignmentsRepository consRepository = new();
            List<Consignment> list = consRepository.GetGroupConsByPharmacyId(pharmacyId);

            Console.WriteLine(new string('-', 15 + 40 + 40 + 4));
            Console.WriteLine("|{0,15}|{1,40}|{2,40}|", "Id", "MedicamentName", "Count");
            Console.WriteLine(new string('-', 15 + 40 + 40 + 4));
            var sortedMedicamentsList = from p in list
                                        orderby p.MedName
                                        select p;
            foreach (var med in sortedMedicamentsList)
            {
                Console.WriteLine("|{0,15}|{1,40}|{2,40}|", med.MedId, med.MedName, med.CountMed);
            }
            Console.WriteLine(new string('-', 15 + 40 + 40 + 4));

            Console.ReadKey();
            return "Работа с аптеками";
        }
    }

}
