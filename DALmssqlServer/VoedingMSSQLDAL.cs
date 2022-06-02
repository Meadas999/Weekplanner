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
       Database db = new();
        /// <summary>
        /// Voegt een nieuwe voeding toe aan de database
        /// </summary>
        /// <param name="voeding"></param>
        /// <param name="userid"></param>
        /// <exception cref="TemporaryDalException"></exception>
        /// <exception cref="PermanentDalException"></exception>
        public void AddVoeding(VoedingDTO voeding, int userid)
        {
            
            try
            {
                db.MakeConnection();
                string query = "INSERT INTO Voeding(Name, Fat, Carbohydrates, Sugar, Fiber, Proteine, Weight, Calories, Type, UserId) " +
                               "VALUES(@name, @fat, @carbs, @sugar, @fiber, @proteine, @weight, @calories, @type, @userid)";
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

        public List<VoedingDTO> GetAllVoedingFrUser(int userid)
        {
            try 
            {
                List<VoedingDTO> voedingen = new();
                db.MakeConnection();
                string query = "SELECT * FROM Voeding WHERE UserId = @userid";
                SqlCommand command = new(query, db.conn);
                command.Parameters.AddWithValue("@userid", userid);
                AddVoedingenToList(voedingen, command);
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
        //Update de voeding met de nieuwe waardes in de database
        public void UpdateVoeding(VoedingDTO dto)
        {
            try
            {
                db.MakeConnection();
                string query = "UPDATE Voeding SET Name = @name, Fat = @fat, Carbohydrates = @carbs, Sugar = @sugar, Fiber = @fiber, " +
                               "Proteine = @proteine, Weight = @weight, Calories = @calories, Type = @type WHERE Id = @id";
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
        //Verwijdert de voeding aan de hand van de voedingsid.
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
        //Voegt de gelezen voeding toe aan de lijst.
        private void AddVoedingenToList(List<VoedingDTO> list, SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadDTO(reader));
            }
        }
        //Maakt een dto met de gegevens uit de query.
        private VoedingDTO ReadDTO(SqlDataReader reader)
        {
            return new VoedingDTO(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToDouble(reader["Fat"]), Convert.ToDouble(reader["Carbohydrates"]),
                                  Convert.ToDouble(reader["Sugar"]), Convert.ToDouble(reader["Fiber"]), Convert.ToDouble(reader["Proteine"]),
                                  Convert.ToDouble(reader["Calories"]), Convert.ToDouble(reader["Weight"]), reader["Type"].ToString(), Convert.ToDateTime(reader["Date"]));
        }



    }
}
