using PharmacyApp.Controllers;
using PharmacyApp.DAL;
using PharmacyApp.Models;
using PharmacyApp.View.Menu;

namespace PharmacyApp.View.Pages
{
    public class CreateStorePage : BasePage
    {
        public override string Create()
        {
            List<string> itemsPharmMenu = new List<string>();

            List<Pharmacy> pharmacies = _unitOfWork.Pharmacies.GetAll();
            if (pharmacies.Count == 0)
            {
                Console.WriteLine("Аптеки отсутствуют. Создайте хотя бы одну аптеку!");
                Console.ReadKey();
                return "В главное меню";
            }
            var sortedList = from p in pharmacies
                             orderby p.Id
                             select p;

            foreach (var pharmacy in sortedList)
            {
                itemsPharmMenu.Add(pharmacy.Id + ". " + pharmacy.Name + " " + pharmacy.Address);
            }

            var pharmaciesMenu = new DynamicMenu(itemsPharmMenu);
            pharmaciesMenu.Draw();
            int pharmacyId = Convert.ToInt32(pharmaciesMenu.WaitingForInput().Split(".")[0]);

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
