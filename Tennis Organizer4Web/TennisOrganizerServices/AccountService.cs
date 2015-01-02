using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
namespace TennisOrganizerServices
{
	public class AccountService : IAccountService
	{
		TennisManagerContext Context = new TennisManagerContext();
		
		public Account CreateAccount(Player player, string login, string password)
		{
			//sprawdź czy dane konto nie jest już zarejestrowane
			if (Context.Accounts.FirstOrDefault<Account>(a => a.Login == login) != null) return null;
			player.TopPosition = Context.Accounts.Count<Account>();
			Account acc = new Account()
			{
				Login = login,
				Password = password,
				Player = player
			};
			//pobierz acc z aktualnym ID
			acc = Context.Accounts.Add(acc);
			Context.SaveChanges();
			return acc;

		}
		
		public bool UpdateAccountPassword(string login, string oldPassword, string newPassword)
		{
			var acc = Context.Accounts.FirstOrDefault<Account>(a => a.Login == login);
			if (acc.Password != oldPassword) return false;
			else acc.Password = newPassword;
			Context.SaveChanges();

			return true;
		}
		
		public bool CheckAvailability(string login)
		{
			if (Context.Accounts.FirstOrDefault<Account>(acc => acc.Login == login) != null) return false;
			else return true;
			
		}
		
		public Account GetAccount(int id, string password)
		{
			var acc = (from a in Context.Accounts
					   where a.AccountID == id
					   select a).FirstOrDefault<Account>();
			if (acc.Password != password) return null;
			return acc;
		}
		
		public Account GetAccount(string login, string password)
		{
			var acc = Context.Accounts.FirstOrDefault<Account>(a => a.Login == login);
			if (acc.Password != password) return null;
			else return acc;
		}
	}
}
