﻿using System;
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
			// pass: kacper
			Player p1 = new Player() { FirstName = "Adam", LastName = "Adamski", BirthDate=new DateTime(1993,9,11), City="Iława", Email="asda@asd.pl", SkillLevel=2 };
			context.Accounts.Add(new Account() { Login = "adam", Password = "/OAEQX6uiWfTuG+AbnANn9V/mM+dQcmWe6SEsMTQX60=", Player = p1 });
			context.Players.Add(p1);
			Player p2 = new Player() { FirstName = "Piotr", LastName = "Piotrowski", BirthDate = new DateTime(1990,1,1), City = "Grudziądz", Email = "zmyslowyogier@buziaczek.pl", SkillLevel = 4 };
			context.Accounts.Add(new Account() { Login = "piotr", Password = "/OAEQX6uiWfTuG+AbnANn9V/mM+dQcmWe6SEsMTQX60=", Player = p2 });
			context.Players.Add(p2);
			Player p3 = new Player() { FirstName = "Jan", LastName = "Dzban", BirthDate = new DateTime(1990,6,6), City = "Kraków", Email = "janek@gmail.com", SkillLevel = 1 };
			context.Accounts.Add(new Account() { Login = "janek", Password = "/OAEQX6uiWfTuG+AbnANn9V/mM+dQcmWe6SEsMTQX60=", Player = p3 });
			context.Players.Add(p3);
			context.SaveChanges();

			context.Duels.Add(new Duel() { Accepted = true, GuestPlayerId = p1.AccountId, HomePlayerId = p2.AccountId, Result = "3:0", Seen = true, DateOfPlay = new DateTime(2015, 1, 30, 0, 0, 0) });
			context.Duels.Add(new Duel() { Accepted = true, GuestPlayerId = p1.AccountId, HomePlayerId = p3.AccountId, Result = "1:3", Seen = true, DateOfPlay = new DateTime(2014, 12, 12, 0, 0, 0) });

			context.SaveChanges();
		}
	}
}