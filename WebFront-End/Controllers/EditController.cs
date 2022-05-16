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
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public EditController(ILogger<EditController> logger)
        {
            _logger = logger;
        }
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
