using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelBug.Entities;
using TravelBug.Entities.User;

namespace TravelBug.Context
{
    public class TravelBugContext : IdentityDbContext<AppUser>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Image> Images { get; set; }
        public TravelBugContext(DbContextOptions<TravelBugContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(u => u.Blogs)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Blog>()
                .HasMany(b => b.Images)
                .WithOne(i => i.Blog)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
