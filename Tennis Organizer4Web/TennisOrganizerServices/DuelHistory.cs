using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace TennisOrganizerServices
{
	[DataContract]
	public class DuelHistory
	{
		[DataMember]
		public String player { get; set; }
		[DataMember]
		public String Result { get; set; }
		[DataMember]
		public DateTime DateOfPlay { get; set; }

		public DuelHistory(String p, String result, DateTime dateOfPlay)
		{
			player = p;
			Result = result;
			DateOfPlay = dateOfPlay;
		}
	}
}
