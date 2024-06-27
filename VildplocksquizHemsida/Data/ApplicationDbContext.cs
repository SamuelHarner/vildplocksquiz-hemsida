using Microsoft.EntityFrameworkCore;
using VildplocksquizHemsida.Models;

namespace VildplocksquizHemsida.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<QuizQuestion> QuizQuestions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizQuestion>().HasData(
                new QuizQuestion { Id = 1, ImageUrl = "/images/maskros_1.jpg", Answer = "maskros" },
                new QuizQuestion { Id = 2, ImageUrl = "/images/maskros_2.jpg", Answer = "maskros" },
                new QuizQuestion { Id = 3, ImageUrl = "/images/rödklöver_1.jpg", Answer = "rödklöver" },
                new QuizQuestion { Id = 4, ImageUrl = "/images/rödklöver_2.jpg", Answer = "rödklöver" },
                new QuizQuestion { Id = 5, ImageUrl = "/images/daggkåpa_1.jpg", Answer = "daggkåpa" },
                new QuizQuestion { Id = 6, ImageUrl = "/images/daggkåpa_2.jpg", Answer = "daggkåpa" },
                new QuizQuestion { Id = 7, ImageUrl = "/images/stensopp_1.jpg", Answer = "stensopp" },
                new QuizQuestion { Id = 8, ImageUrl = "/images/stensopp_2.jpg", Answer = "stensopp" },
                new QuizQuestion { Id = 9, ImageUrl = "/images/kantarell_1.jpg", Answer = "kantarell" }
            );
        }
    }
}
