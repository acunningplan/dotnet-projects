using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using FunFacts.Entities.User;
using FunFacts.Infrastructure.Email;

namespace FunFacts.Infrastructure.UserLogic
{
    public class ResendEmailInput
    {
        public string Email { get; set; }
        public string Origin { get; set; }
    }

    public interface IEmailConfirmation
    {
        Task ResendEmail(ResendEmailInput input);
    }

    public class EmailConfirmation : IEmailConfirmation
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public EmailConfirmation(UserManager<AppUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task ResendEmail(ResendEmailInput input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);


            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailVerificationUrl = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));

            var emailVerificationHtml = $"<a href='{emailVerificationUrl}'>Click here to verify email address</a>";

            await _emailSender.SendEmailAsync(input.Email, "Please verify email address", emailVerificationHtml);
        }
    }
}
