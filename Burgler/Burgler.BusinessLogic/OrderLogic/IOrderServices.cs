using Burgler.Entities.OrderNS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public interface IOrderServices
    {
        Task<Order> GetOrder(string Id);
        Task<List<OrderDto>> GetListOfOrders();
        Task CreateOrder(CreateCommand command);
        Task EditOrder(EditCommand command);
        Task CancelOrder(string Id);
        Task DeleteOrder(Guid Id);
    }
}
