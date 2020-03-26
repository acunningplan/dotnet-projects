using System;
using BurglerEntitiesLib;
using Microsoft.EntityFrameworkCore;

namespace BurglerContextLib
{
    public class Burgler : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public Burgler(DbContextOptions<Burgler> options)
          : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data here
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderDescription = "No Tomatoes" },
                new Order { OrderDescription = "Extra mayo" });

            modelBuilder.Entity<Order>()
              .Property(c => c.OrderDescription)
              .IsRequired()
              .HasMaxLength(40);
        }
    }
}
