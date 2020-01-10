﻿using Domain;
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      
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
