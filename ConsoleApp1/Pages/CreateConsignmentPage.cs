using PharmacyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Pages
{
    public class CreateConsignmentPage : IPage
    {
        public string Create()
        { 
            Console.WriteLine("Партия создана");
            return "Работа с партиями";
        }
    }
}
