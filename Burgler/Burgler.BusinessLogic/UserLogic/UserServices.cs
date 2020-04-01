using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities;
using Burgler.Entities.User;
using BurglerContextLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.UserLogic
{
    public class UserServices : IUserServices
    {
        private readonly Login _login = new Login();
        private readonly Register _register = new Register();
        private readonly GetUsername _getUsername = new GetUsername();
        public UserServices(BurglerContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtServices jwtServices, IHttpContextAccessor httpContextAccessor)
        {
            _login.Inject(context, userManager, signInManager, jwtServices, httpContextAccessor);
            _register.Inject(context, userManager, signInManager, jwtServices, httpContextAccessor);
            _getUsername.Inject(context, userManager, signInManager, jwtServices, httpContextAccessor);
        }

        public Task<UserData> LoginUser(LoginQuery query) => _login.LoginUser(query);
        public Task<UserData> RegisterUser(RegisterCommand query) => _register.RegisterUser(query);
        public string GetCurrentUsername() => _getUsername.GetCurrentUsername();
        public Task<UserData> GetCurrentUser() => _getUsername.GetCurrentUser();
    }
}
