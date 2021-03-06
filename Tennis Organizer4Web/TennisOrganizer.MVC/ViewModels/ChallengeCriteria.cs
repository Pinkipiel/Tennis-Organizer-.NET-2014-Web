﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class ChallengeCriteria
	{
		[Required(ErrorMessage="Wprowadź datę spotkania")]
		[DisplayName("Data Spotkania")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Required(ErrorMessage = "Wprowadź godzinę spotkania")]
		[DisplayName("Godzina")]
		public String Hour { get; set; }
		
		[DisplayName("Wiek od")]
		public int? AgeFrom { get; set; }
		
		[DisplayName("do")]
		public int? AgeTo { get; set; }
		
		[DisplayName("Miasto")]
		public String City { get; set; }
		
		[DisplayName("Poziom od")]
		public float? LevelFrom { get; set; }
		
		[DisplayName("do")]
		public float? LevelTo { get; set; }
		
		public List<Player> SuitableOpponents { get; set; }
		
		[Required(ErrorMessage = "Wprowadź numer gracza!")]
		[Range(1, int.MaxValue, ErrorMessage = "Wprowadź liczbę dodatnią")]
		[DisplayName("Wybierz numer gracza")]
		public int OpponentNumber { get; set; }
	}
}