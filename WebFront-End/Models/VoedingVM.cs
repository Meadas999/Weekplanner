using System.ComponentModel.DataAnnotations;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class VoedingVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Fat { get; set; }
        [Required]        
        public double Carbohydrates { get; set; }
        [Required]
        public double Sugar { get; set; }
        [Required]        
        public double Fiber { get; set; }
        [Required]
        public double Proteine { get; set; }
        [Required]
        public double Calories { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Examplevalue { get; set; }

        public VoedingVM()
        {

        }

        public VoedingVM(string name, double fat, double carbohydrates, double sugar, double fiber, 
                         double proteine, double calories, double weight, string type, DateTime date, double? examplevalue = null)
        {
            Name = name;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Sugar = sugar;
            Fiber = fiber;
            Proteine = proteine;
            Calories = calories;
            Weight = weight;
            Type = type;
            Date = date;
            Examplevalue = examplevalue.Value;
        }

        public VoedingVM(Voeding voeding)
        {
            Id = voeding.Id;
            Name = voeding.Name;
            Fat = voeding.Fat;
            Carbohydrates = voeding.Carbohydrates;
            Sugar = voeding.Sugar;
            Fiber = voeding.Fiber;
            Proteine = voeding.Proteine;
            Calories = voeding.Calories;
            Weight = voeding.Weight;
            Type = voeding.Type;
            Date = voeding.Date;
        }

        public Voeding ToVoeding()
        {
            return new Voeding(Id, Name, Fat, Carbohydrates, Sugar, Fiber, Proteine, Calories, Weight, Type, Examplevalue, Date);
        }
    }
}
