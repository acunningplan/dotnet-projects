using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using FunFacts.Infrastructure;
using FunFacts.Context;

namespace FunFacts.Web.Authorization
{
    public class IsFunFactAuthorRequirement : IAuthorizationRequirement
    {
    }

    public class IsCommentAuthorRequirementHandler : AuthorizationHandler<IsFunFactAuthorRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly FunFactsContext _context;
        private readonly IUserAccessor _userAccessor;

        public IsCommentAuthorRequirementHandler(IHttpContextAccessor httpContextAccessor, FunFactsContext context, IUserAccessor userAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userAccessor = userAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsFunFactAuthorRequirement requirement)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext.Request.RouteValues.ContainsKey("funFactId"))
            {
                var currentUserName = _userAccessor.GetCurrentUsername();

                var funFactId = Guid.Parse(httpContext.Request.RouteValues["funFactId"].ToString());
                //if (funFactId == null) throw new Exception("Can't find comment Id");

                var funFact = _context.FunFacts.FindAsync(funFactId).Result;
                if (funFact == null) throw new Exception("Can't find comment");

                var commentAuthor = funFact.Author;

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
