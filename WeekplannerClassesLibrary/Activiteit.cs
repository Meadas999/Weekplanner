using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class Activiteit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

   

        /// <summary>
        /// Maakt een activiteit aan op basis van de parameters.
        /// </summary>
        /// <param name="id">Activiteitsid</param>
        /// <param name="type">Type van de activiteit</param>
        /// <param name="name">Naam van de activiteit</param>
        /// <param name="description">Beschrijving van de activiteit</param>
        /// <param name="datetime">Datum van de activiteit</param>
        public Activiteit(int id, string type, string name, string description, DateTime datetime)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }
        /// <summary>
        /// Maakt een activiteit aan op basis van de parameters.
        /// </summary>
        /// <param name="type">Type van de activiteit</param>
        /// <param name="name">Naam van de activiteit</param>
        /// <param name="description">Beschrijving van de activiteit</param>
        /// <param name="datetime">Datum van de activiteit</param>
        public Activiteit(string type, string name, string description, DateTime datetime)
        {
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }
        /// <summary>
        /// Maakt een Activiteit op basis van de activiteitsdto.
        /// </summary>
        /// <param name="dto">ActiviteitsDTO</param>
        public Activiteit(ActiviteitDTO dto)
        {
            this.Id = dto.Id;
            this.Type = dto.Type;
            this.Name = dto.Name;
            this.Description = dto.Description;
            this.Date = dto.Date;
        }
        /// <summary>
        /// Zet de activiteit om in een DTO.
        /// </summary>
        /// <returns>ActiviteitsDTO</returns>
        public ActiviteitDTO ToDTO()
        {
            return new ActiviteitDTO(this.Id,this.Type, this.Name, this.Description, this.Date);
        }
        //Override de ToString methode.
        public override string ToString()
        {
            return $"{Type}/{Name}/{Description}/{Date.ToString()}/";
        }

    }
 
}

