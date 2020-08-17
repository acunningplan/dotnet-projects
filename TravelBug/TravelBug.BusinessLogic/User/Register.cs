using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TravelBug.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;
using TravelBug.Entities.User;

namespace TravelBug.BusinessLogic
{
    public class Register
    {
        public class Command
        {
            public string DisplayName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }


        private readonly TravelBugContext _context;
        private readonly UserManager<AppUser> _userManager;
        public Register(TravelBugContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> Handle(Command request, CancellationToken cancellationToken)
        {
            //if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
            //    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            //if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
            //throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            var user = new AppUser
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new User
                {
                    DisplayName = user.DisplayName,
                    Username = user.UserName,
                    Photo = user.UserPhoto.Url
                };
            }

            throw new Exception("Problem creating user");
        }

    }
}