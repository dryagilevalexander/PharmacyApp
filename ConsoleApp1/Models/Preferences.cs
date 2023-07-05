using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Preferences
    {
        public string ServerName { get; set; }
        public string DbName { get; set; }
        public Preferences(string serverName, string dbName)
        {
            ServerName = serverName;
            DbName = dbName;
        }
    }
}
