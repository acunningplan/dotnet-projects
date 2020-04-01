using Burgler.Entities.Order;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurglerContextLib
{
    public class BurglerContext : IdentityDbContext<AppUser>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        //public DbSet<Food> Foods { get; set; }

        public BurglerContext(DbContextOptions<BurglerContext> options)
          : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserOrder>(
                x => x.HasKey(
                    uo => new { uo.AppUserId, uo.OrderId }));

            modelBuilder.Entity<UserOrder>()
                .HasOne(u => u.AppUser)
                .WithMany(o => o.UserOrders)
                .HasForeignKey(u => u.AppUserId);

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
