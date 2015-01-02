using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TennisOrganizerServices;
using System.ServiceModel;

namespace TennisOrganizerHost
{
	public partial class HostForm : Form
	{
		private ServiceHost AccountHost, DuelHost, PlayerHost;
		public HostForm()
		{
			InitializeComponent();
		}

		private void TurnOn_Click(object sender, EventArgs e)
		{
			AccountHost = new ServiceHost(typeof(AccountService));
			DuelHost = new ServiceHost(typeof(DuelService));
			PlayerHost = new ServiceHost(typeof(PlayerService));

			AccountHost.Open();
			Info.Text = "Account Host open\n";
			DuelHost.Open();
			Info.Text += ", Duel Host open\n";
			PlayerHost.Open();
			Info.Text += ", Player Host open\n";

			TurnOn.Enabled = false;
			TurnOff.Enabled = true;
		}

		private void TurnOff_Click(object sender, EventArgs e)
		{
			AccountHost.Close();
			DuelHost.Close();
			PlayerHost.Close();
			Info.Text = String.Empty;

			TurnOff.Enabled = false;
			TurnOn.Enabled = true;
		}
	}
}
