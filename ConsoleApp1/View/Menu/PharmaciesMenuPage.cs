using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Menu
{
    public class PharmaciesMenuPage : BaseMenuPage
    {
        protected override List<string> Items
        {
            get => new()
            {
            "Создать аптеку",
            "Удалить аптеку",
            "Товары в аптеке",
            "В главное меню"
            };
        }
    }
}
