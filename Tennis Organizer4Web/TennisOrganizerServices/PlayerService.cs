using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;


namespace TennisOrganizerServices
{

	public class PlayerService : IPlayerService, IDisposable
	{
		TennisManagerContext Context;
		public PlayerService()
		{
			Context = new TennisManagerContext();
		}
		public void AddPlayer(Player newPlayer)
		{
			Context.Configuration.ProxyCreationEnabled = false;
			newPlayer.AwayMatches = new List<Duel>();
			newPlayer.HomeMatches = new List<Duel>();
			Context.Players.Add(newPlayer);
			Context.SaveChanges();
		}
		public void Update(Player player)
		{
			Context.Players.Attach(player);
			Context.Entry<Player>(player).State = System.Data.Entity.EntityState.Modified;
			Context.SaveChanges();
		}
		public bool CanPlay(Player player, DateTime date)
		{
			bool hasAnotherMatch;
			//Context.Players.Attach(player);
			hasAnotherMatch = (from m in player.Matches
									where m.DateOfPlay.Year == date.Year && m.DateOfPlay.Month == date.Month && m.DateOfPlay.Day == date.Day
									select m).Any<Duel>();
			return !hasAnotherMatch;
		}

		#region Searching
		public Player GetPlayerByID(int accountID)
		{
			return (from p in Context.Players where p.AccountID == accountID select p).Single<Player>();
		}
		public List<Duel> GetAcceptedNotSeenDuels(Player player)
		{
			//Context.Players.Attach(player);
			List<Duel> duels = (from d in player.Matches
						where
						(d.HomePlayerID == player.AccountID
						&& d.Seen == false
						&& d.Accepted == true
						&& DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0)
						select d).ToList<Duel>();
			return duels;
		}
		public List<Duel> GetRejectedNotSeenDuels(Player player)
		{
			List<Duel> duels;
			//Context.Players.Attach(player);
			duels = (from d in player.Matches
						where
						(d.HomePlayerID == player.AccountID
						&& d.Seen == false
						&& d.Accepted == false
						&& DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0)
						select d).ToList<Duel>();
			return duels;
		}
		public List<Duel> GetFinishedNotRatedDuels(Player player)
		{
			List<Duel> info;
			//Context.Players.Attach(player);
			info = (from d in player.Matches
					where
					(d.HomePlayerID == player.AccountID
					&& d.Accepted == true
					&& d.Result == String.Empty
					&& DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0)
					&& !(d.GuestPlayer is Trainer)
					select d).ToList<Duel>();
			return info;
		}
		public List<Duel> GetChallengingDuels(Player player)
		{
			List<Duel> list;
//			Context.Players.Attach(player);
			list = (from d in player.Matches
					where
					(d.GuestPlayerID == player.AccountID
					&& d.Accepted == null
					&& DateTime.Compare(d.DateOfPlay, DateTime.Now) > 0)
					select d).ToList<Duel>();
			return list;
		}
		public Player GetOpponentBy(Player player, int duelID)
		{
			Player pl = (from d in Context.Duels
							where d.DuelID == duelID
							let p = d.HomePlayerID == player.AccountID ? d.GuestPlayer : d.HomePlayer
							select p).Single<Player>();
			return pl;
		}
		public List<Player> GetOpponentsBy(Player player, DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo)
		{
			var playersQuery = from p in Context.Players.AsEnumerable<Player>()
								where CanPlay(player, gameTime)
								&& p.Age >= ageFrom && p.Age <= ageTo
								&& p.SkillLevel >= levelFrom && p.SkillLevel <= levelTo
								&& p.AccountID != player.AccountID
								&& !(p is Trainer)
								select p;

				return playersQuery.ToList<Player>();
		}
		public List<Player> GetOpponentsBy(Player player, DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo, String city)
		{
			var playersQuery = from p in Context.Players.AsEnumerable<Player>()
								where p.CanPlay(gameTime)
								&& p.Age >= ageFrom && p.Age <= ageTo
								&& p.SkillLevel >= levelFrom && p.SkillLevel <= levelTo
								&& p.AccountID != player.AccountID
								&& p.City == city
								&& !(p is Trainer)
								select p;
			return playersQuery.ToList<Player>();
		}
		#endregion
		#region Setting Grids
		public List<PlayerStats> GetPlayerStatsList()
		{
			List<PlayerStats> L = new List<PlayerStats>();
			var players = from p in Context.Players
							where !(p is Trainer)
							select p;
			foreach (Player p in players)
			{
				L.Add(new PlayerStats(p));
			}
			L.Sort();					//sortuje po Position
			Context.SaveChanges();			///zapisuje zmiany odnośnie topPosition()
			return L;
		}
		
		public List<DuelHistory> GetCalendar(Player player)
		{
			List<DuelHistory> L = new List<DuelHistory>();
			//Context.Players.Attach(player);
			var list = ((from d in player.Matches
							where DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0
							&& d.Accepted == true
							let p = d.HomePlayerID == player.AccountID ? d.GuestPlayer : d.HomePlayer
							orderby d.DateOfPlay
							select new { p, d.DateOfPlay }).ToList());
			foreach (var v in list)
			{
				L.Add(new DuelHistory(v.p.ToString(), null, v.DateOfPlay));
			}
			//L.Sort();
			return L;
		}
		
		public List<DuelHistory> GetHistoryOfDuels(Player player)
		{
			List<DuelHistory> L = new List<DuelHistory>();
			//Context.Players.Attach(player);
			var list = ((from d in player.Matches
							let o = d.HomePlayerID != player.AccountID ? d.GuestPlayer : d.HomePlayer
							let p = d.HomePlayerID == player.AccountID ? "Ty vs " + d.GuestPlayer : d.HomePlayer + " vs Ty"
							where DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0
							&& d.Accepted == true
							&& (d.Result != null || o is Trainer)
							orderby d.DateOfPlay
							select new { p, d.Result, d.DateOfPlay }).ToList());
			foreach (var v in list)
			{
				L.Add(new DuelHistory(v.p, v.Result, v.DateOfPlay));
			}
			return L;
		}
		#endregion
		#region Player Statistics
		public int GetMatchesCount(Player player)
		{
			int count;
			//Context.Players.Attach(player);
			count = player.Matches.Where<Duel>(p => p.DateOfPlay < DateTime.Now && p.Accepted == true).Count<Duel>();
			return count;
		}
		public int GetMonthlyMatchesCount(Player player)
		{
			int count;
			//Context.Players.Attach(player);
			count = player.Matches.Where<Duel>
				(p => p.DateOfPlay.Month == DateTime.Now.Month && p.DateOfPlay.Year == DateTime.Now.Year)
				.Count<Duel>();
			return count;
		}
		//ranking na podstawie różnicy wygranych i przegranych meczy
		public int GetRank(Player player)
		{
			int rank = 1;
			var ranking = (from p in Context.Players
							orderby p.SkillLevel descending
							where p.AccountID != player.AccountID && !(p is Trainer)
							select p); /*.AccountID).Count<int>() + 1;*/		//+1 ponieważ mając 0 graczy nad sobą jesteśmy pierwsi w rankingu, nie zerowi
			foreach (Player p in ranking)
			{
				if (GetWonMatchesCount(p) - GetLostMatchesCount(p) >= GetWonMatchesCount(player) - GetLostMatchesCount(player))
					rank++;
			}
			if (rank < player.TopPosition && rank != 0)
			{
				player.TopPosition = rank;
			}
			return rank;
		}
		public int GetTopPosition(Player player)
		{
			return player.TopPosition;
		}
		public float GetSkillLevel(Player player)
		{
			return player.SkillLevel;
		}
		public DateTime? GetLastMatchDate(Player player)
		{
			DateTime? date;
			//Context.Players.Attach(player);
			var pastMatches = (from p in player.Matches
								where p.DateOfPlay < DateTime.Now
								orderby p.DateOfPlay
								select p);
			if (pastMatches.Count<Duel>() > 0)
				date = pastMatches.FirstOrDefault<Duel>().DateOfPlay.Date;
			else
				date = null;
			return date;
		}
		public int GetWonMatchesCount(Player player)
		{
			int wins = 0;
			//db.Players.Attach(player);
			foreach (Duel d in player.Matches)
			{
				if (d.Result == null || d.Result.Length == 0) continue;
				if (player.AccountID == d.HomePlayerID)
				{
					if (d.Result[0] > d.Result[2]) wins++;
				}
				else if (player.AccountID == d.GuestPlayerID)
				{
					if (d.Result[2] > d.Result[0]) wins++;
				}
			}
			return wins;
		}
		public int GetLostMatchesCount(Player player)
		{
			int loses = 0;
			//db.Players.Attach(this);
			foreach (Duel d in player.Matches)
			{
				if (d.Result == null || d.Result.Length == 0) continue;
				if (player.AccountID == d.HomePlayerID)
				{
					if (d.Result[0] < d.Result[2]) loses++;
				}
				else if (player.AccountID == d.GuestPlayerID)
				{
					if (d.Result[2] < d.Result[0]) loses++;
				}
			}
			return loses;
		}
		#endregion

		public void Dispose()
		{
			Context.Dispose();
		}

		public List<Player> GetTrainers()
		{
			List<Player> L = new List<Player>();
			var players = from p in Context.Players
						  where p is Trainer
						  select p;
			foreach (Player p in players)
			{
				L.Add(p);
			}
			Context.SaveChanges();			///zapisuje zmiany odnośnie topPosition()
			return L;
		}
	}
}
