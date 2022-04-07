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
        public string GetEmail(User user)
        {
            return container.GetEmail(user.ToDTO());
        }

        public string GetFullName(User user)
        {
            return $"{container.GetFirstName(user.ToDTO())}  {container.GetLastName(user.ToDTO())}";
        }

        public string GetFirstName(User user)
        {
            return container.GetFirstName(user.ToDTO());
        }

        public string GetLastName(User user)
        {
            return container.GetLastName(user.ToDTO());
        }

        public string GetPassword(User user)
        {
            return container.GetPassword(user.ToDTO());
        }

        public DateTime GetBirthDate(User user)
        {
            return container.GetBirthDate(user.ToDTO());
        }
        public double GetWeight(User user)
        {

            return container.GetWeight(user.ToDTO());
        }
        public int GetLength(User user)
        {
            return container.GetLength(user.ToDTO());
        }

        public void AddUser(UserDTO user)
        {
            container.AddUser(user);
        }
        public bool CheckForUsedEmail(string email)
        {
            return container.CheckForUsedEmail(email);
        }
        public User FindUserByEmailAndPassword(string email, string password)
        {
            UserDTO dto = container.FindUserByEmailAndPassword(email, password);
            return new User(dto);
        }
        public User FindUserByEmail(string email)
        {
            UserDTO dto = container.FindUserByEmail(email);
            return new User(dto);
        }
    }
}
