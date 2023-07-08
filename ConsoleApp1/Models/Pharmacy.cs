using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
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

        public Pharmacy(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Pharmacy()
        {
        }
    }
}
