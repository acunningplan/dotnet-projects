using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities.User;

namespace TravelBug.FollowingServices
{
    public class FollowerListingService : IFollowerListingService
    {
        private readonly TravelBugContext _context;

        public FollowerListingService(TravelBugContext context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> ShowFollowings(string username)
        {
            return await _context.Followings
                .Where(f => f.Observer.UserName == username)
                .Select(f => f.Target).ToListAsync();
        }
        public async Task<List<AppUser>> ShowFollowers(string username)
        {
            return await _context.Followings
                .Where(f => f.Target.UserName == username)
                .Select(f => f.Observer).ToListAsync();
        }
    }
}
