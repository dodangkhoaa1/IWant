using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildNickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildBirthday = table.Column<DateOnly>(type: "date", nullable: false),
                    ChildGender = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VietnameseName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLocalPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRooms_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VietnameseText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnglishText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WordCategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalWords_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalWords_WordCategories_WordCategoryId",
                        column: x => x.WordCategoryId,
                        principalTable: "WordCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VietnameseText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnglishText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WordCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordCategories_WordCategoryId",
                        column: x => x.WordCategoryId,
                        principalTable: "WordCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStar = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rates_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToRoomId = table.Column<int>(type: "int", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_ChatRooms_ToRoomId",
                        column: x => x.ToRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d19bb620-77b5-414e-865a-1894fbcbb689", null, "Admin", "ADMIN" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ChildBirthday", "ChildGender", "ChildName", "ChildNickName", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "Gender", "ImageLocalPath", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "", "Dot Connection", "" },
                    { 2, "", "Coloring", "" },
                    { 3, "", "AAC", "" },
                    { 4, "", "Emotion Selection", "" },
                    { 5, "", "Fruit Drop", "" }
                });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2829), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2830), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2832), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2833), "Hành Động" },
                    { 3, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2835), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2835), "Động Vật" },
                    { 4, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2837), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2838), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2839), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2840), "Quần Áo" },
                    { 6, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2842), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2842), "Màu Sắc" },
                    { 7, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2844), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2844), "Cảm Xúc" },
                    { 8, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2846), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2846), "Thức Ăn" },
                    { 9, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2848), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2849), "Trái Cây" },
                    { 10, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2851), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2851), "Con Số" },
                    { 11, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2853), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2854), "Con Người" },
                    { 12, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2855), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2856), "Địa Điểm" },
                    { 13, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2858), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2858), "Câu Hỏi" },
                    { 14, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2860), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2860), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2862), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2862), "Thời Gian" },
                    { 16, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2865), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2865), "Đồ Chơi" },
                    { 17, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2868), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2868), "Phương Tiện" },
                    { 18, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2870), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2871), "Mong Muốn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d19bb620-77b5-414e-865a-1894fbcbb689", "0bcbb4f7-72f9-435f-9cb3-1621b4503974" });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2907), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2908), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2911), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2912), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2914), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2914), "Đóng", 1 },
                    { 4, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2916), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2917), "Uống", 1 },
                    { 5, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2918), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2919), "Ăn", 1 },
                    { 6, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2928), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2929), "Nhìn", 1 },
                    { 7, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2931), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2931), "Tắt", 1 },
                    { 8, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2934), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2934), "Bật", 1 },
                    { 9, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2936), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2936), "Mở", 1 },
                    { 10, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2939), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2939), "Chơi", 1 },
                    { 11, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2941), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2941), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2943), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2943), "Chạy", 1 },
                    { 13, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2945), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2946), "Ngồi", 1 },
                    { 14, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2948), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2948), "Ngủ", 1 },
                    { 15, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2950), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2950), "Đứng", 1 },
                    { 16, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2952), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2953), "Bơi", 1 },
                    { 17, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2954), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2955), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2957), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2957), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2959), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2959), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2961), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2961), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2964), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2964), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2994), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2995), "Ong", 2 },
                    { 23, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2997), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2997), "Chim", 2 },
                    { 24, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2999), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(2999), "Bướm", 2 },
                    { 25, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3001), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3002), "Mèo", 2 },
                    { 26, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3004), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3005), "Gà", 2 },
                    { 27, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3007), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3007), "Bò", 2 },
                    { 28, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3009), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3009), "Chó", 2 },
                    { 29, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3011), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3011), "Vịt", 2 },
                    { 30, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3013), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3014), "Cá", 2 },
                    { 31, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3015), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3016), "Ngựa", 2 },
                    { 32, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3018), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3018), "Chuột", 2 },
                    { 33, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3021), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3021), "Heo", 2 },
                    { 34, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3044), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3045), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3047), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3048), "Lưng", 3 },
                    { 36, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3050), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3050), "Bụng", 3 },
                    { 37, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3052), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3052), "Mông", 3 },
                    { 38, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3054), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3055), "Tai", 3 },
                    { 39, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3056), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3057), "Mắt", 3 },
                    { 40, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3059), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3059), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3061), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3061), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3064), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3064), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3066), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3066), "Tóc", 3 },
                    { 44, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3068), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3069), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3070), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3071), "Chân", 3 },
                    { 46, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3073), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3073), "Môi", 3 },
                    { 47, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3076), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3076), "Mũi", 3 },
                    { 48, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3078), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3078), "Răng", 3 },
                    { 49, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3080), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3081), "Họng", 3 },
                    { 50, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3082), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3083), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3085), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3085), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3108), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3108), "Ba lô", 4 },
                    { 53, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3110), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3111), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3113), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3113), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3115), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3116), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3117), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3118), "Quần dài", 4 },
                    { 57, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3120), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3120), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3122), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3123), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3125), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3125), "Giày", 4 },
                    { 60, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3127), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3128), "Quần short", 4 },
                    { 61, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3129), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3130), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3132), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3132), "Tất", 4 },
                    { 63, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3134), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3134), "Áo len", 4 },
                    { 64, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3137), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3137), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3139), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3140), "Áo phông", 4 },
                    { 66, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3141), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3142), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3170), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3171), "Màu đen", 5 },
                    { 68, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3175), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3176), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3179), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3180), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3181), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3182), "Màu cam", 5 },
                    { 71, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3184), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3184), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3186), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3186), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3188), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3189), "Màu tím", 5 },
                    { 74, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3190), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3191), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3193), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3193), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3213), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3213), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3215), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3215), "Tức giận", 6 },
                    { 78, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3217), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3217), "Chán nản", 6 },
                    { 79, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3219), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3220), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3221), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3222), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3224), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3224), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3226), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3226), "Đói", 6 },
                    { 83, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3228), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3228), "Đau", 6 },
                    { 84, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3230), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3232), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3234), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3234), "Buồn", 6 },
                    { 86, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3236), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3236), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3238), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3239), "Ốm", 6 },
                    { 88, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3241), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3241), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3244), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3244), "Khát", 6 },
                    { 90, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3246), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3246), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3248), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3249), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3251), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3251), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3253), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3253), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3275), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3275), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3277), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3278), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3279), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3280), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3282), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3283), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3285), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3285), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3287), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3287), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3289), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3289), "Kem", 7 },
                    { 101, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3291), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3292), "Nước ép", 7 },
                    { 102, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3294), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3294), "Sữa", 7 },
                    { 103, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3296), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3297), "Pizza", 7 },
                    { 104, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3298), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3299), "Cơm", 7 },
                    { 105, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3301), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3301), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3303), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3303), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3306), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3306), "Súp", 7 },
                    { 108, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3308), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3308), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3311), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3311), "Trà", 7 },
                    { 110, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3313), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3314), "Nước", 7 },
                    { 111, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3315), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3316), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3337), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3338), "Táo", 8 },
                    { 113, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3340), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3341), "Bơ", 8 },
                    { 114, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3343), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3343), "Chuối", 8 },
                    { 115, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3345), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3346), "Thanh long", 8 },
                    { 116, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3348), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3348), "Nho", 8 },
                    { 117, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3350), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3351), "Ổi", 8 },
                    { 118, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3353), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3353), "Kiwi", 8 },
                    { 119, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3355), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3356), "Cam", 8 },
                    { 120, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3358), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3358), "Đào", 8 },
                    { 121, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3360), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3360), "Dứa", 8 },
                    { 122, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3362), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3362), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3365), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3366), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3387), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3387), "Một", 9 },
                    { 125, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3390), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3390), "Hai", 9 },
                    { 126, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3392), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3392), "Ba", 9 },
                    { 127, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3394), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3394), "Bốn", 9 },
                    { 128, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3397), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3398), "Năm", 9 },
                    { 129, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3400), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3401), "Sáu", 9 },
                    { 130, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3403), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3403), "Bảy", 9 },
                    { 131, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3406), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3406), "Tám", 9 },
                    { 132, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3408), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3408), "Chín", 9 },
                    { 133, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3411), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3411), "Mười", 9 },
                    { 134, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3439), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3440), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3442), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3442), "Em bé", 10 },
                    { 136, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3444), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3445), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3446), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3447), "Bố", 10 },
                    { 138, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3449), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3449), "Mọi người", 10 },
                    { 139, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3451), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3451), "Cô bé", 10 },
                    { 140, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3453), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3454), "Bà", 10 },
                    { 141, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3455), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3456), "Ông", 10 },
                    { 142, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3458), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3458), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3460), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3460), "Mẹ", 10 },
                    { 144, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3463), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3463), "Anh trai", 10 },
                    { 145, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3465), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3465), "Chị gái", 10 },
                    { 146, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3467), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3468), "Cái gì", 10 },
                    { 147, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3469), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3470), "Khi nào", 10 },
                    { 148, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3473), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3473), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3475), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3475), "Cái nào", 10 },
                    { 150, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3477), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3477), "Ai", 10 },
                    { 151, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3480), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3480), "Tại sao", 10 },
                    { 152, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3482), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3483), "Em trai", 10 },
                    { 153, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3484), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3485), "Em gái", 10 },
                    { 154, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3487), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3487), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3511), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3511), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3513), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3514), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3516), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3516), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3518), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3518), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3520), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3521), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3522), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3523), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3525), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3526), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3527), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3528), "Công viên", 11 },
                    { 163, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3530), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3530), "Trường học", 11 },
                    { 164, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3532), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3532), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3534), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3534), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3536), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3536), "Sở thú", 11 },
                    { 167, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3557), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3557), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3559), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3560), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3562), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3563), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3564), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3565), "Cái gì", 12 },
                    { 171, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3567), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3567), "Khi nào", 12 },
                    { 172, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3569), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3569), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3572), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3572), "Cái nào", 12 },
                    { 174, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3574), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3575), "Ai", 12 },
                    { 175, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3576), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3577), "Tại sao", 12 },
                    { 176, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3597), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3598), "Ở trên", 13 },
                    { 177, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3600), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3601), "Phía sau", 13 },
                    { 178, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3603), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3604), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3605), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3606), "Ít", 13 },
                    { 180, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3608), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3608), "Nặng", 13 },
                    { 181, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3610), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3610), "Cao", 13 },
                    { 182, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3612), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3612), "Phía trước", 13 },
                    { 183, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3614), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3615), "Ở trong", 13 },
                    { 184, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3616), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3617), "Lớn", 13 },
                    { 185, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3618), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3619), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3621), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3622), "Dài", 13 },
                    { 187, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3624), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3624), "Thấp", 13 },
                    { 188, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3626), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3626), "Nhiều", 13 },
                    { 189, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3628), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3628), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3630), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3630), "Ngắn", 13 },
                    { 191, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3632), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3633), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3634), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3635), "Dày", 13 },
                    { 193, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3637), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3637), "Mỏng", 13 },
                    { 194, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3660), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3660), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3662), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3662), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3664), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3664), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3666), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3667), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3669), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3670), "Một giờ", 14 },
                    { 199, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3671), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3672), "Mười phút", 14 },
                    { 200, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3673), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3674), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3676), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3676), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3678), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3678), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3680), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3680), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3706), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3706), "Bóng", 15 },
                    { 205, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3708), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3709), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3710), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3711), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3713), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3713), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3715), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3715), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3717), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3717), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3719), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3719), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3725), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3725), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3727), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3727), "Tô màu", 15 },
                    { 213, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3729), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3729), "Bút màu", 15 },
                    { 214, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3731), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3732), "Búp bê", 15 },
                    { 215, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3733), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3734), "Diều", 15 },
                    { 216, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3735), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3736), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3738), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3738), "Tivi", 15 },
                    { 218, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3740), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3740), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3761), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3762), "Máy bay", 16 },
                    { 220, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3764), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3764), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3766), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3766), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3768), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3768), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3770), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3771), "Xe máy", 16 },
                    { 224, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3773), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3774), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3791), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3792), "Ôm", 17 },
                    { 226, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3794), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3794), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3796), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3796), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3798), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3799), "Không", 17 },
                    { 229, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3800), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3801), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3802), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3803), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3804), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 18, 7, 57, 23, 383, DateTimeKind.Local).AddTicks(3805), "Có", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_AdminId",
                table: "ChatRooms",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWords_UserId",
                table: "PersonalWords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalWords_WordCategoryId",
                table: "PersonalWords",
                column: "WordCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_BlogId",
                table: "Rates",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_UserId",
                table: "Rates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordCategoryId",
                table: "Words",
                column: "WordCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PersonalWords");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "WordCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
