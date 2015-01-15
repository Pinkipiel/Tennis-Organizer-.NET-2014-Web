using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
		public ViewResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegistrationViewModel rvm)
		{
			if (ModelState.IsValid)
			{
				using(var db = new TennisOrganizerContext())
				{
					Account acc = rvm.Account;
					Player p = rvm.Player;
					acc.Player = p;
					db.Accounts.Add(acc);
					db.Players.Add(p);
					db.SaveChanges();
				}
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index");

				//return View(rvm);
			}
		}
    }
}
