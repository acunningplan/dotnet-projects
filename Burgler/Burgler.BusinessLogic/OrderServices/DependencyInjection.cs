using BurglerContextLib;

namespace Burgler.BusinessLogic.OrderServices
{
    public partial class OrderServices : IOrderServices
    {
        private readonly BurglerContext _dbContext;

        public OrderServices(BurglerContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
