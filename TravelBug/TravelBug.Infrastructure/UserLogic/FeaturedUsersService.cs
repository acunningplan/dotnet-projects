using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;
using TravelBug.Dtos;
using TravelBug.Entities.UserData;

namespace TravelBug.Infrastructure.UserLogic
{
  public interface IFeaturedUsersService
  {
    Task<List<User>> GetFeaturedUsers();
  }

  public class FeaturedUsersService : IFeaturedUsersService
  {
    private readonly TravelBugContext _context;
    private readonly IMapper _mapper;
    private readonly IList<string> _featuredUsers = new List<string> { "ed", "sam", "sarah" };

    public FeaturedUsersService(TravelBugContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<List<User>> GetFeaturedUsers()
    {
      var appUsers = await _context.Users
          .Where(u => _featuredUsers.Contains(u.UserName))
          .ToListAsync();

      var returnedUsers = _mapper.Map<List<AppUser>, List<User>>(appUsers);

      return returnedUsers;
    }
  }
}
