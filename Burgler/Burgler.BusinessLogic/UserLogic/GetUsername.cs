using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public static class GetUsername
    {
        public static string GetUsernameMethod(IHttpContextAccessor httpContextAccessor)
        {
            string username = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ??
                throw new RestException(HttpStatusCode.Unauthorized, "Cannot find username. Please register or login.");

            return username;
        }
        public static async Task<UserData> GetUserMethod(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IJwtServices jwtServices)
        {
            var username = GetUsernameMethod(httpContextAccessor);

            var user = await userManager.FindByNameAsync(username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user found with given username.");

            var userData = new UserData
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Staff = user.Staff,
                Token = jwtServices.CreateToken(user),
                Image = null
            };
            return userData;
        }
    }
}
