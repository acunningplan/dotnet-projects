using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Infrastructure.Security
{
  public class IsAuthorRequirement : IAuthorizationRequirement { }

  public class IsAuthorRequirementHandler : AuthorizationHandler<IsAuthorRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly DataContext _context;

    public IsAuthorRequirementHandler(IHttpContextAccessor httpContextAccessor, DataContext context)
    {
      _httpContextAccessor = httpContextAccessor;
      _context = context;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAuthorRequirement requirement)
    {
      var currentUserName = _httpContextAccessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

      var tripCardId = Guid.Parse(_httpContextAccessor.HttpContext.Request.RouteValues.SingleOrDefault(x => x.Key == "id").Value.ToString());

      var tripCard = _context.TripCards.FindAsync(tripCardId).Result;

      var author = tripCard.UserTripCard.AppUser;

      if (author == null)
      {
        // throw new RestException(HttpStatusCode.BadRequest, new { author = "Author Not Found" });
        Console.WriteLine("Bad request, cannot find author");
      }

      if (author?.UserName == currentUserName)
        context.Succeed(requirement);

      return Task.CompletedTask;
    }
  }
}