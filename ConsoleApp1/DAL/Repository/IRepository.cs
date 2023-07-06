using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyApp.Models;

namespace PharmacyApp.DAL.Repository
{
    interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(int id);
        List<T> GetAll();
        List<T> GetById(int id);
    }
}
