using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekplannerClassesLibrary;

namespace DALmssqlServer
{
    public class UserMSSQLDAL : IUserContainer
    {
        Database db = new();
        public void AddUser(UserDTO user, string password)
        {
            db.MakeConnection();
            string query =
                "INSERT INTO Users(First_Name, Last_Name, Email, Password, Birthdate, Weight, Length) " +
                "VALUES(@first_name, @last_name, @email, @password, @birthdate, @weight, @length)";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@first_name", user.FirstName);
            command.Parameters.AddWithValue("@last_name", user.LastName);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@birthdate", user.BirthDate.Date);
            command.Parameters.AddWithValue("@weight", user.Weight);
            command.Parameters.AddWithValue("@length", user.Length);
            command.ExecuteNonQuery();
            db.EndConnection();
        }

        public bool CheckForUsedEmail(string email)
        {
            db.MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@email", email);
            int count = Convert.ToInt32(command.ExecuteScalar());
            db.EndConnection();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public UserDTO FindUserByEmailAndPassword(string email, string password)
        {
            db.MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email AND Password = @password";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new(Convert.ToInt32(reader["Id"]), reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                db.EndConnection();
                return user;
            }
            db.EndConnection();
            return null;
        }

        public UserDTO FindUserById(int id)
        {
            db.MakeConnection();
            string query = "SELECT * FROM Users WHERE Id = @id";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new(Convert.ToInt32(reader["Id"]), reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                db.EndConnection();
                return user;
            }
            db.EndConnection();
            return null;
        }

        public UserDTO FindUserByEmail(string email)
        {
            db.MakeConnection();
            string query = "SELECT * FROM Users WHERE Email = @email";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserDTO user = new(Convert.ToInt32(reader["Id"]), reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                db.EndConnection();
                return user;
            }
            db.EndConnection();
            return null;
        }
    }
}
