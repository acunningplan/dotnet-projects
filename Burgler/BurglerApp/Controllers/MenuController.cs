using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Burgler.BusinessLogic.MenuLogic;
using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly BurglerContext _dbContext;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public MenuController(BurglerContext dbContext, IUserServices userServices, IMapper mapper)
        {
            _dbContext = dbContext;
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Menu> GetPendingOrders()
        {
            return GetMenu.GetMenuMethod(_dbContext);
        }
    }
}