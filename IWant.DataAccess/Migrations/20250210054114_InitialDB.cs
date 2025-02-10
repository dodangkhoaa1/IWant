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
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ChildBirthday", "ChildGender", "ChildName", "ChildNickName", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "Gender", "ImageLocalPath", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(7994), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(7995), "Hành Động" },
                    { 2, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(7998), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(7999), "Động Vật" },
                    { 3, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8001), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8002), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8004), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8005), "Quần Áo" },
                    { 5, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8007), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8007), "Màu Sắc" },
                    { 6, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8009), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8010), "Cảm Xúc" },
                    { 7, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8012), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8013), "Thức Ăn" },
                    { 8, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8015), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8015), "Trái Cây" },
                    { 9, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8018), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8019), "Con Số" },
                    { 10, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8021), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8022), "Con Người" },
                    { 11, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8024), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8024), "Địa Điểm" },
                    { 12, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8027), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8028), "Câu Hỏi" },
                    { 13, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8030), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8030), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8033), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8033), "Thời Gian" },
                    { 15, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8035), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8036), "Đồ Chơi" },
                    { 16, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8038), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8038), "Phương Tiện" },
                    { 17, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8041), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8041), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8082), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8082), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8086), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8086), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8089), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8089), "Đóng", 1 },
                    { 4, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8092), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8093), "Uống", 1 },
                    { 5, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8096), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8097), "Ăn", 1 },
                    { 6, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8099), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8100), "Nhìn", 1 },
                    { 7, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8102), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8102), "Tắt", 1 },
                    { 8, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8105), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8105), "Bật", 1 },
                    { 9, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8109), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8110), "Mở", 1 },
                    { 10, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8112), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8113), "Chơi", 1 },
                    { 11, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8115), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8115), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8118), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8118), "Chạy", 1 },
                    { 13, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8121), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8121), "Ngồi", 1 },
                    { 14, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8124), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8124), "Ngủ", 1 },
                    { 15, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8127), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8127), "Đứng", 1 },
                    { 16, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8130), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8130), "Bơi", 1 },
                    { 17, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8132), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8133), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8135), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8136), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8139), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8140), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8142), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8142), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8145), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8145), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8184), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8184), "Ong", 2 },
                    { 23, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8187), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8188), "Chim", 2 },
                    { 24, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8191), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8191), "Bướm", 2 },
                    { 25, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8193), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8194), "Mèo", 2 },
                    { 26, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8196), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8197), "Gà", 2 },
                    { 27, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8199), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8200), "Bò", 2 },
                    { 28, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8202), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8203), "Chó", 2 },
                    { 29, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8205), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8205), "Vịt", 2 },
                    { 30, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8208), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8208), "Cá", 2 },
                    { 31, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8211), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8211), "Ngựa", 2 },
                    { 32, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8215), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8216), "Chuột", 2 },
                    { 33, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8218), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8219), "Heo", 2 },
                    { 34, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8245), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8246), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8257), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8257), "Lưng", 3 },
                    { 36, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8259), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8260), "Bụng", 3 },
                    { 37, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8262), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8263), "Mông", 3 },
                    { 38, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8265), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8266), "Tai", 3 },
                    { 39, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8268), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8269), "Mắt", 3 },
                    { 40, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8271), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8271), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8274), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8274), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8277), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8277), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8280), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8280), "Tóc", 3 },
                    { 44, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8283), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8284), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8286), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8287), "Chân", 3 },
                    { 46, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8289), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8289), "Môi", 3 },
                    { 47, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8292), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8292), "Mũi", 3 },
                    { 48, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8295), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8295), "Răng", 3 },
                    { 49, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8298), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8298), "Họng", 3 },
                    { 50, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8300), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8301), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8303), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8304), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8334), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8335), "Ba lô", 4 },
                    { 53, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8337), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8338), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8340), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8341), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8343), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8344), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8346), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8347), "Quần dài", 4 },
                    { 57, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8350), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8350), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8353), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8353), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8356), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8356), "Giày", 4 },
                    { 60, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8359), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8359), "Quần short", 4 },
                    { 61, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8362), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8362), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8364), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8365), "Tất", 4 },
                    { 63, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8367), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8368), "Áo len", 4 },
                    { 64, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8370), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8371), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8373), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8374), "Áo phông", 4 },
                    { 66, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8376), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8376), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8407), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8408), "Màu đen", 5 },
                    { 68, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8411), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8411), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8416), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8417), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8420), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8420), "Màu cam", 5 },
                    { 71, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8424), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8425), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8427), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8428), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8430), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8431), "Màu tím", 5 },
                    { 74, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8434), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8434), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8437), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8437), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8459), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8459), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8462), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8463), "Tức giận", 6 },
                    { 78, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8465), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8466), "Chán nản", 6 },
                    { 79, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8468), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8469), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8471), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8472), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8474), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8474), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8478), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8478), "Đói", 6 },
                    { 83, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8481), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8481), "Đau", 6 },
                    { 84, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8483), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8484), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8486), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8487), "Buồn", 6 },
                    { 86, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8489), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8489), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8492), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8492), "Ốm", 6 },
                    { 88, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8495), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8495), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8498), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8498), "Khát", 6 },
                    { 90, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8501), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8501), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8503), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8504), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8508), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8508), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8511), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8511), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8540), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8541), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8544), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8544), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8547), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8548), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8550), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8551), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8553), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8554), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8556), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8557), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8559), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8559), "Kem", 7 },
                    { 101, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8562), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8562), "Nước ép", 7 },
                    { 102, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8565), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8565), "Sữa", 7 },
                    { 103, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8567), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8568), "Pizza", 7 },
                    { 104, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8570), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8571), "Cơm", 7 },
                    { 105, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8574), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8574), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8577), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8577), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8585), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8585), "Súp", 7 },
                    { 108, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8588), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8589), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8591), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8591), "Trà", 7 },
                    { 110, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8594), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8594), "Nước", 7 },
                    { 111, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8597), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8597), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8627), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8628), "Táo", 8 },
                    { 113, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8631), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8631), "Bơ", 8 },
                    { 114, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8633), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8634), "Chuối", 8 },
                    { 115, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8636), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8637), "Thanh long", 8 },
                    { 116, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8639), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8640), "Nho", 8 },
                    { 117, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8642), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8643), "Ổi", 8 },
                    { 118, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8650), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8650), "Kiwi", 8 },
                    { 119, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8653), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8654), "Cam", 8 },
                    { 120, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8656), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8657), "Đào", 8 },
                    { 121, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8659), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8660), "Dứa", 8 },
                    { 122, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8662), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8663), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8666), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8666), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8694), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8694), "Một", 9 },
                    { 125, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8697), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8697), "Hai", 9 },
                    { 126, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8700), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8701), "Ba", 9 },
                    { 127, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8703), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8704), "Bốn", 9 },
                    { 128, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8706), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8707), "Năm", 9 },
                    { 129, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8709), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8710), "Sáu", 9 },
                    { 130, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8712), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8713), "Bảy", 9 },
                    { 131, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8715), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8715), "Tám", 9 },
                    { 132, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8718), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8718), "Chín", 9 },
                    { 133, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8722), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8722), "Mười", 9 },
                    { 134, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8751), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8751), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8754), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8754), "Em bé", 10 },
                    { 136, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8757), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8757), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8759), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8760), "Bố", 10 },
                    { 138, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8762), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8763), "Mọi người", 10 },
                    { 139, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8765), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8766), "Cô bé", 10 },
                    { 140, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8768), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8768), "Bà", 10 },
                    { 141, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8771), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8771), "Ông", 10 },
                    { 142, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8773), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8774), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8776), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8777), "Mẹ", 10 },
                    { 144, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8779), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8780), "Anh trai", 10 },
                    { 145, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8782), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8784), "Chị gái", 10 },
                    { 146, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8786), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8786), "Cái gì", 10 },
                    { 147, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8789), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8789), "Khi nào", 10 },
                    { 148, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8791), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8792), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8794), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8795), "Cái nào", 10 },
                    { 150, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8797), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8798), "Ai", 10 },
                    { 151, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8800), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8800), "Tại sao", 10 },
                    { 152, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8803), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8803), "Em trai", 10 },
                    { 153, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8809), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8810), "Em gái", 10 },
                    { 154, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8813), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8814), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8847), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8848), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8850), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8851), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8854), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8854), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8858), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8858), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8861), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8862), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8865), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8866), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8868), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8868), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8871), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8871), "Công viên", 11 },
                    { 163, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8874), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8874), "Trường học", 11 },
                    { 164, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8876), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8877), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8879), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8880), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8882), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8883), "Sở thú", 11 },
                    { 167, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8917), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8917), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8920), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8920), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8923), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8923), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8927), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8928), "Cái gì", 12 },
                    { 171, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8930), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8930), "Khi nào", 12 },
                    { 172, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8933), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8933), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8936), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8936), "Cái nào", 12 },
                    { 174, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8938), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8939), "Ai", 12 },
                    { 175, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8941), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8942), "Tại sao", 12 },
                    { 176, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8966), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8967), "Ở trên", 13 },
                    { 177, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8971), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8971), "Phía sau", 13 },
                    { 178, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8974), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8974), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8977), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8977), "Ít", 13 },
                    { 180, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8979), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8980), "Nặng", 13 },
                    { 181, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8982), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8983), "Cao", 13 },
                    { 182, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8985), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8986), "Phía trước", 13 },
                    { 183, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8989), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8990), "Ở trong", 13 },
                    { 184, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8992), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8993), "Lớn", 13 },
                    { 185, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8995), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8995), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8998), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(8998), "Dài", 13 },
                    { 187, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9000), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9001), "Thấp", 13 },
                    { 188, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9003), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9004), "Nhiều", 13 },
                    { 189, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9006), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9007), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9009), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9009), "Ngắn", 13 },
                    { 191, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9012), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9012), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9015), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9015), "Dày", 13 },
                    { 193, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9017), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9018), "Mỏng", 13 },
                    { 194, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9046), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9046), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9049), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9049), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9052), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9052), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9055), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9055), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9058), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9058), "Một giờ", 14 },
                    { 199, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9060), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9061), "Mười phút", 14 },
                    { 200, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9064), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9065), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9068), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9069), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9071), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9072), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9074), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9074), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9098), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9098), "Bóng", 15 },
                    { 205, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9101), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9101), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9104), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9104), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9107), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9107), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9110), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9110), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9114), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9114), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9117), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9117), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9119), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9120), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9122), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9123), "Tô màu", 15 },
                    { 213, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9125), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9126), "Bút màu", 15 },
                    { 214, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9128), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9128), "Búp bê", 15 },
                    { 215, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9131), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9131), "Diều", 15 },
                    { 216, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9134), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9134), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9137), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9137), "Tivi", 15 },
                    { 218, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9139), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9140), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9168), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9168), "Máy bay", 16 },
                    { 220, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9171), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9171), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9174), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9174), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9177), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9177), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9179), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9180), "Xe máy", 16 },
                    { 224, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9182), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9183), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9204), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9204), "Ôm", 17 },
                    { 226, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9207), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9207), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9210), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9210), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9213), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9213), "Không", 17 },
                    { 229, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9215), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9216), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9218), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9219), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9221), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 10, 12, 41, 14, 107, DateTimeKind.Local).AddTicks(9222), "Có", 17 }
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
