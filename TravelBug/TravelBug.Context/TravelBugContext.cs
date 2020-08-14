using Microsoft.EntityFrameworkCore;
using System;
using TravelBug.Entities;

namespace TravelBug.Context
{
    public class TravelBugContext : DbContext
    {
        public TravelBugContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
    }
}
