using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Consignment
    {
        public int Id { get; set; }
        public int MedId { get; set; }
        public int StoreId { get; set; }
        public int CountMed { get; set; }

        public string? MedName { get; set; }
        public string? PharmacyName { get; set; }
        public string? PharmacyAddress { get; set; }

        public Consignment(int id, int medId, int storeId, int countMed)
        {
            Id = id;
            MedId = medId;
            StoreId = storeId;
            CountMed = countMed;
        }

        public Consignment(int medId, int storeId, int countMed)
        {
            MedId = medId;
            StoreId = storeId;
            CountMed = countMed;
        }

        public Consignment()
        {
        }
    }
}
