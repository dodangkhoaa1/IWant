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
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Birthday", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, "avatar1.png", new DateOnly(2003, 11, 24), "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", false, "Hồ Minh Nhật", true, true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8116), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8116), "Hành Động" },
                    { 2, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8119), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8120), "Động Vật" },
                    { 3, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8121), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8122), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8123), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8124), "Quần Áo" },
                    { 5, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8126), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8127), "Màu Sắc" },
                    { 6, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8128), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8128), "Cảm Xúc" },
                    { 7, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8130), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8130), "Thức Ăn" },
                    { 8, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8133), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8133), "Trái Cây" },
                    { 9, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8134), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8135), "Con Số" },
                    { 10, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8136), "People", "images/wordCategories/People.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8137), "Con Người" },
                    { 11, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8138), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8139), "Địa Điểm" },
                    { 12, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8140), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8141), "Câu Hỏi" },
                    { 13, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8142), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8143), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8144), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8144), "Thời Gian" },
                    { 15, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8146), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8146), "Đồ Chơi" },
                    { 16, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8148), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8148), "Phương Tiện" },
                    { 17, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8150), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8150), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8192), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8193), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8195), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8196), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8198), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8198), "Đóng", 1 },
                    { 4, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8200), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8200), "Uống", 1 },
                    { 5, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8202), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8203), "Ăn", 1 },
                    { 6, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8204), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8205), "Nhìn", 1 },
                    { 7, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8206), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8207), "Tắt", 1 },
                    { 8, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8209), "On", "images/word/actions/On.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8209), "Bật", 1 },
                    { 9, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8211), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8211), "Mở", 1 },
                    { 10, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8213), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8213), "Chơi", 1 },
                    { 11, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8215), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8215), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8217), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8218), "Chạy", 1 },
                    { 13, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8219), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8220), "Ngồi", 1 },
                    { 14, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8221), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8222), "Ngủ", 1 },
                    { 15, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8224), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8224), "Đứng", 1 },
                    { 16, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8227), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8227), "Bơi", 1 },
                    { 17, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8229), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8229), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8231), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8231), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8233), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8233), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8235), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8235), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8237), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8237), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8269), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8269), "Ong", 2 },
                    { 23, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8271), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8272), "Chim", 2 },
                    { 24, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8273), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8274), "Bướm", 2 },
                    { 25, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8276), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8276), "Mèo", 2 },
                    { 26, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8278), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8278), "Gà", 2 },
                    { 27, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8280), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8280), "Bò", 2 },
                    { 28, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8283), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8283), "Chó", 2 },
                    { 29, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8285), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8285), "Vịt", 2 },
                    { 30, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8287), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8288), "Cá", 2 },
                    { 31, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8289), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8290), "Ngựa", 2 },
                    { 32, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8291), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8292), "Chuột", 2 },
                    { 33, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8294), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8294), "Heo", 2 },
                    { 34, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8316), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8316), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8318), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8318), "Lưng", 3 },
                    { 36, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8320), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8321), "Bụng", 3 },
                    { 37, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8322), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8323), "Mông", 3 },
                    { 38, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8325), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8325), "Tai", 3 },
                    { 39, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8327), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8327), "Mắt", 3 },
                    { 40, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8329), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8329), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8332), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8332), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8334), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8335), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8336), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8337), "Tóc", 3 },
                    { 44, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8339), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8339), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8341), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8341), "Chân", 3 },
                    { 46, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8343), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8344), "Môi", 3 },
                    { 47, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8345), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8346), "Mũi", 3 },
                    { 48, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8348), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8348), "Răng", 3 },
                    { 49, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8355), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8355), "Họng", 3 },
                    { 50, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8357), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8357), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8387), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8387), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8411), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8411), "Ba lô", 4 },
                    { 53, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8418), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8418), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8420), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8420), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8422), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8423), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8424), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8425), "Quần dài", 4 },
                    { 57, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8426), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8427), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8429), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8429), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8431), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8431), "Giày", 4 },
                    { 60, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8433), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8433), "Quần short", 4 },
                    { 61, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8435), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8436), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8437), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8438), "Tất", 4 },
                    { 63, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8440), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8440), "Áo len", 4 },
                    { 64, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8442), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8443), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8444), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8445), "Áo phông", 4 },
                    { 66, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8447), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8448), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8471), "Black", "images/word/color/Black.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8472), "Màu đen", 5 },
                    { 68, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8476), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8477), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8480), "Green", "images/word/color/Green.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8480), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8483), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8483), "Màu cam", 5 },
                    { 71, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8485), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8486), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8487), "Red", "images/word/color/Red.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8488), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8490), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8490), "Màu tím", 5 },
                    { 74, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8492), "White", "images/word/color/White.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8492), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8495), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8495), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8515), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8515), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8517), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8517), "Tức giận", 6 },
                    { 78, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8519), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8519), "Chán nản", 6 },
                    { 79, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8521), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8522), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8523), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8524), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8525), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8526), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8528), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8528), "Đói", 6 },
                    { 83, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8530), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8530), "Đau", 6 },
                    { 84, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8532), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8532), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8534), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8534), "Buồn", 6 },
                    { 86, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8536), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8536), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8538), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8539), "Ốm", 6 },
                    { 88, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8540), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8541), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8544), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8544), "Khát", 6 },
                    { 90, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8546), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8546), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8548), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8548), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8550), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8550), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8552), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8553), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8576), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8576), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8578), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8578), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8580), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8581), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8582), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8583), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8584), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8585), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8587), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8587), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8589), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8589), "Kem", 7 },
                    { 101, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8591), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8591), "Nước ép", 7 },
                    { 102, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8593), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8593), "Sữa", 7 },
                    { 103, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8595), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8595), "Pizza", 7 },
                    { 104, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8598), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8598), "Cơm", 7 },
                    { 105, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8600), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8601), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8602), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8603), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8605), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8605), "Súp", 7 },
                    { 108, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8607), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8607), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8609), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8609), "Trà", 7 },
                    { 110, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8611), "Water", "images/word/food/Water.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8611), "Nước", 7 },
                    { 111, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8613), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8613), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8636), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8636), "Táo", 8 },
                    { 113, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8638), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8639), "Bơ", 8 },
                    { 114, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8640), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8641), "Chuối", 8 },
                    { 115, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8644), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8644), "Thanh long", 8 },
                    { 116, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8651), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8651), "Nho", 8 },
                    { 117, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8653), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8653), "Ổi", 8 },
                    { 118, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8660), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8660), "Kiwi", 8 },
                    { 119, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8663), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8663), "Cam", 8 },
                    { 120, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8665), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8665), "Đào", 8 },
                    { 121, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8667), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8667), "Dứa", 8 },
                    { 122, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8669), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8670), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8672), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8672), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8692), "One", "images/word/number/One.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8692), "Một", 9 },
                    { 125, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8694), "Two", "images/word/number/Two.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8695), "Hai", 9 },
                    { 126, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8696), "Three", "images/word/number/Three.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8697), "Ba", 9 },
                    { 127, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8698), "Four", "images/word/number/Four.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8699), "Bốn", 9 },
                    { 128, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8701), "Five", "images/word/number/Five.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8701), "Năm", 9 },
                    { 129, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8703), "Six", "images/word/number/Six.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8703), "Sáu", 9 },
                    { 130, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8705), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8706), "Bảy", 9 },
                    { 131, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8708), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8708), "Tám", 9 },
                    { 132, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8710), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8710), "Chín", 9 },
                    { 133, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8712), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8712), "Mười", 9 },
                    { 134, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8733), "Again", "images/word/people/Again.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8733), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8735), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8735), "Em bé", 10 },
                    { 136, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8737), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8738), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8739), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8740), "Bố", 10 },
                    { 138, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8742), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8742), "Mọi người", 10 },
                    { 139, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8744), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8744), "Cô bé", 10 },
                    { 140, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8746), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8746), "Bà", 10 },
                    { 141, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8748), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8748), "Ông", 10 },
                    { 142, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8751), "How much", "images/word/people/How much.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8751), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8753), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8753), "Mẹ", 10 },
                    { 144, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8755), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8755), "Anh trai", 10 },
                    { 145, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8757), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8757), "Chị gái", 10 },
                    { 146, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8759), "What", "images/word/people/What.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8759), "Cái gì", 10 },
                    { 147, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8761), "When", "images/word/people/When.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8761), "Khi nào", 10 },
                    { 148, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8763), "Where", "images/word/people/Where.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8764), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8765), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8766), "Cái nào", 10 },
                    { 150, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8767), "Who", "images/word/people/Who.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8768), "Ai", 10 },
                    { 151, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8770), "Why", "images/word/people/Why.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8770), "Tại sao", 10 },
                    { 152, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8772), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8772), "Em trai", 10 },
                    { 153, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8774), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8774), "Em gái", 10 },
                    { 154, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8776), "What time", "images/word/people/What time.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8776), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8801), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8801), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8803), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8804), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8806), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8806), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8808), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8808), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8810), "House", "images/word/places/House.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8810), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8812), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8813), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8814), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8815), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8816), "Park", "images/word/places/Park.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8817), "Công viên", 11 },
                    { 163, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8819), "School", "images/word/places/School.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8819), "Trường học", 11 },
                    { 164, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8821), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8822), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8823), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8824), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8826), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8826), "Sở thú", 11 },
                    { 167, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8846), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8847), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8848), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8849), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8851), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8851), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8853), "What", "images/word/questions/What.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8853), "Cái gì", 12 },
                    { 171, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8855), "When", "images/word/questions/When.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8855), "Khi nào", 12 },
                    { 172, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8857), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8858), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8859), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8860), "Cái nào", 12 },
                    { 174, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8862), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8863), "Ai", 12 },
                    { 175, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8865), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8865), "Tại sao", 12 },
                    { 176, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8889), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8890), "Ở trên", 13 },
                    { 177, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8892), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8892), "Phía sau", 13 },
                    { 178, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8894), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8894), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8896), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8896), "Ít", 13 },
                    { 180, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8899), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8899), "Nặng", 13 },
                    { 181, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8901), "High", "images/word/relations/High.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8902), "Cao", 13 },
                    { 182, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8903), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8904), "Phía trước", 13 },
                    { 183, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8906), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8906), "Ở trong", 13 },
                    { 184, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8908), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8908), "Lớn", 13 },
                    { 185, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8910), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8910), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8912), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8912), "Dài", 13 },
                    { 187, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8914), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8915), "Thấp", 13 },
                    { 188, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8916), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8917), "Nhiều", 13 },
                    { 189, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8919), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8920), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8921), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8922), "Ngắn", 13 },
                    { 191, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8924), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8924), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8926), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8926), "Dày", 13 },
                    { 193, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8929), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8929), "Mỏng", 13 },
                    { 194, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8952), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8952), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8954), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8954), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8956), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8958), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8964), "Night", "images/word/time/Night.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8964), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8967), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8967), "Một giờ", 14 },
                    { 199, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8969), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8969), "Mười phút", 14 },
                    { 200, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8971), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8971), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8973), "Today", "images/word/time/Today.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8973), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8975), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8976), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8977), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8978), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8997), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(8998), "Bóng", 15 },
                    { 205, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9000), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9000), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9002), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9002), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9004), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9005), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9006), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9007), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9008), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9009), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9010), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9011), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9013), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9013), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9015), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9015), "Tô màu", 15 },
                    { 213, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9017), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9017), "Bút màu", 15 },
                    { 214, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9019), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9019), "Búp bê", 15 },
                    { 215, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9021), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9021), "Diều", 15 },
                    { 216, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9023), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9023), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9025), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9026), "Tivi", 15 },
                    { 218, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9028), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9029), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9050), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9050), "Máy bay", 16 },
                    { 220, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9052), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9053), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9054), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9055), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9057), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9057), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9059), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9059), "Xe máy", 16 },
                    { 224, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9061), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9061), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9079), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9079), "Ôm", 17 },
                    { 226, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9081), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9081), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9083), "I want", "images/word/want/I want.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9083), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9085), "No", "images/word/want/No.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9086), "Không", 17 },
                    { 229, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9087), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9088), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9089), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9091), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9092), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 1, 10, 14, 36, 31, 866, DateTimeKind.Local).AddTicks(9093), "Có", 17 }
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
