using System;
using System.Collections.Generic;
using System.Text;

namespace TravelBug.BusinessLogic.BlogLogic
{
    public class Create
    {
        //   // Create empty order
        //public static async Task CreateMethod(CreateCommand command, BurglerContext dbContext, IUserServices userServices, IMapper mapper, IMenuServices menuServices)
        //{

        //    string username = userServices.GetCurrentUsername();

        //    // Check if there's already a pending order. If yes, do not create empty order
        //    var orders = await dbContext.Orders.Where(
        //           order => order.User.UserName == username
        //                & DateTime.MinValue == order.CancelledAt
        //                & DateTime.MinValue == order.OrderedAt
        //       ).ToListAsync();

        //    if (orders.Count > 0) return;

        //    var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == username) ??
        //        throw new RestException(HttpStatusCode.Unauthorized, "No user with given username.");

        //    var order = new Order();
        //    order.User = user;
        //    dbContext.Orders.Add(order);

        //    _ = await dbContext.SaveChangesAsync() > 0 ? true :
        //        throw new RestException(HttpStatusCode.InternalServerError, "Problem creating order.");
        //}
    }
}
