using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), "bd591428-5d71-49ee-abd2-c1740ff5f70c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "nhathm2411@gmail.com", false, "Hồ Minh Nhật", true, true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2250), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2251), "Hành Động" },
                    { 2, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2254), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2255), "Động Vật" },
                    { 3, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2257), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2257), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2259), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2259), "Quần Áo" },
                    { 5, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2261), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2262), "Màu Sắc" },
                    { 6, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2264), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2264), "Cảm Xúc" },
                    { 7, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2266), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2266), "Thức Ăn" },
                    { 8, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2268), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2269), "Trái Cây" },
                    { 9, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2270), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2271), "Con Số" },
                    { 10, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2273), "People", "images/wordCategories/People.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2273), "Con Người" },
                    { 11, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2276), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2276), "Địa Điểm" },
                    { 12, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2278), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2278), "Câu Hỏi" },
                    { 13, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2280), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2280), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2282), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2282), "Thời Gian" },
                    { 15, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2284), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2284), "Đồ Chơi" },
                    { 16, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2286), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2287), "Phương Tiện" },
                    { 17, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2288), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2289), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2371), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2373), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2375), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2376), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2378), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2378), "Đóng", 1 },
                    { 4, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2380), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2381), "Uống", 1 },
                    { 5, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2383), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2383), "Ăn", 1 },
                    { 6, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2385), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2386), "Nhìn", 1 },
                    { 7, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2387), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2388), "Tắt", 1 },
                    { 8, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2390), "On", "images/word/actions/On.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2390), "Bật", 1 },
                    { 9, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2392), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2393), "Mở", 1 },
                    { 10, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2401), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2401), "Chơi", 1 },
                    { 11, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2423), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2424), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2427), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2427), "Chạy", 1 },
                    { 13, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2433), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2433), "Ngồi", 1 },
                    { 14, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2435), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2437), "Ngủ", 1 },
                    { 15, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2439), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2439), "Đứng", 1 },
                    { 16, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2441), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2442), "Bơi", 1 },
                    { 17, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2444), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2444), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2446), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2446), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2448), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2449), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2451), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2451), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2453), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2453), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2481), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2481), "Ong", 2 },
                    { 23, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2486), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2486), "Chim", 2 },
                    { 24, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2488), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2489), "Bướm", 2 },
                    { 25, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2493), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2493), "Mèo", 2 },
                    { 26, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2495), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2496), "Gà", 2 },
                    { 27, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2498), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2498), "Bò", 2 },
                    { 28, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2500), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2501), "Chó", 2 },
                    { 29, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2503), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2503), "Vịt", 2 },
                    { 30, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2505), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2505), "Cá", 2 },
                    { 31, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2507), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2507), "Ngựa", 2 },
                    { 32, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2526), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2527), "Chuột", 2 },
                    { 33, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2528), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2529), "Heo", 2 },
                    { 34, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2550), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2551), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2553), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2553), "Lưng", 3 },
                    { 36, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2555), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2556), "Bụng", 3 },
                    { 37, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2557), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2558), "Mông", 3 },
                    { 38, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2560), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2560), "Tai", 3 },
                    { 39, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2562), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2562), "Mắt", 3 },
                    { 40, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2564), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2565), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2567), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2567), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2569), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2569), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2571), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2572), "Tóc", 3 },
                    { 44, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2573), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2574), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2576), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2576), "Chân", 3 },
                    { 46, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2578), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2579), "Môi", 3 },
                    { 47, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2580), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2581), "Mũi", 3 },
                    { 48, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2583), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2583), "Răng", 3 },
                    { 49, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2585), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2585), "Họng", 3 },
                    { 50, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2587), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2588), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2589), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2590), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2612), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2612), "Ba lô", 4 },
                    { 53, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2614), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2615), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2616), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2625), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2627), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2628), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2629), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2630), "Quần dài", 4 },
                    { 57, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2632), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2632), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2634), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2634), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2636), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2637), "Giày", 4 },
                    { 60, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2638), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2639), "Quần short", 4 },
                    { 61, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2641), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2642), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2644), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2644), "Tất", 4 },
                    { 63, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2646), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2647), "Áo len", 4 },
                    { 64, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2649), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2649), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2652), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2652), "Áo phông", 4 },
                    { 66, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2654), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2654), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2685), "Black", "images/word/color/Black.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2685), "Màu đen", 5 },
                    { 68, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2687), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2688), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2690), "Green", "images/word/color/Green.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2690), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2692), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2692), "Màu cam", 5 },
                    { 71, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2694), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2694), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2696), "Red", "images/word/color/Red.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2697), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2699), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2699), "Màu tím", 5 },
                    { 74, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2701), "White", "images/word/color/White.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2702), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2703), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2704), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2722), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2722), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2724), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2725), "Tức giận", 6 },
                    { 78, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2726), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2727), "Chán nản", 6 },
                    { 79, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2729), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2729), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2731), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2731), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2733), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2733), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2735), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2736), "Đói", 6 },
                    { 83, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2737), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2738), "Đau", 6 },
                    { 84, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2739), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2740), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2742), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2742), "Buồn", 6 },
                    { 86, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2744), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2745), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2747), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2747), "Ốm", 6 },
                    { 88, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2749), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2749), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2751), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2751), "Khát", 6 },
                    { 90, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2753), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2754), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2756), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2757), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2758), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2759), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2761), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2761), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2782), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2783), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2785), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2785), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2787), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2788), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2790), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2790), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2792), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2792), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2795), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2795), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2797), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2797), "Kem", 7 },
                    { 101, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2799), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2800), "Nước ép", 7 },
                    { 102, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2802), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2802), "Sữa", 7 },
                    { 103, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2804), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2804), "Pizza", 7 },
                    { 104, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2806), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2807), "Cơm", 7 },
                    { 105, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2808), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2809), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2811), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2811), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2813), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2813), "Súp", 7 },
                    { 108, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2815), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2815), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2817), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2818), "Trà", 7 },
                    { 110, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2819), "Water", "images/word/food/Water.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2820), "Nước", 7 },
                    { 111, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2821), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2822), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2843), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2844), "Táo", 8 },
                    { 113, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2845), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2846), "Bơ", 8 },
                    { 114, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2848), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2848), "Chuối", 8 },
                    { 115, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2850), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2850), "Thanh long", 8 },
                    { 116, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2852), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2853), "Nho", 8 },
                    { 117, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2854), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2855), "Ổi", 8 },
                    { 118, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2856), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2857), "Kiwi", 8 },
                    { 119, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2859), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2859), "Cam", 8 },
                    { 120, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2861), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2861), "Đào", 8 },
                    { 121, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2863), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2863), "Dứa", 8 },
                    { 122, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2865), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2866), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2868), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2868), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2888), "One", "images/word/number/One.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2888), "Một", 9 },
                    { 125, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2890), "Two", "images/word/number/Two.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2891), "Hai", 9 },
                    { 126, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2892), "Three", "images/word/number/Three.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2893), "Ba", 9 },
                    { 127, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2894), "Four", "images/word/number/Four.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2895), "Bốn", 9 },
                    { 128, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2897), "Five", "images/word/number/Five.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2897), "Năm", 9 },
                    { 129, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2899), "Six", "images/word/number/Six.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2899), "Sáu", 9 },
                    { 130, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2901), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2901), "Bảy", 9 },
                    { 131, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2903), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2904), "Tám", 9 },
                    { 132, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2905), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2906), "Chín", 9 },
                    { 133, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2907), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2908), "Mười", 9 },
                    { 134, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2935), "Again", "images/word/people/Again.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2935), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2937), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2938), "Em bé", 10 },
                    { 136, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2939), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2940), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2942), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2943), "Bố", 10 },
                    { 138, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2944), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2945), "Mọi người", 10 },
                    { 139, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2947), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2947), "Cô bé", 10 },
                    { 140, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2949), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2949), "Bà", 10 },
                    { 141, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2951), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2952), "Ông", 10 },
                    { 142, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2953), "How much", "images/word/people/How much.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2954), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2955), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2956), "Mẹ", 10 },
                    { 144, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2958), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2958), "Anh trai", 10 },
                    { 145, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2960), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2960), "Chị gái", 10 },
                    { 146, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2962), "What", "images/word/people/What.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2962), "Cái gì", 10 },
                    { 147, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2964), "When", "images/word/people/When.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2964), "Khi nào", 10 },
                    { 148, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2966), "Where", "images/word/people/Where.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2967), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2968), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2970), "Cái nào", 10 },
                    { 150, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2971), "Who", "images/word/people/Who.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2972), "Ai", 10 },
                    { 151, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2974), "Why", "images/word/people/Why.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2974), "Tại sao", 10 },
                    { 152, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2976), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2976), "Em trai", 10 },
                    { 153, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2978), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2978), "Em gái", 10 },
                    { 154, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2980), "What time", "images/word/people/What time.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(2981), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3003), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3003), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3005), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3006), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3007), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3008), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3010), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3010), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3012), "House", "images/word/places/House.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3012), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3014), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3014), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3016), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3017), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3019), "Park", "images/word/places/Park.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3020), "Công viên", 11 },
                    { 163, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3021), "School", "images/word/places/School.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3022), "Trường học", 11 },
                    { 164, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3023), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3024), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3026), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3026), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3028), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3028), "Sở thú", 11 },
                    { 167, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3049), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3049), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3051), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3051), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3053), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3054), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3056), "What", "images/word/questions/What.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3056), "Cái gì", 12 },
                    { 171, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3058), "When", "images/word/questions/When.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3058), "Khi nào", 12 },
                    { 172, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3060), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3061), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3063), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3063), "Cái nào", 12 },
                    { 174, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3066), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3066), "Ai", 12 },
                    { 175, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3068), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3069), "Tại sao", 12 },
                    { 176, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3086), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3086), "Ở trên", 13 },
                    { 177, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3088), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3089), "Phía sau", 13 },
                    { 178, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3090), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3091), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3092), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3093), "Ít", 13 },
                    { 180, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3095), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3095), "Nặng", 13 },
                    { 181, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3097), "High", "images/word/relations/High.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3097), "Cao", 13 },
                    { 182, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3099), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3099), "Phía trước", 13 },
                    { 183, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3101), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3102), "Ở trong", 13 },
                    { 184, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3103), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3104), "Lớn", 13 },
                    { 185, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3106), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3106), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3108), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3109), "Dài", 13 },
                    { 187, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3111), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3112), "Thấp", 13 },
                    { 188, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3114), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3114), "Nhiều", 13 },
                    { 189, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3116), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3117), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3118), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3119), "Ngắn", 13 },
                    { 191, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3121), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3121), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3124), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3124), "Dày", 13 },
                    { 193, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3126), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3126), "Mỏng", 13 },
                    { 194, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3147), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3147), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3149), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3150), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3159), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3159), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3161), "Night", "images/word/time/Night.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3162), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3166), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3167), "Một giờ", 14 },
                    { 199, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3169), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3169), "Mười phút", 14 },
                    { 200, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3171), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3172), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3173), "Today", "images/word/time/Today.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3174), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3176), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3177), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3178), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3179), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3197), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3198), "Bóng", 15 },
                    { 205, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3200), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3200), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3202), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3202), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3204), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3205), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3206), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3207), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3208), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3209), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3211), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3211), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3213), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3213), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3215), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3215), "Tô màu", 15 },
                    { 213, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3218), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3218), "Bút màu", 15 },
                    { 214, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3220), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3220), "Búp bê", 15 },
                    { 215, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3222), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3223), "Diều", 15 },
                    { 216, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3224), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3225), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3227), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3227), "Tivi", 15 },
                    { 218, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3229), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3229), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3250), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3251), "Máy bay", 16 },
                    { 220, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3253), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3253), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3255), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3255), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3257), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3257), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3259), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3260), "Xe máy", 16 },
                    { 224, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3261), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3262), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3279), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3279), "Ôm", 17 },
                    { 226, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3281), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3282), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3284), "I want", "images/word/want/I want.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3284), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3286), "No", "images/word/want/No.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3286), "Không", 17 },
                    { 229, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3288), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3289), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3291), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3291), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3294), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 1, 5, 11, 4, 45, 698, DateTimeKind.Local).AddTicks(3294), "Có", 17 }
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
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WordCategories");
        }
    }
}
