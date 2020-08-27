using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
//using Application.Errors;
//using Application.Interfaces;
//using MediatR;
using Microsoft.AspNetCore.Identity;
using TravelBug.Entities;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.Exceptions;

namespace TravelBug.Infrastructure
{
    public class ExternalLogin
    {
        public class Query
        {
            public string AccessToken { get; set; }
        }

        private readonly UserManager<AppUser> _userManager;
        //private readonly IFacebookAccessor _facebookAccessor;
        //private readonly IJwtGenerator _jwtGenerator;
        public ExternalLogin(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var userInfo = new AppUser();
            //var userInfo = await _facebookAccessor.FacebookLogin(request.AccessToken);

            if (userInfo == null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem validating token" });

            var user = await _userManager.FindByEmailAsync(userInfo.Email);

            if (user == null)
            {
                user = new AppUser
                {
                    //DisplayName = userInfo.Name,
                    Id = userInfo.Id,
                    Email = userInfo.Email,
                    UserName = "fb_" + userInfo.Id
                };

                var photo = new UserPhoto
                {
                    Id = "fb_" + userInfo.Id,
                    Url = userInfo.UserPhoto.Url,
                };

                var result = await _userManager.CreateAsync(user);

                if (!result.Succeeded)
                    throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem creating user" });
            }

            return new UserDto
            {
                DisplayName = user.DisplayName,
                //Token = _jwtGenerator.CreateToken(user),
                Username = user.UserName,
                Photo = user.UserPhoto.Url
            };
        }

    }
}