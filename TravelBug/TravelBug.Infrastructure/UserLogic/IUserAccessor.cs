using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Dtos;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure
{
  public interface IUserAccessor
  {
    string GetCurrentUsername();
    Task<AppUser> GetCurrentAppUser();
    Task<AppUser> GetAppUser(string username);
    Task<List<AppUser>> GetAllAppUsers();
    Task<User> GetUser(string username);
  }
}