using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public enum LoginMethod
    {
        Facebook,
        Google
    }
    public class UserInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public static class ExternalLogin
    {
        public class Query
        {
            public string AccessToken { get; set; }
        }
        public static async Task<UserData> ExternalLoginMethod(Query query, LoginMethod loginMethod, UserManager<AppUser> userManager, IJwtServices jwtServices)
        {
            var userInfo = loginMethod == LoginMethod.Facebook ?
                await LoginByFB.LoginByFBMethod(query.AccessToken) :
                 await LoginByGoogle.LoginByGoogleMethod(query.AccessToken);

            string username = loginMethod == LoginMethod.Facebook ? $"fb_{userInfo.Id}" : $"google_{userInfo.Id}";

            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new AppUser
                {
                    DisplayName = userInfo.Name,
                    UserName = username
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
