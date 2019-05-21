using System.Net;
using System.Net.Mail;

namespace Helpers
{
    public class Email
    {
        public void SendEmail(string emailDestination, string subject, string body)
        {
            const string emailSource = "cortezcomerciomanager@gmail.com";
            const string passwordEmailSource = "manager@2019";

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(emailSource, passwordEmailSource)
            };

            using (var message = new MailMessage(emailSource, emailDestination)
            {
                Subject = subject,
                Body = body
            })
            {
                smtpClient.Send(message);
            }
        }
    }
}
