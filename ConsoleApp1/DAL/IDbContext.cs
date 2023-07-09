using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.DAL
{
    public interface IDbContext
    {
        public void InitializeDb();
        public void CommExecuteNonQuery(string queryString);
        public List<T> CommExecuteReader<T>(string queryString) where T : class, new();
    }
}
