using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure.UserLogic;

namespace TravelBug.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IRefreshTokenService _refreshTokenService;

        public UserController(ILoginService loginService, IRegisterService registerService, IRefreshTokenService refreshTokenService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _refreshTokenService = refreshTokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<User> Login(LoginInput loginInput)
        {
            return await _loginService.Login(loginInput);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<User> Register(RegisterInput registerInput)
        {
            return await _registerService.Register(registerInput);
        }

        [HttpPost("refreshToken")]
        public async Task<User> RefreshToken(string refreshToken)
        {
            return await _refreshTokenService.GetRefreshToken(refreshToken);
        }
    }
}
