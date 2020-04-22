using Burgler.Entities.FoodItem;
using Burgler.Entities.Ingredients;
using Burgler.Entities.IngredientsNS;
using Burgler.Entities.OrderNS;
using Burgler.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurglerContextLib
{
    public class BurglerContext : IdentityDbContext<AppUser>
    {
        // Ingredients
        public DbSet<Bun> Buns { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Patty> Patties { get; set; }
        public DbSet<DonenessLevel> DonenessLevels { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<BurgerItem> BurgerItems { get; set; }
        //public DbSet<BurgerTopping> BurgerToppings { get; set; }
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
                .WithOne(o => o.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.BurgerItems)
                .WithOne(bi => bi.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.SideItems)
                .WithOne(si => si.Order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.DrinkItems)
                .WithOne(di => di.Order)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<BurgerItem>()
            //    .HasMany(o => o.BurgerToppings)
            //    .WithOne(bt => bt.BurgerItem)
            //    .OnDelete(DeleteBehavior.Cascade);

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
