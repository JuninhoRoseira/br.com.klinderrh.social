
using System.Net;
using System.Net.Mail;

namespace br.com.klinderrh.social.infra.comunicacao
{
	public static class EmailHelper
	{
		public static void EnviarEmail(string emailDestino, string titulo, string texto)
		{
			var toAddress = new MailAddress(emailDestino);
			var fromAddress = new MailAddress("juninhoroseira@gmail.com", "KlinderRH - Admin");

			const string fromPassword = "Pretaponte02";

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
			};

			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = titulo,
				Body = texto
			})
			{
				smtp.Send(message);
			}

		}

	}

}