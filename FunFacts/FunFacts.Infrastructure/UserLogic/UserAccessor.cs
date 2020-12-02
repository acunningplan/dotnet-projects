using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using FunFacts.Dtos;
using FunFacts.Entities.User;
using FunFacts.Context;

namespace FunFacts.Infrastructure
{

    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public UserAccessor(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public string GetCurrentUsername()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return username;
        }

        public async Task<AppUser> GetCurrentAppUser()
        {
            var username = GetCurrentUsername();
            return await _userManager.FindByNameAsync(username);
        }

        public Task<List<AppUser>> GetAllAppUsers()
        {
            return _userManager.Users.ToListAsync();
        }

        public async Task<AppUser> GetAppUser(string username)
        {
            return await _userManager.FindByNameAsync(username)
              ?? throw new RestException(HttpStatusCode.NotFound, $"User {username} not found.");
        }

        public async Task<User> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var refreshToken = _jwtGenerator.GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            var returnedUser = _mapper.Map<AppUser, User>(user);
            returnedUser.Token = _jwtGenerator.CreateToken(user);
            returnedUser.RefreshToken = refreshToken.Token;

            return returnedUser;
        }
    }
}
