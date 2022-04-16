﻿using DALmssqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;


namespace WebFront_End.Controllers
{
    public class LogInController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private UserContainer UC = new(new UserMSSQLDAL());
        private ActiviteitContainer AC = new(new ActiviteitenMSSQLDAL());
        public LogInController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            UserModel_LG vm = new();
            vm.Retry = false;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            User us = UC.FindUserByEmailAndPassword(email, password);
            if (us != null)
            {
                UserVM u = new(us);
                HttpContext.Session.SetInt32("UserId", u.UserId);
                return RedirectToAction("Index", "Home", u);
            }
            else
            {
                UserVM vm = new();
                vm.Retry = true;
                return View(vm);
            }
        }
    }
}
