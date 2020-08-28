using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
    public class CurrentUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserAccessor _userAccessor;
        public CurrentUser(UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
        }

        public async Task<User> GetCurrentUser(CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new User(user, _jwtGenerator, refreshToken.Token);
        }
    }
}
