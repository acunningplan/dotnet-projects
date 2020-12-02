using System.Collections.Generic;
using Moq;
using TravelBug.Entities.UserData;
using TravelBug.Infrastructure;
using TravelBugTests;

public static class MockUserAccessor
{


  public static void SetupMock(Mock<IUserAccessor> userAccessorMock, List<AppUser> users)
  {
    // Returns all app users
    userAccessorMock
      .Setup(u => u.GetAllAppUsers())
      .ReturnsAsync(() => users);
    userAccessorMock
      .Setup(u => u.GetAppUser(It.IsAny<string>()))
      .ReturnsAsync((string s) => users.Find(u => u.UserName == s));

    // Returns current user Ed
    userAccessorMock
      .Setup(u => u.GetCurrentAppUser())
      .ReturnsAsync(() => users[0]);
    userAccessorMock
      .Setup(u => u.GetCurrentUsername())
      .Returns("ed");
  }
}