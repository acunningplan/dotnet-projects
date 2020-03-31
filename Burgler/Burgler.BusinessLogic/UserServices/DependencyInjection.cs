using Burgler.BusinessLogic.JwtServices;
using Burgler.Entities;
using Burgler.Entities.User;
using BurglerContextLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.UserServices
{
    public partial class UserServices : IUserServices
    {
        private readonly BurglerContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtServices _jwtServices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(BurglerContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtServices jwtServices, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtServices = jwtServices;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
