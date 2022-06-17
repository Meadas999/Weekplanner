using System.ComponentModel.DataAnnotations;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class ActiviteitVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Enter a valid type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "The name of the activity is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "The date is required.")]
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
