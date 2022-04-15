using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public int Length { get; set; }
        public bool Retry { get; set; }

        public List<ActiviteitVM> activiteiten { get; set; }

        public UserVM(string firstname, string lastname, string email, DateTime birthdate,  double weight, int length)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            BirthDate = birthdate;
            Weight = weight;
            Length = length;
        }
        public UserVM(User user)
        {
            this.UserId = user.UserId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.BirthDate = user.BirthDate;
            this.Weight = user.Weight;
            this.Length = user.Length;
        }

        public UserVM()
        {
            
        }

        public User ToUser()
        {
            return new User(this.UserId, this.FirstName, this.LastName, this.Email, this.BirthDate, this.Weight, this.Length);
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}