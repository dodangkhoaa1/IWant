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
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "Gender", "ImageLocalPath", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2206), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2206), "Hành Động" },
                    { 2, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2209), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2209), "Động Vật" },
                    { 3, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2212), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2212), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2214), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2214), "Quần Áo" },
                    { 5, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2216), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2217), "Màu Sắc" },
                    { 6, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2218), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2219), "Cảm Xúc" },
                    { 7, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2220), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2222), "Thức Ăn" },
                    { 8, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2224), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2224), "Trái Cây" },
                    { 9, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2226), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2226), "Con Số" },
                    { 10, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2228), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2228), "Con Người" },
                    { 11, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2230), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2231), "Địa Điểm" },
                    { 12, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2232), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2233), "Câu Hỏi" },
                    { 13, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2234), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2235), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2236), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2237), "Thời Gian" },
                    { 15, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2239), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2239), "Đồ Chơi" },
                    { 16, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2241), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2241), "Phương Tiện" },
                    { 17, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2243), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2243), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2280), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2281), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2284), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2284), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2286), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2287), "Đóng", 1 },
                    { 4, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2289), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2289), "Uống", 1 },
                    { 5, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2292), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2293), "Ăn", 1 },
                    { 6, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2294), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2295), "Nhìn", 1 },
                    { 7, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2297), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2297), "Tắt", 1 },
                    { 8, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2299), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2299), "Bật", 1 },
                    { 9, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2301), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2302), "Mở", 1 },
                    { 10, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2304), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2304), "Chơi", 1 },
                    { 11, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2306), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2306), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2309), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2309), "Chạy", 1 },
                    { 13, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2311), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2311), "Ngồi", 1 },
                    { 14, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2313), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2313), "Ngủ", 1 },
                    { 15, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2315), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2316), "Đứng", 1 },
                    { 16, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2318), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2318), "Bơi", 1 },
                    { 17, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2320), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2321), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2323), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2324), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2326), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2326), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2328), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2328), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2337), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2337), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2368), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2368), "Ong", 2 },
                    { 23, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2370), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2370), "Chim", 2 },
                    { 24, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2372), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2373), "Bướm", 2 },
                    { 25, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2375), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2375), "Mèo", 2 },
                    { 26, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2377), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2378), "Gà", 2 },
                    { 27, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2379), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2380), "Bò", 2 },
                    { 28, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2382), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2382), "Chó", 2 },
                    { 29, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2384), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2384), "Vịt", 2 },
                    { 30, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2387), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2388), "Cá", 2 },
                    { 31, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2389), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2390), "Ngựa", 2 },
                    { 32, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2392), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2392), "Chuột", 2 },
                    { 33, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2394), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2394), "Heo", 2 },
                    { 34, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2415), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2415), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2417), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2418), "Lưng", 3 },
                    { 36, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2420), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2420), "Bụng", 3 },
                    { 37, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2422), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2423), "Mông", 3 },
                    { 38, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2424), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2425), "Tai", 3 },
                    { 39, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2427), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2427), "Mắt", 3 },
                    { 40, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2429), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2430), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2432), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2432), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2434), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2434), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2437), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2438), "Tóc", 3 },
                    { 44, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2440), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2440), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2442), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2442), "Chân", 3 },
                    { 46, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2444), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2444), "Môi", 3 },
                    { 47, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2446), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2447), "Mũi", 3 },
                    { 48, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2449), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2449), "Răng", 3 },
                    { 49, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2451), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2451), "Họng", 3 },
                    { 50, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2453), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2454), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2456), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2456), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2480), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2480), "Ba lô", 4 },
                    { 53, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2482), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2483), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2484), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2485), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2487), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2487), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2489), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2489), "Quần dài", 4 },
                    { 57, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2491), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2492), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2494), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2494), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2496), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2496), "Giày", 4 },
                    { 60, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2498), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2499), "Quần short", 4 },
                    { 61, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2500), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2501), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2503), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2503), "Tất", 4 },
                    { 63, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2505), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2505), "Áo len", 4 },
                    { 64, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2508), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2508), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2510), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2510), "Áo phông", 4 },
                    { 66, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2512), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2513), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2534), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2535), "Màu đen", 5 },
                    { 68, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2537), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2537), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2539), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2540), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2542), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2542), "Màu cam", 5 },
                    { 71, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2544), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2544), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2546), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2547), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2548), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2549), "Màu tím", 5 },
                    { 74, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2551), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2551), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2553), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2553), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2576), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2577), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2579), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2579), "Tức giận", 6 },
                    { 78, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2581), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2582), "Chán nản", 6 },
                    { 79, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2584), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2584), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2586), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2586), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2589), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2590), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2591), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2592), "Đói", 6 },
                    { 83, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2594), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2594), "Đau", 6 },
                    { 84, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2596), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2596), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2598), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2599), "Buồn", 6 },
                    { 86, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2601), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2601), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2603), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2603), "Ốm", 6 },
                    { 88, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2605), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2606), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2608), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2608), "Khát", 6 },
                    { 90, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2610), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2610), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2612), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2613), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2614), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2615), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2617), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2617), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2641), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2641), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2643), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2644), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2646), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2646), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2648), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2648), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2650), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2651), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2652), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2653), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2655), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2655), "Kem", 7 },
                    { 101, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2657), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2658), "Nước ép", 7 },
                    { 102, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2659), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2660), "Sữa", 7 },
                    { 103, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2662), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2662), "Pizza", 7 },
                    { 104, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2664), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2664), "Cơm", 7 },
                    { 105, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2667), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2667), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2669), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2670), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2672), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2672), "Súp", 7 },
                    { 108, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2674), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2674), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2676), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2676), "Trà", 7 },
                    { 110, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2678), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2679), "Nước", 7 },
                    { 111, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2681), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2681), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2703), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2704), "Táo", 8 },
                    { 113, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2706), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2706), "Bơ", 8 },
                    { 114, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2708), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2709), "Chuối", 8 },
                    { 115, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2711), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2711), "Thanh long", 8 },
                    { 116, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2713), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2713), "Nho", 8 },
                    { 117, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2715), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2716), "Ổi", 8 },
                    { 118, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2718), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2718), "Kiwi", 8 },
                    { 119, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2721), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2721), "Cam", 8 },
                    { 120, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2723), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2724), "Đào", 8 },
                    { 121, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2726), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2726), "Dứa", 8 },
                    { 122, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2728), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2728), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2730), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2731), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2751), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2752), "Một", 9 },
                    { 125, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2754), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2754), "Hai", 9 },
                    { 126, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2756), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2756), "Ba", 9 },
                    { 127, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2758), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2759), "Bốn", 9 },
                    { 128, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2761), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2761), "Năm", 9 },
                    { 129, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2763), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2763), "Sáu", 9 },
                    { 130, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2765), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2766), "Bảy", 9 },
                    { 131, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2768), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2768), "Tám", 9 },
                    { 132, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2771), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2771), "Chín", 9 },
                    { 133, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2773), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2774), "Mười", 9 },
                    { 134, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2795), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2796), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2804), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2804), "Em bé", 10 },
                    { 136, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2806), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2806), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2808), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2809), "Bố", 10 },
                    { 138, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2811), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2811), "Mọi người", 10 },
                    { 139, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2813), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2813), "Cô bé", 10 },
                    { 140, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2815), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2816), "Bà", 10 },
                    { 141, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2817), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2818), "Ông", 10 },
                    { 142, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2820), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2820), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2822), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2822), "Mẹ", 10 },
                    { 144, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2825), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2826), "Anh trai", 10 },
                    { 145, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2827), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2828), "Chị gái", 10 },
                    { 146, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2830), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2830), "Cái gì", 10 },
                    { 147, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2832), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2832), "Khi nào", 10 },
                    { 148, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2834), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2835), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2837), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2837), "Cái nào", 10 },
                    { 150, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2839), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2839), "Ai", 10 },
                    { 151, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2841), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2842), "Tại sao", 10 },
                    { 152, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2844), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2844), "Em trai", 10 },
                    { 153, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2846), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2846), "Em gái", 10 },
                    { 154, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2848), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2849), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2874), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2875), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2877), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2877), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2879), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2879), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2881), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2882), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2884), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2884), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2886), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2886), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2888), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2889), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2891), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2891), "Công viên", 11 },
                    { 163, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2893), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2893), "Trường học", 11 },
                    { 164, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2895), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2895), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2899), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2899), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2901), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2901), "Sở thú", 11 },
                    { 167, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2921), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2921), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2923), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2923), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2925), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2926), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2928), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2928), "Cái gì", 12 },
                    { 171, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2930), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2930), "Khi nào", 12 },
                    { 172, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2932), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2933), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2935), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2935), "Cái nào", 12 },
                    { 174, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2937), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2937), "Ai", 12 },
                    { 175, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2939), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2940), "Tại sao", 12 },
                    { 176, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2958), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2959), "Ở trên", 13 },
                    { 177, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2961), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2962), "Phía sau", 13 },
                    { 178, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2963), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2964), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2966), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2966), "Ít", 13 },
                    { 180, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2968), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2968), "Nặng", 13 },
                    { 181, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2970), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2971), "Cao", 13 },
                    { 182, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2976), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2977), "Phía trước", 13 },
                    { 183, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2979), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2979), "Ở trong", 13 },
                    { 184, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2981), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2981), "Lớn", 13 },
                    { 185, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2983), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2984), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2985), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2986), "Dài", 13 },
                    { 187, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2988), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2988), "Thấp", 13 },
                    { 188, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2990), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2990), "Nhiều", 13 },
                    { 189, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2992), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2993), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2995), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2995), "Ngắn", 13 },
                    { 191, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2997), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2997), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(2999), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3000), "Dày", 13 },
                    { 193, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3001), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3002), "Mỏng", 13 },
                    { 194, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3022), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3023), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3025), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3025), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3027), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3028), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3029), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3030), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3032), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3032), "Một giờ", 14 },
                    { 199, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3034), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3034), "Mười phút", 14 },
                    { 200, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3036), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3037), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3039), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3039), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3041), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3041), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3043), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3044), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3063), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3063), "Bóng", 15 },
                    { 205, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3065), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3066), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3067), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3068), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3071), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3071), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3073), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3074), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3075), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3076), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3078), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3078), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3080), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3080), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3082), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3083), "Tô màu", 15 },
                    { 213, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3085), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3085), "Bút màu", 15 },
                    { 214, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3087), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3087), "Búp bê", 15 },
                    { 215, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3089), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3090), "Diều", 15 },
                    { 216, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3092), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3092), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3094), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3094), "Tivi", 15 },
                    { 218, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3102), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3102), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3123), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3124), "Máy bay", 16 },
                    { 220, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3126), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3126), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3128), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3129), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3131), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3131), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3134), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3134), "Xe máy", 16 },
                    { 224, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3136), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3136), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3152), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3153), "Ôm", 17 },
                    { 226, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3155), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3155), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3157), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3158), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3159), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3160), "Không", 17 },
                    { 229, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3162), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3162), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3164), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3164), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3166), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 6, 10, 40, 37, 787, DateTimeKind.Local).AddTicks(3167), "Có", 17 }
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
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

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
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "WordCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
