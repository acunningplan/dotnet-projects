using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OrderServicesLib;

namespace OrderServicesLib
{
    public interface IOrderServices
    {
        Task<bool> CreateOrder(CreateCommand command);
        Task<bool> EditOrder(EditCommand command);
        Task<bool> CancelOrder(Guid Id);
        Task<bool> DeleteOrder(Guid Id);
    }
}
