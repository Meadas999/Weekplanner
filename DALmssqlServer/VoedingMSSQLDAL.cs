using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class VoedingMSSQLDAL : IVoedingContainer
    {
        private readonly string connectionString;
        Database db = new();

        public VoedingMSSQLDAL(string cs)
        {
            this.connectionString = cs;
        }


        /// <summary>
        /// Voegt een nieuwe voeding toe aan de database
        /// </summary>
        /// <param name="voeding">De voeding die je wilt toevoegen.</param>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void AddVoeding(VoedingDTO voeding, int userid)
        {
            try
            {
                db.MakeConnection();
                string query = "INSERT INTO Voeding(Name, Fat, Carbohydrates, Sugar, Fiber, Proteine, Weight, Calories, Type, Date, UserId) " +
                               "VALUES(@name, @fat, @carbs, @sugar, @fiber, @proteine, @weight, @calories, @type, @date,@userid)";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@name", voeding.Name);
                command.Parameters.AddWithValue("@fat", voeding.Fat);
                command.Parameters.AddWithValue("@carbs", voeding.Carbohydrates);
                command.Parameters.AddWithValue("@sugar", voeding.Sugar);
                command.Parameters.AddWithValue("@fiber", voeding.Fiber);
                command.Parameters.AddWithValue("@proteine", voeding.Proteine);
                command.Parameters.AddWithValue("@weight", voeding.Weight);
                command.Parameters.AddWithValue("@calories", voeding.Calories);
                command.Parameters.AddWithValue("@type", voeding.Type);
                command.Parameters.AddWithValue("@date", voeding.Date);
                command.Parameters.AddWithValue("@userid", userid);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de voeding niet toevoegen aan de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Haalt alle voedingen op van een specifieke gebruiker.
        /// </summary>
        /// <param name="userid">Id van de gebruiker.</param>
        /// <returns>Lijst met alle voedingen van de gebruiker.</returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public List<VoedingDTO> GetAllVoedingFrUser(int userid)
        {
            try 
            {
                List<VoedingDTO> voedingen = new();
                db.MakeConnection();
                string query = "SELECT * FROM Voeding WHERE UserId = @userid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                voedingen = AddVoedingenToList(command);
                db.EndConnection();
                return voedingen;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de voeding niet toevoegen aan de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Update de voeding met de nieuwe waardes in de database.
        /// </summary>
        /// <param name="dto">De voeding die je wilt wijzigen.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void UpdateVoeding(VoedingDTO dto)
        {
            try
            {
                db.MakeConnection();
                string query = "UPDATE Voeding SET Name = @name, Fat = @fat, Carbohydrates = @carbs, Sugar = @sugar, Fiber = @fiber, " +
                               "Proteine = @proteine, Weight = @weight, Calories = @calories, Type = @type, Date = @date WHERE Id = @id";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@name", dto.Name);
                command.Parameters.AddWithValue("@fat", dto.Fat);
                command.Parameters.AddWithValue("@carbs", dto.Carbohydrates);
                command.Parameters.AddWithValue("@sugar", dto.Sugar);
                command.Parameters.AddWithValue("@fiber", dto.Fiber);
                command.Parameters.AddWithValue("@proteine", dto.Proteine);
                command.Parameters.AddWithValue("@weight", dto.Weight);
                command.Parameters.AddWithValue("@calories", dto.Calories);
                command.Parameters.AddWithValue("@type", dto.Type);
                command.Parameters.AddWithValue("@date", dto.Date);
                command.Parameters.AddWithValue("@id", dto.Id);
                command.ExecuteNonQuery();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de voeding niet toevoegen aan de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Verwijdert de voeding aan de hand van de voedingsid.
        /// </summary>
        /// <param name="id">De id van de voeding die je wilt verwijderen.</param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void DeleteVoeding(int id)
        {
            try
            {
                db.MakeConnection();
                string query = "DELETE FROM Voeding WHERE Id = @id";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                db.EndConnection();
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de voeding niet verwijderen uit de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Haalt de voeding op aan de hand van de voedingsid.
        /// </summary>
        /// <param name="id">Id van de voeding.</param>
        /// <returns>Een VoedingDTO op basis van een id.</returns>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public VoedingDTO GetById(int id)
        {
            try
            {
                VoedingDTO dto = new();  
                db.MakeConnection();
                string query = "SELECT * FROM Voeding WHERE Id = @id";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dto = ReadDTO(reader);
                }
                db.EndConnection();
                return dto;
            }
            catch (InvalidOperationException exc)
            {
                throw new TemporaryDalException("Kon de voeding niet verwijderen uit de database, controleer uw verbinding.", exc.Message);
            }
            catch (Exception exc)
            {
                throw new PermanentDalException("Fout in de applicatie,neem contact op met onze hulpdesk via twitter", exc.Message);
            }
        }
        /// <summary>
        /// Voegt de gelezen voeding toe aan de lijst.
        /// </summary>
        /// <param name="command"></param>
        private List<VoedingDTO> AddVoedingenToList(SqlCommand command)
        {
            List<VoedingDTO> list = new();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadDTO(reader));
            }
            return list;
        }
        //Maakt een dto met de gegevens uit een reader.
        private VoedingDTO ReadDTO(SqlDataReader reader)
        {
            return new VoedingDTO(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["Fat"]), Convert.ToDouble(reader["Carbohydrates"]),
                                  Convert.ToDouble(reader["Sugar"]), Convert.ToDouble(reader["Fiber"]), Convert.ToDouble(reader["Proteine"]),
                                  Convert.ToDouble(reader["Calories"]), Convert.ToDouble(reader["Weight"]), reader["Type"].ToString(), Convert.ToDateTime(reader["Date"]));
        }



    }
}
