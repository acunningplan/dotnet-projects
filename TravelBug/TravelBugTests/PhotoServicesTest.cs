using Xunit;
using TravelBug.Infrastructure;
using TravelBug.PhotoServices;
using Moq;
using TravelBug.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using TravelBug.Infrastructure.PhotoLogic;
using System.Collections.Generic;
using TravelBug.Entities.UserData;

namespace TravelBugTests
{
    public class PhotoServicesTest
    {
        private PhotoService _photoService;
        private List<AppUser> _users;
        private Mock<IPhotoService> _photoServiceMock = new Mock<IPhotoService>();
        private readonly DbContextOptions<TravelBugContext> _options;
        private readonly Mock<IUserAccessor> _userAccessorMock = new Mock<IUserAccessor>();

        // Save mock blogs and users (not from database)


        public PhotoServicesTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TravelBugContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");
            _options = optionsBuilder.Options;

            // Set up users
            _users = MockData.Users;
            MockUserAccessor.SetupMock(_userAccessorMock, _users);
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
                // Arrange (mock profile picture)
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

                // Action (set profile photo for Ed)
                await _photoService.SaveProfilePicture(responseObject);

                // Assert (Ed's profile picture)
                Assert.Equal("imgurId1", _users[0].ProfilePicture.ImgurId);
            }
        }
    }
}
