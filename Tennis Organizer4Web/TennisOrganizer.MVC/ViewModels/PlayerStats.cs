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
		public float Level { get; set; }
		public int PlayedMatches { get; set; }
		public int MatchesInMonth { get; set; }
		public String LastMatchDate { get; set; }
		public PlayerStats(Player p)
		{
			FirstName = p.FirstName;
			LastName = p.LastName;
			Age = p.GetAge();
			Position = p.GetRank();
			TopPosition = p.TopPosition;
			won =  p.GetWonMatchesCount();
			lost = p.GetLostMatchesCount();
			Level = p.SkillLevel;
			PlayedMatches = won + lost;
			MatchesInMonth = p.GetMonthlyMatchesCount();
			
			DateTime? date = p.GetLastMatchDate();
			if (date == null)
				LastMatchDate = "(brak spotkań)";
			else
				LastMatchDate = date.ToString();
				
		}
	}
}