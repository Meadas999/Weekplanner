using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class TeamMSSQLDAL : ITeamContainer
    {
        Database db = new();
        private readonly string connectionString;
        public TeamMSSQLDAL(string cs)
        {
            connectionString = cs;
        }
        
        
        /// <summary>
        /// Haalt de teams op van een specifieke gebruiker.
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <returns></returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public List<TeamDTO> GetTeamsFromUser(int userid)
        { 
            try
            {
                List<TeamDTO> teams = new();
                db.MakeConnection();
                string query = "Select Id, Name, MaxMembers FROM Team INNER JOIN UserTeam ON team.Id = UserTeam.TeamId WHERE UserTeam.UserId = @userid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                teams = AddTeamsToList(command);
                db.EndConnection();
                foreach (TeamDTO dto in teams)
                {
                    dto.Members = AddUsersToTeam(dto.Id);
                }
                return teams;                
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
        /// Voegt de gebruiker toe aan het team.
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <param name="teamid">Id van het team.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void AddUserToTeam(int userid, int teamid)
        {
            try
            {
                db.MakeConnection();
                string query = "INSERT INTO UserTeam(UserId, TeamId) VALUES(@userid, @teamid)";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@teamid", teamid);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de gebruiker niet aan het team toevoegen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Haalt alle teams uit de database op.
        /// </summary>
        /// <returns>All teams.</returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public List<TeamDTO> GetAllTeams() 
        {
            try 
            {
                List<TeamDTO> teams = new();
                db.MakeConnection();
                string query = "SELECT * FROM Team";
                SqlCommand command = new(query, db.conn);
                teams = AddTeamsToList(command);
                db.EndConnection();
                foreach (TeamDTO dto in teams)
                {
                    dto.Members = AddUsersToTeam(dto.Id);
                }
                return teams;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de teams niet ophalen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Verwijdert de gebruiker uit het team.
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <param name="teamid">Id va het team die de gebruiker wilt verlaten.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void RemoveUserFromTeam(int userid, int teamid)
        {
            try 
            {
                db.MakeConnection();
                string query = "DELETE FROM UserTeam WHERE UserId = @userid AND TeamId = @teamid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@teamid", teamid);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de teams niet ophalen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }

        // Zet de teams in een lijst en returned het.
        private List<TeamDTO> AddTeamsToList(SqlCommand command)
        {
            List<TeamDTO> teams = new();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                teams.Add(ReadDTO(reader));
            }
            return teams;
        }
        // Leest een TeamDTO uit een reader.
        private TeamDTO ReadDTO(SqlDataReader reader)
        {
            return new TeamDTO(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToInt32(reader["MaxMembers"]));
        }
        // Voegt de gebruikers van het team en returned deze.
        private List<UserDTO> AddUsersToTeam(int teamid)
        {
            try 
            {
                List<UserDTO> users = new();
                db.MakeConnection();
                string query = "SELECT First_Name, Last_Name FROM Users INNER JOIN UserTeam ON UserTeam.UserId = Users.Id WHERE TeamId = @teamid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@teamid", teamid);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserDTO(reader["First_Name"].ToString(), reader["Last_Name"].ToString()));
                }
                db.EndConnection();
                return users;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de gebruikers uit het team niet ophalen, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }


    }
}
