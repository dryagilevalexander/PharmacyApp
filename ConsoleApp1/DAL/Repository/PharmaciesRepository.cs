using PharmacyApp.Models;

namespace PharmacyApp.DAL.Repository
{
    public class PharmaciesRepository
    {
     private DbContext _db;
        public PharmaciesRepository(DbContext db)
        {
            _db = db;
        }

        public void Create(Pharmacy item)
        {
            string command = "INSERT INTO [dbo].[Pharmacies]([Name],[Address],[Phone]) VALUES ('" + item.Name + "','" + item.Address + "','" + item.Phone + "')";
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
            string command = "DELETE FROM [dbo].[Pharmacies] WHERE [Id] = '" + id + "'";
            try
            {
                _db.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<Pharmacy> GetAll() 
        {
            string command = "SELECT * FROM [dbo].[Pharmacies]";
            List<Pharmacy> list = new List<Pharmacy>();
            
            try
            {
                list = _db.CommExecuteReader<Pharmacy>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Pharmacy> GetById(int id)
        {
            string command = "SELECT * FROM [dbo].[Pharmacies] Where [Id] =" + id;
            List<Pharmacy> list = new List<Pharmacy>();

            List<List<string>> records = new List<List<string>>();
            try
            {
                list = _db.CommExecuteReader<Pharmacy>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
