using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Pharmacy(int id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }

    public class Medicament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } 

        public Medicament(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Store
    {
        public int Id { get; set; }
        public int PharmId { get; set; }
        public string Name { get; set; }

        public Store(int id, int pharmId, string name)
        {
            Id = id;
            PharmId = pharmId;
            Name = name;
        }
    }

    public class Consignment
    {
        public int Id { get; set; }
        public int MedId { get; set; }
        public int StoreId { get; set; }
        public int CountMed { get; set; }

        public Consignment(int id, int medId, int storeId, int countMed)
        {
            Id = id;
            MedId = medId;
            StoreId = storeId;
            CountMed = countMed;
        }
    }
}
