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
    public class ConsignmentsRepository
    {
    DbContext _dbContext;
        public ConsignmentsRepository()
        {
            _dbContext = TransitClass.DbContext;
        }

        public void Create(Consignment item)
        {
            string command = "INSERT INTO [dbo].[Consignments]([MedId],[StoreId],[CountMed]) VALUES ('" + item.MedId + "','" + item.StoreId + "','" + item.CountMed + "')";
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
            string command = "DELETE FROM [dbo].[Consignments] WHERE [Id] = '" + id + "'";
            try
            {
                _dbContext.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<Consignment> GetAllinStore(int id) 
        {
            string command = "SELECT * FROM [dbo].[Consignments] WHERE [StoreId] = '" + id + "'";
            List<Consignment> list = new List<Consignment>();
            
            try
            {
                list = _dbContext.CommExecuteReader<Consignment>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Consignment> GetById(int id)
        {
            string command = "SELECT * FROM [dbo].[Consignments] Where [Id] =" + id;
            List<Consignment> list = new List<Consignment>();

            List<List<string>> records = new List<List<string>>();
            try
            {
                list = _dbContext.CommExecuteReader<Consignment>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
