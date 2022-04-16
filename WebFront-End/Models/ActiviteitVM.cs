using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class ActiviteitVM
    {
        public int ID { get; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public ActiviteitVM()
        {
            
        }
        

        public ActiviteitVM(Activiteit activiteit)
        {
            ID = activiteit.Id;
            Type = activiteit.Type;
            Name = activiteit.Name;
            Description = activiteit.Description;
            Date = activiteit.Date;
        }
        
        public Activiteit ToActiviteit()
        {
            return new Activiteit(ID, Type, Name, Description, Date);
        }

        public override string ToString()
        {
            return $"{Type} {Name} {Description} {Date}";
        }
    }
}
