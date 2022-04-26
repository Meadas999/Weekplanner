using InterfaceLibrary;
using System.Data.SqlClient;

namespace DALmssqlServer
{
    public class ActiviteitenMSSQLDAL : IActiviteitenContainer
    {
        Database db = new();

        /// <summary>
        /// Deze methode voegt de activiteit met alleen een datum(dus zonder tijd) toe aan de database ,doormiddel van een ActiviteitDTO en een userid. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="activiteit"></param>
        public void AddActivityToUserWithDayOnly(int userid, ActiviteitDTO activiteit)
        {
            try
            {
                db.MakeConnection();
                string query = "INSERT INTO Activity(Type, Name, Description, Date, UserId) VALUES(@type, @name, @description, @date, @userid)";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@type", activiteit.Type);
                command.Parameters.AddWithValue("@name", activiteit.Name);
                command.Parameters.AddWithValue("@description", activiteit.Description);
                command.Parameters.AddWithValue("@date", activiteit.Date);
                command.Parameters.AddWithValue("@userid", userid);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch
            {
                throw new ActiviteitException("Kon de Activiteit niet toevoegen aan de database.");
            }
        }

        /// <summary>
        /// Past de specifieke activiteit aan met de nieuwe data. In de front-end
        /// </summary>
        /// <param name="activiteit"></param>
        /// <param name="userid"></param>
        public void UpdateActivityWithDayOnly(ActiviteitDTO activiteit, int userid)
        {
            db.MakeConnection();
            string query = "UPDATE Activity SET Type = @type, Name = @name, Description = @description, Date = @date WHERE UserId = @userid AND Id = @id";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@type", activiteit.Type);
            command.Parameters.AddWithValue("@name", activiteit.Name);
            command.Parameters.AddWithValue("@description", activiteit.Description);
            command.Parameters.AddWithValue("@date", activiteit.Date);
            command.Parameters.AddWithValue("@id", activiteit.Id);
            command.Parameters.AddWithValue("@userid", userid);
            command.ExecuteNonQuery();
            db.EndConnection();
        }

        public void DeleteActivityById(int id)
        {
            db.MakeConnection();
            string query = "DELETE FROM Activity WHERE Id = @id";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            db.EndConnection();
        }

        public ActiviteitDTO GetActivityById(int id)
        {
            db.MakeConnection();
            string query = "SELECT * FROM Activity WHERE Id = @id";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ActiviteitDTO activiteit = ReadDTO(reader);
                    db.EndConnection();
                    return activiteit;
                }
            }
            db.EndConnection();
            return null;

        }
        public int GetAmountActivitysDay(UserDTO user, DateTime date)
        {

            db.MakeConnection();
            string query = "SELECT COUNT(*) FROM Activity WHERE UserId = @userid AND Date = @date";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@userid", user.Id);
            command.Parameters.AddWithValue("@date", date);
            int amount = Convert.ToInt32(command.ExecuteScalar());
            db.EndConnection();
            return amount;
        }

        public List<ActiviteitDTO> GetEventsInfoDay(UserDTO user, DateTime day)
        {
            List<ActiviteitDTO> list = new List<ActiviteitDTO>();
            db.MakeConnection();
            string query = "SELECT * FROM Activity WHERE Date = @date AND UserId = @userid";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@date", day);
            command.Parameters.AddWithValue("@userid", user.Id);
            AddActivityToList(list, command);
            db.EndConnection();
            return list;
        }


        public List<ActiviteitDTO> GetAllEvents(int userid)
        {
            List<ActiviteitDTO> list = new List<ActiviteitDTO>();
            db.MakeConnection();
            string query = "SELECT * FROM Activity WHERE UserId = @userid ORDER BY Date DESC";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@userid", userid);
            AddActivityToList(list, command);
            db.EndConnection();
            return list;
        }
        private void AddActivityToList(List<ActiviteitDTO> list, SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(ReadDTO(reader));
                }
            }
        }

        private ActiviteitDTO ReadDTO(SqlDataReader reader)
        {
            return new ActiviteitDTO(Convert.ToInt32(reader["Id"]), reader["Type"].ToString(), reader["Name"].ToString(), 
                                                     reader["Description"].ToString(), Convert.ToDateTime(reader["Date"]));
        }

    }
}