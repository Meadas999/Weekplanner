using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InterfaceLibrary
{
    public class UserDTO
    {
        
        
        public int Userid { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public int Length { get; set; }


        public UserDTO(int userid,string firstname, string lastname, string email,
            DateTime birthdate,  double weight, int length)
        {
            Userid = userid;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            BirthDate = birthdate;
            Weight = weight;
            Length = length;
        }
    }
}