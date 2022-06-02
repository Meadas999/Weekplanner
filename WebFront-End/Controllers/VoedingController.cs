using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class VoedingController : Controller
    {
        UserContainer UC = new(new UserMSSQLDAL());
        VoedingContainer VC = new(new VoedingMSSQLDAL());
        public IActionResult Index()
        {
            int userid = HttpContext.Session.GetInt32("UserId").Value;
            UserVoedingVM user = new(UC.FindUserById(userid), VC.GetAllVoedingFrUser(userid));
            return View(user);
        }
    }
}
