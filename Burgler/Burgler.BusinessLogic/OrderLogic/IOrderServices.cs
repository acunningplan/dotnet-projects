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
        Task<List<OrderDto>> GetListOfOrders();
        Task CreateOrder(CreateCommand command);
        Task EditOrder(EditCommand command);
        Task ChangeOrderStatus(ChangeStatusCommand command);
        Task DeleteOrder(Guid Id);
    }
}
