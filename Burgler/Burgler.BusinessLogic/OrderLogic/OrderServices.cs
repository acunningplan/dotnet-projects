using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using System;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class OrderServices : IOrderServices
    {
        private readonly BurglerContext _dbContext;
        private readonly IUserServices _userServices;

        public OrderServices(BurglerContext dbContext, IUserServices userServices)
        {
            _dbContext = dbContext;
            _userServices = userServices;
        }

        public async Task<bool> CancelOrder(Guid id) => await Cancel.CancelMethod(id, _dbContext);
        public async Task<bool> CreateOrder(CreateCommand cmd) => await Create.CreateMethod(cmd, _dbContext, _userServices);
        public async Task<bool> EditOrder(EditCommand cmd) => await Edit.EditMethod(cmd, _dbContext);
        public async Task<bool> DeleteOrder(Guid id) => await Delete.DeleteMethod(id, _dbContext);
    }
}
