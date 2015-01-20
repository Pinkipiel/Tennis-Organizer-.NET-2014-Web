using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TennisOrganizer.MVC.Models;
using TennisOrganizer.MVC.ViewModels;

namespace TennisOrganizer.MVC.Controllers
{
	[Authorize]
    public class MainController : Controller
    {
        //
        // GET: /Main/
		TennisOrganizerContext ctx = new TennisOrganizerContext();
		int LoggedInPlayerId = -1;

		[Authorize]
		public ActionResult MainTest()
        {
			if (LoggedInPlayerId == -1)
			{
				String login = (String)TempData["RegisteredLogin"];
				LoggedInPlayerId = ctx.Players.FirstOrDefault<Player>(p => p.Account.Login == login).AccountId;
			}
            return View();
        }
		[Authorize]
		public ActionResult Ranking()
		{
			var stats = Player.GetPlayersStats();
			return View(stats);
		}

		public ActionResult Statistics()
		{
			Player player = ctx.Players.FirstOrDefault<Player>(p => p.AccountId == LoggedInPlayerId);
			var stats = new PlayerStats(player);
			return View(stats);
		}

		[Authorize]
		public ActionResult Challenge()
		{
			//zmienić
			return View();
		}
		[Authorize]
		public ActionResult Training()
		{
			return View();
		}
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
    }
}
