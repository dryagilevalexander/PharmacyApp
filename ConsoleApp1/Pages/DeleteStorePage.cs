using PharmacyApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Pages
{
    public class DeleteStorePage: IPage
    {
    public string Create()
        {
            Console.WriteLine("Склад удален");
            return "Работа со складами";
        }
    }
}
