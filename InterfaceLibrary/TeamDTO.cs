using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDTO> Members { get; set; } = new();
        public int MaxMembers { get; set; }

        public TeamDTO()
        {
            
        }

        public TeamDTO(int id, string name,int maxmembers)
        {
            Id = id;
            Name = name;
            MaxMembers = maxmembers;
        }

        public TeamDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
