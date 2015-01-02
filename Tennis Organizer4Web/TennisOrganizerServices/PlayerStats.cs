using System;
using System.Runtime.Serialization;


namespace TennisOrganizerServices
{
	[DataContract(IsReference=true)]
	public class PlayerStats : IComparable<PlayerStats>
	{
		[DataMember]
		public int won { get; set; }
		[DataMember]
		public int lost { get; set; }
		[DataMember]
		public String FirstName { get; set; }
		[DataMember]
		public String LastName { get; set; }
		[DataMember]
		public int Age { get; set; }
		[DataMember]
		public int TopPosition { get; set; }
		[DataMember]
		public int Position { get; set; }

		public PlayerStats(Player p)
		{
			PlayerService ps = new PlayerService();
			FirstName = p.FirstName;
			LastName = p.LastName;
			Age = p.Age;
			Position = ps.GetRank(p);
			TopPosition = p.TopPosition;
			won = ps.GetWonMatchesCount(p);
			lost = ps.GetLostMatchesCount(p);
		}

		public int CompareTo(PlayerStats other)
		{
			return this.Position - other.Position;
		}
	}
}
