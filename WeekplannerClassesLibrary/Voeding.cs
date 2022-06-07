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
        /// <summary>
        /// Instantieert een Voeding met lege properties.
        /// </summary>
        public Voeding()
        {

        }
        /// <summary>
        /// Instantieert een voeding met de gegeven parameters.
        /// </summary>
        /// <param name="id">Id van de voeding.</param>
        /// <param name="name">Naam van de voeding.</param>
        /// <param name="fat">Aantal vet van de voeding.</param>
        /// <param name="carbohydrates">Aantal carbs van de voeding.</param>
        /// <param name="sugar">Aantal suiker in de voeding</param>
        /// <param name="fiber">Aantal Vezels in de voeding.</param>
        /// <param name="proteine"></param>
        /// <param name="calories"></param>
        /// <param name="weight"></param>
        /// <param name="type"></param>
        /// <param name="examplevalue"></param>
        /// <param name="date"></param>
        public Voeding(int id, string name, double fat, double carbohydrates, double sugar, double fiber, double proteine, double calories, double weight, string type, double examplevalue, DateTime date)
        {
            double deelsom = weight / examplevalue;
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
            double deelsom =  weight / examplevalue;
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
