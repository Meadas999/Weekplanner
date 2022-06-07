using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using System;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class EditController : Controller
    {
        private readonly ILogger<EditController> _logger;
        private readonly IConfiguration _configuration;
        private ActiviteitContainer AC;
        public EditController(ILogger<EditController> logger, IConfiguration ic)
        {
            _configuration = ic;
            _logger = logger;
            AC = new(new ActiviteitenMSSQLDAL(_configuration["db:connectionstring"]));
        }
        
        //Geeft de pagina met de activiteiten die je wilt aanpassen terug.
        [HttpGet]
        public IActionResult Index(int id)
        {
            try
            {
                ActiviteitVM activiteit = new(AC.GetActivityById(id));
                return View(activiteit);
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
        //Verstuurt de nieuwe gegevens naar de database en gaat terug naar de index pagina van activiteiten.
        [HttpPost]
        public IActionResult Return(ActiviteitVM vm)
        {
            try
            {
                Activiteit activity = vm.ToActiviteit();
                AC.UpdateActivityWithDayOnly(activity, HttpContext.Session.GetInt32("UserId").Value);
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
