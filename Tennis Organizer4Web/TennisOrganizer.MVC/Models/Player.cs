using System;
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
		[Range(0, 200)]
		[Display(Name = "Wiek")]
		public int Age { get; set; }

		[Display(Name="Telefon")]
		[DataType(DataType.PhoneNumber)]
		public String PhoneNumber { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
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

		public virtual IEnumerable<Duel> HomeMatches { get; set; }

		public virtual IEnumerable<Duel> AwayMatches { get; set; }

		public IEnumerable<Duel> Matches
		{
			get
			{
				return HomeMatches.Union<Duel>(AwayMatches);
			}
		}

		public virtual Account Account { get; set; }

		public int GetWonMatchesCount(Player player)
		{
			int wins = 0;

			foreach (Duel d in player.Matches)
			{
				if (d.Result == null || d.Result.Length == 0) continue;
				if (player.AccountId == d.HomePlayerId)
				{
					if (d.Result[0] > d.Result[2]) wins++;
				}
				else if (player.AccountId == d.GuestPlayerId)
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
				if (player.AccountId == d.HomePlayerId)
				{
					if (d.Result[0] < d.Result[2]) loses++;
				}
				else if (player.AccountId == d.GuestPlayerId)
				{
					if (d.Result[2] < d.Result[0]) loses++;
				}
			}
			return loses;
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

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}