using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
namespace TennisOrganizerServices
{
	[DataContract]
	public class Account
	{
		[Key, DataMember]
		public int AccountID { get; set; }
		[DataMember]
		public String Login { get; set; }
		[DataMember]
		public String Password { get; set; }
		[DataMember]
		public virtual Player Player { get; set; }

		
	}
}

		/*public static bool CheckAvailability(String login)
		{
			using (var Context = new TennisManagerContext())
			{
				var query = (from a in Context.Accounts
							 where a.Login == login
							 select a.Login);
				if (query.Contains<String>(login)) return false;
				return true;
			}
		}*/
		/*public String GetPassword()
		{
			String password;
			using (var Context = new TennisManagerContext())
			{
				//Context.Accounts.Attach(this);
				password = this.Password;
			}
			return password;
		}*/
/*public static Account GetAccountByLogin(String login)
		{
			Account acc;
			using (var Context = new TennisManagerContext())
			{
				acc = (from a in Context.Accounts
					   where a.Login == login
					   select a).FirstOrDefault<Account>();
			}
			return acc;
		}
		public static Account GetAccountById(int ID)
		{
			Account acc;
			using (var Context = new TennisManagerContext())
			{
				acc = (from a in Context.Accounts
					   where a.AccountID == ID
					   select a).FirstOrDefault<Account>();
				return acc;
			}
		}*/
		/*public void Update()
		{
			using (var Context = new TennisManagerContext())
			{
				Context.Accounts.Attach(this);
				Context.Entry<Account>(this).State = System.Data.Entity.EntityState.Modified;
				Context.SaveChanges();
			}
		}*/
