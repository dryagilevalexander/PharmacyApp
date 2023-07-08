using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyApp.View.Pages;

namespace PharmacyApp.Controllers
{
    public static class PagesController
    {
        public static string Navigate(string pageName)
        {
            string result = string.Empty;
            switch (pageName)
            {
                case "Создать товар":
                    result = new CreateMedicamentPage().Create();
                    break;
                case "Удалить товар":
                    result = new DeleteMedicamentPage().Create();
                    break;
                case "Создать аптеку":
                    result = new CreatePharmacyPage().Create();
                    break;
                case "Удалить аптеку":
                    result = new DeletePharmacyPage().Create();
                    break;
                case "Товары в аптеке":
                    result = new MedInPharmacyPage().Create();
                    break;
                case "Создать склад":
                    result = new CreateStorePage().Create();
                    break;
                case "Удалить склад":
                    result = new DeleteStorePage().Create();
                    break;
                case "Создать партию":
                    result = new CreateConsignmentPage().Create();
                    break;
                case "Удалить партию":
                    result = new DeleteConsignmentPage().Create();
                    break;
            }
            return result;
        }
    }
}
