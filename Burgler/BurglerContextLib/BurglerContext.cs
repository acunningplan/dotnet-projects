using Burgler.Entities.FoodItem;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurglerContextLib
{
    public class BurglerContext : IdentityDbContext<AppUser>
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<BurgerItem> BurgerItems { get; set; }
        public DbSet<BurgerTopping> BurgerToppings { get; set; }
        public DbSet<SideItem> SideItems { get; set; }
        public DbSet<DrinkItem> DrinkItems { get; set; }

        public BurglerContext(DbContextOptions<BurglerContext> options)
          : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.BurgerItems)
                .WithOne(bi => bi.Order);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.SideItems)
                .WithOne(si => si.Order);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.DrinkItems)
                .WithOne(di => di.Order);

            modelBuilder.Entity<BurgerItem>()
                .HasMany(o => o.BurgerToppings)
                .WithOne(bt => bt.BurgerItem);

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
