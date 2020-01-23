using ca_sln_2.Application.Common.Models;
using System.Threading.Tasks;

namespace ca_sln_2.Application
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
