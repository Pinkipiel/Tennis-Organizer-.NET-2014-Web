using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace TennisOrganizerServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Trainer" in both code and config file together.
	public class Trainer : Player
	{
		public String Description { get; set; }

		public Trainer(String firstName, String lastName, int age, String phoneNumber, String email, float skillLevel, String imagePath, String city, int TopPosition, String description)
			: base(firstName, lastName, age, phoneNumber, email, skillLevel, imagePath, city, TopPosition)
		{
			Description = description;
		}
		public Trainer()
			: base()
		{ }

		public override string ToString()
		{
			return "(T) " + FirstName + " " + LastName;
		}
	}
}
