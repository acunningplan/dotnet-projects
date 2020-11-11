using System.Collections.Generic;
using FunFacts.Entities.UserEntities;

namespace FunFacts.Entities.SeedData
{
    public class Users
    {
        public static List<AppUser> SampleUsers = new List<AppUser> {
            new AppUser
            {
            DisplayName = "Sam",
            UserName = "sam",
            Email = "sam@test.com",
            EmailConfirmed = true
            },
            new AppUser
            {
            DisplayName = "Ed",
            UserName = "ed",
            Email = "ed@test.com",
            EmailConfirmed = true
            },
            new AppUser
            {
            DisplayName = "Sarah",
            UserName = "sarah",
            Email = "sarah@test.com",
            EmailConfirmed = true
            }
        };
    }
}
