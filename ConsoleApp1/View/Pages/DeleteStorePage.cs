﻿using PharmacyApp.DAL;
using PharmacyApp.Models;

namespace PharmacyApp.View.Pages
{
    public class DeleteStorePage : BasePage
    {
        public override string Create()
        {
            List<Store> list = new List<Store>();
            list = _unitOfWork.Stores.GetAll();

            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", "Id", "Name", "PharmacyName", "PharmacyAddress");
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));
            var sortedList = from p in list
                             orderby p.Id
                             select p;
            foreach (var store in sortedList)
            {
                Console.WriteLine("|{0,15}|{1,25}|{2,25}|{3,40}|", store.Id, store.Name, store.PharmacyName, store.PharmacyAddress);
            }
            Console.WriteLine(new string('-', 15 + 25 + 25 + 40 + 4));

            Console.Write("Введите Id склада для удаления (для отмены операции нажмите ESC): ");

            string result = Utils.GetValue(9);
            if (result == "AbortOperation") return "Работа со складами";
            int id = Convert.ToInt32(result);

            if (_unitOfWork.Stores.GetById(id).Count != 0)
            {
                _unitOfWork.Stores.Delete(id);
                Console.WriteLine("Склад с id={0} успешно удален", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Склад с id={0} не найден", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            Console.ReadKey();

            return "Работа со складами";
        }
    }
}
