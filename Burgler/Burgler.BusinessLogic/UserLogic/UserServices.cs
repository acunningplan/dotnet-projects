using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using BurglerContextLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class UserServices : IUserServices
    {
        private readonly BurglerContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtServices _jwtServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(BurglerContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtServices jwtServices, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtServices = jwtServices;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserData> LoginUser(LoginQuery query) => await Login.LoginMethod(query, _userManager, _signInManager, _jwtServices);
        public async Task<UserData> RegisterUser(RegisterCommand command) => await Register.RegisterMethod(command, _dbContext, _userManager);
        public string GetCurrentUsername() => GetUsername.GetUsernameMethod(_httpContextAccessor);
        public async Task<UserData> GetCurrentUser() => await GetUsername.GetUserMethod(_httpContextAccessor, _userManager, _jwtServices);
    }
}
