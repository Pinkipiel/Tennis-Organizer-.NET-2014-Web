using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisOrganizerServices;
using TennisOrganizerUnitTests.AccountReference;
using TennisOrganizerUnitTests.PlayerService;
using TennisOrganizerUnitTests.DuelService;

namespace TennisOrganizerUnitTests
{
	/// <summary>
	/// PlayerService
	/// </summary>
	[TestClass]
	public class PlayerServiceUnitTest
	{
		PlayerServiceClient psc;
		AccountServiceClient asc;
		DuelServiceClient dsc;

		[TestInitialize()]
		public void MyTestInitialize() 
		{
 			psc = new PlayerServiceClient();
			asc = new AccountServiceClient();
			dsc = new DuelServiceClient();
		}
		 [TestCleanup()]
		public void MyTestCleanup() 
		 {
			 psc = null;
			 asc = null;
			 dsc = null;
		 }
		[TestMethod]
		public void TestAccountService()
		 {
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			var GetAcc = asc.GetAccount(Acc.AccountID, "password1");
			var GetAccByLogin = asc.GetAccountByLogin(Acc.Login, "password1");
			Assert.IsTrue(GetAcc.Login == Acc.Login);
			Assert.IsTrue(GetAccByLogin.AccountID == Acc.AccountID);
		 }
		[TestMethod]
		public void TestAccountPasswordChange()
		{
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			Assert.IsTrue(asc.UpdateAccountPassword(Acc.Login, "password1", "password2"));
			Assert.IsFalse(asc.UpdateAccountPassword(Acc.Login, "password1", "password2"));
		}
		[TestMethod]
		public void TestAccountAvailability()
		{
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			Assert.IsTrue(asc.CheckAvailability(Acc.Login) == false);
			Assert.IsTrue(asc.CheckAvailability("-1"));
		}
		[TestMethod]
		public void TestPlayerServiceRead()
		{
			Random r = new Random();
			int randomTopPosition = r.Next(100);
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", randomTopPosition);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			var player = psc.GetPlayerByID(Acc.AccountID);
			Assert.IsTrue(player.FirstName == p.FirstName && p.LastName == player.LastName && p.Email == player.Email);
		}
		[TestMethod]
		public void TestPlayerGetOpponentsBy()
		{
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			TennisOrganizerServices.Player p1 = new Player("Piotr", "Nowak", 20, "12312", "b@a.com", 1.0f, null, "Warszawa", 1);
			var Acc2 = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			Assert.IsTrue(psc.GetOpponentsBy(p, DateTime.Now, 0, 100, 1.0f, 7.0f).Length != 0);

		}
		[TestMethod]
		public void TestDuelServiceRead()
		{
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			TennisOrganizerServices.Player p1 = new Player("Piotr", "Nowak", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc1 = asc.CreateAccount(p1, r.Next(100000).ToString(), "password1");
			p = psc.GetPlayerByID(Acc.AccountID);
			p1 = psc.GetPlayerByID(Acc1.AccountID);
			var duel = dsc.ArrangeDuel(p, p1, DateTime.Now);

			var myOpponent = psc.GetOpponentBy(p, duel.DuelID);
			Assert.IsTrue(myOpponent.FirstName == "Piotr");
		}
		[TestMethod]
		public void TestPlayerCanPlay()
		{
			Random r = new Random();
			TennisOrganizerServices.Player p = new Player("Jan", "Kowalski", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc = asc.CreateAccount(p, r.Next(100000).ToString(), "password1");
			TennisOrganizerServices.Player p1 = new Player("Piotr", "Nowak", 20, "12312", "a@a.com", 1.0f, null, "Warszawa", 1);
			var Acc1 = asc.CreateAccount(p1, r.Next(100000).ToString(), "password1");
			p = psc.GetPlayerByID(Acc.AccountID);
			p1 = psc.GetPlayerByID(Acc1.AccountID);
			var Date = new DateTime(2014,12,12);

			dsc.ArrangeDuel(p, p1, Date);
			Assert.IsFalse(p.CanPlay(Date));
			Assert.IsFalse(p1.CanPlay(Date));
		}
		#region Additional test attributes
		//
		// You can use the following additional attributes as you write your tests:
		//
		// Use ClassInitialize to run code before running the first test in the class
		// [ClassInitialize()]
		// public static void MyClassInitialize(TestContext testContext) { }
		//
		// Use ClassCleanup to run code after all tests in a class have run
		// [ClassCleanup()]
		// public static void MyClassCleanup() { }
		//
		// Use TestInitialize to run code before running each test 
		// [TestInitialize()]
		// public void MyTestInitialize() { }
		//
		// Use TestCleanup to run code after each test has run
		// [TestCleanup()]
		// public void MyTestCleanup() { }
		//
		#endregion
	}
}
