using Burgler.Entities.User;
using BurglerContextLib;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class RegisterCommand
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.DisplayName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
    public static class Register
    {
        public static async Task<UserData> RegisterMethod(RegisterCommand command, BurglerContext dbContext, UserManager<AppUser> userManager)
        {
            if (await dbContext.Users.Where(x => x.Email == command.Email).AnyAsync())
            {
                return null;
            }
            if (await dbContext.Users.Where(x => x.UserName == command.UserName).AnyAsync())
            {
                return null;
            }
            var user = new AppUser
            {
                DisplayName = command.DisplayName,
                UserName = command.UserName,
                Email = command.Email,
            };

            var result = await userManager.CreateAsync(user, command.Password);

            return null;
        }
    }
}
