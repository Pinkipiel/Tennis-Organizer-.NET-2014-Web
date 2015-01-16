using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TennisOrganizer.MVC.Models
{
	public class TennisOrganizerInitializer : DropCreateDatabaseIfModelChanges<TennisOrganizerContext>
	{
		protected override void Seed(TennisOrganizerContext context)
		{
			Player p = new Player() { FirstName = "Adam", LastName = "Adamski", Age=12, City="Iława", Email="asda@asd.pl", SkillLevel=2 };
			context.Accounts.Add(new Account() { Login = "adam", Password = "adam", Player = p });
			context.Players.Add(p);
			p = new Player() { FirstName = "Piotr", LastName = "Piotrowski", Age = 45, City = "Grudziądz", Email = "zmyslowyogier@buziaczek.pl", SkillLevel = 4 };
			context.Accounts.Add(new Account() { Login = "piotr", Password = "piotr", Player = p });
			context.Players.Add(p);
			p = new Player() { FirstName = "Jan", LastName = "Dzban", Age = 17, City = "Kraków", Email = "janek@gmail.com", SkillLevel = 1 };
			context.Accounts.Add(new Account() { Login = "janek", Password = "janek", Player = p });
			context.Players.Add(p);

			context.SaveChanges();
		}
	}
}