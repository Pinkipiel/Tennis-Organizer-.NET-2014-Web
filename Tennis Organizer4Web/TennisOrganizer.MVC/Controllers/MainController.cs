using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/
		TennisOrganizerContext ctx = new TennisOrganizerContext();
        public ActionResult MainTest()
        {
            return View();
        }

		public ActionResult Ranking()
		{
			var stats = Player.GetPlayersStats();
			return View(stats);
		}

    }
}
