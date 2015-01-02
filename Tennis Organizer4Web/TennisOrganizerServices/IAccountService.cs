using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TennisOrganizerServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
	[ServiceContract]
	public interface IAccountService
	{
		[OperationContract]
		[ApplyDataContractResolver]
		Account CreateAccount(Player p, string login, string password);
	
		/// <summary>
		/// Zwraca konto na podstawie ID jeżeli podane hasło jest poprawne, w p.p. null
		/// </summary>
		[OperationContract]
		[ApplyDataContractResolver]
		Account GetAccount(int id, string password);

		/// <summary>
		/// Zwraca konto jeżeli podane do niego hasło jest poprawne
		/// </summary>
		[OperationContractAttribute(Name="GetAccountByLogin")]
		[ApplyDataContractResolver]
		Account GetAccount(string login, string password);
		
		/// <summary>
		/// Zwraca true jeżeli udało się zmienić hasło, false, jeżeli podane stare hasło jest błędne
		/// </summary>
		[OperationContract]
		bool UpdateAccountPassword(string login, string oldPassword, string newPassword);

		/// <summary>
		/// Zwraca true, jeżeli podany login nie jest jeszcze zajęty
		/// </summary>
		[OperationContract]
		bool CheckAvailability(string login);
	}
}
