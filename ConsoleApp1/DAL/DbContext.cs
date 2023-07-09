using System.Data.SqlClient;
using System.Text;
using System.Text.Json;
using PharmacyApp.Models;
using System.Reflection;

namespace PharmacyApp.DAL
{
    public class DbContext: IDbContext
    {
        private static DbContext instance;

        private DbContext()
        { }

        public static DbContext GetInstance()
        {
            if (instance == null)
                instance = new DbContext();
            return instance;
        }

        private string _connectionString="";
        public void InitializeDb()
        {
            string serverName = "";
            string dbName = "";

            if (!File.Exists("pref.txt"))
            {
                do
                {
                    Console.Write("Введите имя сервера базы данных: ");
                    serverName = Utils.GetNameValue(50);
                    Console.Clear();
                    if (serverName == "")
                    {
                        Console.WriteLine("Вы не ввели имя сервера базы данных. Для повторной попытки ввода нажмите Y. Любая другая клавиша: выход из приложения.");
                        if (Console.ReadKey(true).Key != ConsoleKey.Y)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                while (serverName == "");

                do
                {
                    Console.Write("Введите имя базы данных: ");
                    dbName = Utils.GetNameValue(50);
                    Console.Clear();

                    if (dbName == "")
                    {
                        Console.WriteLine("Вы не ввели имя базы данных. Для повторной попытки ввода нажмите Y. Любая другая клавиша: выход из приложения.");
                        if (Console.ReadKey(true).Key != ConsoleKey.Y)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                while (dbName == "");



                _connectionString = @"Data Source=.\" + serverName + ";Initial Catalog=master;Integrated Security=True;";


                string createDbCommand = "CREATE DATABASE " + dbName;

                try
                {
                    CommExecuteNonQuery(createDbCommand);
                }
                catch (SqlException ex)
                {
                   Console.WriteLine("Не удалось установить соединение с сервером баз данных");
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                try
                {
                    Preferences pref = new Preferences(serverName, dbName);
                    FileStream fs = File.Create("pref.txt");
                    byte[] buffer = Encoding.Default.GetBytes(JsonSerializer.Serialize(pref));
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Возникла ошибка: " + e.Message);
                    Console.WriteLine("Завершение выполнения программы.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }


                _connectionString = @"Data Source=.\" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True";


                string createMedicamentsTable = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Medicaments')) CREATE TABLE [dbo].[Medicaments]([Id] [int] NOT NULL IDENTITY(1,1), [Name] [nvarchar](50) NULL, [Price] [money] NULL, CONSTRAINT [PK_Medicaments] PRIMARY KEY NONCLUSTERED(Id))";
                CommExecuteNonQuery(createMedicamentsTable);
                string createPharmaciesTable = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Pharmacies')) CREATE TABLE [dbo].[Pharmacies] ([Id] [int] NOT NULL IDENTITY(1,1), [Name] [nvarchar] (50) NULL, [Address][nvarchar] (50) NULL, [Phone][nvarchar] (12) NULL, CONSTRAINT[PK_Pharmacies] PRIMARY KEY NONCLUSTERED(Id))";
                CommExecuteNonQuery(createPharmaciesTable);
                string createStoresTable = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Stores')) CREATE TABLE [dbo].[Stores]([Id] [int] NOT NULL IDENTITY(1,1), [PharmId] [int] NOT NULL, [Name] [nvarchar](50) NULL, CONSTRAINT [PK_Stores] PRIMARY KEY NONCLUSTERED(Id), CONSTRAINT [FK_Pharmacies_Stores] FOREIGN KEY([PharmId]) REFERENCES [dbo].[Pharmacies] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE)";
                CommExecuteNonQuery(createStoresTable);
                string createConsignmentsTable = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Consignments')) CREATE TABLE [dbo].[Consignments]([Id] [int] NOT NULL IDENTITY(1,1), [MedId] [int] NOT NULL, [StoreId] [int] NOT NULL, [CountMed] [int] NULL, CONSTRAINT [PK_Consignments] PRIMARY KEY NONCLUSTERED(Id), CONSTRAINT [FK_Medicaments_Consignments] FOREIGN KEY([MedId]) REFERENCES [dbo].[Medicaments] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [FK_Stores_Consignments] FOREIGN KEY([StoreId]) REFERENCES [dbo].[Stores] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE)";
                CommExecuteNonQuery(createConsignmentsTable);

                Console.Clear();
#if DEBUG
                Console.Write("Добавить тестовое заполнение базы данных (y/любая другая клавиша)?: ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                FillTestSet();
                Console.WriteLine("\r\nТестовый набор данных добавлен. Нажмите любую клавишу для продолжения.");
                Console.ReadKey();
                Console.Clear();
                }
#endif

            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader("pref.txt");
                    string? prefValues = sr.ReadLine();
                    sr.Close();
                    
                    if(prefValues!=null)
                    { 
                        Preferences pref = JsonSerializer.Deserialize<Preferences>(prefValues);
                        serverName = pref.ServerName;
                        dbName = pref.DbName;
                    }
                    else
                    {
                        File.Delete("pref.txt");
                        Console.WriteLine("Файл настроек поврежден. Приложение будет закрыто. Откройте его повторно для продолжения.");
                        Environment.Exit(0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Файл настроек поврежден. Приложение будет закрыто. Откройте его повторно для продолжения.");
                    Console.WriteLine("Завершение выполнения программы.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            string connectionString = @"Data Source=.\" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True";
            _connectionString=connectionString;
        }

#if DEBUG
        private void FillTestSet()

        {
            string command = "";

            List<Pharmacy> pharmacies = new List<Pharmacy>()
            {
                new Pharmacy(1,"Ригла","г. Ярославль, пр-т Московский, д. 21", "+79021223353"),
                new Pharmacy(2,"Апрель","г. Ярославль, ул. Углическая, д. 15", "+79151223158"),
                new Pharmacy(3,"Планета здоровья","г. Ярославль, ул. Комсомольская, д. 2", "+79251441178"),
                new Pharmacy(4,"Аптека № 1","г. Ярославль, ул. Собинова, д. 43", "+79711555421")
            };

            List<Medicament> medicaments = new List<Medicament>()
            {
            new Medicament(1, "Аспирин", 55.22m),
            new Medicament(2, "Ношпа", 120.31m),
            new Medicament(3, "Нурофен", 221.25m),
            new Medicament(4, "Валериана", 21.32m),
            new Medicament(5, "Глицин", 71),
            new Medicament(6, "Кеторол", 320),
            new Medicament(7, "Аммиак", 10),
            new Medicament(8, "Атропин", 45.15m),
            new Medicament(9, "Лидокаин", 200),
            new Medicament(10, "Амброксол", 180),
            new Medicament(11, "Атенолол", 89),
            new Medicament(12, "Капотен", 250),
            new Medicament(13, "Анаприлин", 74),
            new Medicament(14, "Валсартан", 200),
            new Medicament(15, "Омепразол", 120),
            new Medicament(16, "Ампициллин", 115),
            new Medicament(17, "Тетрациклин", 77),
            new Medicament(18, "Фурацилин", 200)
            };

            List<Store> stores = new List<Store>()
            {
                new Store(1,1,"Главный"),
                new Store(2,1,"Северный"),
                new Store(3,2,"Склад №1"),
                new Store(4,2,"Склад №2"),
                new Store(5,2,"Склад №3"),
                new Store(6,2,"Склад №3"),
                new Store(7,3,"Склад \"Ярославль 1\""),
                new Store(8,4,"База \"Центр\""),
                new Store(8,4,"База \"Брагино\"")
            };

            List<Consignment> consignments = new List<Consignment>()
            {
                new Consignment(1,1,1,500),
                new Consignment(2,1,3,500),
                new Consignment(3,1,4,500),
                new Consignment(4,1,5,500),

                new Consignment(5,2,2,200),
                new Consignment(6,2,4,150),
                new Consignment(7,2,6,300),
                new Consignment(8,2,7,120),
                new Consignment(9,2,8,400),

                new Consignment(10,3,8,1500),
                new Consignment(11,3,3,1020),
                new Consignment(12,3,4,200),
                new Consignment(13,3,5,300),
                new Consignment(14,3,4,600),
                new Consignment(15,3,3,500),
                new Consignment(16,3,2,250),
                new Consignment(17,3,1,100),

                new Consignment(18,4,7,400),
                new Consignment(19,4,8,170),

                new Consignment(20,5,7,300),
                new Consignment(21,5,6,250),
                new Consignment(22,5,4,1020),
                new Consignment(23,5,8,200),

                new Consignment(24,6,1,1500),
                new Consignment(25,6,3,400),
                new Consignment(26,6,2,200),
                new Consignment(27,6,1,430),
                new Consignment(28,6,5,320),
                new Consignment(29,6,4,180),
                new Consignment(30,6,6,230),

                new Consignment(31,7,8,170),
                new Consignment(32,7,4,500),
                new Consignment(33,7,5,450),
                new Consignment(34,7,8,520),
                new Consignment(35,7,1,710),
                new Consignment(36,7,3,860),

                new Consignment(37,8,4,270),
                new Consignment(38,8,5,350),
                new Consignment(39,8,2,450),
                new Consignment(40,8,8,1000),

                new Consignment(41,9,6,281),
                new Consignment(42,9,5,457),
                new Consignment(43,9,4,200),
                new Consignment(44,9,6,510),
                new Consignment(45,9,7,211),
                new Consignment(46,9,1,301),
                new Consignment(47,9,2,1700),

                new Consignment(48,10,4,450),
                new Consignment(49,10,3,125),
                new Consignment(50,10,3,200),

                new Consignment(51,11,2,820),
                new Consignment(52,11,1,123),
                new Consignment(53,11,6,400),

                new Consignment(54,12,4,331),
                new Consignment(55,12,5,406),
                new Consignment(56,12,3,721),
                new Consignment(57,12,5,492),
                new Consignment(58,12,6,344),
                new Consignment(59,12,1,532),

                new Consignment(60,13,3,129),
                new Consignment(61,13,2,287),
                new Consignment(62,13,7,897),
                new Consignment(63,13,8,478),
                new Consignment(64,13,2,631),
                new Consignment(65,13,5,754),
                new Consignment(66,13,6,554),

                new Consignment(67,14,4,891),
                new Consignment(68,14,2,331),
                new Consignment(69,14,6,1299),
                new Consignment(70,14,1,223),

                new Consignment(71,15,5,476),
                new Consignment(72,15,7,327),
                new Consignment(73,15,3,891),


                new Consignment(74,16,4,500),
                new Consignment(75,16,2,321),
                new Consignment(76,16,6,287),
                new Consignment(77,16,7,589),
                new Consignment(78,16,1,432),
                new Consignment(79,16,4,894),

                new Consignment(80,17,1,337),
                new Consignment(71,17,5,482),
                new Consignment(72,17,7,982),
                new Consignment(73,17,4,748),

                new Consignment(74,18,2,392),
                new Consignment(75,18,5,128),
            };
#endif

            foreach (var pharmacy in pharmacies)
            {
                command = "INSERT INTO [dbo].[Pharmacies]([Name],[Address],[Phone]) VALUES ('" + pharmacy.Name + "','" + pharmacy.Address + "','" + pharmacy.Phone + "')";
                CommExecuteNonQuery(command);
            }

            foreach (var medicament in medicaments)
            {
                command = "INSERT INTO [dbo].[Medicaments]([Name],[Price]) VALUES ('" + medicament.Name + "','" + medicament.Price.ToString().Replace(",",".") + "')";
                CommExecuteNonQuery(command);
            }

            foreach (var store in stores)
            {
                command = "INSERT INTO [dbo].[Stores]([PharmId],[Name]) VALUES ('" + store.PharmId + "','" + store.Name + "')";
                CommExecuteNonQuery(command);
            }

            foreach (var consignment in consignments)
            {
                command = "INSERT INTO [dbo].[Consignments]([MedId],[StoreId],[CountMed]) VALUES ('" + consignment.MedId + "','" + consignment.StoreId + "','" + consignment.CountMed + "')";
                CommExecuteNonQuery(command);
            }
        }

        public void CommExecuteNonQuery(string queryString)
        {
            using (SqlConnection connection = new SqlConnection(
                       _connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<T>CommExecuteReader<T>(string queryString) where T : class, new()
        {
            List<T> records = new List<T>();
            Type myType = typeof(T);
            List<PropertyInfo> currentClassProps = myType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static).ToList();


             using (SqlConnection connection = new SqlConnection(_connectionString))
             {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int fieldCount = reader.FieldCount;

                    while (reader.Read())
                    {
                        T obj = new T();

                        foreach (PropertyInfo prop in currentClassProps)
                        {
                            for (int i = 0; i < fieldCount; i++)
                            {
                                if (reader.GetName(i)==prop.Name && reader[i].GetType().Name==prop.PropertyType.Name)
                                {
                                PropertyInfo currentProp = currentClassProps.FirstOrDefault(x => x.Name == prop.Name);
                                currentProp.SetValue(obj, reader[i]);
                                }
                            }

                        }
                        records.Add(obj);
                    }
                }
             }
            return records;
        }
    }
}
