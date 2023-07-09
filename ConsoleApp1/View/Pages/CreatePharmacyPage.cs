using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class CreatePharmacyPage : BasePage
    {
        public override string Create()
        {
            string menuName = "Работа с аптеками";
            Console.WriteLine("Добавление аптеки в базу данных (для отмены операции нажмите ESC)");
            Console.Write("Введите наименование: ");
            string result = Utils.GetNameValue(29);
            if (result == "AbortOperation") return menuName;
            string name = result;


            Console.Write("Введите адрес: ");
            result = Utils.GetAddressValue(49);
            if (result == "AbortOperation") return menuName;
            string address = result;

            Console.Write("Введите телефон: +");
            result = Utils.GetValue(11);
            if (result == "AbortOperation") return menuName;
            string phone = result;

            Pharmacy pharmacy = new Pharmacy(name, address, "+" + phone);
            _unitOfWork.Pharmacies.Create(pharmacy);

            Console.WriteLine("Аптека успешно добавлена.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();

            return menuName;

        }
    }
}
