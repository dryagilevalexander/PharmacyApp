using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp
{
    public class DbManager
    {

    public string InitiateDb(string serverName, string dbName)
        {
            string pref = "";
            if(!File.Exists("pref.txt"))
            {
                File.Create("pref.txt");
                try
                {
                    StreamWriter sw = new StreamWriter("pref.txt");
                    sw.WriteLine("{\"connectionString\": "+ @"Data Source=.\" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True");
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            else
            {
                try
                {
                    StreamReader sr = new StreamReader("pref.txt");
                    pref = sr.ReadLine();
                    sr.Close();
                    Console.WriteLine(pref);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }    





            string initiateConnectionString = @"Data Source=.\" + serverName + ";Initial Catalog=master;Integrated Security=True";
            string createDbCommand = "CREATE DATABASE " + dbName;
            int checkDatabaseAvailability = 0;
            string command = "";



            try
            {
                CommExecuteNonQuery(createDbCommand, initiateConnectionString);
            }
            catch (SqlException ex)
            {
                checkDatabaseAvailability = ex.Number;
            }
            Console.WriteLine(checkDatabaseAvailability);
            
            connectionString = @"Data Source=.\" + serverName + ";Initial Catalog=" +dbName + ";Integrated Security=True";


                command = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Medicaments')) CREATE TABLE [dbo].[Medicaments]([Id] [int] NOT NULL IDENTITY(1,1), [Name] [nvarchar](50) NULL, [Price] [decimal](18, 0) NULL, CONSTRAINT [PK_Medicaments] PRIMARY KEY NONCLUSTERED(Id))";
                CommExecuteNonQuery(command, connectionString);
                command = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Pharmacies')) CREATE TABLE [dbo].[Pharmacies] ([Id] [int] NOT NULL IDENTITY(1,1), [Name] [nvarchar] (50) NULL, [Address][nvarchar] (100) NULL, [Phone][nvarchar] (20) NULL, CONSTRAINT[PK_Pharmacies] PRIMARY KEY NONCLUSTERED(Id))";
                CommExecuteNonQuery(command, connectionString);
                command = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Stores')) CREATE TABLE [dbo].[Stores]([Id] [int] NOT NULL IDENTITY(1,1), [PharmId] [int] NOT NULL, [Name] [nvarchar](50) NULL, CONSTRAINT [PK_Stores] PRIMARY KEY NONCLUSTERED(Id), CONSTRAINT [FK_Pharmacies_Stores] FOREIGN KEY([PharmId]) REFERENCES [dbo].[Pharmacies] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE)";
                CommExecuteNonQuery(command, connectionString);
                command = "IF (NOT EXISTS (SELECT *  FROM INFORMATION_SCHEMA.TABLES  WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'Consignments')) CREATE TABLE [dbo].[Consignments]([Id] [int] NOT NULL IDENTITY(1,1), [MedId] [int] NOT NULL, [StoreId] [int] NOT NULL, [CountMed] [int] NULL, CONSTRAINT [PK_Consignments] PRIMARY KEY NONCLUSTERED(Id), CONSTRAINT [FK_Medicaments_Consignments] FOREIGN KEY([MedId]) REFERENCES [dbo].[Medicaments] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [FK_Stores_Consignments] FOREIGN KEY([StoreId]) REFERENCES [dbo].[Stores] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE)";
                CommExecuteNonQuery(command, connectionString);


            return connectionString;
    }


    public void FillTestSet(string connectionString)

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
            new Medicament(1, "Аспирин", 55),
            new Medicament(2, "Ношпа", 120),
            new Medicament(3, "Нурофен", 221),
            new Medicament(4, "Валериана", 21),
            new Medicament(5, "Глицин", 71),
            new Medicament(6, "Кеторол", 320),
            new Medicament(7, "Аммиак", 10),
            new Medicament(8, "Атропин", 45),
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
                new Consignment(1,1,3,500),
                new Consignment(2,1,3,500),
                new Consignment(3,1,3,500),
                new Consignment(4,1,3,500),

                new Consignment(5,2,3,200),
                new Consignment(6,2,3,150),
                new Consignment(7,2,3,300),
                new Consignment(8,2,3,120),
                new Consignment(9,2,3,400),

                new Consignment(10,3,3,1500),
                new Consignment(11,3,3,1020),
                new Consignment(12,3,3,200),
                new Consignment(13,3,3,300),
                new Consignment(14,3,3,600),
                new Consignment(15,3,3,500),
                new Consignment(16,3,3,250),
                new Consignment(17,3,3,100),

                new Consignment(18,4,3,400),
                new Consignment(19,4,3,170),

                new Consignment(20,5,3,300),
                new Consignment(21,5,3,250),
                new Consignment(22,5,3,1020),
                new Consignment(23,5,3,200),

                new Consignment(24,6,3,1500),
                new Consignment(25,6,3,400),
                new Consignment(26,6,3,200),
                new Consignment(27,6,3,430),
                new Consignment(28,6,3,320),
                new Consignment(29,6,3,180),
                new Consignment(30,6,3,230),

                new Consignment(31,7,3,170),
                new Consignment(32,7,3,500),
                new Consignment(33,7,3,450),
                new Consignment(34,7,3,520),
                new Consignment(35,7,3,710),
                new Consignment(36,7,3,860),

                new Consignment(37,8,3,270),
                new Consignment(38,8,3,350),
                new Consignment(39,8,3,450),
                new Consignment(40,8,3,1000),

                new Consignment(41,9,3,281),
                new Consignment(42,9,3,457),
                new Consignment(43,9,3,200),
                new Consignment(44,9,3,510),
                new Consignment(45,9,3,211),
                new Consignment(46,9,3,301),
                new Consignment(47,9,3,1700),

                new Consignment(48,10,3,450),
                new Consignment(49,10,3,125),
                new Consignment(50,10,3,200),

                new Consignment(51,11,3,820),
                new Consignment(52,11,3,123),
                new Consignment(53,11,3,400),

                new Consignment(54,12,3,331),
                new Consignment(55,12,3,406),
                new Consignment(56,12,3,721),
                new Consignment(57,12,3,492),
                new Consignment(58,12,3,344),
                new Consignment(59,12,3,532),

                new Consignment(60,13,3,129),
                new Consignment(61,13,3,287),
                new Consignment(62,13,3,897),
                new Consignment(63,13,3,478),
                new Consignment(64,13,3,631),
                new Consignment(65,13,3,754),
                new Consignment(66,13,3,554),

                new Consignment(67,14,3,891),
                new Consignment(68,14,3,331),
                new Consignment(69,14,3,1299),
                new Consignment(70,14,3,223),

                new Consignment(71,15,3,476),
                new Consignment(72,15,3,327),
                new Consignment(73,15,3,891),


                new Consignment(74,16,3,500),
                new Consignment(75,16,3,321),
                new Consignment(76,16,3,287),
                new Consignment(77,16,3,589),
                new Consignment(78,16,3,432),
                new Consignment(79,16,3,894),

                new Consignment(80,17,3,337),
                new Consignment(71,17,3,482),
                new Consignment(72,17,3,982),
                new Consignment(73,17,3,748),

                new Consignment(74,18,3,392),
                new Consignment(75,18,3,128),
            };

            foreach (var pharmacy in pharmacies)
            {
                command = "INSERT INTO [dbo].[Pharmacies]([Name],[Address],[Phone]) VALUES ('" + pharmacy.Name + "','" + pharmacy.Address + "','" + pharmacy.Phone + "')";
                CommExecuteNonQuery(command, connectionString);
            }

            foreach (var medicament in medicaments)
            {
                command = "INSERT INTO [dbo].[Medicaments]([Name],[Price]) VALUES ('" + medicament.Name + "','" + medicament.Price + "')";
                CommExecuteNonQuery(command, connectionString);
            }

            foreach (var store in stores)
            {
                command = "INSERT INTO [dbo].[Stores]([PharmId],[Name]) VALUES ('" + store.PharmId + "','" + store.Name + "')";
                CommExecuteNonQuery(command, connectionString);
            }

            foreach (var consignment in consignments)
            {
                command = "INSERT INTO [dbo].[Consignments]([MedId],[StoreId],[CountMed]) VALUES ('" + consignment.MedId + "','" + consignment.StoreId + "','" + consignment.CountMed + "')";
                CommExecuteNonQuery(command, connectionString);
            }
        }

    public void CommExecuteNonQuery(string queryString,
    string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


    public void CommExecuteReader(string queryString, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader[0]));
                }
            }
        }
    }
}
}
