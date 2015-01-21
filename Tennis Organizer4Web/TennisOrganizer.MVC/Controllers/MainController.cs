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
		//TennisOrganizerContext ctx = new TennisOrganizerContext();
		int LoggedInPlayerId = -1;

		[Authorize]
		public ActionResult MainTest()
        {
			if (Session["LoggedInPlayerId"] == null || (int)Session["LoggedInPlayerId"] <= 0)
			{
				String login = User.Identity.Name;
				using (var db = new TennisOrganizerContext())
				{
					var LoggedInPlayer = db.Players.FirstOrDefault<Player>(p => p.Account.Login == login);
					if(LoggedInPlayer == null)
					{
						FormsAuthentication.SignOut();
						return RedirectToAction("Index", "Home");
					}
					LoggedInPlayerId = LoggedInPlayer.AccountId;
					Session.Add("LoggedInPlayerId", (int)LoggedInPlayerId);
				}
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
			using (var db = new TennisOrganizerContext())
			{
				int id = (int)Session["LoggedInPlayerId"];
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == id);
				var stats = new PlayerStats(player);
				return View(stats);
			}
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
