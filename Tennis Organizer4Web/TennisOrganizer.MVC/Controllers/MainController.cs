﻿using System;
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
					Session.Add("LoggedInPlayer", (string)User.Identity.Name);
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
		[Authorize]
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
		[HttpGet]
		public ActionResult Challenge()
		{
			return View();
		}
		[Authorize]
		[HttpPost]
		public ActionResult Challenge(ChallengeCriteria cc)
		{
			Player player = Player.GetPlayerByLogin(User.Identity.Name);

			if (cc.AgeFrom == null)
				cc.AgeFrom = 0;
			if (cc.AgeTo == null)
				cc.AgeTo = 200;
			if (cc.LevelFrom == null)
				cc.LevelFrom = 0;
			if (cc.LevelTo == null)
				cc.LevelTo = 100;

			if (cc.City == null || cc.City == String.Empty)
				cc.SuitableOpponents = player.GetOpponentsBy(cc.Date, (int)cc.AgeFrom, (int)cc.AgeTo, (float)cc.LevelFrom, (float)cc.LevelTo);
			else
				cc.SuitableOpponents = player.GetOpponentsBy(cc.Date, (int)cc.AgeFrom, (int)cc.AgeTo, (float)cc.LevelFrom, (float)cc.LevelTo, cc.City);
			return View(cc);
		}
		[Authorize]
		public ActionResult Profile()
		{
			Player player = Player.GetPlayerByLogin(User.Identity.Name);
			return View(player);
		}
		[Authorize]
		public ActionResult Training()
		{
			return View();
		}
		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			Session.Clear();
			return RedirectToAction("Index", "Home");
		}
		[Authorize]
		public ActionResult AccountEdition()
		{
			if (Session["LoggedInPlayerId"] == null || Session["LoggedInPlayer"] == null) return RedirectToAction("Index", "Home");
			AccountEditorData aed = new AccountEditorData() { Login = (string)Session["LoggedInPlayer"]};
			return View(aed);
		}
		[HttpPost]
		[Authorize]
		public ActionResult AccountEdition(AccountEditorData model)
		{
			if (Session["LoggedInPlayerId"] == null || Session["LoggedInPlayer"] == null) return RedirectToAction("Index", "Home");
			if(ModelState.IsValid)
			{
				if (model.Login != (string)Session["LoggedInPlayer"])
				{
					if (!Account.CheckAvailability(model.Login))
					{
						ViewData.Add("LoginAvailability", (bool)false);
						return View(model);
					}
					Account acc = new Account() { AccountId = (int)Session["LoggedInPlayerId"] };
					if(acc.UpdateAccount(model.Password, model.NewPassword, model.Login) == false)
					{
						ViewData.Add("PasswordIncorrect", (bool)true);
						return View(model);
					}
					else
					{
						FormsAuthentication.SignOut();
						FormsAuthentication.SetAuthCookie(model.Login, false);
					}
				}
			}
			return View(model);
		}
		[Authorize]
		public ActionResult ProfileEdition()
		{
			if (Session["LoggedInPlayerId"] == null || Session["LoggedInPlayer"] == null) return RedirectToAction("Index", "Home");
			Player p = Player.GetPlayerById((int)Session["LoggedInPlayerId"]);
			return View(p);
		}

		[HttpPost]
		[Authorize]
		public ActionResult ProfileEdition(Player model)
		{
			if(ModelState.IsValid)
			{
				model.AccountId = (int)Session["LoggedInPlayerId"];
				model.UpdatePlayer();

			}
			return View(model);
		}


    }
}
