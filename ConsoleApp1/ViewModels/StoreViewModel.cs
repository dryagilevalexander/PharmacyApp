using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        public int PharmId { get; set; }
        public string Name { get; set; }
        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }

        public StoreViewModel()
        {
        }
    }
}
