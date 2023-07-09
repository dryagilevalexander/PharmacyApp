using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.View.Menu
{
    public class ConsignmentsMenuPage : BaseMenuPage
    {
        protected override List<string> Items
        {
            get => new()
            {
            "Создать партию",
            "Удалить партию",
            "В главное меню"
            };
        }
    }
}
