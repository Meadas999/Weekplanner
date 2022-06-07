using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static WeekplannerClassesLibrary.Serialiser;
namespace DALmssqlServer
{
    public class Database
    {
        public static string connectionString;
        public SqlConnection? conn;

        public Database(string cs)
        {
            connectionString = cs;
        }

        // Maakt verbinding met de database.
        public void MakeConnection()
        {
            try
            {
                if (connectionString != null)
                {
                    conn = new SqlConnection(connectionString);
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
