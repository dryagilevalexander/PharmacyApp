using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyApp.DAL;
using PharmacyApp.View.Pages;

namespace PharmacyApp.Controllers
{
    public class PagesController
    {
        UnitOfWork unitOfWork;

        public PagesController()
        {
            unitOfWork = new UnitOfWork();
        }

        public string Navigate(string pageName)
        {
            
            string result = string.Empty;
            switch (pageName)
            {
                case "Создать товар":
                    result = new CreateMedicamentPage(unitOfWork).Create();
                    break;
                case "Удалить товар":
                    result = new DeleteMedicamentPage(unitOfWork).Create();
                    break;
                case "Создать аптеку":
                    result = new CreatePharmacyPage(unitOfWork).Create();
                    break;
                case "Удалить аптеку":
                    result = new DeletePharmacyPage(unitOfWork).Create();
                    break;
                case "Товары в аптеке":
                    result = new MedInPharmacyPage(unitOfWork).Create();
                    break;
                case "Создать склад":
                    result = new CreateStorePage(unitOfWork).Create();
                    break;
                case "Удалить склад":
                    result = new DeleteStorePage(unitOfWork).Create();
                    break;
                case "Создать партию":
                    result = new CreateConsignmentPage(unitOfWork).Create();
                    break;
                case "Удалить партию":
                    result = new DeleteConsignmentPage(unitOfWork).Create();
                    break;
            }
            return result;
        }
    }
}
