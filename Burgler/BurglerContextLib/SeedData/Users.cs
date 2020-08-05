using Burgler.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurglerContextLib.SeedData
{
    public class Users
    {
        public static List<AppUser> SampleUsers = new List<AppUser>
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
            Email = "chelsea@test.com",
            Staff = "Server"
            },
        };
    }
}
