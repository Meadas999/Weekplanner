using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class UserTeamVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TeamVM> UserTeams { get; set; }
        public List<TeamVM> AllTeams { get; set; }

        public UserTeamVM()
        {

        }

        public UserTeamVM(int id, string firstName, string lastName, List<TeamVM> teams)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserTeams = teams;
        }

        public UserTeamVM(User user)
        {
            Id = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
