using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Tennis_Organizer.NET_2014
{
	public class Validator
	{
		public bool IsError = false;
	
		/// <summary>
		/// Sprawdza czy podane dane data nie są puste, w przypadku błędu zwraca "Podaj " + name
		/// </summary>
		public String ValidateIfEmpty(String data, String name = null)
		{
			if(String.IsNullOrWhiteSpace(data))
			{
				IsError = true;
				return "Podaj " + name;
			}
			return null;
		}
		public String ValidateLogin(String login)
		{
			String ans = null;
			/*if (Account.CheckAvailability(login) == false)
			{
				IsError = true;
				ans = "Podany login jest już zajęty";
			}
			else */
			if (login.Length <= 3 || String.IsNullOrWhiteSpace(login))
			{
				IsError = true;
				ans = "Login musi się składać z co najmniej 4 znaków.";
			}
			else
			{
				ans = null;
			}
			return ans;
		}
		public String ValidatePassword(String password)
		{
			if (password.Length <= 3)
			{
				IsError = true;
				return "Hasło jest za krótkie";
			}
			else if (String.IsNullOrWhiteSpace(password))
			{
				IsError = true;
				return "Hasło musi zawierać małe lub wielkie litery i cyfry";
			}
			else return null;
		}
		public String ValidateRepeatedPassword(String password, String repeatedPassword)
		{
			if (password != repeatedPassword)
			{
				IsError = true;
				return "Niepoprawne hasło";
			}
			else return null;
		}
		public String ValidatePhoneNumber(String phoneNumber)
		{
			for (int i = 0; i < phoneNumber.Length; i++)
			{
				if (!Char.IsDigit(phoneNumber[i]))
				{
					IsError = true;
					return "Podaj poprawny numer telefonu";
				}
			}
			return null ;
		}
		public String ValidateAge(String age)
		{
			int iAge = 0;
			try
			{
				iAge = Int32.Parse(age);
			}
			catch (ArgumentNullException)
			{
				IsError = true;
				return "Podaj wiek";
			}
			catch (FormatException)
			{
				IsError = true;
				return "Wiek musi być liczbą!";
			}
			if (iAge < 0)
			{
				IsError = true;
				return "Wiek nie może być ujemny!";
			}
			else if (iAge > 200)
			{
				IsError = true;
				return "Podaj prawdziwy wiek (<200)";
			}
			return null;

		}
		public String ValidateEmail(string email)
		{
			Regex regex = new Regex("^([a-zA-Z0-9])+(\\.([a-zA-Z0-9])+)*(@){1}([a-zA-Z0-9])+(\\.[a-zA-Z0-9]+)+");
			if (!regex.IsMatch(email))
			{
				IsError = true;
				return "Podaj poprawny adres email";
			}
			return null;
		}
		public String ValidateDateAndTime(String date, String time)
		{
			DateTime gameDate = new DateTime();
			if (date.Length != 10)
			{
				IsError = true;
				return "Podaj datę w poprawnym formacie!";
			}
			if (time.Length != 5)
			{
				IsError = true;
				return "Podaj czas w poprawnym formacie!";
			}
			if (!DateTime.TryParse(date + " " + time, new CultureInfo("de-DE"), DateTimeStyles.None, out gameDate))
			{
				IsError = true;
				return "Data lub godzina w niepoprawnym formacie";
			}
			if (DateTime.Compare(gameDate, DateTime.Now) < 0)
			{
				IsError = true;
				return "Podaj przyszłą datę";
			}
			
			return null;
		}
		public String ValidatePlayerLevel(String level)
		{
			float playerLevel;
			try
			{
				playerLevel = float.Parse(level);
			}
			catch(Exception)
			{
				IsError = true;
				return "Podaj poprawny poziom gracza";
			}
			if(playerLevel > 7.0f || playerLevel < 1.0f)
			{
				IsError = true;
				return "Podaj poziom gracza w zakresie 1-7";
			}

			return null;
		}
		public String ValidateDuelResult(String homeScore, String guestScore)
		{
			String error = "Podaj poprawny wynik";
			IsError = true;
			int home, guest;

			if (!int.TryParse(homeScore, out home) || !int.TryParse(guestScore, out guest))
				return error;
			if (home > 3 || home < 0 || guest > 3 || guest < 0)
				return error;
			if (home != 3 && guest != 3)
			{
				if (home != 2 && guest != 2)
					return error;
				if (home == 2 && guest == 2)
					return error;
			}
			if (home == 3 && guest == 3)
				return error;

			IsError = false;
			return null;
		}
	}
}
