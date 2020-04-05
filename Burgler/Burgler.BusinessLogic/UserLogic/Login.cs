using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class LoginQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public static class Login
    {
        public class LoginQueryValidator : AbstractValidator<LoginQuery>
        {
            public LoginQueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public static async Task<UserData> LoginMethod(LoginQuery query, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtServices jwtServices)
        {
            var re = new RestException(HttpStatusCode.Unauthorized, new { login = "Incorrect email or password." });
            AppUser user = await userManager.FindByEmailAsync(query.Email) ?? throw re;

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, query.Password, false);
            if (result.Succeeded)
            {
                // generate token
                return new UserData
                {
                    DisplayName = user.DisplayName,
                    Token = jwtServices.CreateToken(user),
                    Username = user.UserName,
                    Image = null
                };
            }
            else
            {
                throw re;
            }
        }
    }
}
