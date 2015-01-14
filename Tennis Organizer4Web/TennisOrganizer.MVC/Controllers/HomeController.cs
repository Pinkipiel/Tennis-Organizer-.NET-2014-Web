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
    }
}
