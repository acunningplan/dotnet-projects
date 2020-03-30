using Burgler.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Burgler.BusinessLogic.UserServices.UserServices;

namespace Burgler.BusinessLogic.UserServices
{
    public interface IUserServices
    {
        Task<User> SignIn(SignInQuery query);
    }
}
