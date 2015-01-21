using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class ChallengeCriteria
	{
		public DateTime Date { get; set; }
		public String Hour { get; set; }
		public int AgeFrom { get; set; }
		public int AgeTo { get; set; }
		public String City { get; set; }
		public float LevelFrom { get; set; }
		public float LevelTo { get; set; }
		public List<Player> SuitableOpponents { get; set; }
	}
}