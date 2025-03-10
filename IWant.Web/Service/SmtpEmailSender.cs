using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace IWant.Web.Service
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IOptions<SmtpOptions> options;
        public SmtpEmailSender(IOptions<SmtpOptions> options)
        {
            this.options = options;
        }

        // Allow to send an email asynchronously
        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toAddress);

            using (var client = new SmtpClient(options.Value.Host, options.Value.Port))
            {
                client.Credentials = new NetworkCredential(options.Value.Username, options.Value.Password);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
