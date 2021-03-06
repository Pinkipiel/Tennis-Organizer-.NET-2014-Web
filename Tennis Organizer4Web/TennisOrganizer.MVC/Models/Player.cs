﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using TennisOrganizer.MVC.ViewModels;

namespace TennisOrganizer.MVC.Models
{
	[Table("Gracze")]
	public class Player
	{
		[Display(Name = "Numer Gracza")]
		[Key, ForeignKey("Account")]
		public int AccountId { get; set; }

		[Required(ErrorMessage="Pole Wymagane")]
		[Display(Name = "Imię")]
		public String FirstName { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[Display(Name = "Nazwisko")]
		public String LastName { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[Display(Name = "Data Urodzenia")]
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }

		[Display(Name="Telefon")]
		[DataType(DataType.PhoneNumber)]
		public String PhoneNumber { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[Display(Name="Adres Email")]
		[DataType(DataType.EmailAddress)]
		public String Email { get; set; }

		[Display(Name="Poziom umiejętności")]
		[Required(AllowEmptyStrings=true)]
		public float SkillLevel { get; set; }

		public String ImagePath { get; set; }
		
		[Required(ErrorMessage="Pole Wymagane")]
		[Display(Name="Miejscowość")]
		public String City { get; set; }

		public int TopPosition { get; set; }

		public virtual ICollection<Duel> HomeMatches { get; set; }

		public virtual ICollection<Duel> AwayMatches { get; set; }

		public IEnumerable<Duel> Matches
		{
			get
			{
				return HomeMatches.Union<Duel>(AwayMatches);
			}
		}

		public virtual Account Account { get; set; }

		public Player()
		{
			HomeMatches = new HashSet<Duel>();
			AwayMatches = new HashSet<Duel>();
			BirthDate = new DateTime(1, 1, 1);
		}
		
		public bool UpdatePlayer()
		{
			using(var db = new TennisOrganizerContext())
			{
				var p = db.Players.Find(this.AccountId);
				if (p == null) return false;
				
				p.FirstName = this.FirstName;
				p.LastName = this.LastName;
				p.BirthDate = this.BirthDate;
				p.City = this.City;
				p.Email = this.Email;
				p.PhoneNumber = this.PhoneNumber;
				p.SkillLevel = this.SkillLevel;
				p.ImagePath = this.ImagePath;
				
				db.SaveChanges();
			}
			return true;
		}
		public int GetWonMatchesCount()
		{
			int wins = 0;

			foreach (Duel d in Matches)
			{
				if (d.Result == null || d.Result.Length == 0) continue;
				if (AccountId == d.HomePlayerId)
				{
					if (d.Result[0] > d.Result[2]) wins++;
				}
				else if (AccountId == d.GuestPlayerId)
				{
					if (d.Result[2] > d.Result[0]) wins++;
				}
			}
			return wins;
		}
		public int GetLostMatchesCount()
		{
			int loses = 0;
			
			foreach (Duel d in Matches)
			{
				if (d.Result == null || d.Result.Length == 0) continue;
				if (AccountId == d.HomePlayerId)
				{
					if (d.Result[0] < d.Result[2]) loses++;
				}
				else if (AccountId == d.GuestPlayerId)
				{
					if (d.Result[2] < d.Result[0]) loses++;
				}
			}
			return loses;
		}
		public int GetRank()
		{
			int rank = 1;
			using (var db = new TennisOrganizerContext())
			{
				var ranking = (from p in db.Players
							   where p.AccountId != AccountId //&& !(p is Trainer)
							   orderby p.SkillLevel descending
							   select p);
				foreach (Player p in ranking)
				{
					if (p.GetWonMatchesCount() - p.GetLostMatchesCount() >= GetWonMatchesCount() - GetLostMatchesCount())
						rank++;
				}
				if (rank < TopPosition && rank != 0)
				{
					TopPosition = rank;
				}
			}
			return rank;
		}
		public static List<PlayerStats> GetPlayersStats()
		{
			using (var db = new TennisOrganizerContext())
			{
				var players = db.Players.ToList();
				List<PlayerStats> stats = new List<PlayerStats>();

				foreach (var p in players)
					stats.Add(new PlayerStats(p));
				return stats;
			}
		}
		public int GetMonthlyMatchesCount()
		{
			int count;

			using (var db = new TennisOrganizerContext())
			{
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				count = player.Matches.Where<Duel>
					(p => p.DateOfPlay.Month == DateTime.Now.Month && p.DateOfPlay.Year == DateTime.Now.Year)
					.Count<Duel>();
			}
			return count;
		}
		public DateTime? GetLastMatchDate()
		{
			DateTime? date;
			using (var db = new TennisOrganizerContext())
			{
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var pastMatches = (from p in player.Matches
								   where p.DateOfPlay < DateTime.Now
								   orderby p.DateOfPlay
								   select p);
				if (pastMatches.Count<Duel>() > 0)
					date = pastMatches.FirstOrDefault<Duel>().DateOfPlay.Date;
				else
					date = null;
			}
			return date;
		}
		public int GetAge()
		{
			DateTime dt = DateTime.Now;
			return dt.Year - BirthDate.Year;
		}
		public List<Player> GetOpponentsBy(DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo)
		{
			using (var Context = new TennisOrganizerContext())
			{
				Player player = Context.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var playersQuery = from p in Context.Players.AsEnumerable<Player>()
								   where CanPlay(p, gameTime)
								   && p.GetAge() >= ageFrom && p.GetAge() <= ageTo
								   && p.SkillLevel >= levelFrom && p.SkillLevel <= levelTo
								   && p.AccountId != player.AccountId
								   && !(p is Trainer)
								   select p;

				return playersQuery.ToList<Player>();
			}
		}
		public List<Player> GetOpponentsBy(DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo, String city)
		{
			List<Player> players;

			using (var Context = new TennisOrganizerContext())
			{
				Player player = Context.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var playersQuery = from p in Context.Players.AsEnumerable<Player>()
								   where CanPlay(p, gameTime)
								   && p.GetAge() >= ageFrom && p.GetAge() <= ageTo
								   && p.SkillLevel >= levelFrom && p.SkillLevel <= levelTo
								   && p.AccountId != player.AccountId
								   && p.City.ToLower() == city.ToLower()
								   && !(p is Trainer)
								   select p;

				return playersQuery.ToList<Player>();
			}
			return players;
		}
		public bool CanPlay(Player player, DateTime date)
		{
			bool hasAnotherMatch;
			hasAnotherMatch = (from m in player.Matches
							   where m.DateOfPlay.Year == date.Year && m.DateOfPlay.Month == date.Month && m.DateOfPlay.Day == date.Day
							   select m).Any<Duel>();
			return !hasAnotherMatch;
		}
		public static Player GetPlayerByLogin(string login)
		{
			using (var db = new TennisOrganizerContext())
			{
				return db.Players.FirstOrDefault<Player>(p => p.Account.Login == login);
			}
		}
		public static Player GetPlayerById(int id)
		{
			using (var db = new TennisOrganizerContext())
			{
				return db.Players.FirstOrDefault<Player>(p => p.Account.AccountId == id);
			}
		}
		private bool CanPlay(DateTime date, TennisOrganizerContext db)
		{
			Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
			bool hasAnotherMatch = (from m in player.Matches
									where m.DateOfPlay.Year == date.Year && m.DateOfPlay.Month == date.Month && m.DateOfPlay.Day == date.Day
									select m).Any<Duel>();
			return !hasAnotherMatch;
		}
		public List<PlayerDuels> GetFinishedRatedDuels()
		{
			List<PlayerDuels> info = new List<PlayerDuels>();

			using (var db = new TennisOrganizerContext())
			{
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var duels = (from d in player.Matches
							 where
							 ((d.HomePlayerId == player.AccountId || d.GuestPlayerId == player.AccountId)
							 && d.Accepted == true
							 && d.Result != String.Empty
							 && DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0)
							 //&& !(d.GuestPlayer is Trainer)
							 select d);
				foreach (var d in duels)
					info.Add(new PlayerDuels(player, d));
			}
			return info;
		}
		public List<PlayerDuels> GetNotFinishedDuels()
		{
			List<PlayerDuels> info = new List<PlayerDuels>();

			using (var db = new TennisOrganizerContext())
			{
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var duels = (from d in player.Matches
							 where
							 ((d.HomePlayerId == player.AccountId || d.GuestPlayerId == player.AccountId)
							 && DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0)
							 select d);
				foreach (var d in duels)
					info.Add(new PlayerDuels(player, d));
			}
			return info;
		}
		public Duel[] GetAcceptedNotSeenDuels()
		{
			Player player = Player.GetPlayerById(AccountId);
			using (var Context = new TennisOrganizerContext())
			{
				Context.Players.Attach(player);
				Duel[] duels = (from d in player.Matches
								where
								(d.HomePlayerId == player.AccountId
								&& d.Seen == false
								&& d.Accepted == true
								&& DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0)
								select d).ToArray<Duel>();
				return duels;
			}
		}
		public Duel[] GetRejectedNotSeenDuels()
		{
			Player player = Player.GetPlayerById(AccountId);
			using (var Context = new TennisOrganizerContext())
			{
				Duel[] duels;
				Context.Players.Attach(player);
				duels = (from d in player.Matches
						 where
						 (d.HomePlayerId == player.AccountId
						 && d.Seen == false
						 && d.Accepted == false
						 && DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0)
						 select d).ToArray<Duel>();
				return duels;
			}
		}
		public Duel[] GetFinishedNotRatedDuels()
		{
			Player player = Player.GetPlayerById(AccountId);
			using (var Context = new TennisOrganizerContext())
			{
				Duel[] info;
				Context.Players.Attach(player);
				info = (from d in player.Matches
						where
						(d.HomePlayerId == player.AccountId
						&& d.Accepted == true
						&& d.Result == String.Empty
						&& DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0)
						//&& !(d.GuestPlayer is Trainer)
						select d).ToArray<Duel>();
				return info;
			}
		}
		public Duel[] GetChallengingDuels()
		{
			Duel[] list;
			Player player = Player.GetPlayerById(AccountId);
			using (var Context = new TennisOrganizerContext())
			{
				Context.Players.Attach(player);
				list = (from d in player.Matches
						where
						(d.GuestPlayerId == player.AccountId
						&& d.Accepted == null
						&& DateTime.Compare(d.DateOfPlay, DateTime.Now) > 0)
						select d).ToArray<Duel>();
			}
			return list;
		}
		public List<PlayerDuels> GetFinished()
		{
			List<PlayerDuels> info = new List<PlayerDuels>();

			using (var db = new TennisOrganizerContext())
			{
				Player player = db.Players.FirstOrDefault<Player>(p => p.AccountId == AccountId);
				var duels = (from d in player.Matches
							 where
							 ((d.HomePlayerId == player.AccountId || d.GuestPlayerId == player.AccountId)
							 && DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0)
							 select d);
				foreach (var d in duels)
					info.Add(new PlayerDuels(player, d));
			}
			return info;
		}
		public Player GetOpponentBy(int duelID)
		{
			Player player;
			using (var db = new TennisOrganizerContext())
			{
				player = (from d in db.Duels
						  where d.DuelId == duelID
						  let p = d.HomePlayerId == AccountId ? d.GuestPlayer : d.HomePlayer
						  select p).Single<Player>();
			}
			return player;
		}
		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}