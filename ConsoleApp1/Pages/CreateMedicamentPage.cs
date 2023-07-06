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
    public class CreateMedicamentPage: IPage
    {
    public string Create()
        {
            string? name = "";
            Console.WriteLine("Добавление медикамента в базу данных");
            Console.Write("Введите наименование: ");
            name = Console.ReadLine();
            if (name == "")
            {
                Console.Clear();
                Console.WriteLine("Не было введено название медикамента. Нажмите любую клавишу для продолжения");
                return "Работа с товарами";
            }


            Console.Write("Введите целую часть цены медикамента: ");
            string priceRub = Utils.GetValue(5);
            Console.Write("Введите дробную часть цены медикамента: ");
            string priceKop = Utils.GetValue(2);
            
            Medicament medicament = new Medicament(name, Decimal.Parse(priceRub + "," + priceKop));
            IRepository<Medicament> medRepository = new MedicamentsRepository();
            medRepository.Create(medicament);
            
            Console.WriteLine("Наименование продукта: " + medicament.Name);
            Console.WriteLine("Цена продукта: " + medicament.Price);

            Console.WriteLine("Медикамент успешно добавлен.");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            return "Работа с товарами";
        }
    }
}
