using System.Collections.Generic;
using System.Threading.Tasks;
using FunFacts.Dtos;
using FunFacts.Entities.User;

namespace FunFacts.Infrastructure
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