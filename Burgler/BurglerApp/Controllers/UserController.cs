using Burgler.BusinessLogic.UserLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Burgler.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
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
    }
}
