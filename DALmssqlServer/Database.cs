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
        public static string connectionString = File.ReadAllText(@"C:\Users\amier\Desktop\Fontys\ICT & Software\S2\Bakka\JsonEncrypt.json");
        public SqlConnection? conn;
        public Rootobject root;


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
        public int GetUserId(UserDTO user)
        {
            MakeConnection();
            string query = "SELECT Id FROM Users WHERE Email = @email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", user.Email);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                EndConnection();
                return id;
            }
            EndConnection();
            return -1;
        }
    }
}
