using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Burgler.BusinessLogic.OrderLogic;
using Burgler.Entities.OrderNS;
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

        [HttpGet]
        [Authorize]
        public async Task<List<OrderDto>> GetListOfOrders()
        {
            return await _orderServices.GetListOfOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrder(string id)
        {
            return await _orderServices.GetOrder(id);
        }

        [HttpPost]
        [Authorize]
        public async Task CreateOrder(CreateCommand command)
        {
            await _orderServices.CreateOrder(command);
        }

        [HttpPut("{id}")]
        public async Task EditOrder(EditCommand command)
        {
            await _orderServices.EditOrder(command);
        }

        [HttpPatch("{id}")]
        public async Task CancelOrder(string id)
        {
            await _orderServices.CancelOrder(id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder(Guid id)
        {
            await _orderServices.DeleteOrder(id);
        }
    }
}