using WeekplannerClassesLibrary;

namespace WebFront_End.Models
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamUsersVM> Members { get; set; } = new();
        public int MaxMembers { get; set; }
        public TeamVM()
        {

        }

        public TeamVM(int id, string name, List<TeamUsersVM> members, int maxMembers)
        {
            Id = id;
            Name = name;
            Members = members;
            MaxMembers = maxMembers;
        }

        public TeamVM(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            Members = team.Members.Select(x => new TeamUsersVM(x)).ToList();
            MaxMembers = team.MaxMembers;
        }
    }
}
