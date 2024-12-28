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
                .HasIndex(p => p.Username)
                .IsUnique();
            modelBuilder.Entity<Player>().HasData(
                new Player() { Id = 1, Username = "admin", Password = "admin", Score = 0 }
                );

            modelBuilder.Entity<WordCategory>().HasData(
                new WordCategory() { Id = 1, VietnameseName = "Chủ từ", EnglishName= "Subject", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath="", Status = true },
                new WordCategory() { Id = 2, VietnameseName = "Động từ", EnglishName= "Verb", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true }
                );

            modelBuilder.Entity<Word>().HasData(
                new Word() { Id = 1, VietnameseText = "Con", EnglishText = "I", WordCategoryId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true},
                new Word() { Id = 2, VietnameseText = "Muốn", EnglishText= "Want To", WordCategory = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
                new Word() { Id = 3, VietnameseText = "Ăn", EnglishText = "Eat", WordCategoryId = 2,CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
                new Word() { Id = 4, VietnameseText = "Uống", EnglishText= "Drink", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true }
                );
        }

    }
}
