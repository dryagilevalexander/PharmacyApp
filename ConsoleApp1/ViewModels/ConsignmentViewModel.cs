using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class ConsignmentViewModel
    {
        public int Id { get; set; }
        public int MedicamentName { get; set; }
        public string StoreName{ get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }

        public ConsignmentViewModel()
        {
        }
    }
}
