using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBug.Entities.User;
using TravelBug.FollowingServices;

namespace TravelBug.Web.Controllers
{
    [ApiController]
    [Route("api/profiles")]
    public class FollowingController : ControllerBase
    {
        private readonly IFollowingService _followingService;
        private readonly IFollowerListingService _followerListingService;

        public FollowingController(IFollowingService followingService, IFollowerListingService followerListingService)
        {
            _followingService = followingService;
            _followerListingService = followerListingService;
        }
        [HttpPost("{username}/follow")]
        public async Task Follow(string username)
        {
            await _followingService.Follow(username);
        }

        [HttpPost("{username}/unfollow")]
        public async Task Unfollow(string username)
        {
            await _followingService.Unfollow(username);
        }

        [HttpGet("{username}/followings")]
        public async Task<List<AppUser>> GetFollowings(string username)
        {
            return await _followerListingService.ShowFollowings(username);
        }

        [HttpGet("{username}/followers")]
        public async Task<List<AppUser>> GetFollowers(string username)
        {
            return await _followerListingService.ShowFollowers(username);
        }
    }
}
