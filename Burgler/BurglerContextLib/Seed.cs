using Burgler.Entities;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurglerContextLib.SeedData;

namespace BurglerContextLib
{
    public class Seed
    {
        public static async Task SeedData(BurglerContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = Users.SampleUsers;
                foreach (var user in users)
                    await userManager.CreateAsync(user, "Pa$$w0rd");
            }

            if (!context.Burgers.Any())
                await context.Burgers.AddRangeAsync(Burgers.BurgersList);
            if (!context.Toppings.Any())
                await context.Toppings.AddRangeAsync(Toppings.ToppingList);
            if (!context.Patties.Any())
                await context.Patties.AddRangeAsync(Patties.PattyList);
            if (!context.DonenessLevels.Any())
                await context.DonenessLevels.AddRangeAsync(PattyCooked.DonenessLevels);
            if (!context.Buns.Any())
                await context.Buns.AddRangeAsync(Buns.BunsList);
            if (!context.Sides.Any())
                await context.Sides.AddRangeAsync(Sides.SidesList);
            if (!context.Drinks.Any())
                await context.Drinks.AddRangeAsync(Drinks.DrinksList);

            // Optional: seed orders here
            await context.SaveChangesAsync();
        }

    }
}
