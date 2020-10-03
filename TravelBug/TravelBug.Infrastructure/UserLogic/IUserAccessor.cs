using System.Threading.Tasks;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
    public interface IUserAccessor
    {
        string GetCurrentUsername();
        Task<AppUser> GetCurrentAppUser();
        Task<AppUser> GetAppUser(string username);
        Task<User> GetUser(string username);
    }
}