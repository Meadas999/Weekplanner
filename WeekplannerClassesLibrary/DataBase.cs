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
            string query = 
                "INSERT INTO Users(First_Name, Last_Name, Email, Password, Birthdate, Weight, Length) " +
                "VALUES(@first_name, @last_name, @email, @password, @birthdate, @weight, @length)";
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

        public User FindUserByEmailAndPassword(string email, string password)
        {
            MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email AND Password = @password";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                User user = new(reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                EndConnection();
                return user;
            }
            EndConnection();
            return null;
        }

        public User FindUserByEmail(string email)
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
            EndConnection();
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
                EndConnection();
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
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@type", activiteit.Type);
            command.Parameters.AddWithValue("@name", activiteit.Name);
            command.Parameters.AddWithValue("@description", activiteit.Description);
            command.Parameters.AddWithValue("@date", activiteit.DateTime.Date);
            command.Parameters.AddWithValue("@userid", id);
            command.ExecuteNonQuery();
            EndConnection();
        }

        public int GetAmountActivitysDay(User user, DateTime date)
        {
            int id = GetUserId(user);
            MakeConnection();
            string query = "SELECT COUNT(*) FROM Activity WHERE UserId = @userid AND Date = @date";
            SqlCommand command = new(query, conn);
            command.Parameters.AddWithValue("@userid", id);
            command.Parameters.AddWithValue("@date", date);
            int amount = Convert.ToInt32(command.ExecuteScalar());
            EndConnection();
            return amount;
        }

        //public List<Activiteit> GetEventsInfoDay(User user, DateTime day)
        //{
        //    List<Activiteit> list = new List<Activiteit>();
        //    int userid = GetUserId(user);
        //    int rows = GetAmountActivitysDay(user, day)-1;
        //    MakeConnection();
        //    string query = "SELECT * FROM Activity WHERE Date = @date AND UserId = @userid";
        //    SqlCommand command = new(query, conn);
        //    command.Parameters.AddWithValue("@date", day);
        //    command.Parameters.AddWithValue("@userid", userid);
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            var act = new List<Activiteit>();
        //            for (int i = 0; i <= rows; i++)
        //            {
        //                act.Add(new Activiteit(reader["ROW_NUMBER"],reader["Type"].ToString(), reader["Name"].ToString(), reader["Description"].ToString(), Convert.ToDateTime(reader["Date"])));
        //             }
        //            EndConnection();
        //            list.AddRange(act);
        //            return list;
        //        }
        //    }

        //    EndConnection();p
        //    return null;


        //}


    }

}
