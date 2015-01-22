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
		Player p = new Player { FirstName = "AccountTest", LastName = "AccountTest", BirthDate=new DateTime(2015,01,01), Email = "a@a.com", City = "AccountTest" };

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
			p = new Player { FirstName = "AccountTest", LastName = "AccountTest",  BirthDate=new DateTime(2015,01,01), Email = "a@a.com", City = "AccountTest" };

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
			acc = new Account { Login = "Account_Test", Password = "asd" };
			bool result2 = acc.UpdatePlayer("asd", p);
			Account.CreateAccount(acc, p);
			bool result3 = acc.UpdateAccount("dsa", "dsa", "Account_Test");
			bool result4 = acc.UpdateAccount("asd", "dsa", "Account_Test2");
			var query = db.Accounts.Where<Account>(a => a.Login == "Account_Test2").FirstOrDefault<Account>();
			bool result5 = query == null ? false : true;
			if(result5 == true)
			{
				acc.UpdateAccount("dsa", "asd", "Account_Test2");
			}
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
			acc = new Account() { Login = "Account_Test", Password = "asd", Player = p };
			bool result2 = acc.UpdatePlayer( "asd", p);
			Account.CreateAccount(acc, p);
			bool result3 = acc.UpdatePlayer( "dsa", p);


			Assert.IsFalse(result2);
			Assert.IsFalse(result3);
		}

		[TestMethod]
		public void Test_CheckPassword()
		{
			Account acc = null;
			acc = new Account() { Login = "Account_Test", Password = "asd", Player = p };
			Account.CreateAccount(acc, p);
			bool result1 = Account.CheckPassword(acc.Login, "asd");
			bool result2 = Account.CheckPassword("Account_Test_fail", "asd");
			bool result3 = Account.CheckPassword(acc.Login, "badPassword");

			Assert.IsTrue(result1);
			Assert.IsFalse(result2);
			Assert.IsFalse(result3);

		}

	}
}
