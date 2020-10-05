using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBug.Infrastructure.UserLogic;
using System.Collections.Generic;
using TravelBug.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using TravelBug.Entities.UserData;

namespace TravelBug.Web.Controllers
{
  [Route("api/profile")]
  public class ProfileController
  {
    private readonly IProfileService _profileService;
    private readonly IFeaturedUsersService _featuredUsersService;

    public ProfileController(IProfileService profileService, IFeaturedUsersService featuredUsersService)
    {
      _profileService = profileService;
      _featuredUsersService = featuredUsersService;
    }

    [HttpGet]
    public async Task<User> GetCurrentUserProfile()
    {
      return await _profileService.GetUserProfile();
    }

    [HttpGet("{username}")]
    public async Task<User> GetUserProfile(string username)
    {
      return await _profileService.GetProfile(username);
    }

    [HttpPatch]
    public async Task<User> EditProfile([FromBody] JsonPatchDocument<AppUser> patchEntity)
    {
      // patchEntity.ApplyTo(entity, ModelState);
      return await _profileService.EditProfile(patchEntity);
    }

    [HttpGet("featured")]
    public async Task<List<User>> FeaturedUsers()
    {
      return await _featuredUsersService.GetFeaturedUsers();
    }
  }
}