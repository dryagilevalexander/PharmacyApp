using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Store
    {
        public int Id { get; set; }
        public int PharmId { get; set; }
        public string Name { get; set; }

        public string PharmacyName { get; set; }
        public string PharmacyAddress { get; set; }

        public Store(int id, int pharmId, string name)
        {
            Id = id;
            PharmId = pharmId;
            Name = name;
        }

        public Store(int pharmId, string name)
        {
            PharmId = pharmId;
            Name = name;
        }

        public Store()
        {
        }
    }
}
