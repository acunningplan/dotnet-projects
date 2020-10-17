using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TravelBug.Infrastructure;
using TravelBug.Context;

namespace TravelBug.Web.Authorization
{
  public class IsCommentAuthorRequirement : IAuthorizationRequirement
  {
  }

  public class IsCommentAuthorRequirementHandler : AuthorizationHandler<IsCommentAuthorRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly TravelBugContext _context;
    private readonly IUserAccessor _userAccessor;

    public IsCommentAuthorRequirementHandler(IHttpContextAccessor httpContextAccessor, TravelBugContext context, IUserAccessor userAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
      _context = context;
      _userAccessor = userAccessor;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsCommentAuthorRequirement requirement)
    {
      var httpContext = _httpContextAccessor.HttpContext;
      if (httpContext.Request.RouteValues.ContainsKey("commentId"))
      {
        var currentUserName = _userAccessor.GetCurrentUsername();

        var commentId = Guid.Parse(httpContext.Request.RouteValues["commentId"].ToString());
        if (commentId == null) throw new Exception("Can't find comment Id");

        var comment = _context.Comments.FindAsync(commentId).Result;
        if (comment == null) throw new Exception("Can't find comment");

        var commentAuthor = comment.Author;

        if (commentAuthor.UserName == currentUserName) context.Succeed(requirement);
      }
      else
      {
        context.Fail();
      }
      return Task.CompletedTask;
    }
  }
}
