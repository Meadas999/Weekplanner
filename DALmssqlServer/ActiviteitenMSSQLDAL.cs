using InterfaceLibrary;
using System.Data.SqlClient;

namespace DALmssqlServer
{
    public class ActiviteitenMSSQLDAL : IActiviteitenContainer
    {
        private readonly string connectionString;
        Database db = new();

        public ActiviteitenMSSQLDAL(string cs)
        {
            connectionString = cs;
        }
        
        /// <summary>
        /// Deze methode voegt de activiteit met alleen een datum(dus zonder tijd) toe aan de database ,doormiddel van een ActiviteitDTO en een userid. 
        /// </summary>
        /// <param name="id">Userid van de gebruiker</param>
        /// <param name="activiteit">Activiteit die je wilt toevoegen</param>
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
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de activiteit niet toevoegen aan de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Past de specifieke activiteit aan met de nieuwe data. In de front-end
        /// </summary>
        /// <param name="activiteit">Activiteit die je wilt wijzigen</param>
        /// <param name="userid">Userid van de gebruiker</param>
        public void UpdateActivityWithDayOnly(ActiviteitDTO activiteit, int userid)
        {
            try
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
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de activiteit niet updaten in de database. Controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Verwijdert de activiteit in de database met de gegeven activiteitsid die gekoppeld is aan de specififieke activiteit. 
        /// Waardoor de specifieke activieit verwijdert kan worden. Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="activiteitsid">Activiteitsid van de activiteit die je wilt verwijderen. </param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void DeleteActivityById(int activiteitsid)
        {
            try
            {
                db.MakeConnection();
                string query = "DELETE FROM Activity WHERE Id = @id";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@id", activiteitsid);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de activiteit niet verwijderen in de database. Controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Haalt een activiteit uit de database doormiddel van de gegeven activiteitsid, en zet deze om in een activiteitDTO. 
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="id">Activiteitsid</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public ActiviteitDTO GetActivityById(int id)
        {
            try
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
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de activiteits' id niet verkrijgen uit de database. Controleer uw verbinding. ", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }

        }
        /// <summary>
        /// Telt het aantal activiteiten op van de gebruiker doormiddel van de userid en de specifieke dag.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="userid">Userid van de gebruiker.</param>
        /// <param name="date">De datum waar je op wilt zoeken.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public int GetAmountActivitysDay(int userid, DateTime date)
        {
            try
            {
                db.MakeConnection();
                string query = "SELECT COUNT(*) FROM Activity WHERE UserId = @userid AND Date = @date";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@date", date);
                int amount = Convert.ToInt32(command.ExecuteScalar());
                db.EndConnection();
                return amount;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon het aantal niet verkrijgen uit de database. Controleer uw verbinding. ", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }

        }
        /// <summary>
        /// Haalt alle activiteien op van de meegegeven specifieke dag en met userid.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="userid">Userid van de gebruiker.</param>
        /// <param name="day">De dag waar je op wilt zoeken.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public List<ActiviteitDTO> GetEventsInfoDay(int userid, DateTime day)
        {
            try
            {
                List<ActiviteitDTO> list = new List<ActiviteitDTO>();
                db.MakeConnection();
                string query = "SELECT * FROM Activity WHERE Date = @date AND UserId = @userid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@date", day);
                command.Parameters.AddWithValue("@userid", userid);
                AddActivityToList(command);
                db.EndConnection();
                return list;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de activiteiten niet verkrijgen uit de database. Controleer uw verbinding. ", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }

        /// <summary>
        /// Haalt alle activiteiten op van de gebruiker doormiddel van de gegeven userid.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public List<ActiviteitDTO> GetAllEvents(int userid)
        {
            try
            {
                List<ActiviteitDTO> list = new List<ActiviteitDTO>();
                db.MakeConnection();
                string query = "SELECT * FROM Activity WHERE UserId = @userid ORDER BY Date DESC";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                AddActivityToList(command);
                db.EndConnection();
                return list;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de Activiteits' id niet verkrijgen uit de database. Controleer uw verbinding. ", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie, neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        //Geeft een lijst van activiteiten terug.
        private List<ActiviteitDTO> AddActivityToList(SqlCommand command)
        {
            List<ActiviteitDTO> list = new();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(ReadDTO(reader));
                }
            }
            return list;
        }
        //Leest een activiteitDTO uit een reader.
        private ActiviteitDTO ReadDTO(SqlDataReader reader)
        {
            return new ActiviteitDTO(Convert.ToInt32(reader["Id"]), reader["Type"].ToString(), reader["Name"].ToString(),
                                                     reader["Description"].ToString(), Convert.ToDateTime(reader["Date"]));
        }

    }
}