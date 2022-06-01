using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class TeamController : Controller
    {
        UserContainer UC = new(new UserMSSQLDAL());
        TeamContainer TC = new(new TeamMSSQLDAL());

        public IActionResult Index()
        {
            int userid = HttpContext.Session.GetInt32("UserId").Value;
            UserTeamVM user = new(UC.FindUserById(userid));
            user.UserTeams = new(TC.GetTeamsFromUser(userid).Select(x => new TeamVM(x)).ToList());
            user.AllTeams = new(TC.GetAllTeams().Select(x => new TeamVM(x)).ToList());
            return View(user);
        }
    }
}
