using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IWant.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<WordCategory> WordCategories { get; set; }
        public DbSet<Word> Words { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.username)
                .IsUnique();
            modelBuilder.Entity<Player>().HasData(
                new Player() { id = 1, username = "admin", password = "admin", score = 0 }
                );

            modelBuilder.Entity<WordCategory>().HasData(
                new WordCategory() { id = 1, name = "Chủ từ", createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath="", status = true },
                new WordCategory() { id = 2, name = "Động từ", createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath = "", status = true }
                );

            modelBuilder.Entity<Word>().HasData(
                new Word() { id = 1, text = "Con", wordCategoryId = 1, createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath = "", status = true},
                new Word() { id = 2, text = "Muốn", wordCategory = null, createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath = "", status = true },
                new Word() { id = 3, text = "Ăn", wordCategoryId = 2,createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath = "", status = true },
                new Word() { id = 4, text = "Uống", wordCategoryId = 2, createdAt = DateTime.Now, updatedAt = DateTime.Now, imagePath = "", status = true }
                );
        }

    }
}
