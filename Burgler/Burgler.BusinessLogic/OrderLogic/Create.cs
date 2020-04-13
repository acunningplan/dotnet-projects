using AutoMapper;
using Burgler.BusinessLogic.ErrorHandlingLogic;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class CreateCommand : OrderDto { }
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleForEach(o => o.BurgerItems).Must(bi => bi.Validate());
            RuleForEach(o => o.SideItems).Must(si => si.Validate());
            RuleForEach(o => o.DrinkItems).Must(di => di.Validate());
        }
    }
    public static class Create
    {
        public static async Task CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices, IMapper mapper)
        {
            var order = mapper.Map<OrderDto, Order>(command);

            string username = userServices.GetCurrentUsername();

            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
                throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

            order.User = user;
            dbContext.Orders.Add(order);

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order.");
        }
    }
}
