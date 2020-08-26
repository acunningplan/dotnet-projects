using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TravelBug.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;
using TravelBug.Entities.UserData;
using TravelBug.BusinessLogic.Exceptions;

namespace TravelBug.BusinessLogic
{
    public interface IRegisterService
    {
        Task<UserDto> Register(RegisterInput input);
    }

    public class RegisterInput
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterService : IRegisterService
    {

        private readonly TravelBugContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public RegisterService(TravelBugContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _context = context;
        }

        public async Task<UserDto> Register(RegisterInput request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            var user = new AppUser
            {
                DisplayName = request.DisplayName,
                Email = request.Email,
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Token = _jwtGenerator.CreateToken(user),
                    Username = user.UserName,
                    //Photo = user.UserPhoto.Url
                };
            }
            throw new Exception("Problem creating user");
        }
    }
}