using Microsoft.EntityFrameworkCore;

namespace IWant.API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasIndex(p => p.username)
                .IsUnique();
            modelBuilder.Entity<Player>().HasData(
                new Player() { id = 1, username = "admin", password = "admin", score = 0 });
        }

    }
}
