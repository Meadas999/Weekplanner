﻿using DALmssqlServer;
using Microsoft.AspNetCore.Mvc;
using WebFront_End.Models;
using WeekplannerClassesLibrary;

namespace WebFront_End.Controllers
{
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        UserContainer UC = new(new UserMSSQLDAL());
        TeamContainer TC = new(new TeamMSSQLDAL());

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
        }
        //Haalt de homepage op van teams.
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                int userid = HttpContext.Session.GetInt32("UserId").Value;
                UserTeamVM user = new(UC.FindUserById(userid));
                user.UserTeams = new(TC.GetTeamsFromUser(userid).Select(x => new TeamVM(x)).ToList());
                user.AllTeams = new(TC.GetAllTeams().Select(x => new TeamVM(x)).ToList());
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
        //Voegt een gebruiker toe aan een team.
        [HttpPost]
        public IActionResult JoinTeam(int teamid, int userid)
        {
            try
            {
                TC.AddUserToTeam(userid, teamid);
                return RedirectToAction("Index", "Team");
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
        //Verwijdert een gebruiker uit een team.
        [HttpPost]
        public IActionResult LeaveTeam(int teamid, int userid)
        {
            try
            {
                TC.RemoveUserFromTeam(userid, teamid);
                return RedirectToAction("Index", "Team");
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
