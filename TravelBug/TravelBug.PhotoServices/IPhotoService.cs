using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace TravelBug.PhotoServices
{
  public interface IPhotoService
  {
    Task CheckUser(string blogId);
    MultipartFormDataContent ConvertToFormData(IFormFile file);
    Task DeletePhoto(string imgurId, string blogId);
    Task SavePhoto(string url, string id, string blogId);
  }
}