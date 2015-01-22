using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TennisOrganizer.MVC.Models;

namespace TennisOrganizer.MVC.ViewModels
{
	public class AccountEditorData
	{
		[Required(ErrorMessage = "Wymagana nazwa użytkownika")]
		[Display(Name = "Użytkownik")]
		public String Login { get; set; }

		[Required(ErrorMessage = "Wprowadź swoje hasło")]
		[MinLength(3, ErrorMessage = "Hasło musi zawierać co najmniej 3 znaki")]
		[StringLength(30, MinimumLength = 3, ErrorMessage = "Hasło musi zawierać co najmniej 3 znaki")]
		[Display(Name = "Hasło")]
		[DataType(DataType.Password)]
		public String Password { get; set; }

		[MinLength(3)]
		[DataType(DataType.Password)]
		[Display(Name = "Powtórz hasło")]
		[CompareAttribute("Password", ErrorMessage = "Hasła są różne")]
		public String RepeatedPassword { get; set; }

		[MinLength(3)]
		[DataType(DataType.Password)]
		[Display(Name = "Nowe hasło")]
		public String NewPassword { get; set; }
	}
}