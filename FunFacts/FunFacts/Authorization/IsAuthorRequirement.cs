using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using FunFacts.Infrastructure;
using FunFacts.Context;

namespace FunFacts.Web.Authorization
{
    public class IsAuthorRequirement : IAuthorizationRequirement
    {
    }

    public class IsAuthorRequirementHandler : AuthorizationHandler<IsAuthorRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly FunFactsContext _context;
        private readonly IUserAccessor _userAccessor;

        public IsAuthorRequirementHandler(IHttpContextAccessor httpContextAccessor, FunFactsContext context, IUserAccessor userAccessor)
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

                var topicId = Guid.Parse(httpContext.Request.RouteValues["id"].ToString());
                if (topicId == null) throw new Exception("Can't find topicId");

                var topic = _context.Topics.FindAsync(topicId).Result;
                if (topic == null) throw new Exception("Can't find topic");

                var author = topic.User;

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
