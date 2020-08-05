using Burgler.BusinessLogic.UserLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Burgler.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowedOrigins")]
    [ApiController]
    public class UserController
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserData>> Login(LoginQuery query)
        {
            return await _userServices.LoginUser(query);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task Register(RegisterCommand command)
        {
            await _userServices.RegisterUser(command);
        }

        [HttpGet]
        public async Task<ActionResult<UserData>> CurrentUser()
        {
            var userData = await _userServices.GetCurrentUser();
            return userData;
        }

        [AllowAnonymous]
        //[EnableCors("AllowedOrigins")]
        [HttpPost("facebook")]
        public async Task<UserData> FacebookLogin(ExternalLogin.Query query)
        {
            return await _userServices.LoginUserByFB(query);
        }

        [AllowAnonymous]
        //[EnableCors("AllowedOrigins")]
        [HttpPost("google")]
        public async Task<UserData> GoogleLogin(ExternalLogin.Query query)
        {
            return await _userServices.LoginUserByGoogle(query);
        }
    }
}
