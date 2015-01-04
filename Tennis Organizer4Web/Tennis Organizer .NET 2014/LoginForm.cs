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
using System.Net.Mail;
using System.Net;
using Tennis_Organizer.NET_2014.AccountService;
using System.ServiceModel;

namespace Tennis_Organizer.NET_2014
{
	public partial class LoginForm : Form
	{
		public LoginForm()
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
		private void LogInClick(object sender, EventArgs e)
		{
			TennisOrganizerServices.Account acc;
			Validator validator = new Validator();
			String error;
			LoginErrorProvider.Clear();
			if ((error = validator.ValidateIfEmpty(LoginTextBox.Text, "login")) != null)
				LoginErrorProvider.SetError(LoginTextBox, error);

			if ((error = validator.ValidatePassword(PasswordTextBox.Text)) != null)
				LoginErrorProvider.SetError(PasswordTextBox, error);

			try
			{
				using (var asc = new AccountServiceClient())
				{
					if (asc.CheckAvailability(LoginTextBox.Text) == true)
					{
						LoginErrorProvider.SetError(LoginTextBox, "Podany login nie istnieje");
						return;
					}
					// Porównuj zahashowane hasła
					//string hashedPassword = Encrypter.GetSHA256Hash(PasswordTextBox.Text);
					if ((acc = asc.GetAccountByLogin(LoginTextBox.Text, PasswordTextBox.Text)) == null)
					{
						LoginErrorProvider.SetError(PasswordTextBox, "Błędne hasło");
						return;
					}
				}
			}
			catch (EndpointNotFoundException)
			{
				TOMessageBox.Show("Brak połączenia z serwerem");
				return;
			}

			if (validator.IsError) return;


			PasswordTextBox.Clear();

			Form1 form = new Form1(acc.AccountID);
			this.Hide();
			DialogResult dr = form.ShowDialog();
			if (dr == System.Windows.Forms.DialogResult.Cancel)
				this.Show();
			else if (dr == System.Windows.Forms.DialogResult.Abort)
				Application.Exit();
		}
		private void ExitButtonClick(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void NewAccountClick(object sender, EventArgs e)
		{
			NewAccountForm newAccountForm = new NewAccountForm();
			newAccountForm.ShowDialog();
		}
		#endregion
		

		private void PasswordTextBoxKeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				LogInClick(sender, null);
			}
		}
	}
}
