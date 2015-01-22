using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class TrainingCriteria
	{
		[Required(ErrorMessage = "Wprowadź datę spotkania")]
		[DisplayName("Data (rrrr-mm-dd)")]
		public DateTime Date { get; set; }
		[Required(ErrorMessage = "Wprowadź godzinę spotkania")]
		[DisplayName("Godzina")]
		public String Hour { get; set; }
		
		public List<Trainer> SuitableOpponents { get; set; }
		[Required(ErrorMessage = "Wprowadź numer gracza!")]
		[Range(1, int.MaxValue, ErrorMessage = "Wprowadź liczbę dodatnią")]
		[DisplayName("Wybierz numer gracza")]
		public int OpponentNumber { get; set; }
	}
}