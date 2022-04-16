using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class ActivityController : Controller
    {
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public IActionResult Index()
        {
            ActiviteitVM vm= new();
            return View(vm);
        }

        public IActionResult Create(string name, string type, string description, DateTime date)
        {
            Activiteit act = new(name, type, description, date);
            AC.AddActivityToUserWTTime(HttpContext.Session.GetInt32("UserId").Value, act);
            return RedirectToAction("Index","Home");
        }
    }
}
