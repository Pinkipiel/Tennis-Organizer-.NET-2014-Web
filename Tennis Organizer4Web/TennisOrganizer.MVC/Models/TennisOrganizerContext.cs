using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TennisOrganizer.MVC.Models
{
	public class TennisOrganizerContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }

		public DbSet<Player> Players { get; set; }

		public DbSet<Duel> Duels { get; set; }

		public DbSet<Trainer> Trainers { get; set;}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Duel>()
						.HasRequired(m => m.HomePlayer)
						.WithMany(t => t.HomeMatches)
						.HasForeignKey(m => m.HomePlayerId)
						.WillCascadeOnDelete(false);

			modelBuilder.Entity<Duel>()
						.HasRequired(m => m.GuestPlayer)
						.WithMany(t => t.AwayMatches)
						.HasForeignKey(m => m.GuestPlayerId)
						.WillCascadeOnDelete(false);
		}
	}
}