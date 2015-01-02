using System;
using System.Net.Mail;
using System.Net;


namespace Tennis_Organizer.NET_2014
{
	public class Mailer
	{
		static MailAddress fromAddress = new MailAddress("tennisorganizer.net@gmail.com", "Tennis Organizer");
		const string fromPassword = "dotnetorganizer";

		public static void NotifyAboutChallenge(string fromPlayerName, string mailAddress, string toPlayerName)
		{
			SmtpClient smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};
			using (var message = new MailMessage(fromAddress, new MailAddress(mailAddress, toPlayerName))
			{
				Subject = "Tennis organizer - wyzwanie na pojedynek",
				Body = "Witaj, " + toPlayerName + "\n Gracz " + fromPlayerName + " wyzwał cię na pojedynek!. Zaloguj się na swoje konto aby potwierdzić, lub odrzucić wyzwanie."
			})
			{
				smtp.Send(message);
			}
		}
	}
}
