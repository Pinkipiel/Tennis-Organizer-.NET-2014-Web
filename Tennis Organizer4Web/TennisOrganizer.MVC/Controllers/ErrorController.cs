using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TennisOrganizer.MVC.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult WrongPage()
        {
			Response.StatusCode = 404;
			Response.TrySkipIisCustomErrors = true;
			if(Request.QueryString["aspxerrorpath"] != null)
			{
				string errorPath = Request.QueryString["aspxerrorpath"].ToString();
				ViewData.Add("ErrorPath", errorPath);
			}
            return View();
        }

    }
}
