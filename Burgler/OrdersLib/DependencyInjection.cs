using BurglerContextLib;

namespace OrderServicesLib
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
