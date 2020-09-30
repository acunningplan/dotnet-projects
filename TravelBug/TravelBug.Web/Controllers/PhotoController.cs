using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TravelBug.PhotoServices;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TravelBug.Infrastructure.Exceptions;
using TravelBug.Infrastructure.PhotoLogic;
using System.Collections.Generic;
using System.Linq;
// using System.Text.Json;

namespace TravelBug.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PhotoController : ControllerBase
  {
    private readonly IPhotoService _photoService;
    private readonly ImgurSettings _settings;
    private readonly HttpClient _httpClient;

    public PhotoController(IPhotoService photoService, IHttpClientFactory clientFactory, IOptions<ImgurSettings> config)
    {
      _photoService = photoService;
      _settings = config.Value;

      // Create http client and set base address and access token
      _httpClient = clientFactory.CreateClient();
      _httpClient.BaseAddress = new Uri(_settings.Url);
      _httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Client-ID", _settings.ClientId);
      _httpClient.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Bearer", _settings.AccessToken);
    }

    private async Task<PhotoUploadResult> UploadAndSavePhoto(IFormFile file, string blogId)
    {
      var response = await _httpClient.PostAsync("upload", _photoService.ConvertToFormData(file));
      if (!response.IsSuccessStatusCode)
        throw new RestException(response.StatusCode, "Upload failed");
      var responseString = await response.Content.ReadAsStringAsync();
      var responseObject = JsonConvert.DeserializeObject<PhotoUploadResponse>(responseString);

      var url = responseObject.Data.Link;
      var id = responseObject.Data.Id;
      await _photoService.SavePhoto(url, id, blogId);
      return new PhotoUploadResult { Url = url, Id = id };
    }

    [HttpPost("{blogId}")]
    public async Task<IEnumerable<PhotoUploadResult>> UploadPhotos([FromForm] UploadForm uploadForm, string blogId)
    {
      // Check that current user is the author of the blog;
      await _photoService.CheckUser(blogId);

      var files = uploadForm.Files;
      var tasks = new List<Task<PhotoUploadResult>>();

      // Upload multiple images in parallel
      files.ForEach(file =>
      {
        tasks.Add(UploadAndSavePhoto(file, blogId));
      });
      return await Task.WhenAll(tasks);
    }

    [HttpDelete("{blogId}/{imgurId}")]
    public async Task DeletePhoto(string blogId, string imgurId)
    {
      // Check that current user is the author of the blog;
      await _photoService.CheckUser(blogId);
      
      var response = await _httpClient.DeleteAsync($"image/{imgurId}");
      var responseContent = response.Content.ReadAsStringAsync().Result;
      if (!response.IsSuccessStatusCode) throw new RestException(response.StatusCode, responseContent);

      // Delete image url from database
      await _photoService.DeletePhoto(blogId, imgurId);
    }
  }

  public class UploadForm
  {
    public List<IFormFile> Files { get; set; }
  }
}
