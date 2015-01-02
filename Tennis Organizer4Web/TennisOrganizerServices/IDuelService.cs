using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TennisOrganizerServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDuel" in both code and config file together.
	[ServiceContract]
	public interface IDuelService : IDisposable
	{
		[OperationContract]
		[ApplyDataContractResolver]
		Duel ArrangeDuel(Player p1, Player p2, DateTime date);
		
		[OperationContract]
		[ApplyDataContractResolver]
		Duel GetDuelByID(int duelID);
		
		[OperationContract]
		void Rate(Duel duel, String result);
		[OperationContract]
		void SetSeen(Duel duel);
		[OperationContract]
		void Delete(Duel duel);
		[OperationContract]
		void MakeDecision(Duel duel, bool decision);

	}
}
