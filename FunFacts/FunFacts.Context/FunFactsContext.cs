using System;
using FunFacts.Entities;
using FunFacts.Entities.Images;
using FunFacts.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FunFacts.Context
{
    public class FunFactsContext : IdentityDbContext<AppUser>
    {
        protected readonly IConfiguration _configuration;
        public DbSet<FunFact> FunFacts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<UserPhoto> ProfilePictures { get; set; }
        public DbSet<FunFactImage> FunFactImages { get; set; }
        public FunFactsContext(DbContextOptions<FunFactsContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // An app user can have many fun facts and topics
            builder.Entity<AppUser>()
                .HasMany(u => u.FunFacts)
                .WithOne(f => f.Author)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUser>()
                .HasMany(u => u.Topics)
                .WithOne(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // User profile picture: one-to-one relationship
            builder.Entity<AppUser>()
              .HasOne(u => u.ProfilePicture)
              .WithOne(p => p.User)
              .HasForeignKey<UserPhoto>(p => p.AppUserId);

            // A topic can have many fun facts (one-to-many)
            builder.Entity<Topic>()
                 .HasMany(t => t.FunFacts)
                 .WithOne(f => f.Topic)
                 .OnDelete(DeleteBehavior.Cascade);

            // Topics and labels have many-to-many relationship
            builder.Entity<TopicLabel>(b =>
            {
                b.HasKey(tl => new { tl.TopicId, tl.LabelId });

                b.HasOne(tl => tl.Topic)
                    .WithMany(t => t.Labels)
                    .HasForeignKey(tl => tl.TopicId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(tl => tl.Label)
                    .WithMany(l => l.Topics)
                    .HasForeignKey(tl => tl.LabelId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
