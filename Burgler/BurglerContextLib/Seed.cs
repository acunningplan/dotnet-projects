using Burgler.Entities;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurglerContextLib
{
    public class Seed
    {
        public static async Task SeedData(BurglerContext context, UserManager<AppUser> userManager)
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

            if (!context.Orders.Any())
            {
                //var tripCards = new List<TripCard>
                //    {
                //    new TripCard
                //    {
                //        Name = "Bristol",
                //        Date = DateTime.Now.AddMonths(-3),
                //        Description = "Beautiful city!",
                //        UserTripCard = new UserTripCard
                //        {
                //        AppUserId = "sam",
                //        DateCreated = DateTime.Now.AddDays(-2),
                //        }
                //    },
                //    new TripCard
                //    {
                //        Name = "Vienna",
                //        Date = DateTime.Now.AddMonths(-2),
                //        Description = "Imperial city!",
                //        UserTripCard = new UserTripCard
                //        {
                //        AppUserId = "ed",
                //        DateCreated = DateTime.Now.AddDays(-3),
                //        }
                //    }

                //context.Orders.AddRange(tripCards);
                context.SaveChanges();
            }

        }
    }
}
