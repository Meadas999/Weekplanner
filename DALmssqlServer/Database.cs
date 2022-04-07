using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class Database
    {
        public static string connectionString = "Server=mssqlstud.fhict.local;Database=dbi457905_wplanner;User Id=dbi457905_wplanner;Password=Amier123!;";
        public SqlConnection conn;


        public void MakeConnection()
        {
            try
            {
                this.conn = new SqlConnection(connectionString);
                this.conn.Open();
                Console.WriteLine("Connected");

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
                this.conn.Close();
                Console.WriteLine("Disconnected");

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
