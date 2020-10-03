using System.Threading.Tasks;
using TravelBug.Dtos;

namespace TravelBug.Infrastructure
{
  public interface IExternalLoginService
  {
    Task<User> SaveUser(ExternalLoginService.UserData request, string socialMedia);
  }
}