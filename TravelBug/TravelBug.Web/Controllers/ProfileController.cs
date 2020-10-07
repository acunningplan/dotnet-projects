using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBug.Infrastructure.UserLogic;
using System.Collections.Generic;
using TravelBug.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using TravelBug.Entities.UserData;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System;
using Microsoft.Extensions.Options;
using TravelBug.Infrastructure.PhotoLogic;
using System.Net.Http.Headers;
using TravelBug.Infrastructure.Exceptions;
using TravelBug.PhotoServices;
using Newtonsoft.Json;
using System.Net;

namespace TravelBug.Web.Controllers
{
  [Route("api/profile")]
  public class ProfileController : ControllerBase
  {
    private readonly IProfileService _profileService;
    private readonly IFeaturedUsersService _featuredUsersService;
    private readonly IPhotoService _photoService;
    private readonly HttpClient _httpClient;
    private readonly ImgurSettings _settings;

    public ProfileController(IProfileService profileService, IFeaturedUsersService featuredUsersService, IPhotoService photoService, IHttpClientFactory clientFactory, IOptions<ImgurSettings> config)
    {
      _profileService = profileService;
      _featuredUsersService = featuredUsersService;
      _photoService = photoService;
      _settings = config.Value;

      _httpClient = clientFactory.CreateClient();
      _httpClient.BaseAddress = new Uri(_settings.Url);
      _httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Client-ID", _settings.ClientId);
      _httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Bearer", _settings.AccessToken);
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

    private async Task UploadAndSavePhoto(IFormFile file)
    {
      // Upload photo to Imgur
      if (file == null) throw new RestException(HttpStatusCode.BadRequest, "Photo not attached properly");
      var response = await _httpClient.PostAsync("upload", _photoService.ConvertToFormData(file));
      if (!response.IsSuccessStatusCode)
        throw new RestException(response.StatusCode, "Upload failed");
      var responseString = await response.Content.ReadAsStringAsync();
      var responseObject = JsonConvert.DeserializeObject<PhotoUploadResponse>(responseString);

      // Save photo data in database
      await _photoService.SaveProfilePicture(responseObject);
    }

    [HttpPatch("photo")]
    public async Task<ActionResult> UpdateProfilePicture([FromForm] UploadProfilePictureForm form)
    {
      var file = form.Files;
      await UploadAndSavePhoto(file);
      return Ok();
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


  public class UploadProfilePictureForm
  {
    public IFormFile Files { get; set; }
  }
}