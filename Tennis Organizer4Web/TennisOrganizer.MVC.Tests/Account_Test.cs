using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Tests
{
	[TestClass]
	public class Account_Test
	{

		static TennisOrganizerContext db;
		Player p = new Player { FirstName = "AccountTest", LastName = "AccountTest", Age = 1, Email = "a@a.com", City = "AccountTest" };

		[ClassInitialize()]
		public static void Initialize(TestContext tc)
		{
			db = new TennisOrganizerContext();
			var query = db.Accounts.FirstOrDefault<Account>(a => a.Login == "Account_Test");
			if(query != null)
			{
				var DuelQuery = (from d in db.Duels
								 where d.HomePlayerId == query.AccountId || d.GuestPlayerId == query.AccountId
								 select d);

				foreach(var d in DuelQuery)
				{
					db.Duels.Remove(d);
				}
				db.Players.Remove(query.Player);
				db.Accounts.Remove(query);

			}
			db.SaveChanges();
		}

		[ClassCleanup()]
		static public void Cleanup()
		{
			db = new TennisOrganizerContext();
			var query = db.Accounts.FirstOrDefault<Account>(a => a.Login == "Account_Test");
			if (query != null)
			{
				var DuelQuery = (from d in db.Duels
								 where d.HomePlayerId == query.AccountId || d.GuestPlayerId == query.AccountId
								 select d);

				foreach (var d in DuelQuery)
				{
					db.Duels.Remove(d);
				}
				db.Players.Remove(query.Player);
				db.Accounts.Remove(query);

			}
			db.SaveChanges();
		}
		
		[TestCleanup()]
		public void TestCelanup()
		{
			db = new TennisOrganizerContext();
			var query = db.Accounts.FirstOrDefault<Account>(a => a.Login == "Account_Test");
			if (query != null)
			{
				var DuelQuery = (from d in db.Duels
								 where d.HomePlayerId == query.AccountId || d.GuestPlayerId == query.AccountId
								 select d);

				foreach (var d in DuelQuery)
				{
					db.Duels.Remove(d);
				}
				db.Players.Remove(query.Player);
				db.Accounts.Remove(query);

			}
			db.SaveChanges();
		}
		
		[TestMethod]
		public void Test_CheckAvailability()
		{
			Account acc = new Account() { Login = "test", Password = "test" };
			db.Accounts.Add(acc);
			db.SaveChanges();

			bool result = Account.CheckAvailability("test");
			bool result2= Account.CheckAvailability("Account_Test");

			Assert.IsFalse(result);
			Assert.IsTrue(result2);
		}
		
		[TestMethod]
		public void Test_CreateAccount()
		{
			Account acc = null;
			Player p = null;

			bool result1 = Account.CreateAccount(acc, p);
			acc = new Account { Login = "Account_Test", Password = "asd"};
			p = new Player { FirstName = "AccountTest", LastName = "AccountTest", Age = 1, Email = "a@a.com", City = "AccountTest" };

			bool result2 = Account.CreateAccount(acc, p);
			bool result3 = Account.CreateAccount(acc, p);
			Assert.IsFalse(result1);
			Assert.IsTrue(result2);
			Assert.IsFalse(result3);
		}

		[TestMethod]
		public void Test_UpdateAccount()
		{
			Account acc = null;
			bool result1 = Account.UpdateAccount(acc, "asd");
			acc = new Account { Login = "Account_Test", Password = "asd" };
			bool result2 = Account.UpdateAccount(acc, "asd");
			Account.CreateAccount(acc, p);
			bool result3 = Account.UpdateAccount(acc, "dsa", "dsa", "Account_Test");
			bool result4 = Account.UpdateAccount(acc, "asd", "dsa", "Account_Test2");
			var query = db.Accounts.Where<Account>(a => a.Login == "Account_Test2").FirstOrDefault<Account>();
			bool result5 = query == null ? false : true;
			if(result5 == true)
			{
				Account.UpdateAccount(acc, "dsa", "asd", "Account_Test2");
			}
			Assert.IsFalse(result1);
			Assert.IsFalse(result2);
			Assert.IsFalse(result3);
			Assert.IsTrue(result4);
			Assert.IsTrue(result5);
		}

		[TestMethod]
		public void Test_UpdatePlayer()
		{
			Account acc = null;
			Player p2 = null;
			bool result1 = Account.UpdatePlayer(acc, "asd", p2);
			acc = new Account() { Login = "Account_Test", Password = "asd", Player = p };
			bool result2 = Account.UpdatePlayer(acc, "asd", p);
			Account.CreateAccount(acc, p);
			bool result3 = Account.UpdatePlayer(acc, "dsa", p);
			bool result4 = Account.UpdatePlayer(acc, "asd", p);
			acc = db.Accounts.Where<Account>(a => a.Login == "Account_Test").FirstOrDefault<Account>();
			bool result5 = db.Players.Where<Player>(pl => pl.AccountId == acc.AccountId).FirstOrDefault<Player>().FirstName == "AccountTest";


			Assert.IsFalse(result1);
			Assert.IsFalse(result2);
			Assert.IsFalse(result3);
			Assert.IsTrue(result4);
			Assert.IsTrue(result5);
		}



	}
}
