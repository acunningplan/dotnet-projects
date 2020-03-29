using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderEntitiesLib;
using UserEntitiesLib;

namespace BurglerContextLib
{
    public class BurglerContext : IdentityDbContext<User>
    {
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Food> Foods { get; set; }

        public BurglerContext(DbContextOptions<BurglerContext> options)
          : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data here
            //modelBuilder.Entity<Order>().HasData(
            //    new Order { OrderDescription = "No Tomatoes" },
            //    new Order { OrderDescription = "Extra mayo" });

            //modelBuilder.Entity<Order>()
            //  .Property(c => c.OrderDescription)
            //  .IsRequired()
            //  .HasMaxLength(40);
        }
    }
}
