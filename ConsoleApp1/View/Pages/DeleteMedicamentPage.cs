using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class DeleteMedicamentPage : BasePage
    {
        public override string Create()
        {
            List<Medicament> list = new List<Medicament>();
            Medicament medicament = new Medicament();
            list = _unitOfWork.Medicaments.GetAll();

            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));
            Console.WriteLine("|{0,15}|{1,50}|{2,20}|", "Id", "Name", "Price");
            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));

            foreach (Medicament med in list)
            {
                Console.WriteLine("|{0,15}|{1,50}|{2,20}|", med.Id, med.Name, med.Price);
            }
            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));
            Console.Write("Введите Id медикамента для удаления (для отмены операции нажмите ESC): ");

            string result = Utils.GetValue(9);
            if (result == "AbortOperation") return "Работа с товарами";
            int id = Convert.ToInt32(result);


            if (_unitOfWork.Medicaments.GetById(id).Count != 0)
            {
                _unitOfWork.Medicaments.Delete(id);
                Console.WriteLine("Медикамент с id={0} успешно удален", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Медикамент с id={0} не найден", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            Console.ReadKey();

            return "Работа с товарами";
        }
    }
}
