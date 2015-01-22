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
		[DisplayName("Data Treningu")]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
		
		[Required(ErrorMessage = "Wprowadź godzinę spotkania")]
		[DisplayName("Godzina")]
		[DataType(DataType.Time)]
		public String Hour { get; set; }
		
		public List<Trainer> SuitableOpponents { get; set; }
		[Required(ErrorMessage = "Wybierz gracza")]
		[Range(1, int.MaxValue, ErrorMessage = "Wybierz gracza")]
		[DisplayName("Wybierz numer gracza")]
		public int OpponentNumber { get; set; }
	}
}