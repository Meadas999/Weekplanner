using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class ActivityController : Controller
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ActiviteitContainer AC;
        public ActivityController(ILogger<ActivityController> logger, IConfiguration ic)
        {
            _configuration = ic;
            _logger = logger;
            AC = new(
                         new ActiviteitenMSSQLDAL(_configuration["db:connectionstring"]));

        }
        // Geeft een view door waar een nieuwe acitviteit aangemaakt kan worden.
        [HttpGet]
        public IActionResult Index()
        {
            ActiviteitVM vm = new();
            return View(vm);
        }
        /// <summary>
        /// Maakt een Activiteit aan. Als dit niet lukt wordt de juiste exceptie opgevangen, en deze stuurt de gebruiker dan door naar de juist errorview.
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(ActiviteitVM vm)
        {
            try
            {
                Activiteit act = vm.ToActiviteit();
                AC.AddActivityToUserWTTime(HttpContext.Session.GetInt32("UserId").Value, act);
                return RedirectToAction("Index", "Home");
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
