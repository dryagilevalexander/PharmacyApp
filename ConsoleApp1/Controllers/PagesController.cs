using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Controllers
{
    public static class PagesController
    {
        public static string RoutingPages(string pageName)
        {
            string result = string.Empty;
            switch (pageName)
            {
                case "Создать товар":
                    result = Pages.CreateMedicament();
                    break;
                case "Удалить товар":
                    result = Pages.DeleteMedicament();
                    break;
                case "Создать аптеку":
                    result = Pages.CreatePharmacy();
                    break;
                case "Удалить аптеку":
                    result = Pages.DeletePharmacy();
                    break;
                case "Создать склад":
                    result = Pages.CreateStore();
                    break;
                case "Удалить склад":
                    result = Pages.DeleteStore();
                    break;
                case "Создать партию":
                    result = Pages.CreateConsignment();
                    break;
                case "Удалить партию":
                    result = Pages.DeleteConsignment();
                    break;
            }

            Console.ReadKey();
            return result;
        }
    }
}
