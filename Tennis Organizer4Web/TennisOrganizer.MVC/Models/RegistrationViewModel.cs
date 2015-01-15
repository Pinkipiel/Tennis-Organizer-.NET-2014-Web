using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TennisOrganizer.MVC.Models
{
	public class RegistrationViewModel
	{
		public Account Account { get; set; }

		[DataType(DataType.Password)]
		[MinLength(3)]
		[Display(Name="Powtórz hasło")]
		[CompareAttribute("Account.Password", ErrorMessage = "Hasła są różne")]
		public String RepeatedPassword { get; set; }

		public Player Player { get; set; }
	}
}
