using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TripCard> TripCards { get; set; }
    public DbSet<UserTripCard> UserTripCards { get; set; }
    public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // Initialize data in data base:

      // builder.Entity<TripCard>().HasData(
      //   new TripCard
      //   {
      //     Name = "Munich",
      //     Description = "Beautiful City!"
      //   }
      // );

      // Give each relationship a primary key

      builder.Entity<UserTripCard>(x => x.HasKey(ut => new { ut.AppUserId, ut.TripCardId }));

      // Define many to many relationship
      builder.Entity<UserTripCard>()
        .HasOne(ut => ut.AppUser)
        .WithMany(u => u.UserTripCards)
        .HasForeignKey(ut => ut.AppUserId);

      builder.Entity<UserTripCard>()
        .HasOne(ut => ut.TripCard)
        .WithMany(t => t.UserTripCards)
        .HasForeignKey(ut => ut.TripCardId);
    }
  }
}
