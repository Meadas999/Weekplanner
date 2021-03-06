using DALmssqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;


namespace WebFront_End.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private readonly IConfiguration _configuration;
        private UserContainer UC;
        private ActiviteitContainer AC;
        public LogInController(ILogger<LogInController> logger, IConfiguration ic)
        {
            _configuration = ic;
            _logger = logger;
            AC = new(new ActiviteitenMSSQLDAL(_configuration["db:connectionstring"]));
            UC = new(new UserMSSQLDAL(_configuration["db:connectionstring"]));
        }
        [HttpGet]
        public ActionResult Index()
        {
            UserLogInVM vm = new();
            vm.Retry = false;
            return View(vm);
        }
        //TODO: Use Uservm instead of strings as parameters.
        //TODO: Full name van Uservm in session. 

        //Haalt de login page op.
        [HttpPost]
        public IActionResult Index(UserLogInVM vm)
        {
            try
            {
                User us = UC.FindUserByEmailAndPassword(vm.Email, vm.Password);
                if (us != null)
                {
                    UserVM u = new(us);
                    HttpContext.Session.SetInt32("UserId", u.UserId);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    UserLogInVM newvm = new();
                    newvm.Retry = true;
                    return View(newvm);
                }
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
