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

        //TODO: ADD A Start and End time
        // also if there is enough time add reminder time


        public Activiteit(int id, string type, string name, string description, DateTime datetime)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }
        public Activiteit(string type, string name, string description, DateTime datetime)
        {
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }

        public Activiteit(ActiviteitDTO dto)
        {
            this.Id = dto.Id;
            this.Type = dto.Type;
            this.Name = dto.Name;
            this.Description = dto.Description;
            this.Date = dto.Date;
        }
        public ActiviteitDTO ToDTO()
        {
            return new ActiviteitDTO(this.Id,this.Type, this.Name, this.Description, this.Date);
        }

        public override string ToString()
        {
            return $"{Type}/{Name}/{Description}/{Date.ToString()}/";
        }

    }
 
}

