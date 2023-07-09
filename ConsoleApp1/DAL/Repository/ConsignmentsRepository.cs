using PharmacyApp.Models;

namespace PharmacyApp.DAL.Repository
{
    public class ConsignmentsRepository
    {
        private IDbContext _db;
        public ConsignmentsRepository(IDbContext db)
        {
            _db = db;
        }

        public void Create(Consignment item)
        {
            string command = "INSERT INTO [dbo].[Consignments]([MedId],[StoreId],[CountMed]) VALUES ('" + item.MedId + "','" + item.StoreId + "','" + item.CountMed + "')";
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
            string command = "DELETE FROM [dbo].[Consignments] WHERE [Id] = '" + id + "'";
            try
            {
                _db.CommExecuteNonQuery(command);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления из базы данных");
            }
        }

        public List<Consignment> GetAll() 
        {
            string command = "SELECT [Consignments].[Id] AS [Id], [Medicaments].[Name] AS MedName, [Stores].[Name] AS [StoreName], [Pharmacies].[Name] AS [PharmacyName], [Pharmacies].[Address] AS [PharmacyAddress] FROM [Consignments] INNER JOIN [Stores] ON [Stores].[Id]=[Consignments].[StoreId] INNER JOIN [Pharmacies] ON [Pharmacies].[Id]=[Stores].[PharmId] INNER JOIN [Medicaments] ON [Consignments].[MedId]=[Medicaments].[Id]";
            List<Consignment> list = new List<Consignment>();
            
            try
            {
                list = _db.CommExecuteReader<Consignment>(command);
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
                list = _db.CommExecuteReader<Consignment>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }

        public List<Consignment> GetGroupConsByPharmacyId(int id)
        {
            string command = "SELECT[Medicaments].[Id] AS [MedId], [Medicaments].[Name] AS [MedName], SUM([Consignments].[CountMed]) AS [CountMed] FROM[dbo].[Consignments] INNER JOIN[Medicaments] ON[Consignments].[MedId] =[Medicaments].[Id] INNER JOIN[Stores] ON[Stores].[Id] =[Consignments].[StoreId] INNER JOIN[Pharmacies] ON[Pharmacies].[Id] =[Stores].[PharmId] WHERE[Pharmacies].[Id] = '" + id + "' GROUP BY[Medicaments].[Id], [Medicaments].[Name]";
            List <Consignment> list = new();

            try
            {
                list = _db.CommExecuteReader<Consignment>(command);
            }
            catch
            {
                Console.WriteLine("Ошибка получения данных из базы");
            }
            return list;
        }
    }
}
