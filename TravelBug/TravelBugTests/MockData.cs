using System;
using System.Collections.Generic;
using System.Text;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBugTests
{
  public class MockData
  {
    public List<AppUser> MockAppUsers { get; set; } = new List<AppUser>
    {
        new AppUser {UserName = "ed"},
        new AppUser {UserName = "sarah"},
        new AppUser {UserName = "sam"},
    };
  }
}
