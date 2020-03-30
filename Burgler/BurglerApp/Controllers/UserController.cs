using Burgler.BusinessLogic.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost("signin")]
        public async Task<ActionResult<bool>> SignIn(SignInQuery query)
        {
            var user = await _userServices.SignIn(query);
            return true;
        }
    }
}
