using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static WeekplannerClassesLibrary.Encrypter;
namespace DALmssqlServer
{
    public class Database
    {
        public static string connectionString = File.ReadAllText(@"C:\Users\amier\OneDrive - Office 365 Fontys\Weekplanner\JsonEncrypt.json");
        public SqlConnection? conn;
        public Rootobject root;

        // Maakt verbinding met de database.
        public void MakeConnection()
        {
            try
            {
                root = JsonSerializer.Deserialize<Rootobject>(connectionString);
                if (root != null)
                {
                    conn = new SqlConnection(root.DatabaseConfig.ConnectionString);
                    conn.Open();
                    Console.WriteLine("Connected to database");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
        // Eindigt de connectie met de database.
        public void EndConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    Console.WriteLine("Connection closed");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
        
    }
}
