using TravelBug.Context;

namespace TravelBugTests
{
  public static class Seed
  {
    public static void SeedData(TravelBugContext context)
    {
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();

      context.Users.AddRange(MockData.Users);

      context.Blogs.AddRange(MockData.Blogs);

      context.Images.AddRange(MockData.Images);

      context.SaveChanges();
    }
  }
}