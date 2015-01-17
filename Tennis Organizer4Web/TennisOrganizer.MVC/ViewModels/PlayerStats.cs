using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class PlayerStats
	{
		public int won { get; set; }
		public int lost { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public int Age { get; set; }
		public int TopPosition { get; set; }
		public int Position { get; set; }

		public PlayerStats(Player p)
		{
			FirstName = p.FirstName;
			LastName = p.LastName;
			Age = p.Age;
			Position = p.GetRank();
			TopPosition = p.TopPosition;
			won =  p.GetWonMatchesCount();
			lost = p.GetLostMatchesCount();
		}
	}
}