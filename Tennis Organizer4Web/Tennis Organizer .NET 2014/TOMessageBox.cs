using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Tennis_Organizer.NET_2014
{
	public partial class TOMessageBox : Form
	{
		private TOMessageBox()
		{
			InitializeComponent();
		}
		
		#region Moving title bar hanlder
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCHITTEST:
					base.WndProc(ref m);
					if ((int)m.Result == HTCLIENT)
						m.Result = (IntPtr)HTCAPTION;
					return;
			}
			base.WndProc(ref m);
		}
		#endregion

		#region Mouse Click handlers
		private void ExitButtonClick(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		private void OkClick(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		private void YesButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Yes;
		}
		private void NoButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.No;
		}
		#endregion

		public static DialogResult Show(String text, MessageBoxButtons mbb = MessageBoxButtons.OK)
		{
			TOMessageBox mb = new TOMessageBox();
			if(mbb == MessageBoxButtons.YesNo)
			{
				mb.OkButton.Visible = false;
				mb.YesButton.Visible = true;
				mb.NoButton.Visible = true;
			}
			else
			{
				mb.OkButton.Visible = true;
				mb.YesButton.Visible = false;
				mb.NoButton.Visible = false;
			}
			mb.Text.Text = text;
			return mb.ShowDialog();
		}


	}
}
