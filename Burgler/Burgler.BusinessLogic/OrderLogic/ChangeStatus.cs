using Burgler.BusinessLogic.ErrorHandlingLogic;
using BurglerContextLib;
using FluentValidation;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public enum ChangeStatusType
    {
        PlaceOrder,
        Cancel
    }
    public class ChangeStatusCommand
    {
        public Guid Id { get; set; }
        public int StatusChange { get; set; }
    }
    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
            RuleFor(x => x.StatusChange).Must(sc => Enum.IsDefined(typeof(ChangeStatusType), sc));
        }
    }
    public static class ChangeStatus
    {
        public static async Task ChangeStatusMethod(ChangeStatusCommand command, BurglerContext dbContext)
        {
            var order = await dbContext.Orders.FindAsync(command.Id) ??
                throw new RestException(HttpStatusCode.NotFound, "Order not found");

            switch ((ChangeStatusType)command.StatusChange)
            {
                case ChangeStatusType.PlaceOrder:
                    order.OrderedAt = DateTime.Now;
                    break;
                case ChangeStatusType.Cancel:
                    order.CancelledAt = DateTime.Now;
                    break;
            }

            _ = await dbContext.SaveChangesAsync() > 0 ? true :
                throw new RestException(HttpStatusCode.InternalServerError, "Problem cancelling order");
        }
    }
}
