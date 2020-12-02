using System.Threading.Tasks;

namespace FunFacts.Infrastructure.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}