using System;
using System.Collections.Generic;
using TravelBug.Context;
using TravelBug.Entities;
using TravelBug.Entities.UserData;

namespace TravelBugTests
{
  public static class Seed
  {
    public static void SeedData(TravelBugContext context)
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      var users = new List<AppUser>
      {
          new AppUser() {UserName = "ed"},
          new AppUser() {UserName = "sarah"},
          new AppUser() {UserName = "sam"},
      };
      context.Users.AddRange(users);

      var blogs = new List<Blog>
        {
            new Blog {Title = "Ed's blog"},
            new Blog {Title = "Sarah's first blog", Images = new List<Image> {

            }},
            new Blog {Title = "Sarah's second blog"},
            new Blog {Title = "Sam's blog"},
        };
      context.Blogs.AddRange(blogs);


      var images = new List<Image>
        {
            new Image {Url = "url1"},
            new Image {Url = "url2"},
            new Image {Url = "url3"},
            new Image {Url = "url4"},
        };
      context.Images.AddRange(images);

      context.SaveChanges();
    }
  }
}