using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Threading.Tasks;
using TravelBug.Dtos;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.Exceptions;

namespace TravelBug.Infrastructure
{
    public class ExternalLoginService : IExternalLoginService
    {
        public class UserData
        {
            public string AccessToken { get; set; }
            public string Id { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string PhotoUrl { get; set; }
        }

        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        //private readonly IFacebookAccessor _facebookAccessor;
        //private readonly IJwtGenerator _jwtGenerator;
        public ExternalLoginService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<User> SaveUser(UserData userData, string socialMedia)
        {

            var user = await _userManager.FindByEmailAsync(userData.Email);

            var refreshToken = _jwtGenerator.GenerateRefreshToken();

            // Declare returned user
            User returnedUser;

            // If there is an existing user with the same email, simply update the user with the refresh token
            if (user != null)
            {
                user.RefreshTokens.Add(refreshToken);
                user.LastLogin = DateTime.Now;
                await _userManager.UpdateAsync(user);

                returnedUser = _mapper.Map<AppUser, User>(user);
                returnedUser.Token = _jwtGenerator.CreateToken(user);
                returnedUser.RefreshToken = refreshToken.Token;

                return returnedUser;
            }

            // Otherwise, create the new user with info from social media and save to database
            user = new AppUser
            {
                //DisplayName = userInfo.Name,
                Id = userData.Id,
                Email = userData.Email,
                UserName = $"{socialMedia}_" + userData.Id,
                EmailConfirmed = true
            };

            var photo = new UserPhoto
            {
                // ImgurId = $"{socialMedia}_" + userData.Id,
                Url = userData.PhotoUrl,
            };

            user.ProfilePicture = photo;
            user.RefreshTokens.Add(refreshToken);
            user.DisplayName = userData.Username;

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem creating user" });

            returnedUser = _mapper.Map<AppUser, User>(user);
            returnedUser.Token = _jwtGenerator.CreateToken(user);
            returnedUser.RefreshToken = refreshToken.Token;

            return returnedUser;
        }

    }
}