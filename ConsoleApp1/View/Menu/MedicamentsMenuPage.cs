using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Menu
{
    public class MedicamentsMenuPage : BaseMenuPage
    {
        protected override List<string> Items
        {
            get => new()
            {
            "Создать товар",
            "Удалить товар",
            "В главное меню"
            };
        }
    }
}
