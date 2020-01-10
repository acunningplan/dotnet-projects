using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
  public class Seed
  {
    public static void SeedData(DataContext context)
    {
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