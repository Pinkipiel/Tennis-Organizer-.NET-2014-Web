using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Models
{
	[Table("Konta")]
	public class Account
	{
		[Key]
		public int AccountId { get; set; }

		[Required(ErrorMessage = "Wymagana nazwa użytkownika")]
		[Display(Name = "Użytkownik")]
		public String Login { get; set; }

		[Required(ErrorMessage = "Wprowadź swoje hasło")]
		[MinLength(3, ErrorMessage="Hasło musi zawierać co najmniej 3 znaki")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Hasło musi zawierać co najmniej 3 znaki")]
		[Display(Name = "Hasło")]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		public virtual Player Player { get; set; }


		public static bool CheckAvailability(String login)
		{
			using (var db = new TennisOrganizerContext())
			{
				var query = (from a in db.Accounts
							 where a.Login == login
							 select a.Login);
				if (query.Contains<String>(login)) return false;
			}
			return true;
		}

		public static bool CreateAccount(Account acc, Player p)
		{
			if (acc == null || p == null) return false;
			if (CheckAvailability(acc.Login) == false) return false;
			acc.Player = p;
			acc.Password = Encrypter.GetSHA256Hash(acc.Password);
			using (var db = new TennisOrganizerContext())
			{
				db.Accounts.Add(acc);
				db.Players.Add(p);
				db.SaveChanges();

				var query = (from a in db.Accounts
							 where a.Login == acc.Login
							 select a);
				if (query.Count<Account>() != 0) return true;
				else return false;
			}
		}

		public bool UpdateAccount(String oldPassword, String newPassword = "default", String newLogin = "default")
		{
			if (this == null) return false;
			using (var db = new TennisOrganizerContext())
			{
				var query = db.Accounts.FirstOrDefault<Account>(a => a.AccountId == this.AccountId);
				if (query == null) return false;
				else if (query.Password != Encrypter.GetSHA256Hash(oldPassword)) return false;
				else
				{
					if (newLogin != "default" && newLogin != null)
					{
						query.Login = newLogin;
					}
					if (newPassword != "default" && newPassword != null)
					{
						query.Password = Encrypter.GetSHA256Hash(newPassword);
					}
					db.SaveChanges();
					return true;
				}
			}
		}

		public bool UpdatePlayer(String Password, Player p)
		{
			if (this == null || p == null) return false;
			using (var db = new TennisOrganizerContext())
			{
				var query = db.Accounts.FirstOrDefault<Account>(a => a.AccountId == this.AccountId);
				if (query == null || query.Password != Password) return false;
				else
				{
					var updated = db.Players.FirstOrDefault<Player>(player => player.AccountId == this.AccountId);
					if (updated == null) return false;
					updated.FirstName = p.FirstName;
					updated.LastName = p.LastName;
					updated.BirthDate = p.BirthDate ;
					updated.PhoneNumber = p.PhoneNumber;
					updated.Email = p.Email;
					updated.ImagePath = p.ImagePath;
					updated.City = p.City;

					db.SaveChanges();
					return true;
				}
			}
		}
	
		public static bool CheckPassword(String login, String password)
		{
			password = Encrypter.GetSHA256Hash(password);
			using(var db = new TennisOrganizerContext())
			{
				var query = db.Accounts.FirstOrDefault<Account>(a => a.Login == login);
				if (query == null) return false;
				if (password != query.Password) return false;
				return true;
			}
		}
	}

}