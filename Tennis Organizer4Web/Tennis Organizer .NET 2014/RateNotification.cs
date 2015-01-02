using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tennis_Organizer.NET_2014
{
	public partial class RateNotification : Notification
	{
		ErrorProvider ep = new ErrorProvider();
		public RateNotification(int duelID, String p1firstName, String p1lastName, String p2firstName, String p2lastName, DateTime date)
		{
			InitializeComponent();
			PlayerName.Text = p1lastName + " vs " + p2lastName;
			Date.Text = date.ToShortDateString();
			Hour.Text = "godzina " + date.ToShortTimeString();
			DuelID = duelID;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			ep.Clear();
			Validator v = new Validator();
			String error = v.ValidateDuelResult(HomeScoreTextBox.Text, GuestScoreTextBox.Text);
			if (error != null)
			{
				ep.SetError(HomeScoreTextBox, error);
				ep.SetError(GuestScoreTextBox, error);
				return;
			}
			String result = HomeScoreTextBox.Text + ":" + GuestScoreTextBox.Text;
			SendEevent(new PlayerDecision(DuelID, true, result));
		}
	}
}
