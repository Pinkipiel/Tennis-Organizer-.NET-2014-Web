using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TennisOrganizerServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlayerService" in both code and config file together.
	[ServiceContract]
	public interface IPlayerService
	{
		[OperationContract]
		void AddPlayer(Player newPlayer);
		[OperationContract]
		void Update(Player player);
		[OperationContract]
		bool CanPlay(Player player, DateTime date);

		#region Searching
		[OperationContract]
		[ApplyDataContractResolver]
		Player GetPlayerByID(int accountID);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Duel> GetAcceptedNotSeenDuels(Player player);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Duel> GetRejectedNotSeenDuels(Player player);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Duel> GetFinishedNotRatedDuels(Player player);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Duel> GetChallengingDuels(Player player);
		[OperationContract]
		[ApplyDataContractResolver]
		Player GetOpponentBy(Player player, int duelID);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Player> GetOpponentsBy(Player player, DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo);
		[OperationContract(Name="GetOpponentsByCity")]
		[ApplyDataContractResolver]
		List<Player> GetOpponentsBy(Player player, DateTime gameTime, int ageFrom, int ageTo, float levelFrom, float levelTo, String city);
		[OperationContract]
		[ApplyDataContractResolver]
		List<Player> GetTrainers();
		#endregion
		#region Setting Grids
		[OperationContract]
		[ApplyDataContractResolver]
		List<PlayerStats> GetPlayerStatsList();
		[OperationContract]
		[ApplyDataContractResolver]
		List<DuelHistory> GetCalendar(Player player);
		
		[OperationContract]
		[ApplyDataContractResolver]
		List<DuelHistory> GetHistoryOfDuels(Player player);
		#endregion
		#region Player Statistics
		[OperationContract]
		int GetMatchesCount(Player player);
		[OperationContract]
		int GetMonthlyMatchesCount(Player player);
		//ranking na podstawie różnicy wygranych i przegranych meczy
		[OperationContract]
		int GetRank(Player player);
		[OperationContract]
		int GetTopPosition(Player player);
		[OperationContract]
		float GetSkillLevel(Player player);
		[OperationContract]
		DateTime? GetLastMatchDate(Player player);
		[OperationContract]
		int GetWonMatchesCount(Player player);
		[OperationContract]
		int GetLostMatchesCount(Player player);
		#endregion
	}
}
