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

        public Voeding()
        {

        }
        public Voeding(int id, string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, double examplevalue)
        {
            Id = id;
            Name = name;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Sugar = sugar;
            Fiber = fiber;
            Proteine = proteine;
            Calories = calories;
            
        }
        public Voeding(string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, double examplevalue)
        {
            Name = name;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Sugar = sugar;
            Fiber = fiber;
            Proteine = proteine;
            Calories = calories;
            
        }

        public VoedingDTO ToDTO()
        {
            return new VoedingDTO(Id, Name, Fat, Carbohydrates, Sugar, Fiber, Proteine, Calories);
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
