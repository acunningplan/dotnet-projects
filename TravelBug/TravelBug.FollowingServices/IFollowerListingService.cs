using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Dtos;

namespace TravelBug.FollowingServices
{
  public interface IFollowerListingService
  {
    Task<List<User>> ShowFollowings(string username);
    Task<List<User>> ShowFollowers(string username);
  }
}