using System;
using System.Collections.Generic;
using System.Text;
using TravelBug.Entities.User;

namespace TravelBug.Entities.SeedData
{
    public class Users
    {
        public static List<AppUser> SampleUsers = new List<AppUser> {
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
            }
        };
    }
}
