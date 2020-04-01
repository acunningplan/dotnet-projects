using Burgler.BusinessLogic.JwtLogic;
using Burgler.Entities.User;
using BurglerContextLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.UserLogic
{
    public class UserMethod
    {
        protected BurglerContext DbContext { get; private set; }
        protected UserManager<AppUser> UserManager { get; private set; }
        protected SignInManager<AppUser> SignInManager { get; private set; }
        protected IJwtServices JwtServices { get; private set; }
        protected IHttpContextAccessor HttpContextAccessor { get; private set; }
        public void Inject(BurglerContext dbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtServices jwtServices, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = dbContext;
            UserManager = userManager;
            SignInManager = signInManager;
            JwtServices = jwtServices;
            HttpContextAccessor = httpContextAccessor;
        }
    }
}
