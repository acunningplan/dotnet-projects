using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserServices
{
    public partial class UserServices : IUserServices
    {
        public async Task<UserData> GetCurrentUser()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByNameAsync(username);

            var userData = new UserData
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                Token = _jwtServices.CreateToken(user),
                Image = null
            };

            return userData;
        }
    }
}
