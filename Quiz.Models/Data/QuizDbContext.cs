//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Quiz.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

namespace Quiz.Web.Data
{
    public partial class QuizDbContext : IdentityDbContext<Person>
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<QuizClass> Quizzes { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<QuizQuestions> QuizQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<QuizQuestions>(entity =>
            {
                entity.HasKey(e => new { e.QuestionId, e.QuizId });
            });
        }
    }
}