using FunFacts.Context.SeedData;
using FunFacts.Entities;
using FunFacts.Entities.User;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunFacts.Context
{
    public class Seed
    {
        public static async Task SeedData(FunFactsContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = Users.SampleUsers;
                foreach (var user in users)
                    await userManager.CreateAsync(user, "Pa$$w0rd");
            }


            if (!context.Topics.Any())
            {
                var topics = Topics.SampleTopics;
                await context.Topics.AddRangeAsync(topics);
            }
            await context.SaveChangesAsync();
        }
    }
}
