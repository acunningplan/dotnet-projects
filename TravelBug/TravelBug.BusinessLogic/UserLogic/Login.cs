using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TravelBug.Entities;
//using FluentValidation;
//using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelBug.Context;
using TravelBug.Entities.User;
using System;
using TravelBug.BusinessLogic.Exceptions;

namespace TravelBug.BusinessLogic
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }


        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly IJwtGenerator _jwtGenerator;
        public Login(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<User> LoginMethod(CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(Email);

            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, Password, false);

            if (result.Succeeded)
            {
                // TODO: generate token
                return new User
                {
                    DisplayName = user.DisplayName,
                    //Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    Photo = user.UserPhoto.Url
                };
            }
            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}