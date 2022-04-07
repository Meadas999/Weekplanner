using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IUserContainer
    {
        public string GetEmail(UserDTO user);
        public string GetFullName(UserDTO user);
        public string GetFirstName(UserDTO user);
        public string GetLastName(UserDTO user);
        public string GetPassword(UserDTO user);
        public DateTime GetBirthDate(UserDTO user);
        public double GetWeight(UserDTO user);
        public int GetLength(UserDTO user);
        public void AddUser(UserDTO user);
        public bool CheckForUsedEmail(string email);
        public UserDTO FindUserByEmailAndPassword(string email, string password);
        public UserDTO FindUserByEmail(string email);
        


    }
}
