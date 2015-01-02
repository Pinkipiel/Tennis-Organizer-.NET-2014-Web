using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TennisOrganizerServices
{
	[DataContract(IsReference = true)]
	[KnownType(typeof(Trainer))]

	public class Player
	{
		public Player()
		{
			HomeMatches = new List<Duel>();
			AwayMatches = new List<Duel>();
		}
		[DataMember]
		[Key, ForeignKey("Account")]
		public int AccountID { get; set; }

		[DataMember]
		public String FirstName { get; set; }
		[DataMember]
		public String LastName { get; set; }
		[DataMember]
		public int Age { get; set; }
		[DataMember]
		public String PhoneNumber { get; set; }
		[DataMember]
		public String Email { get; set; }
		[DataMember]
		public float SkillLevel { get; set; }
		[DataMember]
		public String ImagePath { get; set; }
		[DataMember]
		public String City { get; set; }
		[DataMember]
		public int TopPosition { get; set; }
		[DataMember]
		public virtual List<Duel> HomeMatches { get; set; }
		[DataMember]
		public virtual List<Duel> AwayMatches { get; set; }
		
		[NotMapped]
		public List<Duel> Matches
		{
			get
			{
				if (HomeMatches != null && AwayMatches != null)
					return HomeMatches.Union<Duel>(AwayMatches).ToList<Duel>();
				else return null;
			}
		}
		[DataMember]
		public virtual Account Account { get; set; }

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
		public override bool Equals(object obj)
		{
			if (!(obj is Player))
				return false;
			Player p = obj as Player;

			if (p.AccountID == AccountID)
				return true;
			return false;
		}
		public override int GetHashCode()
		{
			return AccountID;
		}
		public Player(String firstName, String lastName, int age, String phoneNumber, String email, float skillLevel, String imagePath, String city, int TopPosition)
		{
			HomeMatches = new List<Duel>();
			AwayMatches = new List<Duel>();
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			PhoneNumber = phoneNumber;
			Email = email;
			SkillLevel = skillLevel;
			ImagePath = imagePath;
			City = city;
			this.TopPosition = TopPosition;
		}

		private bool CanPlay(DateTime date, TennisManagerContext db)
		{
			db.Players.Attach(this);
			bool hasAnotherMatch = (from m in Matches
									where m.DateOfPlay.Year == date.Year && m.DateOfPlay.Month == date.Month && m.DateOfPlay.Day == date.Day
									select m).Any<Duel>();
			return !hasAnotherMatch;
		}
		public bool CanPlay(DateTime date)
		{
			bool hasAnotherMatch;
			using (var db = new TennisManagerContext())
			{
				//db.Players.Attach(this);
				var player = db.Players.Single<Player>(p => p.AccountID == this.AccountID);
				hasAnotherMatch = (from m in player.Matches
								   where m.DateOfPlay.Year == date.Year && m.DateOfPlay.Month == date.Month && m.DateOfPlay.Day == date.Day
								   select m).Any<Duel>();
			}
			return !hasAnotherMatch;
		}
		/*
		#region Setting Grids
		public static void SetPlayerList(DataGridView grid)
		{
			List<PlayerStats> L = new List<PlayerStats>();
			using (var db = new TennisManagerContext())
			{
				var players = from p in db.Players
							  where !(p is Trainer)
							  select p;
				foreach (Player p in players)
				{
					L.Add(new PlayerStats(p));
				}
				L.Sort();					//sortuje po Position
				grid.DataSource = L;
				db.SaveChanges();			///zapisuje zmiany odnośnie topPosition()
			}
		}
		public void SetCalendar(DataGridView grid)
		{
			using (var db = new TennisManagerContext())
			{
				db.Players.Attach(this);
				var list = ((from d in Matches
							 where DateTime.Compare(d.DateOfPlay, DateTime.Now) >= 0
							 && d.Accepted == true
							 let p = d.HomePlayerID == AccountID ? d.GuestPlayer : d.HomePlayer
							 orderby d.DateOfPlay
							 select new { p, d.DateOfPlay }).ToList());
				grid.DataSource = list;
			}
		}
		public void SetHistoryOfDuels(DataGridView grid)
		{
			using (var db = new TennisManagerContext())
			{
				db.Players.Attach(this);
				var list = ((from d in Matches
							 let o = d.HomePlayerID != AccountID ? d.GuestPlayer : d.HomePlayer
							 let p = d.HomePlayerID == AccountID ? "Ty vs " + d.GuestPlayer : d.HomePlayer + " vs Ty"
							 where DateTime.Compare(d.DateOfPlay, DateTime.Now) < 0
							 && d.Accepted == true
							 && (d.Result != null || o is Trainer)
							 orderby d.DateOfPlay
							 select new { p, d.Result, d.DateOfPlay }).ToList());
				grid.DataSource = list;
			}
		}
		#endregion
		 * */
	}
}
