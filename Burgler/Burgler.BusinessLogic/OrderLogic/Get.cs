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
using Burgler.BusinessLogic.MenuLogic;

namespace Burgler.BusinessLogic.OrderLogic
{
    public static class Get
    {
        public static async Task<OrderDto> GetMethod(Guid id, IMenuServices menuServices, BurglerContext dbContext, IMapper _mapper)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            var orderToReturn = _mapper.Map<Order, OrderDto>(order);

            var menu = await menuServices.GetMenu();
            orderToReturn.Calories = menu.CalculateTotalCalories(order);
            orderToReturn.Price = menu.CalculateTotalPrice(order);

            return orderToReturn;
        }
    }
}
