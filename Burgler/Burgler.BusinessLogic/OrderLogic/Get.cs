using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Get
    {
        public static async Task<OrderDto> GetMethod(Guid id, BurglerContext dbContext, IMapper _mapper)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            var orderToReturn = _mapper.Map<Order, OrderDto>(order);

            orderToReturn.Price = order.CalculateCalories();
            orderToReturn.Calories = order.CalculatePrice();

            return orderToReturn;
        }
    }
}
