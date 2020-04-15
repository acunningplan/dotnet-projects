using Burgler.BusinessLogic.ErrorHandlingLogic;
using BurglerContextLib;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public enum StaffUpdateType
    {
        FoodReady,
        FoodTaken
    }
    public class StaffUpdateCommand
    {
        public int StatusChange { get; set; }
    }
    public class StaffUpdateCommandValidator : AbstractValidator<StaffUpdateCommand>
    {
        public StaffUpdateCommandValidator()
        {
            RuleFor(x => x.StatusChange).Must(sc => Enum.IsDefined(typeof(StaffUpdateType), sc));
        }
    }
    public class StaffUpdate
    {
        public static async Task StaffUpdateOrder(StaffUpdateCommand command, Guid id, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            switch ((StaffUpdateType)command.StatusChange)
            {
                case StaffUpdateType.FoodReady:
                    order.ReadyAt = DateTime.Now;
                    break;
                case StaffUpdateType.FoodTaken:
                    order.FoodTakenAt = DateTime.Now;
                    break;
            }

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem cancelling order");
        }
    }
}
