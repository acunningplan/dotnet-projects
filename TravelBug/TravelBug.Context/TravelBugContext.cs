using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TravelBug.Entities;

namespace TravelBug.Context
{
    public class TravelBugContext : IdentityDbContext<AppUser>
    {
        public TravelBugContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
    }
}
