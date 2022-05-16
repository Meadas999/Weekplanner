﻿using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<LogInController> _logger;
        private UserContainer UC = new(new UserMSSQLDAL());        
        public RegisterController(ILogger<LogInController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(RegisterVM vm)
        {
            UC.AddUser(vm.ToUser(), vm.Password);
            return RedirectToAction("Index", "LogIn");
        }
    }
}
