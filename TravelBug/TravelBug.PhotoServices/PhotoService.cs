using Microsoft.AspNetCore.Http;
using PhotoSauce.MagicScaler;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TravelBug.Context;
using TravelBug.Entities;
using TravelBug.Infrastructure;
using TravelBug.Infrastructure.Exceptions;
using TravelBug.Infrastructure.PhotoLogic;


namespace TravelBug.PhotoServices
{
  public class PhotoService : IPhotoService
  {
    private readonly TravelBugContext _context;
    private readonly IUserAccessor _userAccessor;
    private Blog _blog;

    public PhotoService(TravelBugContext context, IUserAccessor userAccessor)
    {
      _context = context;
      _userAccessor = userAccessor;
    }

    private async Task CheckUser(string blogId)
    {
      var username = _userAccessor.GetCurrentUsername();

      _blog = (await _context.Blogs.FindAsync(Guid.Parse(blogId))) ??
          throw new RestException(HttpStatusCode.NotFound, "Blog not found.");

      if (_blog.User.UserName != username)
        throw new RestException(HttpStatusCode.Forbidden, "This is not your blog!");
    }

    public async Task<MultipartFormDataContent> ConvertToFormData(IFormFile file, string blogId)
    {
      await CheckUser(blogId);

      if (file == null || file.Length == 0)
        throw new RestException(HttpStatusCode.BadRequest, "Invalid file input.");


      // Write FormFile into byte array
      byte[] data;
      using (var stream = file.OpenReadStream())
      using (var outStream = new MemoryStream((int)stream.Length))
      {
        const int size = 150;
        const int quality = 75;

        var settings = new ProcessImageSettings()
        {
          Width = size,
          Height = size,
          ResizeMode = CropScaleMode.Max,
          SaveFormat = FileFormat.Jpeg,
          JpegQuality = quality,
          JpegSubsampleMode = ChromaSubsampleMode.Subsample420
        };

        MagicImageProcessor.ProcessImage(outStream, stream, settings);

        using (var br = new BinaryReader(outStream))
        { 
          data = br.ReadBytes((int)file.OpenReadStream().Length);
        }
      }

      ByteArrayContent bytes = new ByteArrayContent(data);
      MultipartFormDataContent multiContent = new MultipartFormDataContent();
      multiContent.Add(bytes, "image", file.FileName);

      return multiContent;
    }

    public async Task SavePhoto(string url, string imgurId, string blogId)
    {

      var blog = await _context.Blogs.FindAsync(Guid.Parse(blogId));
      blog.Images.Add(
          new TravelBug.Entities.Image() { Url = url, ImgurId = imgurId });

      var success = await _context.SaveChangesAsync() > 0;
      if (!success)
        throw new Exception("Problem saving changes");
    }

    public async Task DeletePhoto(string blogId, string imgurId)
    {
      await CheckUser(blogId);

      var image = _blog.Images.SingleOrDefault(b => b.ImgurId == imgurId)
          ?? throw new RestException(HttpStatusCode.NotFound, "Image not found.");

      _blog.Images.Remove(image);

      var success = await _context.SaveChangesAsync() > 0;
      if (!success)
        throw new Exception("Problem saving changes");
    }
  }
}
