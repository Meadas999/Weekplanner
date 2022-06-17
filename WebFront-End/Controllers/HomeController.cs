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
        private readonly IConfiguration _configuration;
        private UserContainer UC;
        private ActiviteitContainer AC;
        public HomeController(ILogger<HomeController> logger, IConfiguration ic)
        {
            _configuration = ic;
            _logger = logger;
            AC = new(new ActiviteitenMSSQLDAL(_configuration["db:connectionstring"]));
            UC = new(new UserMSSQLDAL(_configuration["db:connectionstring"]));
        }
        //Haalt de homepage op van de gebruiker.
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetInt32("UserId").Value != -1)
                {
                    int? id = HttpContext.Session.GetInt32("UserId");
                    if (id == null) return RedirectToAction("Login", "User");
                    UserVM user = new(UC.FindUserById(id.Value));
                    user.activiteiten = AC.GetAllEvents(user.UserId).Select(x => new ActiviteitVM(x)).ToList();
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Logout", "LogIn");
                }
            }
            catch (TemporaryDalException exc)
            {
                _logger.LogError(exc, exc.Message);
                return View("TemporaryError", exc);
            }
            catch (PermanentDalException exc)
            {
                _logger.LogError(exc, exc.Message);
                return View("PermanentError", exc);
            }
        }
        
        //Verwijdert een activiteit.
       [HttpPost]
        public IActionResult DeleteActivity(int id)
        {
            try
            {
                AC.DeleteActivityById(id);
                return RedirectToAction("Index");
            }
            catch (TemporaryDalException exc)
            {
                _logger.LogError(exc, exc.Message);
                return View("TemporaryError", exc);
            }
            catch (PermanentDalException exc)
            {
                //TODO: make view with feedback
                _logger.LogError(exc, exc.Message);
                return View("PermanentError", exc);
            }
        }
    }
}