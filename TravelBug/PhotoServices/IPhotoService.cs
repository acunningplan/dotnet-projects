using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhotoServices
{
    public interface IPhotoService
    {
        Task<MultipartFormDataContent> ConvertToFormData(IFormFile file, string blogId);
        Task DeletePhoto(string imgurId, string blogId);
        Task SavePhoto(string url, string id);
    }
}