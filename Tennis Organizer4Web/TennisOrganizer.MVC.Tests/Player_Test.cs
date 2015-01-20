using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.Tests
{
	[TestClass]
	public class Player_Test
	{
		 static  TennisOrganizerContext context;
		[ClassInitialize()]
		public static void Initialize(TestContext tc)
		{
			context = new TennisOrganizerContext();
		}

		[ClassCleanup()]
		static public void Cleanup()
		{
			context.Dispose();
		}
		[TestInitialize()]
		 public void MyTestInitialize() 
		{
			 Player p1 = new Player() { FirstName = "Test_1", LastName = "Test", Age = 1, City = "TEST", Email = "test@test.pl", SkillLevel = 2 };
			 context.Accounts.Add(new Account() { Login = "test_1", Password = "adam", Player = p1 });
			 context.Players.Add(p1);
			 Player p2 = new Player() { FirstName = "Test_2", LastName = "Testowy", Age = 45, City = "TESTION", Email = "as@asa.pl", SkillLevel = 4 };
			 context.Accounts.Add(new Account() { Login = "test_2", Password = "piotr", Player = p2 });
			 context.Players.Add(p2);
			 Player p3 = new Player() { FirstName = "Test_3", LastName = "Te?ciak", Age = 17, City = "T", Email = "sddfs@sdfsdf.com", SkillLevel = 1};
			 context.Accounts.Add(new Account() { Login = "test_3", Password = "janek", Player = p3 });
			 context.Players.Add(p3);
			 context.SaveChanges();

			 p1 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_1");
			 p2 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_2");
			 p3 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_3");
			 context.Duels.Add(new Duel() { Accepted = true, GuestPlayerId = p1.AccountId, HomePlayerId = p2.AccountId, Result = "3:0", Seen = true, DateOfPlay = new DateTime(2015, 1, 15, 0, 0, 0) });
			 context.Duels.Add(new Duel() { Accepted = true, GuestPlayerId= p1.AccountId, HomePlayerId = p3.AccountId, Result = "1:3", Seen = true, DateOfPlay=new DateTime(2014,12,12,0,0,0) });
			 context.SaveChanges();
		 }
		
		 [TestCleanup()]
		 public void MyTestCleanup() 
		 {
			 var duels = context.Duels.Where<Duel>(d => d.HomePlayer.FirstName.Contains("Test"));
			 foreach (var duel in duels)
				 context.Duels.Remove(duel);
			 var players = context.Players.Where<Player>(p => p.FirstName.Contains("Test"));
			 foreach (var player in players)
				 context.Players.Remove(player);
			 context.SaveChanges();
		 }

		[TestMethod]
		public void Test_GetWonMatches()
		{
			Player player = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_1");
			int actual = player.GetWonMatchesCount();
			int expected = 1;
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void Test_GetLostMatches()
		{
			Player player = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_3");
			int actual = player.GetWonMatchesCount();
			int expected = 0;
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void Test_GetRank()
		{
			Player p1 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_1");
			Player p3 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_3");
			int r1 = p1.GetRank();
			int r3 = p3.GetRank();
			Assert.IsTrue(r1 < r3);
		}
		[TestMethod]
		public void Test_GetMonthlyMatchesCount()
		{
			Player p1 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_1");
			int actual = p1.GetMonthlyMatchesCount();
			int expected = 1;
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void Test_GetLastMatchDate()
		{
			Player p3 = context.Players.FirstOrDefault<Player>(p => p.FirstName == "Test_3");
			DateTime? expected = new DateTime(2014, 12, 12, 0, 0, 0);
			DateTime? actual = p3.GetLastMatchDate();
			Assert.AreEqual(expected, actual);
		}
	}
}