using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class VoedingController : Controller
    {
        private readonly ILogger<VoedingController> _logger;
        private readonly IConfiguration _configuration;
        UserContainer UC;
        VoedingContainer VC;
        public VoedingController(ILogger<VoedingController> logger)
        {
            _logger = logger;
            UC = new(new UserMSSQLDAL(_configuration["db:connectionstring"]));
            VC = new(new VoedingMSSQLDAL(_configuration["db:connectionstring"]))
        }
        //Haalt de homepage view op van de voeding pagina
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                int userid = HttpContext.Session.GetInt32("UserId").Value;
                UserVoedingVM user = new(UC.FindUserById(userid), VC.GetAllVoedingFrUser(userid));
                return View(user);
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
        //Haalt de voeding view op waar de voeding wordt gewijzigd.
        [HttpPost]
        public IActionResult Edit(int id)
        {
            try
            {
                VoedingVM vm = new(VC.GetById(id));
                return View("Edit", vm);
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
        //Wijzigt de voeding en stuurt de gebruiker terug naar de homepage van voeding.
        [HttpPost]
        public IActionResult ReturnEdit(VoedingVM vm)
        {
            try
            {
                VC.UpdateVoeding(vm.ToVoeding());
                return RedirectToAction("Index", "Voeding");
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
        [HttpPost]
        public IActionResult Create()
        {
            try
            {
                VoedingVM vm = new();
                return View("Create", vm);
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
        [HttpPost]
        public IActionResult ReturnCreate(VoedingVM vm)
        {
            try
            {
                int userid = HttpContext.Session.GetInt32("UserId").Value;
                VC.AddVoeding(vm.ToVoeding(), userid);
                return RedirectToAction("Index", "Voeding");
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
        [HttpPost]        
        public IActionResult Delete(int id)
        {
            try
            {
                VC.DeleteVoeding(id);
                return RedirectToAction("Index", "Voeding");
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
