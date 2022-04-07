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
        
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Reminder { get; set; }
        public DateTime Date { get; set; }

        // Later toevoegen of verwijderen:
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        //public int Id ;
        //public Color Color { get; set; }


        //public Activiteit(int id, string type, string name, string description, DateTime reminder, DateTime datetime)
        //{
        //    this.Id = id;
        //    this.Type = type;
        //    this.Name = name;
        //    this.Description = description;
        //    this.Reminder = reminder;
        //    this.DateTime = datetime;
        //}

        //public Activiteit(int id,string type, string name, string description, DateTime datetime)
        //{
        //    this.Id = id;
        //    this.Type = type;
        //    this.Name = name;
        //    this.Description = description;
        //    this.DateTime = datetime;
        //}

        public Activiteit(string type, string name, string description, DateTime datetime)
        {
         
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }

        public Activiteit(ActiviteitDTO dto)
        {
            this.Type = dto.Type;
            this.Name = dto.Name;
            this.Description = dto.Description;
            this.Date = dto.Date;
        }

        public ActiviteitDTO ToDTO()
        {
            return new ActiviteitDTO(this.Type, this.Name, this.Description, this.Date);
        }


        // Make a animals interface with the following methods: Poop, Eat, Shit, Fart
        



        //public void ChangeActivityName(string name)
        //{
        //    this.Name = name;
        //    // TODO: Database veranderen
        //}
        //public void ChangeActivityType(string type)
        //{
        //    this.Type = type;
        //    // TODO: Database veranderen
        //}
        //public void ChangeActivityDescription(string description)
        //{
        //    this.Description = description;
        //    // TODO: Database veranderen
        //}
        //public void ChangeActivityReminder(DateTime reminder)
        //{
        //    this.Reminder = reminder;
        //    // TODO: Database veranderen
        //}
        //public void ChangeActivityTime(DateTime time)
        //{
        //    this.Date = time;
        //    // TODO: Database veranderen
        //}
        //public void ChangeActivityColor(Color color)
        //{
        //    this.Color = color;
        //    // TODO: Database veranderen
        //}

        public override string ToString()
        {
            return $"{Type}/{Name}/{Description}/{Date.ToString()}/";
        }

    }
 
}

