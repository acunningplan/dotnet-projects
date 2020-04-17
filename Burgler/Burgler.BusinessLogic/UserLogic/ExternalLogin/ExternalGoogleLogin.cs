using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class ExternalGoogleLogin
    {
        public class Query
        {
            public string AccessToken { get; set; }
        }
        public static async Task<UserData> ExternalGoogleLoginMethod(Query query, UserManager<AppUser> userManager, IJwtServices jwtServices)
        {
            var userInfo = await LoginByGoogle.LoginByGoogleMethod(query.AccessToken);
            if (userInfo.id == null) throw new RestException(HttpStatusCode.NotFound, "User info has no id");

            var user = await userManager.FindByNameAsync($"google_{userInfo.id}");

            if (user == null)
            {
                user = new AppUser
                {
                    DisplayName = userInfo.name,
                    Id = userInfo.id,
                    UserName = $"google_{userInfo.id}"
                };
                var result = await userManager.CreateAsync(user);
                if (!result.Succeeded)
                    throw new RestException(HttpStatusCode.InternalServerError, new { User = "Unable to create user" });
            }
            return new UserData
            {
                DisplayName = user.DisplayName,
                Token = jwtServices.CreateToken(user),
                Username = user.UserName
            };
        }
    }
}
