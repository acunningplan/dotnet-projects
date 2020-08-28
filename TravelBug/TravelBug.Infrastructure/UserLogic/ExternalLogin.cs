using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IJwtGenerator _jwtGenerator;

        //private readonly IFacebookAccessor _facebookAccessor;
        //private readonly IJwtGenerator _jwtGenerator;
        public ExternalLogin(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<User> Handle(Query request, CancellationToken cancellationToken)
        {
            var userInfo = new AppUser();
            //var userInfo = await _facebookAccessor.FacebookLogin(request.AccessToken);

            if (userInfo == null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem validating token" });

            var user = await _userManager.FindByEmailAsync(userInfo.Email);

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
                Id = userInfo.Id,
                Email = userInfo.Email,
                UserName = "fb_" + userInfo.Id
            };

            var photo = new UserPhoto
            {
                Id = "fb_" + userInfo.Id,
                Url = userInfo.Photo.Url,
            };

            user.Photo = photo;
            user.RefreshTokens.Add(refreshToken);

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Problem creating user" });

            return new User(user, _jwtGenerator, refreshToken.Token);
        }

    }
}