using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface IUserContainer
    {
        public void AddUser(UserDTO user, string password);
        public bool CheckForUsedEmail(string email);
        public UserDTO FindUserByEmailAndPassword(string email, string password);
        public UserDTO FindUserByEmail(string email);
        public UserDTO FindUserById(int id);
    }
}
