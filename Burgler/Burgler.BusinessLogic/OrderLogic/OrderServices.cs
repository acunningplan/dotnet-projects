using AutoMapper;
using Burgler.BusinessLogic.UserLogic;
using Burgler.Entities.OrderNS;
using BurglerContextLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class OrderServices : IOrderServices
    {
        private readonly BurglerContext _dbContext;
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public OrderServices(BurglerContext dbContext, IUserServices userServices, IMapper mapper)
        {
            _dbContext = dbContext;
            _userServices = userServices;
            _mapper = mapper;
        }

        // Queries
        public async Task<Order> GetOrder(string id) => await Get.GetMethod(id, _dbContext);
        public async Task<List<OrderDto>> GetListOfOrders() => await Get.GetManyMethod(_dbContext, _userServices, _mapper);

        // Commands
        public async Task CreateOrder(CreateCommand cmd) => await Create.CreateMethod(cmd, _dbContext, _userServices);
        public async Task EditOrder(EditCommand cmd) => await Edit.EditMethod(cmd, _dbContext);
        public async Task CancelOrder(string id) => await Cancel.CancelMethod(id, _dbContext);
        public async Task DeleteOrder(Guid id) => await Delete.DeleteMethod(id, _dbContext);
    }
}
