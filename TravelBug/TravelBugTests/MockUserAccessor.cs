using Moq;
using TravelBug.Infrastructure;
using TravelBugTests;

public static class MockUserAccessor
{


  public static void SetupMock(Mock<IUserAccessor> userAccessorMock)
  {
    var mockUsers = new MockData().MockAppUsers;

    // Returns all app users
    userAccessorMock
      .Setup(u => u.GetAllAppUsers())
      .ReturnsAsync(() => mockUsers);
    userAccessorMock
      .Setup(u => u.GetAppUser(It.IsAny<string>()))
      .ReturnsAsync((string s) => mockUsers.Find(u => u.UserName == s));

    // Returns current user Ed
    userAccessorMock
      .Setup(u => u.GetCurrentAppUser())
      .ReturnsAsync(() => mockUsers[0]);
    userAccessorMock
      .Setup(u => u.GetCurrentUsername())
      .Returns("ed");
  }
}