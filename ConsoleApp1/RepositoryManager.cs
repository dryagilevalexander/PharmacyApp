using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public static class RepositoryManager
    {
    public static string CreateMedicament()
        {
            Console.WriteLine("Медикамент создан");
            return "Работа с медикаментами";
        }
        public static string DeleteMedicament()
        {
            Console.WriteLine("Медикамент удален");
            return "Работа с медикаментами";

        }

        public static string CreatePharmacy()
        {
            Console.WriteLine("Аптека создана");
            return "Работа с аптеками";
        }

        public static string DeletePharmacy()
        {
            Console.WriteLine("Аптека удалена");
            return "Работа с аптеками";
        }

        public static string CreateStore()
        {
            Console.WriteLine("Склад создан");
            return "Работа со складами";
        }

        public static string DeleteStore()
        {
            Console.WriteLine("Склад удален");
            return "Работа со складами";
        }

        public static string CreateConsignment()
        {
            Console.WriteLine("Партия создана");
            return "Работа с партиями";
        }

        public static string DeleteConsignment()
        {
            Console.WriteLine("Партия удалена");
            return "Работа с партиями";
        }
    }
}
