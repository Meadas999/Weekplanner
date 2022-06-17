using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private readonly IConfiguration _configuration;
        private UserContainer UC;
        public RegisterController(ILogger<LogInController> logger, IConfiguration ic)
        {
            _configuration = ic;
            _logger = logger;
            UC = new(new UserMSSQLDAL(_configuration["db:connectionstring"]));
        }
        //Haalt de view op voor het registreren van een nieuwe gebruiker
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                
                return View();
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
        //Registreert een nieuwe gebruiker
        [HttpPost]
        public IActionResult Register(RegisterVM vm)
        {
            try
            {
                UC.AddUser(vm.ToUser(), vm.Password);
                return RedirectToAction("Index", "LogIn");
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
