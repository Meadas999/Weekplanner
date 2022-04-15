using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class ActiviteitVM
    {
        public int ID;
        public string Type;
        public string Name;
        public string Description;
        public DateTime Date;

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
