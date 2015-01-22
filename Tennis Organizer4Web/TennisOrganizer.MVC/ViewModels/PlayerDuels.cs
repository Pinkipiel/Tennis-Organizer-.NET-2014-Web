using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class PlayerDuels
	{
		public Player Opponent { get; set; }
		public String Score { get; set; }
		public DateTime Date { get; set; }

		public PlayerDuels(Player player, Duel d)
		{
			Opponent = d.HomePlayerId == player.AccountId ? d.GuestPlayer : d.HomePlayer;
			Score = d.Result;
			Date = d.DateOfPlay;
		}
	}
}