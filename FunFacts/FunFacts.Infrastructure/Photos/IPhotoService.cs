﻿using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using FunFacts.Entities.Images;

namespace FunFacts.Infrastructure.Photos
{
  public interface IPhotoService
  {
    Task CheckUser(string blogId);
    MultipartFormDataContent ConvertToFormData(IFormFile file);
    Task<Image> GetPhotoByUrl(string url);
    Task DeletePhoto(string url, string blogId);
    Task SaveBlogPhoto(PhotoUploadResponse responseObject, string blogId);
    Task SaveProfilePicture(PhotoUploadResponse responseObject);
  }
}