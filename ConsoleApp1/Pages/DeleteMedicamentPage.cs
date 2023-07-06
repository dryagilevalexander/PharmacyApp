﻿using PharmacyApp.DAL;
using PharmacyApp.DAL.Repository;
using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.Pages
{
    public class DeleteMedicamentPage: IPage
    {
    public string Create()
        {
            List<Medicament> list = new List<Medicament>();
            Medicament medicament = new Medicament();
            IRepository<Medicament> medRepository = new MedicamentsRepository();
            list = medRepository.GetAll();

            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));
            Console.WriteLine("|{0,15}|{1,50}|{2,20}|", "Id", "Name", "Price");
            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));

            foreach (Medicament med in list) 
            {
                Console.WriteLine("|{0,15}|{1,50}|{2,20}|",med.Id,med.Name,med.Price);
            }
            Console.WriteLine(new string('-', 15 + 50 + 20 + 4));
            Console.Write("Введите Id медикамента для удаления: ");
            int id = Convert.ToInt32(Utils.GetValue(10));
            if (medRepository.GetById(id).Count != 0)
            {
                medRepository.Delete(id);
                Console.WriteLine("Медикамент с id={0} успешно удален", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            else
            {
                Console.WriteLine("Медикамент с id={0} не найден", id);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
            }
            return "Работа с товарами";
        }
    }
}