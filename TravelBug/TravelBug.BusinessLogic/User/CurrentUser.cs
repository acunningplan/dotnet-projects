using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TravelBug.Entities.User;

namespace TravelBug.BusinessLogic
{
    public class CurrentUser
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly IJwtGenerator _jwtGenerator;
        //private readonly IUserAccessor _userAccessor;
        public CurrentUser(UserManager<AppUser> userManager)
        {
            //_userAccessor = userAccessor;
            //_jwtGenerator = jwtGenerator;
            _userManager = userManager;
        }

        public async Task<User> Handle(CancellationToken cancellationToken)
        {
            var user = new AppUser();
            //var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());

            return new User
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                //Token = _jwtGenerator.CreateToken(user),
                Photo = user.UserPhoto.Url
            };
        }
    }
}
