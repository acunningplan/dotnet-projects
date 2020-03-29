using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderServicesLib;

namespace BurglerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _orderServices;

        public OrderController(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateOrder(CreateCommand command)
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