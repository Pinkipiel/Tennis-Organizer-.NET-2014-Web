using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TennisOrganizerServices
{
	[DataContract]
	public class Duel
	{
		[DataMember]
		public int DuelID { get; set; }
		[DataMember]
		public DateTime DateOfPlay { get; set; }
		[DataMember]
		public bool? Accepted { get; set; }
		[DataMember]
		public bool Seen { get; set; }
		[DataMember]
		public String Result { get; set; }
		[DataMember]
		public int HomePlayerID { get; set; }
		[DataMember]
		public int GuestPlayerID { get; set; }
		[DataMember]
		public virtual Player HomePlayer { get; set; }
		[DataMember]
		public virtual Player GuestPlayer { get; set; }

		public Duel()
		{

		}
		public Duel(Player p1, Player p2)
		{
			HomePlayer = p1;
			GuestPlayer = p2;
		}
		public Duel(Player p1, Player p2, DateTime Date)
		{
			DateOfPlay = Date;
			Accepted = null;
			Result = String.Empty;
			Seen = false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Duel))
				return false;
			Duel d = obj as Duel;
			return DuelID == d.DuelID;
		}
	}
}
