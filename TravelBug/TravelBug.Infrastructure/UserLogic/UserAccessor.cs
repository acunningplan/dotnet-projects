using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{

    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;

        public UserAccessor(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
        }

        public string GetCurrentUsername()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }

        public async Task<AppUser> GetCurrentAppUser()
        {
            var username = GetCurrentUsername();
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<AppUser> GetAppUser(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new User(user, _jwtGenerator, refreshToken.Token);
        }
    }
}
