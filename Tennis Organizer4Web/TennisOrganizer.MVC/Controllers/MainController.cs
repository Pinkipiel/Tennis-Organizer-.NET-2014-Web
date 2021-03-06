﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
		public MainController()
		{
			//var player = Player.GetPlayerByLogin(User.Identity.Name);

		}
		[Authorize]
		public ActionResult Ranking()
		{
			var stats = Player.GetPlayersStats().OrderBy(p => p.Position);
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

			
			if (cc.OpponentNumber <= 0)
			{
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

			// else
			Player opponent = new Player() {  AccountId = cc.OpponentNumber};
			String[] hour = cc.Hour.ToString().Split(':') ;
			DateTime date = (DateTime)cc.Date;
			//dateOfPlay.Hour = hour[0];
			//dateOfPlay.Minute = hour[1];
			DateTime dateOfPlay;
			try
			{
				dateOfPlay = new DateTime(date.Date.Year, date.Date.Month, date.Date.Day, int.Parse(hour[0]), int.Parse(hour[1]), 0);
			}
			catch (IndexOutOfRangeException)
			{
				return View(cc);
			}

			using (var db = new TennisOrganizerContext())
			{
				db.Duels.Add(new Duel() { Accepted = false, GuestPlayerId = opponent.AccountId, HomePlayerId = player.AccountId, Seen = false, DateOfPlay = dateOfPlay });
				db.SaveChanges();

				TempData.Add("opponentName", Player.GetPlayerById(cc.OpponentNumber).ToString());
				TempData.Add("dateOfPlay", cc.Date.ToShortDateString());
				TempData.Add("hourOfPlay", cc.Hour);

				return RedirectToAction("ChallengeSuccess", "Main");
			}
		}

		[Authorize]
		public ActionResult ChallengeSuccess()
		{
			ViewBag.opponentName = TempData["opponentName"];
			ViewBag.dateOfPlay = TempData["dateOfPlay"];
			ViewBag.hourOfPlay = TempData["hourOfPlay"];
			return View();
		}
		[Authorize]
		public ActionResult Profile()
		{
			if (Session["LoggedInPlayerId"] == null || (int)Session["LoggedInPlayerId"] <= 0)
			{
				String login = User.Identity.Name;
				using (var db = new TennisOrganizerContext())
				{
					var LoggedInPlayer = db.Players.FirstOrDefault<Player>(p => p.Account.Login == login);
					if (LoggedInPlayer == null)
					{
						FormsAuthentication.SignOut();
						return RedirectToAction("Index", "Home");
					}
					LoggedInPlayerId = LoggedInPlayer.AccountId;
					Session.Add("LoggedInPlayerId", (int)LoggedInPlayerId);
					Session.Add("LoggedInPlayer", (string)User.Identity.Name);
					Session.Add("ImagePath", (string)LoggedInPlayer.ImagePath);
				}
			}
			Player player = Player.GetPlayerByLogin(User.Identity.Name);
			return View(player);
		}
		[Authorize]
		public ActionResult Training()
		{
			TrainingCriteria cc = new TrainingCriteria();
			cc.SuitableOpponents = Trainer.GetTrainersList();

			return View(cc);
		}
		
		[Authorize]
		[HttpPost]
		public ActionResult Training(TrainingCriteria cc)
		{
			Player player = Player.GetPlayerByLogin(User.Identity.Name);


			if (cc.OpponentNumber <= 0)
			{
				return View(cc);
			}
			Player opponent = Player.GetPlayerById(cc.OpponentNumber);
			String[] hour = cc.Hour.ToString().Split(':');
			DateTime date = (DateTime)cc.Date;
			DateTime dateOfPlay = new DateTime(date.Date.Year, date.Date.Month, date.Date.Day, int.Parse(hour[0]), int.Parse(hour[1]), 0);

			using (var db = new TennisOrganizerContext())
			{
				db.Duels.Add(new Duel() { Accepted = false, GuestPlayerId = opponent.AccountId, HomePlayerId = player.AccountId, Seen = false, DateOfPlay = dateOfPlay });
				db.SaveChanges();
				try
				{
					Mailer.NotifyAboutChallenge(player.ToString(), opponent.Email, opponent.ToString());
				}
				catch(FormatException e)
				{

				}
				TempData.Add("opponentName", Player.GetPlayerById(cc.OpponentNumber).ToString());
				TempData.Add("dateOfPlay", cc.Date.ToShortDateString());
				TempData.Add("hourOfPlay", cc.Hour);

				return RedirectToAction("TrainingSuccess", "Main");
			}
		}
		

		public ActionResult TrainingSuccess()
		{
			ViewBag.opponentName = TempData["opponentName"];
			ViewBag.dateOfPlay = TempData["dateOfPlay"];
			ViewBag.hourOfPlay = TempData["hourOfPlay"];
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
		public ActionResult ProfileEdition(Player model, HttpPostedFileBase file)
		{
			string fileName, fileExt;
			int width = 140;
			int height = 140;
			if(ModelState.IsValid)
			{
				if (file != null && file.ContentLength > 0)
				{
					char DirSeparator = System.IO.Path.DirectorySeparatorChar;
					string FilesPath = HttpContext.Server.MapPath("~\\Content" + DirSeparator + "Uploads" + DirSeparator);
					
					fileName = (DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()
						+ DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()) + "_" + (string)Session["LoggedInPlayer"];

					fileExt = Path.GetExtension(file.FileName);
					if(!fileExt.Contains("jpg") && !fileExt.Contains("png") && !fileExt.Contains("bmp"))
					{
						ViewData.Add("WrongFileExtension", (bool)true);
						return View(model);
					}
					if (!Directory.Exists(FilesPath))
					{
						Directory.CreateDirectory(FilesPath);
					}
					string path = FilesPath + DirSeparator + fileName + fileExt; 
					file.SaveAs(Path.GetFullPath(path));
					model.ImagePath = fileName + fileExt;

					//zapisz thumbnail:

					string thumbnailDirectory = String.Format(@"{0}{1}{2}", FilesPath, DirSeparator, "Thumbnails");

					if (!Directory.Exists(thumbnailDirectory))
					{
						Directory.CreateDirectory(thumbnailDirectory);
					}

					string imagePath = String.Format(@"{0}{1}{2}{3}", thumbnailDirectory, DirSeparator, fileName, fileExt);
					
					FileStream stream = new FileStream(Path.GetFullPath(imagePath), FileMode.OpenOrCreate);

					Image OrigImage = Image.FromStream(file.InputStream);
					
					Bitmap TempBitmap = new Bitmap(width,height);

					Graphics NewImage = Graphics.FromImage(TempBitmap);
					NewImage.CompositingQuality = CompositingQuality.HighQuality;
					NewImage.SmoothingMode = SmoothingMode.HighQuality;
					NewImage.InterpolationMode = InterpolationMode.HighQualityBicubic;

					Rectangle imageRectangle = new Rectangle(0, 0, width, height);
					NewImage.DrawImage(OrigImage, imageRectangle);

					TempBitmap.Save(stream, OrigImage.RawFormat);

					NewImage.Dispose();
					TempBitmap.Dispose();
					OrigImage.Dispose();
					stream.Close();
					stream.Dispose();
				}
				model.AccountId = (int)Session["LoggedInPlayerId"];
				model.UpdatePlayer();
			}
			return View(model);
		}


    }
}
