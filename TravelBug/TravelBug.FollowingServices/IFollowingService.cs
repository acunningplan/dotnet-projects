using System.Threading.Tasks;

namespace TravelBug.FollowingServices
{
    public interface IFollowingService
    {
        Task Follow(string username);
        Task Unfollow(string username);
    }
}