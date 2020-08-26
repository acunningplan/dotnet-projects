using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities.UserData;

namespace TravelBug.FollowingServices
{
    public class FollowerListingService : IFollowerListingService
    {
        private readonly TravelBugContext _context;
        private readonly IMapper _mapper;

        public FollowerListingService(TravelBugContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> ShowFollowings(string username)
        {
            var followings = await _context.Followings
                .Where(f => f.Observer.UserName == username)
                .Select(f => f.Target).ToListAsync();
            return _mapper.Map<List<AppUser>, List<UserDto>>(followings);
        }
        public async Task<List<UserDto>> ShowFollowers(string username)
        {
            var followers = await _context.Followings
                .Where(f => f.Target.UserName == username)
                .Select(f => f.Observer).ToListAsync();
            return _mapper.Map<List<AppUser>, List<UserDto>>(followers);
        }
    }
}
