using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public static class ExternalFBLogin
    {
        public class Query
        {
            public string AccessToken { get; set; }
        }
        public static async Task<UserData> ExternalFBLoginMethod(Query query, UserManager<AppUser> userManager, IJwtServices jwtServices)
        {
            var userInfo = await LoginByFB.LoginByFBMethod(query.AccessToken);
            var user = await userManager.FindByNameAsync($"fb_{userInfo.Id}");
            if (user == null)
            {
                user = new AppUser
                {
                    DisplayName = userInfo.Name,
                    Id = userInfo.Id,
                    UserName = $"fb_{userInfo.Id}"
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
