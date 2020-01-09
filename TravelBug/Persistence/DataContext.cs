using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TripCard> TripCards { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      // builder.Entity<TripCard>().HasData(

      //   new TripCard
      //   {
      //     Name = "Munich",
      //     Description = "Beautiful City!"
      //   }
      // );
    }
  }
}
