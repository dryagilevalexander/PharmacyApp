using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class MedInPharmacyPage : IPage
    {
        UnitOfWork _unitOfWork;

        public MedInPharmacyPage(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string Create()
        {
            List<string> itemsMenu = new List<string>();

            List<Pharmacy> pharmacies = _unitOfWork.Pharmacies.GetAll();
            if (pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                Console.ReadKey();
                return "В главное меню";
            }
            var sortedPharmaciesList = from p in pharmacies
                                       orderby p.Name
                                       select p;

            foreach (var pharmacy in sortedPharmaciesList)
            {
                itemsMenu.Add(pharmacy.Id + ". " + pharmacy.Name + " " + pharmacy.Address);
            }
            int pharmacyId = new MenuController().CreateDbMenu(itemsMenu);
            Console.Clear();

            List<Consignment> list = _unitOfWork.Consignments.GetGroupConsByPharmacyId(pharmacyId);

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
