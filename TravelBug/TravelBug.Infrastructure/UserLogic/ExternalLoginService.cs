using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;
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

        //private readonly IFacebookAccessor _facebookAccessor;
        //private readonly IJwtGenerator _jwtGenerator;
        public ExternalLoginService(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<User> SaveUser(UserData userData, string socialMedia)
        {

            var user = await _userManager.FindByEmailAsync(userData.Email);

            var refreshToken = _jwtGenerator.GenerateRefreshToken();

            if (user != null)
            {
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
                return new User(user, _jwtGenerator, refreshToken.Token);
            }


            user = new AppUser
            {
                //DisplayName = userInfo.Name,
                Id = userData.Id,
                Email = userData.Email,
                UserName = $"{socialMedia}_" + userData.Id
            };

            var photo = new UserPhoto
            {
                Id = $"{socialMedia}_" + userData.Id,
                Url = userData.PhotoUrl,
            };

            user.Photo = photo;
            user.RefreshTokens.Add(refreshToken);
            user.DisplayName = userData.Username;

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem creating user" });

            return new User(user, _jwtGenerator, refreshToken.Token);
        }

    }
}