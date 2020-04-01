using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burgler.BusinessLogic.OrderLogic;
using BurglerContextLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        //private readonly BurglerContext _dbContext;
        //private readonly OrderServices _orderServices;

        //public OrderController(BurglerContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _orderServices = new OrderServices(_dbContext);
        //}

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Create(CreateCommand command)
        {
            bool success = await _orderServices.CreateOrder(command);
            return success;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> EditOrder(EditCommand command)
        {
            bool success = await _orderServices.EditOrder(command);
            return success;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<bool>> CancelOrder(Guid id)
        {
            bool success = await _orderServices.CancelOrder(id);
            return success;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOrder(Guid id)
        {
            bool success = await _orderServices.DeleteOrder(id);
            return success;
        }
    }
}