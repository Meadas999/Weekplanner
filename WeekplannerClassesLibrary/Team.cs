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

        public Team()
        {

        }
        public Team(int id, string name)
        {
            Id = id;
            Name = name;
        }
        


    }
}
