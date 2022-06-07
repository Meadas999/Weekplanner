using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLibrary
{
    public interface ITeamContainer
    {
        public List<TeamDTO> GetTeamsFromUser(int userid);
        public void AddUserToTeam(int userid, int teamid);
        public List<TeamDTO> GetAllTeams();
        public void RemoveUserFromTeam(int userid, int teamid);
    }
}
