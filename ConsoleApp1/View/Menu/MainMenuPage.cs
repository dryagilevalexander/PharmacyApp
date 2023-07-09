using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Menu
{
    public class MainMenuPage: BaseMenuPage
    {
    protected override List<string> Items
        {
            get => new()
            {
                "Работа с товарами",
                "Работа с аптеками",
                "Работа со складами",
                "Работа с партиями"
            };
        }
    }
}
