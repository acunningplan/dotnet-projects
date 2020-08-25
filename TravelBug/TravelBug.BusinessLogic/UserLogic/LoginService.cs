//using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TravelBug.BusinessLogic.Exceptions;
using TravelBug.Entities.User;

namespace TravelBug.BusinessLogic
{
    public interface ILoginService
    {
        Task<User> Login(LoginInput input);
    }
    public class LoginInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;
        public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
        }

        public async Task<User> Login(LoginInput input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);

            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, input.Password, false);

            if (result.Succeeded)
            {
                return new User
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    //Photo = user.UserPhoto.Url
                };
            }
            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}