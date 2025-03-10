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
                    { 1, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4735), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4736), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4739), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4740), "Hành Động" },
                    { 3, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4742), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4742), "Động Vật" },
                    { 4, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4744), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4745), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4747), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4747), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4749), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4749), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4751), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4751), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4753), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4754), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4756), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4756), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4758), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4758), "Con Số" },
                    { 11, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4760), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4761), "Con Người" },
                    { 12, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4762), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4763), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4765), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4765), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4767), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4767), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4769), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4769), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4771), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4772), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4774), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4774), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4776), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4777), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4816), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4817), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4820), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4820), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4823), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4823), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4825), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4826), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4828), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4828), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4830), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4831), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4833), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4833), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4835), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4836), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4838), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4838), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4840), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4841), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4842), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4843), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4845), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4845), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4849), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4850), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4852), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4852), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4854), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4854), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4856), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4857), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4858), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4859), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4861), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4861), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4863), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4864), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4866), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4866), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4875), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4875), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4907), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4907), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4909), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4909), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4911), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4912), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4914), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4914), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4916), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4917), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4919), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4920), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4922), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4922), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4924), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4924), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4926), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4927), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4929), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4929), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4931), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4931), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4933), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4934), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4955), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4956), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4958), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4959), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4960), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4961), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4963), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4964), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4965), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4966), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4968), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4968), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4971), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4971), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4973), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4974), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4975), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4976), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4978), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4978), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4980), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4980), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4982), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4983), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4985), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4985), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4987), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4988), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4990), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4990), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4992), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4992), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4994), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4995), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4997), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(4997), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5020), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5021), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5023), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5023), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5026), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5027), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5029), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5029), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5031), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5032), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5034), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5034), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5036), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5037), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5038), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5039), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5041), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5041), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5043), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5043), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5045), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5046), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5048), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5049), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5051), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5051), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5053), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5054), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5056), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5056), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5080), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5080), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5083), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5083), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5086), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5087), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5095), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5095), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5097), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5097), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5100), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5100), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5102), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5102), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5104), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5105), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5107), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5107), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5127), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5127), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5129), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5130), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5131), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5132), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5134), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5134), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5136), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5137), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5138), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5139), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5141), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5141), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5144), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5144), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5146), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5147), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5149), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5149), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5151), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5151), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5153), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5154), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5156), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5156), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5158), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5158), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5160), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5161), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5162), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5163), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5165), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5165), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5167), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5167), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5189), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5190), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5192), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5192), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5194), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5195), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5197), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5197), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5199), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5200), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5202), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5202), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5204), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5204), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5206), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5206), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5208), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5209), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5211), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5211), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5213), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5213), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5215), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5216), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5218), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5218), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5220), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5220), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5222), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5223), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5224), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5225), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5227), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5227), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5230), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5230), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5255), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5256), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5258), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5258), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5261), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5261), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5263), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5264), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5266), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5267), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5268), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5269), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5271), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5271), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5273), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5274), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5275), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5276), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5278), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5278), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5280), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5281), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5282), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5283), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5305), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5306), "Một", 10 },
                    { 125, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5308), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5308), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5310), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5311), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5313), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5313), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5315), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5316), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5318), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5319), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5321), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5321), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5323), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5323), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5325), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5326), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5328), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5328), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5356), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5356), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5358), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5359), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5361), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5361), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5363), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5363), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5366), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5366), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5368), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5369), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5370), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5371), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5373), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5373), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5375), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5375), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5377), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5378), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5380), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5380), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5382), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5382), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5384), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5385), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5387), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5387), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5389), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5389), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5391), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5392), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5393), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5394), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5396), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5396), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5398), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5399), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5401), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5401), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5403), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5404), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5427), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5427), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5429), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5430), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5431), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5432), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5434), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5434), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5436), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5437), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5438), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5439), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5441), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5441), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5443), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5443), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5445), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5446), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5447), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5448), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5450), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5450), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5455), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5456), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5476), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5476), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5478), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5479), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5480), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5481), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5483), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5483), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5485), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5485), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5487), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5488), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5489), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5490), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5492), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5492), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5494), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5494), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5514), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5514), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5516), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5517), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5519), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5519), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5521), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5522), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5524), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5525), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5527), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5527), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5529), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5529), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5531), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5532), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5534), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5534), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5536), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5536), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5538), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5539), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5541), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5541), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5543), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5543), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5545), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5546), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5547), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5548), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5555), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5556), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5558), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5558), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5560), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5560), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5585), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5586), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5588), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5588), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5590), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5590), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5592), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5593), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5594), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5595), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5597), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5597), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5599), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5599), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5601), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5602), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5603), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5604), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5606), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5606), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5625), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5626), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5627), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5628), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5630), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5630), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5632), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5632), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5636), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5636), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5639), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5639), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5641), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5641), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5643), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5644), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5646), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5646), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5648), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5648), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5651), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5651), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5653), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5653), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5655), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5656), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5658), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5658), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5660), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5660), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5682), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5683), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5684), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5685), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5687), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5690), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5692), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5692), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5694), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5694), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5696), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5697), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5715), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5715), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5717), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5718), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5720), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5720), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5722), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5723), "Không", 18 },
                    { 229, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5725), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5726), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5727), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5728), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5730), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 10, 16, 35, 59, 127, DateTimeKind.Local).AddTicks(5730), "Có", 18 }
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
