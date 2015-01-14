using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TennisOrganizer.MVC.Models
{
	public class TennisManagerContext : DbContext
	{
		public DbSet<Account> Accounts {get; set;}
		public DbSet<Player> Players { get; set; }
		public DbSet<Duel> Duels { get; set; }

	}
}