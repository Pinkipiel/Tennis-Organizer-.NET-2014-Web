using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tennis_Organizer.NET_2014.AccountService;

namespace Tennis_Organizer.NET_2014
{
	public partial class NewAccountForm : Form
	{

		#region Stałe
		private String[] cSkillLevelDescriptions = new String[]{
								"Ten gracz dopiero rozpoczyna grę w tenisa",
								"Ma ograniczone doświadczenie i ciągle głównie koncentruje się na utrzymaniu piłki w korcie.",
								"Potrzebuje doświadczenia kortowego (ogrania). Ma widoczne braki w technice, ma pojęcie o podstawach gry singlowej i deblowej.",
								"Uczy się oceniać lot piłki ale ma słabą umiejętność krycia kortu. Wytrzymuje krótkie wymiany prowadzone w wolnym tempie z graczami o podobnych umiejętnościach.",
								"Radzi sobie z uderzeniami granymi w średnim tempie. Nie czuje się komfortowo przy wszystkich uderzeniach. Ma kłopoty z uzyskaniem odpowiedniej kontroli, głębokości i siły uderzeń. W deblu gra w ustawieniu jeden z przodu jeden z tyłu (pamiętajmy, w deblu staramy się dążyć do uzyskania i utrzymania linii równoległej do siatki)",
								"Umie wybierać uderzenia w zależności od sytuacji ale nadal ma problem z ich głębokością i z ich doborem. Zaczyna wykazywać pewną agresję w grze przy siatce, poprawił krycie kortu i uczy się pracy zespołowej w deblu.",
								"Umie dobierać uderzenia pod względem kontroli, głębokości z forhendu i bekhebdu przy różnych zagraniach plus zdolność do grania z powodzeniem lobów, smeczy, uderzeń przygotowawczych do ataku przy siatce i wolejem. Czasem wymusza błędy serwisem i widać u niego umiejętność gry zespołowej w deblu. Może przegrywać wymiany przez niecierpliwość.",
								"Zaczyna nabywać umiejętność posługiwania się siłą i rotacją i zaczyna radzić sobie z tempem, ma dobrą pracę nóg, umie kontrolować głebokość zagrań i zaczyna dobierać taktykę do danego przeciwnika. Umie uderzać pierwszy serwis silnie i dokładnie i plasować drugi serwis. Ma tendencję do „przestrzeliwania” trudnych zagrań. W deblu gra agresywnie (ofensywnie).",
								"Ma dobrą antycypację uderzeń i czasami zagrywa efektowne piłki. Posiada regularność, na której może opierać grę. Umie grać regularne winnery i wymuszać błędy przeciwnika po jego krótkich piłkach. Umie operować wolejem (kończyć nim). Umie grać loby, skróty, półwoleje i smecze. Umie uzyskać odpowiednią głębokość uderzeń i rotację przy większości drugich serwisów.",
								"Jego główną bronią, którą rozwiną, jest siła i/lub regularność. Może zmieniać taktykę i styl gry w czasie meczu i umie grać efektywnie pod presją.",
								"Zasadniczo nie potrzebuje wskaźnika NTRP. Obecne rankingi i dawne rankingi mówią za niego. Ten gracz jest notowany w krajowych rankingach.",
								"Ma szerokie doświadczenie w turniejach satelitarnych",
								"Żyje z tenisa - zawodowiec" };
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		#endregion

		private String PicturePath;
		private TennisOrganizerServices.Account Account;
		private TennisOrganizerServices.Player Player;
		public NewAccountForm()
		{
			InitializeComponent();
		}
		#region Działanie paska okna
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCHITTEST:
					base.WndProc(ref m);
					// Lparam - LOWORD zawiera pozycję x kursora myszy, HIWORD zawiera pozycję y
					if ((int)m.Result == HTCLIENT)
					{
						int x = m.LParam.ToInt32() & 0x0000FFFF;						//LOWORD z Lparam
						int y = (int)((m.LParam.ToInt32() & 0xFFFF0000)>>16);			//HIWORD z Lparam
						Point CursorPosition = new Point(x, y);
						Point RelativeCursorPosition = this.PointToClient(CursorPosition);
						if(RelativeCursorPosition.Y < CloseButton.Height)				//wysokość "paska" do przenoszenia okna jest określona wysokością przycisku zamykania
							m.Result = (IntPtr)HTCAPTION;
					}
					return;
			}
			base.WndProc(ref m);
		}
		#endregion

		#region Obsługa kliknięć na przyciski
		private void NewAccountClick(object sender, EventArgs e)
		{
			Validator validator = new Validator();
			LoginErrorProvider.Clear();
			String error = validator.ValidateLogin(LoginTextBox.Text);
			if (error != null) LoginErrorProvider.SetError(LoginTextBox, (String)error);
			error = validator.ValidatePassword(PasswordTextBox.Text);
			if (error != null) LoginErrorProvider.SetError(PasswordTextBox, error);
			error = validator.ValidateRepeatedPassword(PasswordTextBox.Text, RepeatPasswordTextBox.Text);
			if (error != null) LoginErrorProvider.SetError(RepeatPasswordTextBox, error);
			AccountServiceClient asc = new AccountServiceClient();
			if(validator.IsError) return;
			if (asc.CheckAvailability(LoginTextBox.Text) == false)
			{
				LoginErrorProvider.SetError(LoginTextBox, "Podany login jest już zajęty!");
				return;
			}

			LoginTextBox.Enabled = false;
			PasswordLabel.Enabled = false;
			RepeatPasswordLabel.Enabled = false;
			NewAccountButton.Enabled = false;
			NewAccountButton.BackColor = Color.Gray;
			NewAccountGroupBox.Enabled = false;
			button1.Enabled = false;
			button1.FlatAppearance.BorderColor = Color.Gray;
			NewAccountGroupBox.BackColor = Color.Gray;

			/////////////////////////////////////////////
			ProfileGroupBox.Enabled = true;
			ProfileGroupBox.BackColor = SystemColors.MenuHighlight;
			NameTextBox.Enabled = true;
			LastNameTextBox.Enabled = true;
			CityTextBox.Enabled = true;
			PhoneTextBox.Enabled = true;
			EmailTextBox.Enabled = true;
			SkillLevelComboBox.Enabled = true;
			FillProfileButton.Enabled = true;
			FillProfileButton.BackColor = Color.FromArgb(145,205,255);
			button2.FlatAppearance.BorderColor = Color.White;
			button2.Enabled = true;
			SelectPictureButton.Enabled = true;
			SelectPictureButton.BackColor = Color.FromArgb(145, 205, 255);
			AgeTextBox.Enabled = true;
			CityTextBox.Enabled = true;

			CityLabel.Enabled = true;
			AgeLabel.Enabled = true;
			SelectPictureLabel.Enabled = true;
			NameLabel.Enabled = true;
			LastNameLabel.Enabled = true;
			CityLabel.Enabled = true;
			PhoneLabel.Enabled = true;
			EmailLabel.Enabled = true;
			SkillLevelLabel.Enabled = true;
			
		}

		private void SelectPictureButtonClick(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png";
			fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				PicturePath = fileDialog.FileName;
			}
		}

		private void FillProfileButtonClick(object sender, EventArgs e)
		{
			Validator validator = new Validator();
			FillProfileErrorProvider.Clear();
			int age = 0;
			
			String error = validator.ValidateAge(AgeTextBox.Text);
			if(error != null)
				FillProfileErrorProvider.SetError(AgeTextBox, error);

			
			if((error = validator.ValidateIfEmpty(NameTextBox.Text, "Imię")) !=  null)
				FillProfileErrorProvider.SetError(NameTextBox, error);

			if((error = validator.ValidateIfEmpty(LastNameTextBox.Text, "Nazwisko")) != null)
				FillProfileErrorProvider.SetError(LastNameTextBox, error);

			if ((error = validator.ValidatePhoneNumber(PhoneTextBox.Text)) != null)
				FillProfileErrorProvider.SetError(PhoneTextBox, error);

			if ((error = validator.ValidateEmail(EmailTextBox.Text)) != null)
				FillProfileErrorProvider.SetError(EmailTextBox, error);

			if((error = validator.ValidateIfEmpty(CityTextBox.Text, "Miasto")) != null)
				FillProfileErrorProvider.SetError(CityTextBox, error);
			
			if (validator.IsError) return;

			age = Int32.Parse(AgeTextBox.Text);
			Player = new TennisOrganizerServices.Player()
			{
				Age = age,
				FirstName = NameTextBox.Text,
				LastName = LastNameTextBox.Text,
				PhoneNumber = PhoneTextBox.Text,
				Email = EmailTextBox.Text,
				ImagePath = PicturePath,
				City = CityTextBox.Text,
				TopPosition = Int32.MaxValue
			};
			NameLabel.Enabled = false;
			LastNameLabel.Enabled = false;
			PhoneLabel.Enabled = false;
			EmailLabel.Enabled = false;
			AgeLabel.Enabled = false;
			SelectPictureLabel.Enabled = false;
			SelectPictureButton.Enabled = false;
			FillProfileButton.Enabled = false;
			button2.Enabled = false;
			ProfileGroupBox.Enabled = false;
			ProfileGroupBox.BackColor = Color.Gray;
			button2.FlatAppearance.BorderColor = Color.Gray;
			SelectPictureButton.BackColor = Color.Gray;
			FillProfileButton.BackColor = Color.Gray;
			CityLabel.Enabled = false;
			CityTextBox.Enabled = false;
			//////////////
			button3.Enabled = true;
			AddressGroupBox.Enabled = true;
			SkillLevelLabel.Enabled = true;
			SkillLevelComboBox.Enabled = true;
			
			LevelDescriptionLabel.Enabled = true;
			CreateAccountButton.Enabled = true;
			CreateAccountButton.BackColor = Color.FromArgb(145, 205, 255);

			AddressGroupBox.BackColor = SystemColors.MenuHighlight;
			button3.FlatAppearance.BorderColor = Color.White;
		}

		private void SkillLevelSelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			LevelDescriptionLabel.Text = cSkillLevelDescriptions[comboBox.SelectedIndex];
		}

		private void CreateAccountButtonClick(object sender, EventArgs e)
		{
			if (SkillLevelComboBox.SelectedIndex == -1)
			{
				FillProfileErrorProvider.SetError(SkillLevelComboBox, "Wybierz poziom umiejętności");
				return;
			}
			FillProfileErrorProvider.Clear();
			Player.SkillLevel = 1.0f + 0.5f * SkillLevelComboBox.SelectedIndex;
			
			using(AccountServiceClient asc = new AccountServiceClient())
			{
				Account = asc.CreateAccount(Player, LoginTextBox.Text, PasswordTextBox.Text);//PasswordTextBox.Text); ///
			}
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		#endregion
	}
}	
