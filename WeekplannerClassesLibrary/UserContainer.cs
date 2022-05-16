using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class UserContainer
    {
        private readonly IUserContainer container;

        public UserContainer(IUserContainer container)
        {
            this.container = container;
        }
        public void AddUser(User user, string password)
        {
            container.AddUser(user.ToDTO(), password);
        }
        public bool CheckForUsedEmail(string email)
        {
            return container.CheckForUsedEmail(email);
        }
        public User FindUserByEmailAndPassword(string email, string password)
        {
            if (container.FindUserByEmailAndPassword(email, password) != null)
            {
                UserDTO dto = container.FindUserByEmailAndPassword(email, password);
                return new User(dto);
            }
            else
            {
                return null;
            }
        }
        public User FindUserByEmail(string email)
        {
            UserDTO dto = container.FindUserByEmail(email);
            return new User(dto);
        }

        public User FindUserById(int id)
        {
            UserDTO dto = container.FindUserById(id);
            return new User(dto);
        }
    }
}
