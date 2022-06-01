using InterfaceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekplannerClassesLibrary
{
    public class TeamContainer
    {
        private readonly ITeamContainer Container;

        public TeamContainer(ITeamContainer container)
        {
            Container = container;
        }

        public List<Team> GetTeamsFromUser(int userid)
        {
            List<Team> teams = Container.GetTeamsFromUser(userid).Select(x => new Team(x)).ToList();
            return teams;
        }
        public void AddUserToTeam(int userid, int teamid)
        {
            Container.AddUserToTeam(userid, teamid);
        }
        public List<Team> GetAllTeams()
        {
            return Container.GetAllTeams().Select(x => new Team(x)).ToList();
        }

        public void RemoveUserFromTeam(int userid, int teamid)
        {
            Container.RemoveUserFromTeam(userid,teamid);
        }
    }
}
