using FunFacts.Entities.SeedData;
using FunFacts.Entities.UserEntities;
using Microsoft.AspNetCore.Identity;
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
            await context.SaveChangesAsync();
        }
    }
}
