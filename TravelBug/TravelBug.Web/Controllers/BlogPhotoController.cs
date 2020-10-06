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
// using System.Text.Json;

namespace TravelBug.Web.Controllers
{
  [Route("api/photo")]
  [ApiController]
  public class BlogPhotoController : ControllerBase
  {
    private readonly IPhotoService _photoService;
    private readonly ImgurSettings _settings;
    private readonly HttpClient _httpClient;

    public BlogPhotoController(IPhotoService photoService, IHttpClientFactory clientFactory, IOptions<ImgurSettings> config)
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
      // Upload photo to Imgur
      var response = await _httpClient.PostAsync("upload", _photoService.ConvertToFormData(file));
      if (!response.IsSuccessStatusCode)
        throw new RestException(response.StatusCode, "Upload failed");
      var responseString = await response.Content.ReadAsStringAsync();
      var responseObject = JsonConvert.DeserializeObject<PhotoUploadResponse>(responseString);

      // Save photo data in database
      await _photoService.SaveBlogPhoto(responseObject, blogId);
      return new PhotoUploadResult(responseObject);
    }

    [HttpPost("{blogId}")]
    public async Task<IEnumerable<PhotoUploadResult>> UploadPhotos([FromForm] UploadForm uploadForm, string blogId)
    {
      // Check that current user is the author of the blog;
      await _photoService.CheckUser(blogId);

      var files = uploadForm.Files;
      var tasks = new List<Task<PhotoUploadResult>>();

      // Upload multiple images in parallel
      if (files != null)
      {
        files.ForEach(file =>
        {
          tasks.Add(UploadAndSavePhoto(file, blogId));
        });
      }
      return await Task.WhenAll(tasks);
    }


    private async Task DeletePhoto(string url, string blogId)
    {
      // Get delete hash of the photo in order to delete it on Imgur
      var photo = await _photoService.GetPhotoByUrl(url);
      var deleteHash = photo.DeleteHash;

      // Delete it in the database (and check that the photo belongs to the blog)
      await _photoService.DeletePhoto(url, blogId);

      // Delete the photo on Imgur
      var response = await _httpClient.DeleteAsync($"image/{deleteHash}");
      if (!response.IsSuccessStatusCode)
        throw new RestException(response.StatusCode, "Cannot delete image on Imgur");
    }

    [HttpDelete("{blogId}")]
    public async Task DeletePhotos([FromBody] DeleteForm deleteForm, string blogId)
    {
      // Check that current user is the author of the blog;
      await _photoService.CheckUser(blogId);
      var urls = deleteForm.Urls;
      // var tasks = new List<Task>();

      // Delete multiple photos in parallel
      if (urls != null)
      {
        foreach (var url in urls)
        {
          await DeletePhoto(url, blogId);
        }
      }
      // await Task.WhenAll(tasks);
    }
  }

  public class UploadForm
  {
    public List<IFormFile> Files { get; set; }
  }

  public class DeleteForm
  {
    public List<string> Urls { get; set; }
  }
}
