using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

		public ActionResult Index(string returnUrl)
        {
			if (Request.IsAuthenticated)
				return RedirectToAction("MainTest", "Main");
			ViewBag.ReturnUrl = returnUrl;
            return View();
        }
		public ViewResult Register()
		{
			return View();
		}
		public ViewResult RegisterSuccess()
		{

			ViewData.Add("RegisteredLogin", (String)TempData["RegisteredLogin"]);
			Mailer.NotifyAboutRegistration((string)TempData["RegisteredName"], (string)TempData["RegisteredLogin"], (string)TempData["RegisteredEmail"]);
			return View();
		}
		[HttpPost]
		public ActionResult Index(Account acc, string ReturnUrl)
		{
			using (var db =  new TennisOrganizerContext())
			{
				var query = db.Accounts.FirstOrDefault<Account>(a => a.Login == acc.Login);
				if (query == null)
				{
					ViewData.Add("LoginNotFound", (bool)true);
					return View(acc);
				}
				else if (Account.CheckPassword(query.Login, acc.Password) == false)
				{
					ViewData.Add("PasswordIncorrect", (bool)true);
					return View(acc);
				}
				else
				{
				//	Session["User"] = acc.Login;
					FormsAuthentication.SetAuthCookie(acc.Login, false);
					if (ReturnUrl != null) return Redirect(ReturnUrl);
					TempData["RegisteredLogin"] = acc.Login;
					return RedirectToAction("MainTest", "Main");
				}
			}
		}


		[HttpPost]
		public ActionResult Register(RegistrationViewModel rvm)
		{
			if (ModelState.IsValid)
			{
				using(var db = new TennisOrganizerContext())
				{
					if (!Account.CheckAvailability(rvm.Login))
					{
						ViewData.Add("LoginAvailability", (bool)false);
						return View(rvm);
					}
					else
					{
						Account acc = new Account { Login = rvm.Login, Password = rvm.Password };
						Player p = rvm.Player;
						Account.CreateAccount(acc, p);

						TempData.Add("RegisteredLogin", rvm.Login);
						TempData.Add("RegisteredName", rvm.Player.FirstName);
						TempData.Add("RegisteredEmail", rvm.Player.Email);
						return RedirectToAction("RegisterSuccess");
					}
				}
			}
			else
			{
				return View(rvm);
			}
		}
    }
}
