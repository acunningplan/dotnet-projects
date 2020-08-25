using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Entities.User;

namespace TravelBug.FollowingServices
{
    public interface IFollowerListingService
    {
        Task<List<AppUser>> ShowFollowings(string username);
        Task<List<AppUser>> ShowFollowers(string username);
    }
}