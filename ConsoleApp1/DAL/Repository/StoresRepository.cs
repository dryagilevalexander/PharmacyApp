using PharmacyApp.Models;

namespace PharmacyApp.DAL.Repository
{
    public class StoresRepository
    {
     private DbContext _db;
        public StoresRepository(DbContext db)
        {
            _db = db;
        }

        public void Create(Store item)
        {
            string command = "INSERT INTO [dbo].[Stores]([PharmId],[Name]) VALUES ('" + item.PharmId + "','" + item.Name + "')";
            try 
            {
            _db.CommExecuteNonQuery(command);
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
                _db.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<Store> GetAll() 
        {
            string command = "SELECT [Stores].[Id], [stores].[Name], [Pharmacies].[Name] AS [PharmacyName], [Pharmacies].[Address] AS [PharmacyAddress] FROM [dbo].[Stores] INNER JOIN [dbo].[Pharmacies] ON [Stores].[PharmId]=[Pharmacies].[Id]";
            List<Store> list = new List<Store>();
            
            try
            {
                list = _db.CommExecuteReader<Store>(command);
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
                list = _db.CommExecuteReader<Store>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Store> GetByParentId(int id)
        {
            string command = "SELECT * FROM [dbo].[Stores] Where [PharmId] =" + id;
            List<Store> list = new List<Store>();

            List<List<string>> records = new List<List<string>>();
            try
            {
                list = _db.CommExecuteReader<Store>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
