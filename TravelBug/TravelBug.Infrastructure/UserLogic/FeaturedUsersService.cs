using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;

namespace TravelBug.Infrastructure.UserLogic
{
    public interface IFeaturedUsersService
    {
        Task<List<User>> GetFeaturedUsers();
    }

    public class FeaturedUsersService : IFeaturedUsersService
    {
        private readonly TravelBugContext _context;
        private readonly IList<string> _featuredUsers = new List<string> { "ed", "sam", "sarah" };

        public FeaturedUsersService(TravelBugContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetFeaturedUsers()
        {
            var appUsers = await _context.Users
                .Where(u => _featuredUsers.Contains(u.UserName))
                .ToListAsync();

            var users = new List<User>();
            appUsers.ForEach(u => users.Add(new User(u)));

            return users;
        }
    }
}
