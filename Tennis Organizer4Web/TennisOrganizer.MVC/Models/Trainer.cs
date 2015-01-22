using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TennisOrganizer.MVC.Models
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Trainer" in both code and config file together.
	public class Trainer : Player
	{
		public String Description { get; set; }

		public Trainer()
			: base()
		{ }

		public static List<Trainer> GetTrainersList()
		{
			using(var db = new TennisOrganizerContext())
			{
				var query = (from t in db.Trainers
							 where t is Trainer
							 select t);
				return query.ToList<Trainer>();
			}
		}
		public override string ToString()
		{
			return "(T) " + FirstName + " " + LastName;
		}
	}
}
