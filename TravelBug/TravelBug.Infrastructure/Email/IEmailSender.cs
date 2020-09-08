using System.Threading.Tasks;

namespace TravelBug.Infrastructure.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}