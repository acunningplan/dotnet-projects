using Burgler.BusinessLogic.MenuLogic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuServices _menuServices;

        public MenuController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }
        [HttpGet]
        public async Task<Menu> Get()
        {
            return await _menuServices.GetMenu();
        }
    }
}