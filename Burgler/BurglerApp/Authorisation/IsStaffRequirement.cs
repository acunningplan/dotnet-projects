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
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsStaffRequirement requirement)
        {
            UserData user = await _userServices.GetCurrentUser();
            if (user.Staff != null) context.Succeed(requirement);
        }
    }
}
