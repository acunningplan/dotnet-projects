using System;
using Xunit;
using TravelBug.Infrastructure;
using TravelBug.PhotoServices;
using Moq;
using TravelBug.Context;

namespace TravelBugTests
{
    public class PhotoServicesTest
    {
        private readonly PhotoService _photoService;
        private readonly Mock<IUserAccessor> _userAccessorMock = new Mock<IUserAccessor>();
        private readonly Mock<TravelBugContext> _travelBugContextMock = new Mock<TravelBugContext>();

        public PhotoServicesTest()
        {
            _photoService = new PhotoService(_travelBugContextMock.Object, _userAccessorMock.Object);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
