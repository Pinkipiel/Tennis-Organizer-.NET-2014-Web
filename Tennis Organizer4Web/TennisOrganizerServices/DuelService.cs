using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TennisOrganizerServices
{
	public class DuelService : IDuelService
	{
		TennisManagerContext Context;
		public DuelService()
		{
			Context = new TennisManagerContext();
		}
		public Duel ArrangeDuel(Player p1, Player p2, DateTime date)
		{
			Duel d = new Duel(p1, p2, date);
			Player player1 = Context.Players.Single<Player>(p => p.AccountID == p1.AccountID);
			Player player2 = Context.Players.Single<Player>(p => p.AccountID == p2.AccountID);
			d.HomePlayer = player1;
			d.GuestPlayer = player2;
			d = Context.Duels.Add(d);
			Context.SaveChanges();
			return d;
		}
		public Duel GetDuelByID(int duelID)
		{
			return Context.Duels.FirstOrDefault<Duel>(d => d.DuelID == duelID);
		}
		public void Rate(Duel duel, String result)
		{
			duel.Result = result;
			//Context.Duels.Attach(duel);
			var d = Context.Entry<Duel>(duel);
			d.Property(p => p.Result).IsModified = true;
			Context.SaveChanges();
		}
		public void SetSeen(Duel duel)
		{
			//duel.Seen = true;
			//Context.Duels.Attach(duel);
			var d = Context.Duels.Single<Duel>(l => l.DuelID == duel.DuelID);
			d.Seen = true;
			//var d = Context.Entry<Duel>(duel);
			//d.Property(p => p.Seen).IsModified = true;
			Context.SaveChanges();
		}
		public void Delete(Duel duel)
		{
			var d = Context.Entry<Duel>(duel);
			Context.Duels.Attach(duel);
			Context.Duels.Remove(duel);
			Context.SaveChanges();
		}
		public void MakeDecision(Duel duel, bool decision)
		{
			//duel.Accepted = decision;
			//Context.Duels.Attach(duel);
			var d = Context.Duels.Single<Duel>(l => l.DuelID == duel.DuelID);
			d.Accepted = decision;
			//d.Property(p => p.Accepted).IsModified = true;
			Context.SaveChanges();
		}

		public void Dispose()
		{
			Context.Dispose();
		}
	}
}
