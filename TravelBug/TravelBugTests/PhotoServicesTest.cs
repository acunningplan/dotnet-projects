using System;
using Xunit;
using TravelBug.Infrastructure;
using TravelBug.PhotoServices;
using Moq;
using TravelBug.Context;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using Microsoft.EntityFrameworkCore;
using TravelBug.Entities;
using System.Linq;

namespace TravelBugTests
{
    public class PhotoServicesTest
    {
        private readonly PhotoService _photoService;
        private readonly Mock<IUserAccessor> _userAccessorMock = new Mock<IUserAccessor>();
        private readonly Mock<TravelBugContext> _travelBugContextMock = new Mock<TravelBugContext>();

        public PhotoServicesTest()
        {

            var blogSetMock = new Mock<DbSet<Blog>>();
            _travelBugContextMock = new Mock<TravelBugContext>();
            _travelBugContextMock.Setup(m => m.Blogs).Returns(blogSetMock.Object);

            var mockBlogs = new MockData().MockBlogs.AsQueryable();
            var mockBlogSet = new Mock<DbSet<Blog>>();
            mockBlogSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(mockBlogs.Provider);
            mockBlogSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(mockBlogs.Expression);
            mockBlogSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(mockBlogs.ElementType);
            mockBlogSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(mockBlogs.GetEnumerator());


            var mockContext = new Mock<TravelBugContext>();
            mockContext.Setup(c => c.Blogs).Returns(mockBlogSet.Object);

            _photoService = new PhotoService(_travelBugContextMock.Object, _userAccessorMock.Object);
        }

        [Fact]
        public void Test1()
        {

            //_travelBugContextMock.Setup(t => t.Images).Returns(new DbSet<TravelBug.Entities.Image>());

        }
    }
}
