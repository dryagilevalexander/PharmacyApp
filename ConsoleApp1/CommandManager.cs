using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public static class CommandManager
    {
        public static string CommandSelection(string command)
        {
            string resultCommand = string.Empty;
            switch (command)
            {
                case "Создать товар":
                    resultCommand = RepositoryManager.CreateMedicament();
                    break;
                case "Удалить товар":
                    resultCommand = RepositoryManager.DeleteMedicament();
                    break;
                case "Создать аптеку":
                    resultCommand = RepositoryManager.CreatePharmacy();
                    break;
                case "Удалить аптеку":
                    resultCommand = RepositoryManager.DeletePharmacy();
                    break;
                case "Создать склад":
                    resultCommand = RepositoryManager.CreateStore();
                    break;
                case "Удалить склад":
                    resultCommand = RepositoryManager.DeleteStore();
                    break;
                case "Создать партию":
                    resultCommand = RepositoryManager.CreateConsignment();
                    break;
                case "Удалить партию":
                    resultCommand = RepositoryManager.DeleteConsignment();
                    break;
            }
            Console.ReadKey();
            return resultCommand;
        }
    }
}
