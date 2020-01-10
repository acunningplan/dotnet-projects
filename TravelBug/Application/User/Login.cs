using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.User
{
  public class Login
  {
    public class Query : IRequest<AppUser>
    {
      public string Email { get; set; }
      public string Password { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, AppUser>
    {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
        _context = context;

      }

      public async Task<AppUser> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _context.Users.FindAsync(request.Email);
        
        return user;
      }
    }
  }

}