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
                    ViewCount = table.Column<int>(type: "int", nullable: false),
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
                    WordCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_WordCategories_WordCategoryId",
                        column: x => x.WordCategoryId,
                        principalTable: "WordCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Dot Connection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 2, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Coloring", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 3, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "AAC", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 4, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Emotion Selection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 5, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Fruit Drop", "https://www.youtube.com/watch?v=ynJ_nraLqU4" }
                });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3589), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3589), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3592), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3593), "Hành Động" },
                    { 3, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3595), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3595), "Động Vật" },
                    { 4, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3598), "Body Parts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3598), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3600), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3601), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3603), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3603), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3605), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3606), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3608), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3609), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3611), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3611), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3613), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3613), "Con Số" },
                    { 11, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3615), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3616), "Con Người" },
                    { 12, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3618), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3618), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3620), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3620), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3622), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3623), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3624), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3625), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3627), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3628), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3629), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3630), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3632), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3632), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3674), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3675), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3679), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3679), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3681), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3682), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3684), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3684), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3686), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3686), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3688), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3689), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3691), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3691), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3693), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3693), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3695), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3696), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3698), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3698), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3700), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3700), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3703), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3703), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3705), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3706), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3708), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3708), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3710), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3711), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3712), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3713), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3715), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3715), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3717), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3718), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3720), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3720), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3722), "Go", "images/word/actions/Go.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3723), "Đi", 2 },
                    { 21, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3734), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3734), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3766), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3766), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3768), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3769), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3771), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3771), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3773), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3774), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3776), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3777), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3779), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3779), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3781), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3781), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3784), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3784), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3786), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3787), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3788), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3789), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3792), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3792), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3794), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3794), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3824), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3824), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3826), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3827), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3834), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3835), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3836), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3837), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3839), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3839), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3843), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3844), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3846), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3846), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3848), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3849), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3850), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3851), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3853), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3853), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3855), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3855), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3858), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3859), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3861), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3862), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3864), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3864), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3866), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3867), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3869), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3870), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3872), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3872), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3874), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3875), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3899), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3899), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3901), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3902), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3904), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3904), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3906), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3907), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3908), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3909), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3911), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3911), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3913), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3914), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3915), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3916), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3918), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3918), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3920), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3921), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3922), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3923), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3925), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3925), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3927), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3927), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3929), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3930), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3931), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3932), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3956), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3957), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3960), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3960), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3962), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3962), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3971), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3971), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3974), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3974), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3976), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3976), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3978), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3979), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3980), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3981), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3983), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(3983), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4003), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4003), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4005), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4005), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4007), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4008), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4010), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4010), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4012), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4012), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4015), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4015), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4017), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4018), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4019), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4020), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4022), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4022), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4024), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4026), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4028), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4028), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4030), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4030), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4036), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4036), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4038), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4039), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4040), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4041), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4043), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4043), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4045), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4046), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4047), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4048), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4072), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4072), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4075), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4075), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4077), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4078), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4079), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4080), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4082), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4082), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4084), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4085), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4086), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4087), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4089), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4089), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4091), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4091), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4093), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4094), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4096), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4096), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4098), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4099), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4100), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4101), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4102), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4103), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4105), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4105), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4108), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4108), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4110), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4111), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4112), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4113), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4138), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4139), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4141), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4141), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4143), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4143), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4145), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4146), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4148), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4148), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4150), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4150), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4152), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4153), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4155), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4155), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4157), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4157), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4159), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4160), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4161), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4162), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4164), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4165), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4186), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4186), "Một", 10 },
                    { 125, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4188), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4189), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4191), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4191), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4193), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4193), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4195), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4196), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4197), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4198), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4200), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4200), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4202), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4202), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4204), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4204), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4206), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4207), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4237), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4237), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4239), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4240), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4242), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4242), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4245), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4246), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4248), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4249), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4250), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4251), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4253), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4253), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4255), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4255), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4257), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4258), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4260), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4260), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4262), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4262), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4264), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4265), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4267), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4267), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4269), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4269), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4271), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4271), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4273), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4274), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4276), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4276), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4279), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4279), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4281), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4281), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4283), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4284), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4285), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4286), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4312), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4312), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4314), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4314), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4316), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4317), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4318), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4319), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4320), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4321), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4323), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4323), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4325), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4325), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4327), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4328), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4329), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4330), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4332), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4332), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4335), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4335), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4337), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4338), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4359), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4360), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4361), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4362), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4364), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4364), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4368), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4369), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4370), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4371), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4373), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4373), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4377), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4378), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4380), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4380), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4382), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4382), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4402), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4403), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4405), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4405), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4408), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4408), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4410), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4410), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4412), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4413), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4414), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4415), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4417), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4417), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4419), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4419), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4421), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4422), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4424), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4424), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4426), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4426), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4428), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4429), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4430), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4431), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4433), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4433), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4435), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4436), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4437), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4438), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4450), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4451), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4453), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4454), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4480), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4480), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4482), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4483), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4485), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4485), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4487), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4488), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4489), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4490), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4491), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4492), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4494), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4494), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4496), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4497), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4498), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4499), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4500), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4501), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4521), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4522), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4524), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4524), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4527), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4527), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4529), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4530), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4531), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4532), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4534), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4534), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4536), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4537), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4538), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4539), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4541), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4541), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4543), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4543), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4545), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4546), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4548), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4548), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4550), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4550), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4552), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4552), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4554), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4555), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4582), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4583), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4585), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4585), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4587), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4588), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4592), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4592), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4594), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4595), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4596), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4597), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4617), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4618), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4620), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4620), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4622), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4623), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4624), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4625), "Không", 18 },
                    { 229, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4627), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4627), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4629), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4630), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4632), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 11, 20, 38, 59, 48, DateTimeKind.Local).AddTicks(4632), "Có", 18 }
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
