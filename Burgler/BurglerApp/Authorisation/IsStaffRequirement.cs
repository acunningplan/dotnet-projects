using Burgler.BusinessLogic.UserLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BurglerApp.Authorisation
{
    public class IsStaffRequirement : IAuthorizationRequirement { }

    public class IsStaffRequirementHandler : AuthorizationHandler<IsStaffRequirement>
    {
        private readonly IUserServices _userServices;

        public IsStaffRequirementHandler(IHttpContextAccessor httpContextAccessor, IUserServices userServices)
        {
            _userServices = userServices;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsStaffRequirement requirement)
        {
            UserData user = _userServices.GetCurrentUser().Result;
            if (user.Staff != null) context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
