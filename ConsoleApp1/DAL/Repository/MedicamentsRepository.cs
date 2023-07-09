using PharmacyApp.Models;

namespace PharmacyApp.DAL.Repository
{
    public class MedicamentsRepository
    {
     private IDbContext _db;
        public MedicamentsRepository(IDbContext db)
        {
            _db = db;
        }

        public void Create(Medicament item)
        {
            string command = "INSERT INTO [dbo].[Medicaments]([Name],[Price]) VALUES ('" + item.Name + "','" + item.Price.ToString().Replace(",",".") + "')";
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
            string command = "DELETE FROM [dbo].[Medicaments] WHERE [Id] = '" + id + "'";
            try
            {
                _db.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<Medicament> GetAll() 
        {
            string command = "SELECT * FROM [dbo].[Medicaments]";
            List<Medicament> list = new List<Medicament>();
            
            try
            {
                list = _db.CommExecuteReader<Medicament>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Medicament> GetById(int id)
        {
            string command = "SELECT * FROM [dbo].[Medicaments] Where [Id] =" + id;
            List<Medicament> list = new List<Medicament>();

            List<List<string>> records = new List<List<string>>();
            try
            {
                list = _db.CommExecuteReader<Medicament>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
