using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TennisOrganizer.MVC.Models
{
	[Table("Pojedynki")]
	class Duel
	{
		[Key]
		public int DuelId { get; set; }

		[Display(Name="Data")]
		public DateTime DateOfPlay { get; set; }

		public bool? Accepted { get; set; }

		public bool Seen { get; set; }

		[Display(Name="Wynik")]
		public String Result { get; set; }

		public int HomePlayerId { get; set; }

		public int GuestPlayerId { get; set; }

		public Player HomePlayer { get; set; }

		public Player GuestPlayer { get; set; }

		public Duel(Player _homePlayer, Player _guestPlayer)
		{
			HomePlayer = _homePlayer;
			GuestPlayer = _guestPlayer;
		}

	}
}
