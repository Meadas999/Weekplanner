using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;



namespace WeekplannerClassesLibrary
{
    public class DataBase
    {
        private static string connectionString = "Server=mssqlstud.fhict.local;Database=dbi457905_wplanner;User Id=dbi457905_wplanner;Password=Amier123!;";
        private SqlConnection conn;

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

        // For User

        public void AddUser(User user)
        {
            MakeConnection();
            string query = "INSERT INTO Users(First_Name, Last_Name, Email, Password, Birthdate, Weight, Length) VALUES(@first_name, @last_name, @email, @password, @birthdate, @weight, @length)";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@first_name", user.GetFirstName());
            command.Parameters.AddWithValue("@last_name", user.GetLastName());
            command.Parameters.AddWithValue("@email", user.GetEmail());
            command.Parameters.AddWithValue("@password", user.GetPassword());
            command.Parameters.AddWithValue("@birthdate", user.GetBirthDate());
            command.Parameters.AddWithValue("@weight", user.GetWeight());
            command.Parameters.AddWithValue("@length", user.GetLength());
            command.ExecuteNonQuery();
            EndConnection();
        }

        public bool CheckForUsedEmail(string email)
        {
            MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", email);
            int count = Convert.ToInt32(command.ExecuteScalar());
            EndConnection();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool CheckInlogDataCorrect(string email, string password)
        {
            MakeConnection();
            string query = "Select Password From Users WHERE Email = @email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Password"].ToString() == password)
                { return true; }
                
            }
            EndConnection();
            return false;
        }

        public User LogIn(string email)
        {
            MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
    
                User user = new(reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                EndConnection();
                return user;
            }
            
            return null;
        }

        public int GetUserId(User user)
        {
            
            MakeConnection();
            string query = "SELECT Id FROM Users WHERE Email = @email";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", user.GetEmail().ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["Id"]);
                return id;
            }
            EndConnection();
            return -1;
            
        }

        public void AddActivityToUserWTTime(User user, Activiteit activiteit)
        {
            int id = GetUserId(user);
            MakeConnection();
            string query = "INSERT INTO Activity(Type, Name, Description, Date, UserId) VALUES(@type, @name, @description, @date, @userid)";
            SqlCommand command = new(query,conn);
            command.Parameters.AddWithValue("@type", activiteit.Type);
            command.Parameters.AddWithValue("@name", activiteit.Name);
            command.Parameters.AddWithValue("@description", activiteit.Description);
            command.Parameters.AddWithValue("@date", activiteit.DateTime); 
            command.Parameters.AddWithValue("@userid", id);
            command.ExecuteNonQuery();
            EndConnection();
        }
    }

}
