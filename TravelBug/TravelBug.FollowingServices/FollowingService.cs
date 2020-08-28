using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Infrastructure.Exceptions;
using TravelBug.Context;
using TravelBug.Entities.UserData;

namespace TravelBug.FollowingServices
{
    public class FollowingService : IFollowingService
    {
        private readonly TravelBugContext _context;
        private readonly IUserAccessor _userAccessor;
        private AppUser _observer;
        private AppUser _target;

        public FollowingService(TravelBugContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        private async Task<UserFollowing> FindFollowing(string username)
        {
            _observer = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());

            _target = await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);

            if (_target == null)
                throw new RestException(HttpStatusCode.NotFound, new { User = "Not found" });

            return await _context.Followings.SingleOrDefaultAsync(x => x.ObserverId == _observer.Id && x.TargetId == _target.Id);
        }
        public async Task Follow(string username)
        {
            var following = await FindFollowing(username);

            if (following != null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Already following user." });

            following = new UserFollowing
            {
                Observer = _observer,
                Target = _target
            };

            _context.Followings.Add(following);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return;
            throw new Exception("Cannot follow user.");
        }
        public async Task Unfollow(string username)
        {
            var following = await FindFollowing(username);

            if (following == null)
                throw new RestException(HttpStatusCode.BadRequest, new { User = "Not following user." });

            _context.Followings.Remove(following);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return;
            throw new Exception("Cannot unfollow user.");
        }
    }
}
