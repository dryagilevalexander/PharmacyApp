using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class CreateConsignmentPage : IPage, IDisposable
    {
        private UnitOfWork _unitOfWork;
        public CreateConsignmentPage()
        {
            _unitOfWork = new UnitOfWork(DbContext.GetInstance());
        }   

        public string Create()
        {


            List<string> itemsPharmaciesMenu = new List<string>();

            List<Pharmacy> pharmacies = _unitOfWork.Pharmacies.GetAll();
            if (pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                Console.ReadKey();
                return "В главное меню";
            }
            var pharmaciesSortedList = from p in pharmacies
                                       orderby p.Id
                                       select p;

            foreach (var pharmacyItem in pharmaciesSortedList)
            {
                itemsPharmaciesMenu.Add(pharmacyItem.Id + ". " + pharmacyItem.Name + " " + pharmacyItem.Address);
            }
            int pharmacyId = new Router().CreateDbMenu(itemsPharmaciesMenu);
            Console.Clear();



            List<string> itemsStoresMenu = new List<string>();

            List<Store> stores = _unitOfWork.Stores.GetByParentId(pharmacyId);
            if (stores.Count == 0)
            {
                Console.WriteLine("Склады отсутствуют. Создайте хотя бы один склад!");
                Console.ReadKey();
                return "В главное меню";
            }
            var storesSortedList = from p in stores
                                   orderby p.Id
                                   select p;

            foreach (var storeItem in storesSortedList)
            {
                itemsStoresMenu.Add(storeItem.Id + ". " + storeItem.Name);
            }
            int storeId = new Router().CreateDbMenu(itemsStoresMenu);
            Console.Clear();




            Console.WriteLine("Добавление партии товара в базу данных.");

            List<string> itemsMedMenu = new List<string>();

            List<Medicament> medicaments = _unitOfWork.Medicaments.GetAll();
            if (medicaments.Count == 0)
            {
                Console.WriteLine("Медикаменты отсутствуют. Создайте хотя бы один медикамент!");
                Console.ReadKey();
                return "В главное меню";
            }
            var medicamentsSortedList = from p in medicaments
                                        orderby p.Id
                                        select p;

            foreach (var medicamentItem in medicamentsSortedList)
            {
                itemsMedMenu.Add(medicamentItem.Id + ". " + medicamentItem.Name);
            }
            int medicamentId = new Router().CreateDbMenu(itemsMedMenu);
            Console.Clear();


            Console.Write("Введите количество: ");

            string result = Utils.GetValue(9);
            if (result == "AbortOperation") return "Работа с партиями";
            int countMed = Convert.ToInt32(result);

            Consignment consignment = new Consignment(medicamentId, storeId, countMed);

            _unitOfWork.Consignments.Create(consignment);

            Console.WriteLine("Партия успешно добавлена.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            return "Работа с партиями";
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            Dispose();
        }
    }
}
