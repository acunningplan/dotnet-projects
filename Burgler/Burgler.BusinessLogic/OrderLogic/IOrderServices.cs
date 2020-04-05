using Burgler.Entities.OrderNS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public interface IOrderServices
    {
        Task<Order> GetOrder(Guid Id);
        Task<List<Order>> GetOrders(string username);
        Task CreateOrder(CreateCommand command);
        Task EditOrder(EditCommand command);
        Task CancelOrder(Guid Id);
        Task DeleteOrder(Guid Id);
    }
}
