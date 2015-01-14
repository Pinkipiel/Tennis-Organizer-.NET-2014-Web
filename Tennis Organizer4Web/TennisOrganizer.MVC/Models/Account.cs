using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TennisOrganizer.MVC.Models
{
	public class Account
	{
		public int AccountID { get; set; }

		public String  Login { get; set; }

		public String Password { get; set; }

		public virtual Player Player { get; set; }
	}
}