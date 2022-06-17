using System.ComponentModel.DataAnnotations;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class VoedingVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fat can not be empty.")]
        public double Fat { get; set; }
        [Required(ErrorMessage = "Carbohydrates can not be empty.")]
        public double Carbohydrates { get; set; }
        [Required(ErrorMessage = "Sugar can not be empty.")]
        public double Sugar { get; set; }
        [Required(ErrorMessage = "Fiber can not be empty.")]
        public double Fiber { get; set; }
        [Required(ErrorMessage = "Proteine can not be empty.")]
        public double Proteine { get; set; }
        [Required(ErrorMessage = "Calories can not be empty.")]
        public double Calories { get; set; }
        [Required(ErrorMessage = "Weight can not be empty.")]
        public double Weight { get; set; }
        [Required(ErrorMessage = "Type can not be empty.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Date can not be empty.")]
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
