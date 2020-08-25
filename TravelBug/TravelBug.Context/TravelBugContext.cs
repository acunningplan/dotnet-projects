using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TravelBug.Entities;
using TravelBug.Entities.User;

namespace TravelBug.Context
{
    public class TravelBugContext : IdentityDbContext<AppUser>
    {
        protected readonly IConfiguration _configuration;
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<UserFollowing> Followings { get; set; }
        public TravelBugContext(DbContextOptions<TravelBugContext> options) : base(options) { }

        protected virtual IList<Assembly> Assemblies
        {
            get => new List<Assembly>() { Assembly.Load("TravelBug.Entities") };
        }
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

            builder.Entity<UserFollowing>(b =>
            {
                b.HasKey(k => new { k.ObserverId, k.TargetId });

                b.HasOne(o => o.Observer)
                    .WithMany(f => f.Followings)
                    .HasForeignKey(o => o.ObserverId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(t => t.Target)
                    .WithMany(f => f.Followers)
                    .HasForeignKey(t => t.TargetId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            foreach (var assembly in Assemblies)
            {
                // Loads all types from an assembly which have an interface of IBase and is a public class
                var classes = assembly.GetTypes().Where(s => s.GetInterfaces().Any(_interface =>
                    _interface.Equals(typeof(IBase)) && s.IsClass && !s.IsAbstract && s.IsPublic));

                foreach (var _class in classes)
                {
                    // Invoke "OnModelCreating" methods of all the classes found
                    var onModelCreatingMethod = _class.GetMethods().FirstOrDefault(x => x.Name == "OnModelCreating" && x.IsStatic);

                    if (onModelCreatingMethod != null)
                    {
                        onModelCreatingMethod.Invoke(_class, new object[] { builder });
                    }

                    // Also invoke "OnModelCreating" in the base types
                    if (_class.BaseType == null || _class.BaseType != typeof(Base)) continue;

                    var baseOnModelCreatingMethod = _class.BaseType.GetMethods().FirstOrDefault(x => x.Name == "OnModelCreating" && x.IsStatic);

                    if (baseOnModelCreatingMethod == null) continue;

                    var baseOnModelCreatingGenericMethod = baseOnModelCreatingMethod.MakeGenericMethod(new Type[] { _class });

                    if (baseOnModelCreatingGenericMethod == null) continue;

                    baseOnModelCreatingGenericMethod.Invoke(typeof(Base), new object[] { builder });
                }
            }
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IBase)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Created").CurrentValue = DateTimeOffset.Now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTimeOffset.Now;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
