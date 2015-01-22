using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TennisOrganizer.MVC.Models
{
	[Table("Pojedynki")]
	public class Duel
	{
		[Key]
		public int DuelId { get; set; }

		[Display(Name = "Data")]
		public DateTime DateOfPlay { get; set; }

		public bool? Accepted { get; set; }

		public bool Seen { get; set; }

		[Display(Name = "Wynik")]
		public String Result { get; set; }

		public int HomePlayerId { get; set; }

		public int GuestPlayerId { get; set; }

		public virtual Player HomePlayer { get; set; }

		public virtual Player GuestPlayer { get; set; }


		public Duel() { }
		public Duel(Player _homePlayer, Player _guestPlayer)
		{
			HomePlayer = _homePlayer;
			GuestPlayer = _guestPlayer;
		}
		public static Duel GetDuelByID(int duelID)
		{
			Duel duel;
			using (var db = new TennisOrganizerContext())
			{
				duel = db.Duels.FirstOrDefault<Duel>(d => d.DuelId == duelID);
			}
			return duel;
		}
		public override bool Equals(object obj)
		{
			if (!(obj is Duel))
				return false;
			Duel d = obj as Duel;
			return DuelId == d.DuelId;
		}
	}
}