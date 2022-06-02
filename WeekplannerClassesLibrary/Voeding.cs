using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class Voeding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Proteine { get; set; }
        public double Calories { get; set; }
        public double Weight { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }  

        public Voeding()
        {

        }
        public Voeding(int id, string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, double examplevalue, DateTime date)
        {
            double deelsom = examplevalue / weight;
            Id = id;
            Name = name;
            Fat = fat * deelsom;
            Carbohydrates = carbohydrates * deelsom;
            Sugar = sugar * deelsom;
            Fiber = fiber * deelsom;
            Proteine = proteine * deelsom;
            Calories = calories * deelsom;
            Weight = weight;
            Type = type;
            Date = date;
        }
        public Voeding(string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, double examplevalue, DateTime date)
        {
            double deelsom = examplevalue / weight;
            Name = name;
            Fat = fat * deelsom;
            Carbohydrates = carbohydrates * deelsom;
            Sugar = sugar * deelsom;
            Fiber = fiber * deelsom;
            Proteine = proteine * deelsom;
            Calories = calories * deelsom;
            Weight = weight;
            Type = type;
            Date = date;
        }
        public Voeding(VoedingDTO dto)
        { 
            Id = dto.Id;
            Name = dto.Name;
            Fat = dto.Fat;
            Carbohydrates = dto.Carbohydrates;
            Sugar = dto.Sugar;
            Fiber = dto.Fiber;
            Proteine = dto.Proteine;
            Calories = dto.Calories;
            Weight = dto.Weight;
            Type = dto.Type;
            Date = dto.Date;
        }
        public VoedingDTO ToDTO()
        {
            return new VoedingDTO(Id, Name, Fat, Carbohydrates, Sugar, Fiber, Proteine, Calories, Weight, Type, Date);
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
