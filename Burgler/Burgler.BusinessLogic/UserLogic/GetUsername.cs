using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public static class GetUsername
    {
        public static string GetUsernameMethod(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        public static async Task<UserData> GetUserMethod(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IJwtServices jwtServices)
        {
            var username = GetUsernameMethod(httpContextAccessor);

            var user = await userManager.FindByNameAsync(username);

            var userData = new UserData
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Token = jwtServices.CreateToken(user),
                Image = null
            };

            return userData;
        }
    }
}
