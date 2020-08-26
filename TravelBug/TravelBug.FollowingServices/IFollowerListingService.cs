using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Entities.UserData;

namespace TravelBug.FollowingServices
{
    public interface IFollowerListingService
    {
        Task<List<UserDto>> ShowFollowings(string username);
        Task<List<UserDto>> ShowFollowers(string username);
    }
}