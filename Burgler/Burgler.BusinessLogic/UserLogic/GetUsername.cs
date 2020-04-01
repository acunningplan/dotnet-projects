using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class GetUsername : UserMethod
    {
        public string GetCurrentUsername()
        {
            return HttpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        public async Task<UserData> GetCurrentUser()
        {
            var username = GetCurrentUsername();

            var user = await UserManager.FindByNameAsync(username);

            var userData = new UserData
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Token = JwtServices.CreateToken(user),
                Image = null
            };

            return userData;
        }
    }
}
