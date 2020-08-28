using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using TravelBug.Entities.SeedData;
using TravelBug.Entities.UserData;

namespace TravelBug.Context
{
    public class Seed
    {
        public static async Task SeedData(TravelBugContext context, UserManager<AppUser> userManager)
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
