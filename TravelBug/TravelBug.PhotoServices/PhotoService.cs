using Microsoft.AspNetCore.Http;

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
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;
using SixLabors.ImageSharp.Formats.Jpeg;

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
      // memory stream
      using (var memoryStream = new MemoryStream())
      // filestream
      using (var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream()))
      {

        // Resize to height = 200 (proportional)
        var dims = image.Size();
        int height = 200;
        int width = (int)(((double)dims.Width / (double)dims.Height) * height);
        ResizeMode mode = ResizeMode.Stretch;

        // init resize object
        var resizeOptions = new ResizeOptions
        {
          Size = new Size(width, height),
          Mode = mode
        };

        // mutate image
        image.Mutate(x => x.Resize(resizeOptions));

        //Encode here for quality
        var encoder = new JpegEncoder()
        {
          Quality = 100 //Use variable to set between 5-30 based on your requirements
        };

        //This saves to the memoryStream with encoder
        image.Save(memoryStream, encoder);
        memoryStream.Position = 0; // The position needs to be reset.

        // prepare result to byte[]
        data = memoryStream.ToArray();
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
