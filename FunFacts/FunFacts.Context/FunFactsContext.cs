using System;
using FunFacts.Entities;
using FunFacts.Entities.UserEntities;
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
        public FunFactsContext(DbContextOptions<FunFactsContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
