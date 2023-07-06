using PharmacyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Pages
{
    public class CreateStorePage: IPage
    {
        public string Create()
        { 
            Console.WriteLine("Склад создан");
            return "Работа со складами";
        }
    }
}
