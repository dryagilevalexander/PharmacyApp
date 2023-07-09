using PharmacyApp.DAL;
using PharmacyApp.View.Menu;
using PharmacyApp.View.Pages;

namespace PharmacyApp.Controllers
{
    public class Router
    {   
        public void Navigate(string menuItem)
        {
            Console.Clear();

            switch (menuItem)
            {
                case "Работа с товарами":
                    CreateMenu(new MedicamentsMenuPage());
                    break;
                case "Работа с аптеками":
                    CreateMenu(new PharmaciesMenuPage());
                    break;
                case "Работа со складами":
                    CreateMenu(new StoresMenuPage());
                    break;
                case "Работа с партиями":
                    CreateMenu(new ConsignmentsMenuPage());
                    break;
                case "В главное меню":
                    CreateMenu(new MainMenuPage());
                    break;
                case "Создать товар":
                    CreatePage(new CreateMedicamentPage());
                    break;
                case "Удалить товар":
                    CreatePage(new DeleteMedicamentPage());
                    break;
                case "Создать аптеку":
                    CreatePage(new CreatePharmacyPage());
                    break;
                case "Удалить аптеку":
                    CreatePage(new DeletePharmacyPage());
                    break;
                case "Товары в аптеке":
                    CreatePage(new MedInPharmacyPage());
                    break;
                case "Создать склад":
                    CreatePage(new CreateStorePage());
                    break;
                case "Удалить склад":
                    CreatePage(new DeleteStorePage());
                    break;
                case "Создать партию":
                    CreatePage(new CreateConsignmentPage());
                    break;
                case "Удалить партию":
                    CreatePage(new DeleteConsignmentPage());
                    break;
            }
        }

        public void CreatePage(BasePage page)
        {
            string routerItem = page.Create();
            page.Dispose();
            Navigate(routerItem);
        }

        public void CreateMenu(BaseMenuPage page)
        {
            page.Draw();
            Navigate(page.WaitingForInput());
        }
    }
}
