using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TravelBug.Context;
using TravelBug.Dtos;
using TravelBug.Entities.UserData;
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
    private readonly IMapper _mapper;

    public RequestUsersService(TravelBugContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<User> GetUser(string username)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username)
      ?? throw new RestException(HttpStatusCode.NotFound, $"User {username} not found.");
      return _mapper.Map<AppUser, User>(user);
    }
  }
}
