using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizerTests
{
	[TestClass]
	public class PlayerTest
	{
		int id1;
		int id2;
		static TennisOrganizerContext context;
		[ClassInitialize()]
		public static void PlayerClassInitialize(TestContext testContext)
		{
			context = new TennisOrganizerContext();
		}

		[ClassCleanup()]
		public static void PlayerClassCleanup()
		{
			context.Dispose();
		}

		[TestInitialize()]
		public void EachTestInitialize()
		{
			Player p1 = new Player() {FirstName="TestFirstName1", LastName="TestLastName1", BirthDate=new DateTime(1993,10,10), PhoneNumber="606", Email="test@test.pl", SkillLevel=.0f, City="Testowo", TopPosition=1};
			Player p2 = new Player() { FirstName = "TestFirstName2", LastName = "TestLastName2", BirthDate = new DateTime(1991, 11, 04), PhoneNumber = "606", Email = "test@test.pl", SkillLevel = .5f, City = "Testolandia", TopPosition = 2 };
			Account a1 = new Account()
			{
				Login = "test1",
				Password = "test",
				Player = p1
			};
			Account a2 = new Account()
			{
				Login = "test2",
				Password = "test",
				Player = p2
			};
			context.Accounts.Add(a1);
			context.Accounts.Add(a2);
			context.Players.Add(p1);
			context.Players.Add(p2);
			context.SaveChanges();
			id1 = context.Accounts.FirstOrDefault<Account>(a => a.Login == "test1").AccountId;
			id2 = context.Accounts.FirstOrDefault<Account>(a => a.Login == "test2").AccountId;
			context.SaveChanges();
		}

		[TestCleanup()]
		public void EachTestCleanup()
		{
			context.Duels.RemoveRange(context.Duels.Where<Duel>(d => d.HomePlayerId == id1));
			context.Duels.RemoveRange(context.Duels.Where<Duel>(d => d.HomePlayerId == id2));

			context.Players.Remove(context.Players.FirstOrDefault<Player>(p => p.AccountId == id1));
			context.Players.Remove(context.Players.FirstOrDefault<Player>(p => p.AccountId == id2));
			context.Accounts.Remove(context.Accounts.FirstOrDefault<Account>(a => a.AccountId == id1));
			context.Accounts.Remove(context.Accounts.FirstOrDefault<Account>(a => a.AccountId == id2));
			context.SaveChanges();
		}

	/*	[TestMethod]
		public void GetAcceptedNotSeenDuelsTest()
		{
			Player p1;
			Player p2;
			Duel d;
			p1 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id1);
			p2 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id2);
			d = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Seen = false, Accepted = true };

			context.Duels.Add(new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Seen = true, Accepted = false });
			context.Duels.Add(new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Seen = true, Accepted = true });
			context.Duels.Add(d);
			context.Duels.Add(new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Seen = false, Accepted = false });
			context.SaveChanges();

			Duel[] actual = p1.GetAcceptedNotSeenDuels();
			List<Duel> expected = new List<Duel>();
			expected.Add(Duel.GetDuelByID(d.DuelId));
			CollectionAssert.AreEqual(expected.ToArray(), actual);
		}*/
	/*	[TestMethod]
		public void GetFinishedNotRatedDuelsTest()
		{
			Player p1;
			Player p2;
			Duel d1, d2, d3, d4;

			p1 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id1);
			p2 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id2);
			d1 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Accepted = true, Result = "3:1" };
			d2 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Accepted = true, Result = String.Empty };
			d3 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2013, 10, 10), Result = "1:3", Accepted = true };
			d4 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2013, 10, 10), Accepted = true, Result = String.Empty };
			context.Duels.Add(d1);
			context.Duels.Add(d2);
			context.Duels.Add(d3);
			context.Duels.Add(d4);
			context.SaveChanges();

			Duel[] actual = p1.GetFinishedNotRatedDuels();
			List<Duel> expected = new List<Duel>();
			expected.Add(Duel.GetDuelByID(d4.DuelId));
			CollectionAssert.AreEqual(expected.ToArray<Duel>(), actual);
		}
		[TestMethod]
		public void GetChallengingDuelsTest()
		{
			Player p1;
			Player p2;
			Duel d1, d2, d3, d4;

			p1 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id1);
			p2 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id2);
			d1 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Accepted = true };
			d2 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10), Accepted = null };
			d3 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2013, 10, 10), Accepted = false };
			d4 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2013, 10, 10), Accepted = null };
			context.Duels.Add(d1);
			context.Duels.Add(d2);
			context.Duels.Add(d3);
			context.Duels.Add(d4);
			context.SaveChanges();

			Duel[] actual = p2.GetChallengingDuels();
			List<Duel> expected = new List<Duel>();
			expected.Add(Duel.GetDuelByID(d2.DuelId));
			CollectionAssert.AreEqual(expected.ToArray(), actual);
		}
		[TestMethod]
		public void GetOpponentByDuelIDTest()
		{
			Player p1;
			Player p2;
			Duel d1;

			p1 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id1);
			p2 = context.Players.FirstOrDefault<Player>(p => p.AccountId == id2);
			d1 = new Duel() { HomePlayer = p1, GuestPlayer = p2, DateOfPlay = new DateTime(2015, 10, 10) };
			context.Duels.Add(d1);
			context.SaveChanges();

			List<int> actual = new List<int>();
			actual.Add(p1.GetOpponentBy(d1.DuelId).AccountId);
			actual.Add(p2.GetOpponentBy(d1.DuelId).AccountId);
			List<int> expected = new List<int>();
			expected.Add(p2.AccountId);
			expected.Add(p1.AccountId);
			CollectionAssert.AreEqual(expected, actual);
		}
		*/

	}
}
