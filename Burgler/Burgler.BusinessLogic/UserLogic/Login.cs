using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
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
            var user = await userManager.FindByEmailAsync(query.Email);
            // null check needed

            var result = await signInManager.CheckPasswordSignInAsync(user, query.Password, false);
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
            return new UserData();
        }
    }
}
