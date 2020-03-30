using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Burgler.Entities;
using Microsoft.AspNetCore.Identity;

namespace Burgler.BusinessLogic.UserServices
{
    public class SignInQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public partial class UserServices : IUserServices
    {
        public class SignInQueryValidator : AbstractValidator<SignInQuery>
        {
            public SignInQueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public async Task<User> SignIn(SignInQuery query)
        {
            var user = await _userManager.FindByEmailAsync(query.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, query.Password, false);
            if (result.Succeeded)
            {
                // generate token
                return user;
            }
            return new User();
        }
    }
}
