using Burgler.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Burgler.BusinessLogic.UserLogic.UserServices;

namespace Burgler.BusinessLogic.UserLogic
{
    public interface IUserServices
    {
        Task<UserData> LoginUser(LoginQuery query);
        Task<UserData> RegisterUser(RegisterCommand query);
        string GetCurrentUsername();
        Task<UserData> GetCurrentUser();
        Task<UserData> LoginUserByFB(ExternalFBLogin.Query query);
        Task<UserData> LoginUserByGoogle(ExternalGoogleLogin.Query query);
    }
}
