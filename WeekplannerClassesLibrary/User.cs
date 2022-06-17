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
        public List<Activiteit> activitys { get; set; } = new();
        public List<Voeding> Voedingen { get; set; } = new();
        public List<Team> teams { get; set; } = new();
        public Team Team { get; set; } = new();
        public double BMI { get { return this.Weight / (this.Length * this.Length); } set { BMI = value; } }
        
        public User(int userid, string firstname, string lastname, string email, DateTime birthdate, double weight, int length)
                    : base(userid, firstname, lastname, email, birthdate)
        {
            this.Weight = weight;
            this.Length = length;

        }
        public User(UserDTO userDTO) : base(userDTO.Id, userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.BirthDate)
        {
            this.Weight = userDTO.Weight;
            this.Length = userDTO.Length;
        }

        public User(string firstname, string lastname) : base(firstname, lastname)
        {
            FirstName = firstname;
            LastName = lastname;
            
        }
        public User(string firstname, string lastname, string email, DateTime birthdate, double weight, int length)
                    : base(firstname, lastname, email, birthdate)
        {
            this.Weight = weight;
            this.Length = length;
        }
        public UserDTO ToDTO()
        {
            return new UserDTO(this.UserId, this.FirstName, this.LastName, this.Email, this.BirthDate, this.Weight, this.Length);
        }
    }
}
