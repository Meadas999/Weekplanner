using InterfaceLibrary;
using System.Data.SqlClient;

namespace DALmssqlServer
{
    public class ActiviteitenMSSQLDAL : IActiviteitenContainer
    {
    
        Database db = new();
        
        
        public void AddActivityToUserWTTime(UserDTO user, ActiviteitDTO activiteit)
        {
            int id = db.GetUserId(user);
            db.MakeConnection();
            string query = "INSERT INTO Activity(Type, Name, Description, Date, UserId) VALUES(@type, @name, @description, @date, @userid)";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@type", activiteit.Type);
            command.Parameters.AddWithValue("@name", activiteit.Name);
            command.Parameters.AddWithValue("@description", activiteit.Description);
            command.Parameters.AddWithValue("@date", activiteit.Date.Date);
            command.Parameters.AddWithValue("@userid", id);
            command.ExecuteNonQuery();
            db.EndConnection();
        }

        public int GetAmountActivitysDay(UserDTO user, DateTime date)
        {
            int id = db.GetUserId(user);
            db.MakeConnection();
            string query = "SELECT COUNT(*) FROM Activity WHERE UserId = @userid AND Date = @date";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@userid", id);
            command.Parameters.AddWithValue("@date", date);
            int amount = Convert.ToInt32(command.ExecuteScalar());
            db.EndConnection();
            return amount;
        }

        public List<ActiviteitDTO> GetEventsInfoDay(UserDTO user, DateTime day)
        {
            List<ActiviteitDTO> list = new List<ActiviteitDTO>();
            int userid = db.GetUserId(user);
            db.MakeConnection();
            string query = "SELECT * FROM Activity WHERE Date = @date AND UserId = @userid";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@date", day);
            command.Parameters.AddWithValue("@userid", userid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new ActiviteitDTO(reader["Type"].ToString(), reader["Name"].ToString(), reader["Description"].ToString(), Convert.ToDateTime(reader["Date"])));
                }
            }
            db.EndConnection();
            return list;
        }
    }
}