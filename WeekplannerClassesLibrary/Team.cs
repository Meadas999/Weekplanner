using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; } = new();
        public int MaxMembers { get; set; }

        public Team()
        {

        }
        public Team(int id, string name, List<User> members, int maxMembers)
        {
            Id = id;
            Name = name;
            Members = members;
            MaxMembers = maxMembers;
        }
        
        public Team(string name, List<User> members, int maxMembers)
        {
            Name = name;
            Members = members;
            MaxMembers = maxMembers;
        }
        
        public Team(TeamDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Members = dto.Members.Select(x => new User(x)).ToList();
            MaxMembers = dto.MaxMembers;
        }

        public TeamDTO ToDTO()
        {
            return new TeamDTO(this.Id, this.Name, this.MaxMembers);
        }




    }
}
