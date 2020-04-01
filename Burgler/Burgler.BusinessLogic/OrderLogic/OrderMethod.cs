using BurglerContextLib;
using Burgler.BusinessLogic.UserLogic;

using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.OrderLogic
{
    public class OrderMethod
    {
        protected BurglerContext DbContext { get; private set; }
        protected IUserServices UserServices { get; private set; }
        public void Inject(BurglerContext dbContext, IUserServices userServices)
        {
            DbContext = dbContext;
            UserServices = userServices;
        }
    }
}
