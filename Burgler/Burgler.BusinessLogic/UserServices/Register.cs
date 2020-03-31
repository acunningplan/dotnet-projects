using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Burgler.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Burgler.Entities.User;

namespace Burgler.BusinessLogic.UserServices
{
    public class RegisterCommand
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public partial class UserServices : IUserServices
    {
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

        public async Task<UserData> Register(RegisterCommand command)
        {
            if (await _context.Users.Where(x => x.Email == command.Email).AnyAsync())
            {
                return null;
            }
            if (await _context.Users.Where(x => x.UserName == command.UserName).AnyAsync())
            {
                return null;
            }
            var user = new AppUser
            {
                DisplayName = command.DisplayName,
                UserName = command.UserName,
                Email = command.Email,
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            return null;
        }
    }
}
