using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Menu
{
    public class StoresMenuPage : BaseMenuPage
    {
        protected override List<string> Items
        {
            get => new()
            {
            "Создать склад",
            "Удалить склад",
            "В главное меню"
            };
        }
    }
}
