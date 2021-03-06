using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public class VoedingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Sugar { get; set; }
        public double Fiber { get; set; }
        public double Proteine { get; set; }
        public double Calories { get; set; }
        public double Weight{ get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        

        public VoedingDTO()
        {
        }
        public VoedingDTO(int id, string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, DateTime date)
        {
            Id = id;
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
        }
        public VoedingDTO(string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, DateTime date)
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
        }
    }
}
