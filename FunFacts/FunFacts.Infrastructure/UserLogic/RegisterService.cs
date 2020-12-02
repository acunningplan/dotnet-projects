using FunFacts.Context;
using FunFacts.Entities.User;
using FunFacts.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FunFacts.Infrastructure.Email;
//using FunFacts.Infrastructure.Email;

namespace FunFacts.Infrastructure
{

    public class RegisterInput
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string Origin { get; set; }
    }

    public class VerifyEmailInput
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public interface IRegisterService
    {
        Task<string> GenerateEmailToken(RegisterInput request);

        Task SendEmail(string email, string emailVerificationUrl);
        Task VerifyEmail(VerifyEmailInput input);
    }

    public class RegisterService : IRegisterService
    {

        private readonly FunFactsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IEmailSender _emailSender;


        public RegisterService(FunFactsContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IEmailSender emailSender)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _emailSender = emailSender;
            _context = context;
        }

        public async Task<string> GenerateEmailToken(RegisterInput request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            var user = new AppUser
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Problem creating user");
            }

            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));
        }

        public async Task SendEmail(string email, string emailVerificationUrl)
        {

            //if (_userManager.Options.SignIn.RequireConfirmedEmail)
            //{
            var emailVerificationHtml = $"<a href='{emailVerificationUrl}'>Click here to verify email address</a>";

            await _emailSender.SendEmailAsync(email, "Please verify email address", emailVerificationHtml);

            //}
            //else
            //{
            //    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Confirmation email not required." });
            //    //var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            //    //if (!signInResult.Succeeded) { return BadRequest(); }

            //    //return RedirectToAction("Profile");
            //}
        }

        public async Task VerifyEmail(VerifyEmailInput input)
        {
            var email = input.Email;
            var emailToken = input.Token;
            if (email == null || emailToken == null)
                throw new RestException(HttpStatusCode.BadRequest, new { Errors = "Invalid input" });

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new Exception("Cannot find user by email");

            emailToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(emailToken));

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);
            if (!result.Succeeded) throw new Exception($"Cannot confirm email");
        }
    }
}