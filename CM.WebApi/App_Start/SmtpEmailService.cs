using System.Collections.Concurrent;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CM.WebApi
{
    public class SmtpEmailService : IIdentityMessageService
    {
        private readonly ConcurrentQueue<SmtpClient> _clients = new ConcurrentQueue<SmtpClient>();

        public async Task SendAsync(IdentityMessage message)
        {
            var client = GetOrCreateSmtpClient();
            try
            {
                var mailMessage = new MailMessage();

                mailMessage.To.Add(new MailAddress(message.Destination));
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;

                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                await client.SendMailAsync(mailMessage);
            }
            finally
            {
                _clients.Enqueue(client);
            }
        }

        private SmtpClient GetOrCreateSmtpClient()
        {
            return _clients.TryDequeue(out var client) ? client : new SmtpClient();
        }
    }
}