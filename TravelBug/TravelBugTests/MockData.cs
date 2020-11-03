using System;
using System.Collections.Generic;
using System.Text;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBugTests
{
  public static class MockData
  {
    public static List<AppUser> Users { get; } = new List<AppUser>
    {
        new AppUser {UserName = "ed"},
        new AppUser {UserName = "sarah"},
        new AppUser {UserName = "sam"},
    };
    public static List<Blog> Blogs { get; } = new List<Blog>
        {
            new Blog {Title = "Ed's blog"},
            new Blog {Title = "Sarah's first blog", Images = new List<Image> {

            }},
            new Blog {Title = "Sarah's second blog"},
            new Blog {Title = "Sam's blog"},
        };
    public static List<Image> Images { get; } = new List<Image>
        {
            new Image {Url = "url1"},
            new Image {Url = "url2"},
            new Image {Url = "url3"},
            new Image {Url = "url4"},
        };

  }
}
