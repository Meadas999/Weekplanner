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

        public ActiviteitDTO(int id,string type, string name, string description, DateTime datetime)
        {
            this.Id = id;
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }
        public ActiviteitDTO(string type, string name, string description, DateTime datetime)
        {
            this.Type = type;
            this.Name = name;
            this.Description = description;
            this.Date = datetime;
        }
    }
}