using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
    {
      if (!userManager.Users.Any())
      {
        var users = new List<AppUser>
        {
            new AppUser
            {
              DisplayName = "Sam",
              UserName = "sam",
              Email = "sam@test.com"
            },
            new AppUser
            {
              DisplayName = "Ed",
              UserName = "ed",
              Email = "ed@test.com"
            },
            new AppUser
            {
              DisplayName = "Chelsea",
              UserName = "chelsea",
              Email = "chelsea@test.com"
            },
        };

        foreach (var user in users)
        {
          await userManager.CreateAsync(user, "Pa$$w0rd");
        }
      }

      if (!context.TripCards.Any())
      {
        var tripCards = new List<TripCard>
        {
          new TripCard
          {
            Name = "Bristol",
            Date = DateTime.Now.AddMonths(-3),
            Description = "Beautiful city!",
          },
          new TripCard
          {
            Name = "Vienna",
            Date = DateTime.Now.AddMonths(-2),
            Description = "Imperial city!",
          }
        };

        context.TripCards.AddRange(tripCards);
        context.SaveChanges();
      }

    }
  }
}