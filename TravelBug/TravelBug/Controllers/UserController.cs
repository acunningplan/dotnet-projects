using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBug.BusinessLogic;

namespace TravelBug.Web.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public UserController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
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
    }
}
