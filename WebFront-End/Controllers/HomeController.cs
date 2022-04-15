using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebFront_End.Models;
using WeekplannerClassesLibrary;
using Microsoft.AspNetCore.Http;

namespace WebFront_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserContainer UC = new(new UserMSSQLDAL());
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            if(id == null) return RedirectToAction("Login", "User");
            UserVM user = new(UC.FindUserById(id.Value));
            user.activiteiten = AC.GetAllEvents(user.UserId).Select(x => new ActiviteitVM(x)).ToList();
            return View(user);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}