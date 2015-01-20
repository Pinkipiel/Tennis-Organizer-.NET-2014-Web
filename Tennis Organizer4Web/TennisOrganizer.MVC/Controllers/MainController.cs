using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisOrganizer.MVC.Models;
using TennisOrganizer.MVC.ViewModels;

namespace TennisOrganizer.MVC.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
		TennisOrganizerContext ctx = new TennisOrganizerContext();
		Player LoggedInPlayer;
		public ActionResult MainTest()
        {
            return View();
        }

		public ActionResult Ranking()
		{
			var stats = Player.GetPlayersStats();
			return View(stats);
		}

		public ActionResult Statistics()
		{
			LoggedInPlayer = ctx.Players.FirstOrDefault<Player>(p => p.AccountId == 1);		// DO USUNIĘCIA!!!!   DO USUNIĘCIA!!!!   DO USUNIĘCIA!!!!   DO USUNIĘCIA!!!!
			var stats = new PlayerStats(LoggedInPlayer);
			return View(stats);
		}

    }
}
