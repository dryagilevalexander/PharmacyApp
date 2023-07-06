using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacyApp.DAL.Repository
{
    public class StoresRepository
    {
    DbContext _dbContext;
        public StoresRepository()
        {
            _dbContext = TransitClass.DbContext;
        }

        public void Create(Store item)
        {
            string command = "INSERT INTO [dbo].[Stores]([PharmId],[Name]) VALUES ('" + item.PharmId + "','" + item.Name + "')";
            try 
            {
            _dbContext.CommExecuteNonQuery(command);
            }
            catch
            { 
            Console.WriteLine("Ошибка записи в базу данных");
            }
        }

        public void Delete(int id)
        {
            string command = "DELETE FROM [dbo].[Stores] WHERE [Id] = '" + id + "'";
            try
            {
                _dbContext.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<StoreViewModel> GetAllAndPharmacyInformation() 
        {
            string command = "SELECT [Stores].[Id], [stores].[Name], [Pharmacies].[Name] AS [PharmacyName], [Pharmacies].[Address] AS [PharmacyAddress] FROM [dbo].[Stores] INNER JOIN [dbo].[Pharmacies] ON [Stores].[PharmId]=[Pharmacies].[Id]";
            List<StoreViewModel> list = new List<StoreViewModel>();
            
            try
            {
                list = _dbContext.CommExecuteReader<StoreViewModel>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Store> GetById(int id)
        {
            string command = "SELECT * FROM [dbo].[Stores] Where [Id] =" + id;
            List<Store> list = new List<Store>();

            List<List<string>> records = new List<List<string>>();
            try
            {
                list = _dbContext.CommExecuteReader<Store>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        List<Store> GetAll()
        {
            string command = "SELECT * FROM [dbo].[Stores]";
            List<Store> list = new List<Store>();

            try
            {
                list = _dbContext.CommExecuteReader<Store>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
