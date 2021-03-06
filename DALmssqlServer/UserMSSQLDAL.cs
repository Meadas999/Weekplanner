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
        Database db;
        public UserMSSQLDAL(string cs)
        {
            db = new(cs);
        }


        /// <summary>
        /// Voegt de gebruiker toe aan de database doormiddel van een UserDTO en een wachtwoord.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="user">De User die je wilt toevoegen.</param>
        /// <param name="password">Het wachtwoord van de User.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void AddUser(UserDTO user, string password)
        {
            // TODO: make bool and combine with checkforused email
            try
            {
                password = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 12);
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
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de gegevens niet registreren, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }

        }
        /// <summary>
        /// Controleert of de gegeven email al bestaat in de database.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="email">De email van de gebruiker.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public bool CheckForUsedEmail(string email)
        {
            try
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
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de gegeven email niet controleren, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }

        }
        /// <summary>
        /// Geeft een User terug doormiddel van een email en wachtwoord.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="email">De email van de gebruiker.</param>
        /// <param name="password">Het wachtwoord van de gebruiker.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public UserDTO? FindUserByEmailAndPassword(string email, string password)
        {

            try
            {
                bool verified = false;
                int id = 0;
                db.MakeConnection();
                string query = "SELECT Id, Password FROM Users WHERE Email = @email";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@email", email.ToLower());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                    string hash = reader["Password"].ToString();
                    verified = BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
                    
                }
                db.EndConnection();
                if (verified)
                {
                    return FindUserById(id);
                }
                return null;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de de gebruiker niet ophalen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Geeft een UserDTO terug doormiddel van een userid.
        /// Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="id">Id van de user.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public UserDTO FindUserById(int id)
        {
            try
            {
                db.MakeConnection();
                UserDTO user = new();
                string query = "SELECT * FROM Users WHERE Id = @id";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                user = ReadUserDTO(reader);
                if (user != null)
                { 
                    return user;
                }
                db.EndConnection();
                return null;
            
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de de gebruiker niet ophalen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Geeft een UserDTO terug doormiddel van een email. Als er een probleem optreedt die wordt veroorzaakt 
        /// door de gebruiker dan wordt er een tijdelijke exceptie gethrowed, zo niet dan een een permanente exceptie.
        /// </summary>
        /// <param name="email">De email van de gebruiker.</param>
        /// <returns></returns>
        public UserDTO FindUserByEmail(string email)
        {
            db.MakeConnection();
            UserDTO user = new();
            string query = "SELECT * FROM Users WHERE Email = @email";
            SqlCommand command = new(query, db.conn);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            user = ReadUserDTO(reader);
            db.EndConnection();
            return user;
        }
        //Leest een UserDTO uit de reader
        private UserDTO ReadUserDTO(SqlDataReader reader)
        {
            while (reader.Read())
            {
                return new UserDTO(Convert.ToInt32(reader["Id"]), reader["First_Name"].ToString(), reader["Last_Name"].ToString(), reader["Email"].ToString(),
                               Convert.ToDateTime(reader["Birthdate"]), Convert.ToDouble(reader["Weight"]), Convert.ToInt16(reader["Length"]));
            }
            return null;
        }
    }
}
