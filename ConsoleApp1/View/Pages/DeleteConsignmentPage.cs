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
    public class DeleteConsignmentPage
    {
        UnitOfWork _unitOfWork;

        public DeleteConsignmentPage(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Create()
        {
            List<Consignment> list = new List<Consignment>();
            list = _unitOfWork.Consignments.GetAll();

            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", "Id", "Name", "PharmacyName", "PharmacyAddress");
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            var sortedList = from p in list
                             orderby p.PharmacyName
                             select p;
            foreach (var consignment in sortedList)
            {
                Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", consignment.Id, consignment.MedName, consignment.PharmacyName, consignment.PharmacyAddress);
            }
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));

            Console.Write("Введите Id партии для удаления (для отмены операции нажмите ESC): ");

            string result = Utils.GetValue(9);
            if (result == "AbortOperation") return "Работа с партиями";
            int id = Convert.ToInt32(result);

            if (_unitOfWork.Consignments.GetById(id).Count != 0)
            {
                _unitOfWork.Consignments.Delete(id);
                Console.WriteLine("Партия с id={0} успешно удалена", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Партия с id={0} не найдена", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            Console.ReadKey();
            return "Работа с партиями";
        }
    }
}
