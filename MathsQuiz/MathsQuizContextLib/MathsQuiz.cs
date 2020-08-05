using System;
using Microsoft.EntityFrameworkCore;
using MathsQuizEntitiesLib;

namespace MathsQuizContextLib
{
    public class MathsQuiz : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public MathsQuiz(DbContextOptions<MathsQuiz> options)
          : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data here
            modelBuilder.Entity<Question>().HasData(
                new Question { QuestionID = "1", QuestionString = "What is 1+2?" },
                new Question { QuestionID = "2", QuestionString = "How many sides does a triangle have?" });

            modelBuilder.Entity<Question>()
              .Property(c => c.QuestionString)
              .IsRequired()
              .HasMaxLength(40);
        }
    }
}