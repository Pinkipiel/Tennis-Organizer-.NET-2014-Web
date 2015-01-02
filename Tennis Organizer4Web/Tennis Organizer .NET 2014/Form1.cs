using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Tennis_Organizer.NET_2014.AccountService;
using Tennis_Organizer.NET_2014.PlayerService;
using Tennis_Organizer.NET_2014.DuelService;

namespace Tennis_Organizer.NET_2014
{
	public partial class Form1 : Form
	{
		TennisOrganizerServices.Player LoggedInPlayer;
		List<Notification> notifications;
		
		public Form1(int accountID)
		{
			/*
			using(var Context = new TennisManagerContext())
			{
				if(Context.Trainers.Count<Trainer>() == 0)
				{
					Account t1acc = new Account() { Login = "jannowak", Password = "asdf" },
							t2acc = new Account() { Login = "annakowalska", Password = "asdf" },
							t3acc = new Account() { Login = "adamadamiecki", Password = "asdf" }; 
					Trainer t1 = new Trainer("Jan", "Nowak", 30, "600500400", "jan.nowak@gmail.com", 7.0f, null, "Warszawa", 1, "Trener dla początkujacych");
					Trainer t2 = new Trainer("Anna", "Kowalska", 27, "700600500", "akowalska@gmail.com", 7.0f, null, "Kraków", 1, "Trener serwisu");
					Trainer t3 = new Trainer("Adam", "Adamiecki", 32, "800700600", "adamadamiecki@o2.pl", 7.0f, null, "Wrocław", 1, "Trener backhandu i forehandu");
					t1acc.Player = (Player)t1;
					t2acc.Player = (Player)t2;
					t3acc.Player = (Player)t3;

					Context.Accounts.Add(t1acc); Context.Accounts.Add(t2acc); Context.Accounts.Add(t3acc);
					Context.Trainers.Add(t1); Context.Trainers.Add(t2); Context.Trainers.Add(t3);

					Context.SaveChanges();
				}
			}*/
			using (var psc = new PlayerServiceClient())
			{
				LoggedInPlayer = psc.GetPlayerByID(accountID);
			}

			InitializeComponent();

			ProfileButton_Click(null, null);
			
			InitializeRanking();
			InitializeTrainers();
			InitializeStatistics();
			InitializeProfile();

		}

		#region Testy
		/*
		private void TestEntityFrameworkKacperVer()
		{
			LoggedInPlayer = new Player("Roger",
					   "Federer",
					   40,
					   "606543234",
					   "roger@federer.sw",
					   9.5f,
					   "",
					   "Warszawa", 
					   Int32.MaxValue);
			new Player("Michał",
					   "Michałowicz",
					   16,
					   "903459120",
					   "michal667@wp.pl",
					   1.5f,
					   "",
					   "Pcim Dolny",
					   Int32.MaxValue);
			new Player("Marcin",
					   "Żółć",
					   32,
					   "504394029",
					   "zolc@onet.eu",
					   3.5f,
					   "",
					   "Wrocław",
					   Int32.MaxValue);
			new Player("Piotr",
					   "Wcisło",
					   21,
					   "606183794",
					   "piterwu666@gmail.com",
					   3.0f,
					   "",
					   "Warszawa",
					   Int32.MaxValue);`
			new Player("Novak",
					   "Djoković",
					   26,
					   "666000666",
					   "blabla@gmail.com",
					   7.0f,
					   "",
					   "Gdzieś w Serbii",
					   Int32.MaxValue);
			new Player("Kacper",
					   "Sarnacki",
					   21,
					   "602111720",
					   "sarnackik@student.mini.pw.edu.pl",
					   3.0f,
					   "",
					   "Warszawa",
					   Int32.MaxValue);
		}
		/*private void TestEntityFramework()
		{
			DropCreateDatabaseIfModelChanges<TennisManagerContext> initializer = new DropCreateDatabaseIfModelChanges<TennisManagerContext>();
			Database.SetInitializer<TennisManagerContext>(initializer);
			using (var v = new TennisManagerContext())
			{
				Player p1 = new Player()
				{
					Age = 26,
					Email = "blabla@gmail.com",
					FirstName = "Novak",
					LastName = "Djokovic",
					PhoneNumber = "666000666",
					SkillLevel = 7.0f,
					City = "warsaw",
					TopPosition = Int32.MaxValue
				};
				LoggedInPlayer = p1;
				Player p2 = new Player()
				{
					Age = 21,
					Email = "piterwu666@gmail.com",
					FirstName = "Piotr",
					LastName = "Wcislo",
					PhoneNumber = "606183794",
					SkillLevel = 3.0f,
					City = "warsaw",
					TopPosition = Int32.MaxValue
				};
				Player p3 = new Player()
				{
					Age = 21,
					Email = "kacperro@buziaczek.biz",
					FirstName = "Kacper",
					LastName = "Sarnacki",
					PhoneNumber = "666itd",
					SkillLevel = 11.0f,
					City = "Warsaw",
					TopPosition = Int32.MaxValue
				};

				Account acc1 = new Account() { Login = "login", Password = "asd1", Player = p1 };
				Account acc2 = new Account() { Login = "login", Password = "qwerty", Player = p2 };
				Account acc3 = new Account() { Login = "login", Password = "qwerty1", Player = p3 };
				v.Accounts.Add(acc1); 
				v.Accounts.Add(acc2);
				v.Accounts.Add(acc3);
				v.Players.Add(p1); 
				v.Players.Add(p2);
				v.Players.Add(p3);
				v.SaveChanges();
				Duel d = new Duel(v.Players.Where(x => x.FirstName == "Piotr").ToArray()[0], v.Players.Where(x => x.FirstName == "Novak").ToArray()[0])
				{
					Accepted = true,
					DateOfPlay = new DateTime(2014, 11, 12),
				};
				//v.Duels.Add(d);
				d = new Duel(v.Players.Where(x => x.FirstName == "Piotr").ToArray()[0], v.Players.Where(x => x.FirstName == "Kacper").ToArray()[0])
				{
					Accepted = false,
					DateOfPlay = new DateTime(2013, 11, 1),
				};
				//v.Duels.Add(d);
				v.SaveChanges();

				// transakcje
			}
		}*/
		#endregion

		#region Menu initialization
		private void InitializeProfile()
		{	
			//profile picture
			if (String.IsNullOrWhiteSpace(LoggedInPlayer.ImagePath))
				ProfileImagePictureBox.BackgroundImage = Properties.Resources.profile;
			else
				ProfileImagePictureBox.BackgroundImage = new Bitmap(LoggedInPlayer.ImagePath);

			//profile button
			NameButton.Text = LoggedInPlayer.ToString();
			
			// calendar
			using (var psc = new PlayerServiceClient())
			{
					var calendar = psc.GetCalendar(LoggedInPlayer).ToList<TennisOrganizerServices.DuelHistory>();
					duelGridView.DataSource = calendar;

					duelGridView.Columns[0].Width = 200;
					duelGridView.Columns[1].Width = 1 ;
					duelGridView.Columns[2].Width = 200;
					duelGridView.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold);

					//LoggedInPlayer.SetHistoryOfDuels(passedDuelsDataGridView);
					var history = psc.GetHistoryOfDuels(LoggedInPlayer).ToList<TennisOrganizerServices.DuelHistory>();
					passedDuelsDataGridView.DataSource = (from f in history
														  select f);
			}
			//passedDuelsDataGridView.Columns[0].Width = 400;
			//passedDuelsDataGridView.Columns[1].Width = 100;
			//passedDuelsDataGridView.Columns[2].Width = 200;
			//passedDuelsDataGridView.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Bold);

			// notifications
			NoNotificationsLabel.SendToBack();
			notifications = new List<Notification>();

			using (var psc = new PlayerServiceClient())
			{
				// RateNotifications
				foreach (var duel in psc.GetFinishedNotRatedDuels(LoggedInPlayer))
				{
					TennisOrganizerServices.Player p = psc.GetOpponentBy(LoggedInPlayer, duel.DuelID);
					DateTime date = duel.DateOfPlay;
					notifications.Add(new RateNotification(duel.DuelID, LoggedInPlayer.FirstName, LoggedInPlayer.LastName, p.FirstName, p.LastName, date));
				}
				// ChallengeNotifications
				foreach (var duel in psc.GetChallengingDuels(LoggedInPlayer))
				{
					TennisOrganizerServices.Player p = psc.GetOpponentBy(LoggedInPlayer, duel.DuelID);
					DateTime date = duel.DateOfPlay;
					//if () todo
					notifications.Add(new ChallengeNotification(duel.DuelID, p.FirstName, p.LastName, date));
				}
				// AcceptedNotifications
				foreach (var duel in psc.GetAcceptedNotSeenDuels(LoggedInPlayer))
				{
					TennisOrganizerServices.Player p = psc.GetOpponentBy(LoggedInPlayer, duel.DuelID);
					DateTime date = duel.DateOfPlay;
					notifications.Add(new AcceptNotification(duel.DuelID, p.FirstName, p.LastName, date));
				}
				// RejectedNotifications
				foreach (var duel in psc.GetRejectedNotSeenDuels(LoggedInPlayer))
				{
					TennisOrganizerServices.Player p = psc.GetOpponentBy(LoggedInPlayer, duel.DuelID);
					DateTime date = duel.DateOfPlay;
					notifications.Add(new RejectNotification(duel.DuelID, p.FirstName, p.LastName, date));
				}
			}

			SetNewNotification();
		}
		private void InitializeRanking()
		{
			using (var psc = new PlayerServiceClient())
			{
				List<TennisOrganizerServices.PlayerStats> ps = new List<TennisOrganizerServices.PlayerStats>();
				ps = psc.GetPlayerStatsList().ToList<TennisOrganizerServices.PlayerStats>();
				playerBindingSource.DataSource = ps;
				PlayerDataGridView.DataSource = ps;
				//playerBindingSource.DataSource = ps;
			}
			//Player.SetPlayerList(PlayerDataGridView);
		}
		private void InitializeTrainers()
		{
			using (var psc = new PlayerServiceClient())
			{
				var L = psc.GetTrainers();
				TrainerDataGrid.DataSource = L;
				//trainerBindingSource.DataSource = L;
			}
			//Trainer.SetTrainerList(TrainerDataGrid);
			
		}
		private void InitializeStatistics()
		{
			using (var psc = new PlayerServiceClient())
			{
				RankPositionLabel.Text = psc.GetRank(LoggedInPlayer).ToString();
				HighestRankLabel.Text = psc.GetTopPosition(LoggedInPlayer).ToString();
				SkillLevelLabel.Text = psc.GetSkillLevel(LoggedInPlayer).ToString();
				MatchesCountLabel.Text = psc.GetMatchesCount(LoggedInPlayer).ToString();
				WonMatchesCountLabel.Text = psc.GetWonMatchesCount(LoggedInPlayer).ToString();
				LostMatchesCountLabel.Text = psc.GetLostMatchesCount(LoggedInPlayer).ToString();
				MonthMatchesCountLabel.Text = psc.GetMonthlyMatchesCount(LoggedInPlayer).ToString();
				if (psc.GetLastMatchDate(LoggedInPlayer) != null)
					LastMatchDateLabel.Text = psc.GetLastMatchDate(LoggedInPlayer).Value.Date.ToShortDateString();
			}
		}
		#endregion

		#region Notifications
		void SetNewNotification()
		{
			if (notifications.Count > 0)
			{
				Notification notification = notifications[0];
				ProfilePanel.Controls.Add(notification);
				notification.BringToFront();
				notification.GotAnswer += notification_GotAnswer;
			}
		}
		void notification_GotAnswer(object sender, EventArgs e)
		{
			Notification n = sender as Notification;
			ProfilePanel.Controls.Remove(n);
			notifications.RemoveAt(0);

			PlayerDecision decision = e as PlayerDecision;
			TennisOrganizerServices.Duel duel;
			using (var dsc = new DuelServiceClient())
			{
				duel = dsc.GetDuelByID(decision.DuelID);
				if (n is AcceptNotification)
				{
					dsc.SetSeen(duel);
				}
				else if (n is RejectNotification)
				{
					//dsc.SetSeen(duel);
					dsc.Delete(duel);
				}
				else if (n is ChallengeNotification)
				{	
					//dsc.SetSeen(duel);
					dsc.MakeDecision(duel, decision.Accepted);
				}
				else if (n is RateNotification)
				{
					//dsc.SetSeen(duel);
					dsc.Rate(duel, decision.Score);
				}
			}
			SetNewNotification();
			using (var psc = new PlayerServiceClient())
			{
				LoggedInPlayer = psc.GetPlayerByID(LoggedInPlayer.AccountID);//Player.GetPlayerByID(LoggedInPlayer.AccountID);
			}
			//LoggedInPlayer.SetCalendar(duelGridView);
			//LoggedInPlayer.SetHistoryOfDuels(passedDuelsDataGridView);
			InitializeStatistics();
		}
		#endregion

		#region Control handlers
		private void DeactivateMenuButtonsAndPanels()
		{
			ProfileButton.BackColor = SystemColors.MenuHighlight;
			ChallengeButton.BackColor = SystemColors.MenuHighlight;
			TrainerButton.BackColor = SystemColors.MenuHighlight;
			RankingButton.BackColor = SystemColors.MenuHighlight;

			ProfilePanel.Visible = false;
			ChallengePanel.Visible = false;
			TrainerPanel.Visible = false;
			RankingPanel.Visible = false;
			EditProfilePanel.Visible = false;
		}
		
		// Challenge time:
		private void GodzinaTextBox_Enter(object sender, EventArgs e)
		{
			if (GodzinaTextBox.Text != "gg:mm")
				return;
			GodzinaTextBox.Text = String.Empty;
			GodzinaTextBox.ForeColor = Color.Black;
		}
		private void GodzinaTextBox_Leave(object sender, EventArgs e)
		{
			if (GodzinaTextBox.Text != String.Empty)
				return;
			GodzinaTextBox.Text = "gg:mm";
			GodzinaTextBox.ForeColor = SystemColors.ScrollBar;
		}
		private void DataTextBox_Enter(object sender, EventArgs e)
		{
			if (DataTextBox.Text != "dd.mm.rrrr")
				return;
			DataTextBox.Text = String.Empty;
			DataTextBox.ForeColor = Color.Black;
		}
		private void DataTextBox_Leave(object sender, EventArgs e)
		{
			if (DataTextBox.Text != String.Empty)
				return;
			DataTextBox.Text = "dd.mm.rrrr";
			DataTextBox.ForeColor = SystemColors.ScrollBar;
		}
		private void DataTextBox_TextChanged(object sender, EventArgs e)
		{
			WyzwijPrzeciwnika.Enabled = false;
		}
		
		private void TrainingDateTextBox_Leave(object sender, EventArgs e)
		{
			if (TrainingDateTextBox.Text != String.Empty)
				return;
			TrainingDateTextBox.Text = "dd.mm.rrrr";
			TrainingDateTextBox.ForeColor = SystemColors.ScrollBar;
		}
		private void TrainingDateTextBox_Enter(object sender, EventArgs e)
		{
			if (TrainingDateTextBox.Text != "dd.mm.rrrr")
				return;
			TrainingDateTextBox.Text = String.Empty;
			TrainingDateTextBox.ForeColor = Color.Black;
		}
		private void TrainingHourTextBox_Leave(object sender, EventArgs e)
		{
			if (TrainingHourTextBox.Text != String.Empty)
				return;
			TrainingHourTextBox.Text = "gg:mm";
			TrainingHourTextBox.ForeColor = SystemColors.ScrollBar;

		}
		private void TrainingHourTextBox_Enter(object sender, EventArgs e)
		{
			if (TrainingHourTextBox.Text != "gg:mm")
				return;
			TrainingHourTextBox.Text = String.Empty;
			TrainingHourTextBox.ForeColor = Color.Black;
		}
		
		// Challenge handlers
		private void SzukajPrzeciwnika_Click(object sender, EventArgs e)
		{
			SearchErrorProvider.Clear();
			int ageFrom = 0;
			int ageTo = 200;
			float levelFrom = 1;
			float levelTo = 7;
			DateTime gameDate;
			String error;
			Validator validator = new Validator();
			//wyczyść okienko z aktualnie kilniętym graczem, gdyż wyniki wyszukiwania mogą zwrócić puste
			OpponentName.Text = String.Empty;
			OpponentCityLabel.Text = String.Empty;
			OpponentPhoneLabel.Text = String.Empty;
			OpponentMatchesLabel.Text = String.Empty;
			OpponentImage.BackgroundImage = Properties.Resources.profile;

			if ((error = validator.ValidateDateAndTime(DataTextBox.Text, GodzinaTextBox.Text)) != null)
			{
				SearchErrorProvider.SetError(DataTextBox, error);
				SearchErrorProvider.SetError(GodzinaTextBox, error);
			}
			if (WiekOdTextBox.Text.Length > 0)
			{
				if ((error = validator.ValidateAge(WiekOdTextBox.Text)) != null)
					SearchErrorProvider.SetError(WiekOdTextBox, error);
				else ageFrom = Int32.Parse(WiekOdTextBox.Text);
			}
			if (WiekDoTextBox.Text.Length > 0)
			{
				if ((error = validator.ValidateAge(WiekDoTextBox.Text)) != null)
					SearchErrorProvider.SetError(WiekDoTextBox, error);
				else ageTo = Int32.Parse(WiekDoTextBox.Text);
			}
			if (PoziomOdTextBox.Text.Length > 0)
			{
				if ((error = validator.ValidatePlayerLevel(PoziomOdTextBox.Text)) != null)
					SearchErrorProvider.SetError(PoziomOdTextBox, error);
				else levelFrom = float.Parse(PoziomOdTextBox.Text);
			}
			if (PoziomDoTextBox.Text.Length > 0)
			{
				if ((error = validator.ValidatePlayerLevel(PoziomDoTextBox.Text)) != null)
					SearchErrorProvider.SetError(PoziomDoTextBox, error);
				else levelTo = float.Parse(PoziomDoTextBox.Text);
			}

			if (validator.IsError) return;

			DateTime.TryParse(DataTextBox.Text + " " + GodzinaTextBox.Text, new CultureInfo("de-DE"), DateTimeStyles.None, out gameDate);

			using (var psc = new PlayerServiceClient())
			{
				if (MiastoTextBox.Text.Length > 0)
					opponentBindingSource.DataSource = psc.GetOpponentsByCity(LoggedInPlayer, gameDate, ageFrom, ageTo, levelFrom, levelTo, MiastoTextBox.Text);
				else
					opponentBindingSource.DataSource = psc.GetOpponentsBy(LoggedInPlayer, gameDate, ageFrom, ageTo, levelFrom, levelTo);
			}
			if (OpponentGridView.CurrentRow == null)
				WyzwijPrzeciwnika.Enabled = false;
			else
				WyzwijPrzeciwnika.Enabled = true;
		}
		private void OpponentGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			TennisOrganizerServices.Player opponent;
			using (var psc = new PlayerServiceClient())
			{
				opponent = psc.GetPlayerByID(int.Parse(OpponentGridView.Rows[index].Cells[0].Value.ToString()));
				OpponentMatchesLabel.Text = "Rozegranych meczy: " + psc.GetMatchesCount(opponent);//opponent.GetMatchesCount();
			}
			OpponentName.Text = opponent.FirstName + " " + opponent.LastName;
			OpponentCityLabel.Text = opponent.City;
			OpponentPhoneLabel.Text = "Tel. " + opponent.PhoneNumber;
			if (String.IsNullOrWhiteSpace(opponent.ImagePath))
				OpponentImage.BackgroundImage = Properties.Resources.profile;
			else
				OpponentImage.BackgroundImage = new Bitmap(opponent.ImagePath);
		}
		private void WyzwijPrzeciwnika_Click(object sender, EventArgs e)
		{
			DateTime date = DateTime.Parse(DataTextBox.Text + " " + GodzinaTextBox.Text, new CultureInfo("de-DE"), DateTimeStyles.None);
			if (!LoggedInPlayer.CanPlay(date))
			{
				if(TOMessageBox.Show("Masz już zaplanowane spotkanie na ten dzień!\n Czy na pewno chcesz zaplanować spotkanie?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
				return;
			}
			
			int opponentAccountID = int.Parse(OpponentGridView.CurrentRow.Cells[0].Value.ToString());
			TennisOrganizerServices.Player opponent;
			using (var psc = new PlayerServiceClient())
			{
				opponent = psc.GetPlayerByID(opponentAccountID);
			}
			using (var dsc = new DuelServiceClient())
			{
				dsc.ArrangeDuel(LoggedInPlayer, opponent, date);
			}

			SzukajPrzeciwnika_Click(null, null);
			Mailer.NotifyAboutChallenge(LoggedInPlayer.FirstName + " " +  LoggedInPlayer.LastName, opponent.Email, opponent.FirstName+ " " + opponent.LastName);
			TOMessageBox.Show(opponent + " został wyzwany!");
		}
		private void ArrangeTrainerButtonClick(object sender, EventArgs e)
		{
			Validator validator = new Validator();
			String error;
			DateTime date;

			ArrangeTrainerErrorProvider.Clear();

			if((error = validator.ValidateDateAndTime(TrainingDateTextBox.Text, TrainingHourTextBox.Text)) != null)
			{
				ArrangeTrainerErrorProvider.SetError(TrainingDateTextBox, error);
				ArrangeTrainerErrorProvider.SetError(TrainingHourTextBox, error);
			}
			if (validator.IsError) return;

			date = DateTime.Parse(TrainingDateTextBox.Text + " " + TrainingHourTextBox.Text, new CultureInfo("de-DE"), DateTimeStyles.None);
			if(!LoggedInPlayer.CanPlay(date))
			{
				TOMessageBox.Show("Masz już zaplanowane spotkanie na ten dzień!");
				return;
			}

			int trainerAccountID = int.Parse(TrainerDataGrid.SelectedRows[0].Cells[0].Value.ToString());
			TennisOrganizerServices.Player trainer;
			using (var psc = new PlayerServiceClient())
			{
				trainer = psc.GetPlayerByID(trainerAccountID);
			}
			//dsc.ArrangeDuel()
			TOMessageBox.Show("Spotkanie z trenerem zostało umówione");
		}

		//profile edition:
		private void ChangePasswordButton_Click(object sender, EventArgs e)
		{
			EditProfileErrorProvider.Clear();
			String error;
			Validator validator = new Validator();
			string hashedPassword = Encrypter.GetSHA256Hash(OldPasswordTextBox.Text);

			if ((error = validator.ValidatePassword(NewPasswordTextBox.Text)) != null)
				EditProfileErrorProvider.SetError(NewPasswordTextBox, error);

			if (validator.IsError) return;

			TennisOrganizerServices.Account acc;
			using (var asc = new AccountServiceClient())
			{
				acc = asc.GetAccount(LoggedInPlayer.AccountID, hashedPassword);
			}
			if(acc == null)
			{
				EditProfileErrorProvider.SetError(OldPasswordTextBox, "Błędne hasło.");
				return;
			}
			// Zapisz nowe hasło jako hasz
			bool password;
			using (var asc = new AccountServiceClient())
			{
				password = asc.UpdateAccountPassword(acc.Login, hashedPassword, Encrypter.GetSHA256Hash(NewPasswordTextBox.Text));
			}
			if(password == false)
			{
				EditProfileErrorProvider.SetError(OldPasswordTextBox, "Błędne hasło.");
				return;
			}

			
			TOMessageBox.Show("Hasło zmieniono pomyślnie");
		}
		private void ChangeUserDataButton_Click(object sender, EventArgs e)
		{
			EditProfileErrorProvider.Clear();
			Validator validator = new Validator();
			String error;
			if ((error = validator.ValidateIfEmpty(NameTextBox.Text, "Imię")) != null)
				EditProfileErrorProvider.SetError(NameTextBox, error);
			if ((error = validator.ValidateIfEmpty(LastNameTextBox.Text, "Nazwisko")) != null)
				EditProfileErrorProvider.SetError(LastNameTextBox, error);
			if ((error = validator.ValidateIfEmpty(CityTextBox.Text, "Miasto")) != null)
				EditProfileErrorProvider.SetError(CityTextBox, error);
			
			if ((error = validator.ValidateAge(AgeTextBox.Text)) != null)
				EditProfileErrorProvider.SetError(AgeTextBox, error);
			if ((error = validator.ValidateEmail(EmailTextBox.Text)) != null)
				EditProfileErrorProvider.SetError(EmailTextBox, error);
			if ((error = validator.ValidatePhoneNumber(PhoneTextBox.Text)) != null)
				EditProfileErrorProvider.SetError(PhoneTextBox, error);

			if (validator.IsError) return;
			
			LoggedInPlayer.FirstName = NameTextBox.Text;
			LoggedInPlayer.LastName = LastNameTextBox.Text;
			LoggedInPlayer.City = CityTextBox.Text;
			LoggedInPlayer.Age = Int32.Parse(AgeTextBox.Text);
			LoggedInPlayer.Email = EmailTextBox.Text;
			LoggedInPlayer.PhoneNumber = PhoneTextBox.Text;

			using (var psc = new PlayerServiceClient())
			{
				psc.Update(LoggedInPlayer);
			}
			NameButton.Text = LoggedInPlayer.ToString();
		}
		private void ChangeProfilePictureButton_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png";
			fileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
			if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (LoggedInPlayer.ImagePath != fileDialog.FileName)
				{
					LoggedInPlayer.ImagePath = fileDialog.FileName;
					//LoggedInPlayer.Update();
					using (var psc = new PlayerServiceClient())
					{
						psc.Update(LoggedInPlayer);
					}
					ProfileImagePictureBox.BackgroundImage = new Bitmap(LoggedInPlayer.ImagePath);
					ChangeProfileImagePictureBox.BackgroundImage = new Bitmap(LoggedInPlayer.ImagePath);
				}
			}
		}
		private void ChangeProfilePicturePictureBoxClick(object sender, EventArgs e)
		{
			ChangeProfilePictureButton_Click(sender, e);
		}
		private void ChangeProfileImagePictureBoxClick(object sender, EventArgs e)
		{
			ChangeProfilePictureButton_Click(sender, e);
		}
		
		//left panel:
		private void LogOffClick(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		private void EditProfileButtonClick(object sender, EventArgs e)
		{
			DeactivateMenuButtonsAndPanels();
			EditProfilePanel.Visible = true;
			//////kontrolki danych uzytkownika
			NameTextBox.Text = LoggedInPlayer.FirstName;
			LastNameTextBox.Text = LoggedInPlayer.LastName;
			PhoneTextBox.Text = LoggedInPlayer.PhoneNumber;
			EmailTextBox.Text = LoggedInPlayer.Email;
			AgeTextBox.Text = LoggedInPlayer.Age.ToString();
			CityTextBox.Text = LoggedInPlayer.City;
			if (String.IsNullOrWhiteSpace(LoggedInPlayer.ImagePath))
				ChangeProfileImagePictureBox.BackgroundImage = Properties.Resources.profile;
			else
			{
				ChangeProfileImagePictureBox.BackgroundImage = new Bitmap(LoggedInPlayer.ImagePath);
			}
		}
		
		//right panel:
		private void ProfileButton_Click(object sender, EventArgs e)
		{
			DeactivateMenuButtonsAndPanels();
			ProfileButton.BackColor = Color.White;
			ProfilePanel.Visible = true;
			//LoggedInPlayer.SetCalendar(duelGridView);
			//LoggedInPlayer.SetHistoryOfDuels(passedDuelsDataGridView);
		}
		private void ChallengeButton_Click(object sender, EventArgs e)
		{
			DeactivateMenuButtonsAndPanels();
			ChallengeButton.BackColor = Color.White;
			ChallengePanel.Visible = true;
		}
		private void TrainerButton_Click(object sender, EventArgs e)
		{
			DeactivateMenuButtonsAndPanels();
			TrainerButton.BackColor = Color.White;
			TrainerPanel.Visible = true;
		}
		private void RankingButton_Click(object sender, EventArgs e)
		{
			DeactivateMenuButtonsAndPanels();
			RankingButton.BackColor = Color.White;
			RankingPanel.Visible = true;

			// row numeration
			foreach (DataGridViewRow row in PlayerDataGridView.Rows)
			{
				row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
			}
		}
		#endregion

		# region Window properties
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		private const int WM_NCLBUTTONDOWN = 0xA1;
		[DllImport("User32.dll")]
		public static extern bool ReleaseCapture();
		[DllImport("User32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private void MouseDownMainPanel(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
			}
		}
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCLBUTTONDOWN:
					if ((int)m.WParam == HTCAPTION)				//tylko ręcznie można wywołać HTCAPTION(dla tego okna), więc jest to na pewno wiadomość wysłana z MouseDownMainPanel
					{
						Point RelativePoint = new Point(Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top);
						if (RelativePoint.Y < CloseButton.Location.Y + CloseButton.Height)			//"pasek" przesuwania obliczany względem przycisku zamykania
							base.WndProc(ref m);
						else m.Result = (IntPtr)HTCLIENT;
					}
					return;
			}
			base.WndProc(ref m);
		}

		private void CloseButtonClick(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Abort;
		}
		private void MinimizeButtonClick(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void ExitButtonClick(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Abort;
		}
		private void MinimizeButton_MouseEnter(object sender, EventArgs e)
		{
			MinimizeButton.ForeColor = SystemColors.MenuHighlight;
		}

		private void MinimizeButton_MouseLeave(object sender, EventArgs e)
		{
			MinimizeButton.ForeColor = Color.White;
		}
		#endregion

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the '_Tennis_Organizer_NET_2014_TennisManagerContextDataSet1.Players' table. You can move, or remove it, as needed.
			this.playersTableAdapter.Fill(this._Tennis_Organizer_NET_2014_TennisManagerContextDataSet1.Players);

		}


	}
}	