using System.Threading;
using System.Threading.Tasks;

namespace TravelBug.Infrastructure
{
    public interface IExternalLoginService
    {
        Task<User> SaveUser(ExternalLoginService.UserData request, string socialMedia);
    }
}