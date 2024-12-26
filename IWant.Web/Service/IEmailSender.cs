using System.Threading.Tasks;

namespace IWant.Web.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
