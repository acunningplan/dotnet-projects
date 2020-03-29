
using FluentValidation;
using OrderEntitiesLib;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderServicesLib
{
    public class CreateCommand
    {
        public string UserId { get; set; }
        public IEnumerable<FoodOrder> FoodOrders { get; set; }
    }
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
    public partial class OrderServices
    {
        public async Task<bool> CreateOrder(CreateCommand command)
        {
            var order = new Order
            {
                UserId = command.UserId,
                FoodOrders = command.FoodOrders
            };

            _dbContext.Orders.Add(order);

            bool success = await _dbContext.SaveChangesAsync() > 0;

            return success;
        }
    }
}
