using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisOrganizerServices
{
	internal class TennisManagerContext : DbContext
	{
		
		public DbSet<Player> Players { get; set; }
		public DbSet<Duel> Duels { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Trainer> Trainers { get; set; }

		public TennisManagerContext()
		{

			Database.SetInitializer<TennisManagerContext>(new DropCreateDatabaseIfModelChanges<TennisManagerContext>());
			Configuration.AutoDetectChangesEnabled = true;
			Configuration.LazyLoadingEnabled = true;
			Configuration.ProxyCreationEnabled = true;
			Configuration.ValidateOnSaveEnabled = false;

			/*if (this.Trainers.Count<TennisOrganizerServices.Trainer>() < 1)
			{
				Trainer t1 = new Trainer("Jan", "Kowalsky", 30, "606606606", "kowalsky@gmail.com", 7.0f, null, "Warszawa", 1, "Trener serwisu");
				Trainer t2 = new Trainer("Piotr", "Nowak", 31, "606606601", "nowak@gmail.com", 7.0f, null, "Warszawa", 1, "Trener forehandu");
				Trainer t3 = new Trainer("Ola", "Malonowska", 30, "606606607", "malina@gmail.com", 7.0f, null, "Warszawa", 1, "Trener backhandu");
				this.Trainers.Add(t1);
				this.Trainers.Add(t2);
				this.Trainers.Add(t3);
			}*/

		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{	
			modelBuilder.Entity<Duel>()
						.HasRequired(m => m.HomePlayer)
						.WithMany(t => t.HomeMatches)
						.HasForeignKey(m => m.HomePlayerID)
						.WillCascadeOnDelete(false);

			modelBuilder.Entity<Duel>()
						.HasRequired(m => m.GuestPlayer)
						.WithMany(t => t.AwayMatches)
						.HasForeignKey(m => m.GuestPlayerID)
						.WillCascadeOnDelete(false);
		}
	}
}
