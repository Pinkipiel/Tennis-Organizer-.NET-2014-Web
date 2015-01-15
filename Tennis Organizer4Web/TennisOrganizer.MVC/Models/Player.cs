using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TennisOrganizer.MVC.Models
{
	[Table("Gracze")]
	public class Player
	{
		[Display(Name = "Numer Gracza")]
		[Key, ForeignKey("Account")]
		public int AccountId { get; set; }

		[Required(ErrorMessage="Pole Wymagane")]
		[Display(Name = "Imię")]
		public String FirstName { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[Display(Name = "Nazwisko")]
		public String LastName { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[Range(0, 200)]
		[Display(Name = "Wiek")]
		public int Age { get; set; }

		[Display(Name="Telefon")]
		[DataType(DataType.PhoneNumber)]
		public String PhoneNumber { get; set; }

		[Required(ErrorMessage = "Pole Wymagane")]
		[DataType(DataType.EmailAddress)]
		public String Email { get; set; }

		[Display(Name="Poziom umiejętności")]
		[Required(AllowEmptyStrings=true)]
		public float SkillLevel { get; set; }

		public String ImagePath { get; set; }
		
		[Required(ErrorMessage="Pole Wymagane")]
		[Display(Name="Miejscowość")]
		public String City { get; set; }

		public int TopPosition { get; set; }

		public virtual IEnumerable<Duel> HomeMatches { get; set; }

		public virtual IEnumerable<Duel> AwayMatches { get; set; }

		public IEnumerable<Duel> Matches
		{
			get
			{
				return HomeMatches.Union<Duel>(AwayMatches);
			}
		}

		public virtual Account Account { get; set; }

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}
	}
}