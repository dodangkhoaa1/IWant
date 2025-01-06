using IWant.BusinessObject.Enitities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Reflection.Emit;

namespace IWant.DataAccess;

public partial class ApplicationDbContext : IdentityDbContext
{

    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ChatRoom> ChatRooms { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<WordCategory> WordCategories { get; set; }
    public virtual DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"),
            server => server.EnableRetryOnFailure());
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "d19bb620-77b5-414e-865a-1894fbcbb689",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "fbd6a6c8-27eb-4171-bb75-50e97adffebb",
                Name = "Member",
                NormalizedName = "MEMBER"
            });

        builder.Entity<User>().HasData(new User
        {
            Id = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
            FullName = "Hồ Minh Nhật",
            Avatar = "",
            Gender = true,
            Birthday = DateOnly.Parse("2003-11-24"),
            Status = true,
            UserName = "nhathm2411@gmail.com",
            NormalizedUserName = "NHATHM2411@GMAIL.COM",
            Email = "nhathm2411@gmail.com",
            NormalizedEmail = "NHATHM2411@GMAIL.COM",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==",
            SecurityStamp = "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY",
            ConcurrencyStamp = "bd591428-5d71-49ee-abd2-c1740ff5f70c",
            PhoneNumber = null,
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = "0bcbb4f7-72f9-435f-9cb3-1621b4503974",
            RoleId = "d19bb620-77b5-414e-865a-1894fbcbb689"
        });

        //Word Category
        builder.Entity<WordCategory>().HasData(
                new WordCategory() { Id = 1, VietnameseName = "Chủ từ", EnglishName = "Subject", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
                new WordCategory() { Id = 2, VietnameseName = "Động từ", EnglishName = "Verb", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true }
        );

        //Word
        builder.Entity<Word>().HasData(
            new Word() { Id = 1, VietnameseText = "Con", EnglishText = "I", WordCategoryId = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
            new Word() { Id = 2, VietnameseText = "Muốn", EnglishText = "Want To", WordCategory = null, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
            new Word() { Id = 3, VietnameseText = "Ăn", EnglishText = "Eat", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true },
            new Word() { Id = 4, VietnameseText = "Uống", EnglishText = "Drink", WordCategoryId = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImagePath = "", Status = true }
            );
    }

}