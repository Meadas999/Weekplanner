using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class User : UserBase
    {
        public double Weight { get; set; }
        public int Length { get; set; }
        public List<Activiteit> activitys = new List<Activiteit>();
        

        public User(string firstname, string lastname, string email, string password, DateTime birthdate, double weight, int length) 
                    : base(firstname, lastname, email, password, birthdate)
        {
            this.Weight = weight;
            this.Length = length;
        }
        public User(UserDTO userDTO) : base(userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.Password, userDTO.BirthDate)
        {
            this.Weight = userDTO.Weight;
            this.Length = userDTO.Length;
        }
        //public void MakeActivity(string type, string name, string description, DateTime reminder, DateTime time, Color color)
        //{
        //    var x = new Activiteit(type, name, description, reminder, time, color);
        //    activitys.Add(x);

        //}

        public UserDTO ToDTO()
        {
            return new UserDTO(this.FirstName, this.LastName, this.Email, this.Password, this.BirthDate, this.Weight, this.Length);
        }

        
        


        public void UpdateInfo(double? changedweight = null, int? changedlenght = null, DateTime? changedage = null)
        {
            this.Weight = changedweight.GetValueOrDefault(this.Weight);
            this.Length = changedlenght.GetValueOrDefault(this.Length);
            this.BirthDate = changedage.GetValueOrDefault(this.BirthDate);
        }

        //public override string ToString()
        //{
        //    return $"";
        //}



    }
}
