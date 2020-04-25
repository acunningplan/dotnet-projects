using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Get
    {
        public static async Task<OrderDto> GetMethod(Guid id, BurglerContext dbContext, IMapper _mapper)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            var orderToReturn = _mapper.Map<Order, OrderDto>(order);

            return orderToReturn;
        }
    }
}
