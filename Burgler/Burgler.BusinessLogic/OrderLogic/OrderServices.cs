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
        public async Task<OrderDto> GetOrder(Guid id) => await Get.GetMethod(id, _dbContext, _mapper);
        public async Task<List<OrderDto>> GetPendingOrders() => await GetMany.GetManyMethod(OrderType.PendingOrders, _dbContext, _userServices, _mapper);
        public async Task<List<OrderDto>> GetPlacedOrders() => await GetMany.GetManyMethod(OrderType.PlacedOrders, _dbContext, _userServices, _mapper);

        // Commands
        public async Task CreateOrder(CreateCommand cmd) => await Create.CreateMethod(cmd, _dbContext, _userServices, _mapper);
        public async Task EditOrder(EditCommand cmd) => await Edit.EditMethod(cmd, _dbContext, _mapper);
        public async Task ChangeOrderStatus(ChangeStatusCommand cmd, Guid id) => await ChangeStatus.ChangeStatusMethod(cmd, id, _dbContext);
        public async Task StaffUpdateOrder(StaffUpdateCommand cmd, Guid id) => await StaffUpdate.StaffUpdateOrder(cmd, id, _dbContext);
        public async Task DeleteOrder(Guid id) => await Delete.DeleteMethod(id, _dbContext);
    }
}
