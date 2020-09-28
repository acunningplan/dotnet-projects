using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
//using Newtonsoft.Json;
using TravelBug.PhotoServices;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TravelBug.Infrastructure.Exceptions;
using TravelBug.Infrastructure.PhotoLogic;
using System.Text.Json;

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
    [HttpPost("{blogId}")]
    public async Task<PhotoUploadResult> UploadPhoto([FromForm] DataFromForm dataFromForm, string blogId)
    {
      var file = dataFromForm.File;
      var formData = await _photoService.ConvertToFormData(file, blogId);

      // Upload form containing images to imgur
      var response = await _httpClient.PostAsync("upload", formData);
      if (!response.IsSuccessStatusCode) throw new RestException(response.StatusCode, "Upload failed");

      // Deserialise response to get image id and url
      using (var responseStream = await response.Content.ReadAsStreamAsync())
      {
        var uploadResult = await JsonSerializer.DeserializeAsync<PhotoUploadResponse>(responseStream);
        if (uploadResult.Data == null) throw new Exception("No data from response");
        var url = uploadResult.Data.Link;
        var id = uploadResult.Data.Id;

        // Save image url to database
        await _photoService.SavePhoto(url, id, blogId);

        return new PhotoUploadResult { Url = url, Id = id };
      }
    }

    [HttpDelete("{blogId}/{imgurId}")]
    public async Task DeletePhoto(string blogId, string imgurId)
    {
      var response = await _httpClient.DeleteAsync($"image/{imgurId}");
      var responseContent = response.Content.ReadAsStringAsync().Result;
      if (!response.IsSuccessStatusCode) throw new RestException(response.StatusCode, responseContent);

      // Delete image url from database
      await _photoService.DeletePhoto(blogId, imgurId);
    }
  }

  public class DataFromForm
  {
    public IFormFile File { get; set; }
  }
}
