using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using System;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class EditController : Controller
    {
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public IActionResult Index(int id)
        {
            ActiviteitVM activiteit = new(AC.GetActivityById(id));
            return View(activiteit);
        }
        public IActionResult Return(ActiviteitVM vm)
        {
            Activiteit activity = vm.ToActiviteit();
            AC.UpdateActivityWithDayOnly(activity, HttpContext.Session.GetInt32("UserId").Value);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
