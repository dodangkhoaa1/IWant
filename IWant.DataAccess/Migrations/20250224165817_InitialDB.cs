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
                    { 1, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6194), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6194), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6198), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6199), "Hành Động" },
                    { 3, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6201), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6202), "Động Vật" },
                    { 4, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6204), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6205), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6207), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6207), "Quần Áo" },
                    { 6, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6210), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6211), "Màu Sắc" },
                    { 7, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6213), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6213), "Cảm Xúc" },
                    { 8, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6216), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6217), "Thức Ăn" },
                    { 9, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6219), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6219), "Trái Cây" },
                    { 10, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6222), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6222), "Con Số" },
                    { 11, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6224), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6225), "Con Người" },
                    { 12, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6227), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6228), "Địa Điểm" },
                    { 13, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6230), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6231), "Câu Hỏi" },
                    { 14, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6233), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6233), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6236), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6236), "Thời Gian" },
                    { 16, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6238), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6239), "Đồ Chơi" },
                    { 17, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6241), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6241), "Phương Tiện" },
                    { 18, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6243), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6244), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6289), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6291), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6294), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6294), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6297), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6298), "Đóng", 2 },
                    { 4, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6301), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6302), "Uống", 2 },
                    { 5, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6304), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6305), "Ăn", 2 },
                    { 6, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6307), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6307), "Nhìn", 2 },
                    { 7, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6310), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6310), "Tắt", 2 },
                    { 8, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6313), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6313), "Bật", 2 },
                    { 9, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6315), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6316), "Mở", 2 },
                    { 10, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6318), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6319), "Chơi", 2 },
                    { 11, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6321), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6321), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6324), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6324), "Chạy", 2 },
                    { 13, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6327), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6327), "Ngồi", 2 },
                    { 14, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6330), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6330), "Ngủ", 2 },
                    { 15, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6333), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6333), "Đứng", 2 },
                    { 16, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6335), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6336), "Bơi", 2 },
                    { 17, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6339), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6339), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6342), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6342), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6345), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6345), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6347), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6348), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6350), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6351), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6386), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6387), "Ong", 3 },
                    { 23, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6389), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6390), "Chim", 3 },
                    { 24, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6392), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6392), "Bướm", 3 },
                    { 25, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6395), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6395), "Mèo", 3 },
                    { 26, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6398), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6398), "Gà", 3 },
                    { 27, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6401), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6402), "Bò", 3 },
                    { 28, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6404), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6404), "Chó", 3 },
                    { 29, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6407), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6407), "Vịt", 3 },
                    { 30, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6411), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6412), "Cá", 3 },
                    { 31, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6414), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6414), "Ngựa", 3 },
                    { 32, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6416), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6417), "Chuột", 3 },
                    { 33, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6420), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6420), "Heo", 3 },
                    { 34, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6448), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6448), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6451), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6451), "Lưng", 4 },
                    { 36, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6454), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6454), "Bụng", 4 },
                    { 37, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6457), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6458), "Mông", 4 },
                    { 38, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6460), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6461), "Tai", 4 },
                    { 39, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6463), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6464), "Mắt", 4 },
                    { 40, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6466), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6467), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6470), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6470), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6472), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6473), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6475), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6476), "Tóc", 4 },
                    { 44, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6486), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6486), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6489), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6489), "Chân", 4 },
                    { 46, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6491), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6491), "Môi", 4 },
                    { 47, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6494), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6494), "Mũi", 4 },
                    { 48, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6496), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6497), "Răng", 4 },
                    { 49, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6500), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6500), "Họng", 4 },
                    { 50, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6502), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6502), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6505), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6505), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6534), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6535), "Ba lô", 5 },
                    { 53, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6537), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6538), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6540), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6541), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6544), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6544), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6547), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6547), "Quần dài", 5 },
                    { 57, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6549), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6550), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6552), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6553), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6555), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6556), "Giày", 5 },
                    { 60, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6558), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6559), "Quần short", 5 },
                    { 61, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6561), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6562), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6564), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6564), "Tất", 5 },
                    { 63, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6567), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6567), "Áo len", 5 },
                    { 64, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6569), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6570), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6572), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6573), "Áo phông", 5 },
                    { 66, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6575), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6575), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6603), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6604), "Màu đen", 6 },
                    { 68, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6607), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6608), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6610), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6610), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6613), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6613), "Màu cam", 6 },
                    { 71, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6617), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6618), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6620), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6621), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6623), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6624), "Màu tím", 6 },
                    { 74, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6626), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6626), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6629), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6629), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6655), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6655), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6659), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6660), "Tức giận", 7 },
                    { 78, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6662), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6663), "Chán nản", 7 },
                    { 79, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6665), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6666), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6669), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6669), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6671), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6672), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6674), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6674), "Đói", 7 },
                    { 83, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6677), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6677), "Đau", 7 },
                    { 84, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6679), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6680), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6683), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6683), "Buồn", 7 },
                    { 86, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6686), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6686), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6688), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6689), "Ốm", 7 },
                    { 88, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6691), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6692), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6694), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6694), "Khát", 7 },
                    { 90, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6697), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6697), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6699), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6700), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6702), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6703), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6706), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6706), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6734), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6734), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6737), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6737), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6739), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6740), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6742), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6743), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6745), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6745), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6747), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6748), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6750), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6751), "Kem", 8 },
                    { 101, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6753), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6753), "Nước ép", 8 },
                    { 102, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6756), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6756), "Sữa", 8 },
                    { 103, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6758), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6759), "Pizza", 8 },
                    { 104, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6761), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6761), "Cơm", 8 },
                    { 105, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6764), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6764), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6767), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6768), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6771), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6772), "Súp", 8 },
                    { 108, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6774), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6775), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6777), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6777), "Trà", 8 },
                    { 110, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6780), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6780), "Nước", 8 },
                    { 111, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6782), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6783), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6810), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6810), "Táo", 9 },
                    { 113, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6820), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6821), "Bơ", 9 },
                    { 114, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6823), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6824), "Chuối", 9 },
                    { 115, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6826), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6826), "Thanh long", 9 },
                    { 116, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6829), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6829), "Nho", 9 },
                    { 117, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6832), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6832), "Ổi", 9 },
                    { 118, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6834), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6836), "Kiwi", 9 },
                    { 119, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6838), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6839), "Cam", 9 },
                    { 120, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6841), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6841), "Đào", 9 },
                    { 121, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6843), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6844), "Dứa", 9 },
                    { 122, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6846), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6847), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6849), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6849), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6875), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6875), "Một", 10 },
                    { 125, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6878), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6879), "Hai", 10 },
                    { 126, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6881), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6882), "Ba", 10 },
                    { 127, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6884), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6884), "Bốn", 10 },
                    { 128, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6887), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6887), "Năm", 10 },
                    { 129, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6890), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6890), "Sáu", 10 },
                    { 130, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6893), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6893), "Bảy", 10 },
                    { 131, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6896), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6896), "Tám", 10 },
                    { 132, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6898), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6899), "Chín", 10 },
                    { 133, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6901), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6901), "Mười", 10 },
                    { 134, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6927), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6928), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6931), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6931), "Em bé", 11 },
                    { 136, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6933), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6934), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6936), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6936), "Bố", 11 },
                    { 138, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6939), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6939), "Mọi người", 11 },
                    { 139, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6941), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6942), "Cô bé", 11 },
                    { 140, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6944), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6945), "Bà", 11 },
                    { 141, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6947), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6947), "Ông", 11 },
                    { 142, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6950), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6950), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6952), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6953), "Mẹ", 11 },
                    { 144, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6956), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6956), "Anh trai", 11 },
                    { 145, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6958), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6959), "Chị gái", 11 },
                    { 146, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6961), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6962), "Cái gì", 11 },
                    { 147, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6964), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6965), "Khi nào", 11 },
                    { 148, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6967), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6967), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6969), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6970), "Cái nào", 11 },
                    { 150, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6972), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6972), "Ai", 11 },
                    { 151, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6975), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6975), "Tại sao", 11 },
                    { 152, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6978), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6978), "Em trai", 11 },
                    { 153, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6980), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6981), "Em gái", 11 },
                    { 154, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6983), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(6983), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7013), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7013), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7016), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7017), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7019), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7019), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7022), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7022), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7024), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7025), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7027), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7028), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7030), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7031), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7033), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7033), "Công viên", 12 },
                    { 163, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7035), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7036), "Trường học", 12 },
                    { 164, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7038), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7039), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7041), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7042), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7044), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7044), "Sở thú", 12 },
                    { 167, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7068), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7069), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7071), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7072), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7074), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7074), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7077), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7077), "Cái gì", 13 },
                    { 171, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7080), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7080), "Khi nào", 13 },
                    { 172, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7082), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7083), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7095), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7095), "Cái nào", 13 },
                    { 174, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7097), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7098), "Ai", 13 },
                    { 175, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7100), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7101), "Tại sao", 13 },
                    { 176, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7124), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7125), "Ở trên", 14 },
                    { 177, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7127), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7128), "Phía sau", 14 },
                    { 178, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7130), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7130), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7133), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7134), "Ít", 14 },
                    { 180, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7136), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7137), "Nặng", 14 },
                    { 181, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7139), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7140), "Cao", 14 },
                    { 182, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7146), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7147), "Phía trước", 14 },
                    { 183, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7149), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7150), "Ở trong", 14 },
                    { 184, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7152), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7152), "Lớn", 14 },
                    { 185, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7155), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7155), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7157), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7158), "Dài", 14 },
                    { 187, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7160), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7161), "Thấp", 14 },
                    { 188, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7163), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7163), "Nhiều", 14 },
                    { 189, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7166), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7167), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7169), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7169), "Ngắn", 14 },
                    { 191, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7172), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7172), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7174), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7175), "Dày", 14 },
                    { 193, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7177), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7177), "Mỏng", 14 },
                    { 194, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7205), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7206), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7208), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7209), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7211), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7211), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7214), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7214), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7217), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7217), "Một giờ", 15 },
                    { 199, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7219), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7220), "Mười phút", 15 },
                    { 200, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7222), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7223), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7225), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7225), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7227), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7228), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7230), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7231), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7253), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7253), "Bóng", 16 },
                    { 205, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7256), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7256), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7259), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7259), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7264), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7265), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7267), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7267), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7270), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7271), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7273), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7274), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7276), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7277), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7279), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7279), "Tô màu", 16 },
                    { 213, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7281), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7282), "Bút màu", 16 },
                    { 214, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7284), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7285), "Búp bê", 16 },
                    { 215, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7287), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7287), "Diều", 16 },
                    { 216, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7289), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7290), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7292), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7293), "Tivi", 16 },
                    { 218, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7295), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7295), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7321), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7322), "Máy bay", 17 },
                    { 220, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7324), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7325), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7327), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7327), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7330), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7330), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7333), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7333), "Xe máy", 17 },
                    { 224, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7336), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7336), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7359), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7359), "Ôm", 18 },
                    { 226, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7361), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7362), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7364), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7365), "Con muốn", 18 },
                    { 228, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7367), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7368), "Không", 18 },
                    { 229, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7370), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7370), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7372), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7373), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7375), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 24, 23, 58, 16, 425, DateTimeKind.Local).AddTicks(7376), "Có", 18 }
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
