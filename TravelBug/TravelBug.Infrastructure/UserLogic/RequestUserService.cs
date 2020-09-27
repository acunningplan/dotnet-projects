using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;
using TravelBug.Infrastructure.Exceptions;

namespace TravelBug.Infrastructure.UserLogic
{
  public interface IRequestUsersService
  {
    Task<User> GetUser(string username);
  }

  public class RequestUsersService : IRequestUsersService
  {
    private readonly TravelBugContext _context;

    public RequestUsersService(TravelBugContext context)
    {
      _context = context;
    }

    public async Task<User> GetUser(string username)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username)
      ?? throw new RestException(HttpStatusCode.NotFound, $"User {username} not found.");
      return new User(user);
    }
  }
}
