using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class TeamUsersVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public TeamUsersVM()
        {

        }

        public TeamUsersVM(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public TeamUsersVM(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
