using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class UserMSSQLDAL : IUserContainer
    {
        
        //TODO: Add Database class instead of above
        Database db = new();
       
        public string GetEmail(UserDTO user)
        {
            return user.Email;
        }

        public string GetFullName(UserDTO user)
        {
            return $"{user.FirstName}  {user.LastName}";
        }

        public string GetFirstName(UserDTO user)
        {
            return user.FirstName;
        }

        public string GetLastName(UserDTO user)
        {
            return user.LastName;
        }

        public string GetPassword(UserDTO user)
        {
            return user.Password;
        }

        public DateTime GetBirthDate(UserDTO user)
        {
            return user.BirthDate.Date;
        }
        public double GetWeight(UserDTO user)
        {
            return user.Weight;
        }
        public int GetLength(UserDTO user)
        {
            return user.Length;
        }
        public void AddUser(UserDTO user)
        {
            db.MakeConnection();
            string query =
                "INSERT INTO Users(First_Name, Last_Name, Email, Password, Birthdate, Weight, Length) " +
                "VALUES(@first_name, @last_name, @email, @password, @birthdate, @weight, @length)";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@first_name", GetFirstName(user));
            command.Parameters.AddWithValue("@last_name", GetLastName(user));
            command.Parameters.AddWithValue("@email", GetEmail(user));
            command.Parameters.AddWithValue("@password", GetPassword(user));
            command.Parameters.AddWithValue("@birthdate", GetBirthDate(user));
            command.Parameters.AddWithValue("@weight", GetWeight(user));
            command.Parameters.AddWithValue("@length", GetLength(user));
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

                UserDTO user = new(reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
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

                UserDTO user = new(reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
                db.EndConnection();
                return user;
            }
            db.EndConnection();
            return null;
        }
    }
}
