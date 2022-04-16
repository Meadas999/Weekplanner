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
        public IActionResult Return(int id,string name, string type, string description, DateTime date)
        {
            Activiteit activity = new(id,name, type, description, date);
            AC.UpdateActivityWithDayOnly(activity, HttpContext.Session.GetInt32("UserId").Value);
            return RedirectToAction("Index", "Home");
        }
        
    }
}
