using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Controllers
{
	[Authorize]
    public class MainController : Controller
    {
        //
        // GET: /Main/
		TennisOrganizerContext ctx = new TennisOrganizerContext();
		[Authorize]
		public ActionResult MainTest()
        {
            return View();
        }
		[Authorize]
		public ActionResult Ranking()
		{
			var stats = Player.GetPlayersStats();
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
