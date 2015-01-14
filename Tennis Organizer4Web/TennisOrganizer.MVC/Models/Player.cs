using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TennisOrganizer.MVC.Models
{
	class Player
	{
		[Key, ForeignKey("Account")]
		public int AccountID { get; set; }

		public String FirstName { get; set; }

		public String LastName { get; set; }

		public int Age { get; set; }

		public String PhoneNumber { get; set; }

		public String Email { get; set; }

		public float SkillLevel { get; set; }

		public String ImagePath { get; set; }

		public String City { get; set; }

		public int TopPosition { get; set; }

		public virtual ICollection<Duel> HomeMatches { get; set; }

		public virtual ICollection<Duel> AwayMatches { get; set; }
	}
}
