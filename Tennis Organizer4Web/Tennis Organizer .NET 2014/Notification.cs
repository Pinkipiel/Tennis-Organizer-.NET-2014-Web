using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tennis_Organizer.NET_2014
{
	public abstract class Notification : UserControl
	{
		public event EventHandler GotAnswer;
		protected int DuelID;

		protected void SendEevent(PlayerDecision playerDecision)
		{
			GotAnswer(this, playerDecision);
		}
	}

	public class PlayerDecision : EventArgs
	{
		public int DuelID;
		public bool Accepted = true;
		public String Score = String.Empty;

		public PlayerDecision(int duelID, bool decision, String score)
		{
			DuelID = duelID;
			Accepted = decision;
			Score = score;
		}
		public PlayerDecision(int duelID, bool decision) : this (duelID, decision, String.Empty) { }
		public PlayerDecision(int duelID, String score) : this(duelID, true, score) { }
	}
}
