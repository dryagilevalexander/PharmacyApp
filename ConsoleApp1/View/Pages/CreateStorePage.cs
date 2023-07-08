using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class CreateStorePage : IPage
    {
        UnitOfWork _unitOfWork;

        public CreateStorePage(UnitOfWork unitOfWork)
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
                return "В главное меню";
            }
            var sortedList = from p in pharmacies
                             orderby p.Id
                             select p;

            foreach (var pharmacy in sortedList)
            {
                itemsMenu.Add(pharmacy.Id + ". " + pharmacy.Name + " " + pharmacy.Address);
            }
            int pharmacyId = new MenuController().CreateDbMenu(itemsMenu);
            Console.Clear();

            Console.WriteLine("Добавление склада в базу данных (для отмены операции нажмите ESC)");
            Console.Write("Введите наименование: ");
            string result = Utils.GetNameValue(24);
            if (result == "AbortOperation") return "Работа со складами";
            string? name = result;

            Store store = new Store(pharmacyId, name);

            _unitOfWork.Stores.Create(store);

            Console.WriteLine("Склад успешно добавлен.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");

            Console.ReadKey();
            return "Работа со складами";
        }
    }
}
