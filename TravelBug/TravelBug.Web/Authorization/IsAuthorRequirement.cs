using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Context;

namespace TravelBug.Web.Authorization
{
  public class IsAuthorRequirement : IAuthorizationRequirement
  {
  }

  public class IsAuthorRequirementHandler : AuthorizationHandler<IsAuthorRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TravelBugContext _context;
    private readonly IUserAccessor _userAccessor;

    public IsAuthorRequirementHandler(IHttpContextAccessor httpContextAccessor, TravelBugContext context, IUserAccessor userAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
      _context = context;
      _userAccessor = userAccessor;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAuthorRequirement requirement)
    {
      var httpContext = _httpContextAccessor.HttpContext;
      if (httpContext.Request.RouteValues.ContainsKey("id"))
      {
        var currentUserName = _userAccessor.GetCurrentUsername();

        var blogId = Guid.Parse(httpContext.Request.RouteValues["id"].ToString());
        if (blogId == null) throw new Exception("Can't find blogId");

        var blog = _context.Blogs.FindAsync(blogId).Result;
        if (blog == null) throw new Exception("Can't find blog");

        var author = blog.User;

        if (author.UserName == currentUserName) context.Succeed(requirement);
      }
      else
      {
        context.Fail();
      }
      return Task.CompletedTask;
    }
  }
}
