using Burgler.BusinessLogic.UserLogic;
using BurglerContextLib;
using System;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class OrderServices : IOrderServices
    {
        private readonly Cancel cancel = new Cancel();
        private readonly Create create = new Create();
        private readonly Edit edit = new Edit();
        private readonly Delete delete = new Delete();


        public OrderServices(BurglerContext dbContext, IUserServices userServices)
        {
            cancel.Inject(dbContext, userServices);
            create.Inject(dbContext, userServices);
            edit.Inject(dbContext, userServices);
            delete.Inject(dbContext, userServices);
        }

        public async Task<bool> CancelOrder(Guid id) => await cancel.CancelOrder(id);
        public async Task<bool> CreateOrder(CreateCommand cmd) => await create.CreateOrder(cmd);
        public async Task<bool> EditOrder(EditCommand cmd) => await edit.EditOrder(cmd);
        public async Task<bool> DeleteOrder(Guid id) => await delete.DeleteOrder(id);
    }
}
