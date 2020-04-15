using Burgler.BusinessLogic.OrderLogic;
using Burgler.Entities.OrderNS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<List<OrderDto>> GetListOfOrders()
        {
            return await _orderServices.GetListOfOrders();
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrder(Guid id)
        {
            return await _orderServices.GetOrder(id);
        }

        [HttpPost]
        public async Task CreateOrder(CreateCommand command)
        {
            await _orderServices.CreateOrder(command);
        }

        [HttpPatch("edit")]
        public async Task EditOrder(EditCommand command)
        {
            await _orderServices.EditOrder(command);
        }

        [HttpPatch("change/{id}")]
        public async Task ChangeOrderStatus(ChangeStatusCommand command, Guid id)
        {
            await _orderServices.ChangeOrderStatus(command, id);
        }

        [HttpPatch("staff/{id}")]
        [Authorize(Policy = "IsStaff")]
        public async Task StaffUpdateOrder(StaffUpdateCommand command, Guid id)
        {
            await _orderServices.StaffUpdateOrder(command, id);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "IsStaff")]
        public async Task DeleteOrder(Guid id)
        {
            await _orderServices.DeleteOrder(id);
        }
    }
}