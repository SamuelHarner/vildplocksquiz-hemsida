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
            new QuizQuestion { Id = 1, ImageUrl = "/images/maskros_1.jpg", Answer = "maskros", Credit = "David Monniaux", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 2, ImageUrl = "/images/maskros_2.jpg", Answer = "maskros", Credit = "Green Yoshi", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 3, ImageUrl = "/images/rödklöver_1.jpg", Answer = "rödklöver", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
            new QuizQuestion { Id = 4, ImageUrl = "/images/rödklöver_2.jpg", Answer = "rödklöver", Credit = "Tony Wills", License = "https://creativecommons.org/licenses/by/2.5/"}
            );
        }
    }
}
