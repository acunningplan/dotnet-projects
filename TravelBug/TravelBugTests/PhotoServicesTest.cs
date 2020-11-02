using Xunit;
using TravelBug.Infrastructure;
using TravelBug.PhotoServices;
using Moq;
using TravelBug.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using TravelBug.Infrastructure.PhotoLogic;

namespace TravelBugTests
{
  public class PhotoServicesTest
  {
    private PhotoService _photoService;
    private Mock<IPhotoService> _photoServiceMock = new Mock<IPhotoService>();
    private readonly MockData mockData = new MockData();
    private readonly DbContextOptions<TravelBugContext> _options;
    private readonly Mock<IUserAccessor> _userAccessorMock = new Mock<IUserAccessor>();

    // Save mock blogs and users (not from database)


    public PhotoServicesTest()
    {
      var optionsBuilder = new DbContextOptionsBuilder<TravelBugContext>();
      optionsBuilder.UseSqlite("Data Source=blog.db");
      _options = optionsBuilder.Options;

      // Set up users
      MockUserAccessor.SetupMock(_userAccessorMock);
    }

    [Fact]
    public async Task ShouldGetPhotoByUrl()
    {
      using (var context = new TravelBugContext(_options))
      {
        // Arrange
        Seed.SeedData(context);
        _photoService = new PhotoService(context, _userAccessorMock.Object);

        // Action
        var photo1 = await _photoService.GetPhotoByUrl("url1");
        var photo2 = await _photoService.GetPhotoByUrl("url0");

        // Assert
        Assert.NotNull(photo1);
        Assert.Null(photo2);
      }
    }

    [Fact]
    public async Task ShouldSaveProfilePicture()
    {
      using (var context = new TravelBugContext(_options))
      {
        // Arrange
        Seed.SeedData(context);
        _photoService = new PhotoService(context, _userAccessorMock.Object);

        var responseObject = new PhotoUploadResponse
        {
          Data = new ResponseData
          {
            Id = "imgurId1",
            Link = "link1",
            DeleteHash = "deleteHash1"
          }
        };

        // Action
        await _photoService.SaveProfilePicture(responseObject);
        var user = await context.Users.FirstAsync(u => u.UserName == "ed");

        // Assert
        // Assert.Equal("imgurId1", user.ProfilePicture.ImgurId);
      }
    }
  }
}
