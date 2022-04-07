using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public double Weight { get; set; }
        public int Length { get; set; }

        public UserDTO(string firstname, string lastname, string email, string password, DateTime birthdate,  double weight, int length)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            BirthDate = birthdate;
            Password = password;
            Weight = weight;
            Length = length;
        }
       
    }
}