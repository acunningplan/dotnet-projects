using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Burgler.Entities;
using Microsoft.AspNetCore.Identity;

namespace Burgler.BusinessLogic.UserLogic
{
    public class LoginQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Login : UserMethod
    {
        public class LoginQueryValidator : AbstractValidator<LoginQuery>
        {
            public LoginQueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public async Task<UserData> LoginUser(LoginQuery query)
        {
            var user = await UserManager.FindByEmailAsync(query.Email);
            // null check needed

            var result = await SignInManager.CheckPasswordSignInAsync(user, query.Password, false);
            if (result.Succeeded)
            {
                // generate token
                return new UserData
                {
                    DisplayName = user.DisplayName,
                    Token = JwtServices.CreateToken(user),
                    Username = user.UserName,
                    Image = null
                };
            }
            return new UserData();
        }
    }
}
