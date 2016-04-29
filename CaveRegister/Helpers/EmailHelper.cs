using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CaveRegister.Helpers
{
	public static class EmailHelper
	{
		public static void SendEmail(string to,string subject,string body)
		{
			MailAddress fromAddress = new MailAddress("SECCaveRegister@speleo.co.za", "SEC Cave Register");
			MailMessage mail = new MailMessage(fromAddress,new MailAddress(to));
			SmtpClient client = new SmtpClient();
			//client.Port = 25;
			//client.DeliveryMethod = SmtpDeliveryMethod.Network;
			//client.UseDefaultCredentials = false;
			//client.pa
			mail.IsBodyHtml = true;
			mail.Subject = subject;

			string htmlBody = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplate.html"));
			htmlBody = htmlBody.Replace("{{Heading}}", subject).Replace("{{Body}}", body);

			mail.Body = htmlBody;
			client.Send(mail);
		}
	}
}