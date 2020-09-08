using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.Exceptions;

namespace TravelBug.Infrastructure
{

    public class RegisterInput
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public interface IRegisterService
    {
        Task<string> GenerateEmailToken(AppUser user);
        Task<AppUser> CreateNewUser(RegisterInput request);
        Task<User> RegisterUser(AppUser user, string password);
        Task SendEmail(string email, string emailVerificationUrl);
        Task VerifyEmail(string userId, string emailToken);
    }

    public class RegisterService : IRegisterService
    {

        private readonly TravelBugContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IEmailService _emailService;

        public RegisterService(TravelBugContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IEmailService emailService)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _emailService = emailService;
            _context = context;
        }

        public async Task<AppUser> CreateNewUser(RegisterInput request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            return new AppUser
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                UserName = request.Username
            };
        }

        public async Task<string> GenerateEmailToken(AppUser user)
        {
            var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(emailToken));
        }

        public async Task SendEmail(string email, string emailVerificationUrl)
        {

            //if (_userManager.Options.SignIn.RequireConfirmedEmail)
            //{
            var emailVerificationHtml = $"<a href='{HtmlEncoder.Default.Encode("")}'>Verify Email Address!</a>";

            await _emailService.SendAsync(email, "Email Verification", emailVerificationHtml, true);

            //}
            //else
            //{
            //    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Confirmation email not required." });
            //    //var signInResult = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);
            //    //if (!signInResult.Succeeded) { return BadRequest(); }

            //    //return RedirectToAction("Profile");
            //}
        }

        public async Task<User> RegisterUser(AppUser user, string password)
        {
            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return new User(user, _jwtGenerator, refreshToken.Token);
            }
            throw new Exception("Problem creating user");

        }

        public async Task VerifyEmail(string userId, string emailToken)
        {
            if (userId == null || emailToken == null) 
                throw new RestException(HttpStatusCode.BadRequest, new { Errors = "Invalid input" }); 

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new Exception("Cannot find user");

            emailToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(emailToken));

            var result = await _userManager.ConfirmEmailAsync(user, emailToken);
            if (!result.Succeeded) throw new Exception("Cannot confirm email.");
        }
    }
}