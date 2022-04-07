using System.Drawing;

namespace InterfaceLibrary
{
    public class ActiviteitDTO
    {
        public int Id;
        public string Type;
        public string Name;
        public string Description;
        public DateTime Reminder;
        public DateTime Date;
        
        //later toevoegen:
        //public DateTime StartTime;
        //public DateTime EndTime;
        
        //public Color Color;

        //public ActiviteitDTO(int id, string type, string name, string description, DateTime reminder, DateTime datetime)
        //{
        //    this.Id = id;
        //    this.Type = type;
        //    this.Name = name;
        //    this.Description = description;
        //    this.Reminder = reminder;
        //    this.DateTime = datetime;
        //}

        //public ActiviteitDTO(int id, string type, string name, string description, DateTime datetime)
        //{
        //    this.Id = id;
        //    this.Type = type;
        //    this.Name = name;
        //    this.Description = description;
        //    this.DateTime = datetime;
        //}

        public ActiviteitDTO(string type, string name, string description, DateTime datetime)
        {

            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }

    }
}