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
                    { 1, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1523), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1524), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1526), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1527), "Hành Động" },
                    { 3, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1529), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1529), "Động Vật" },
                    { 4, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1531), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1532), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1533), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1534), "Quần Áo" },
                    { 6, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1536), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1537), "Màu Sắc" },
                    { 7, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1538), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1539), "Cảm Xúc" },
                    { 8, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1542), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1543), "Thức Ăn" },
                    { 9, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1544), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1545), "Trái Cây" },
                    { 10, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1547), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1547), "Con Số" },
                    { 11, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1549), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1549), "Con Người" },
                    { 12, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1551), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1551), "Địa Điểm" },
                    { 13, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1553), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1553), "Câu Hỏi" },
                    { 14, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1555), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1556), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1557), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1558), "Thời Gian" },
                    { 16, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1560), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1561), "Đồ Chơi" },
                    { 17, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1562), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1563), "Phương Tiện" },
                    { 18, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1565), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1565), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1601), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1603), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1605), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1606), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1608), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1609), "Đóng", 2 },
                    { 4, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1610), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1611), "Uống", 2 },
                    { 5, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1613), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1613), "Ăn", 2 },
                    { 6, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1615), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1615), "Nhìn", 2 },
                    { 7, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1617), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1618), "Tắt", 2 },
                    { 8, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1630), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1630), "Bật", 2 },
                    { 9, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1632), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1633), "Mở", 2 },
                    { 10, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1635), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1635), "Chơi", 2 },
                    { 11, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1638), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1639), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1641), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1641), "Chạy", 2 },
                    { 13, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1643), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1644), "Ngồi", 2 },
                    { 14, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1645), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1646), "Ngủ", 2 },
                    { 15, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1648), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1648), "Đứng", 2 },
                    { 16, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1650), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1651), "Bơi", 2 },
                    { 17, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1653), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1653), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1655), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1655), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1658), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1658), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1661), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1661), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1663), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1663), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1693), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1694), "Ong", 3 },
                    { 23, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1696), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1696), "Chim", 3 },
                    { 24, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1699), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1699), "Bướm", 3 },
                    { 25, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1701), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1702), "Mèo", 3 },
                    { 26, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1703), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1704), "Gà", 3 },
                    { 27, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1706), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1707), "Bò", 3 },
                    { 28, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1709), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1710), "Chó", 3 },
                    { 29, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1711), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1712), "Vịt", 3 },
                    { 30, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1714), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1714), "Cá", 3 },
                    { 31, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1716), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1716), "Ngựa", 3 },
                    { 32, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1719), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1719), "Chuột", 3 },
                    { 33, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1721), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1721), "Heo", 3 },
                    { 34, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1744), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1745), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1748), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1748), "Lưng", 4 },
                    { 36, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1750), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1751), "Bụng", 4 },
                    { 37, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1753), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1753), "Mông", 4 },
                    { 38, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1755), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1756), "Tai", 4 },
                    { 39, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1757), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1758), "Mắt", 4 },
                    { 40, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1760), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1760), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1762), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1763), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1765), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1765), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1767), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1768), "Tóc", 4 },
                    { 44, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1769), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1770), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1772), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1772), "Chân", 4 },
                    { 46, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1775), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1775), "Môi", 4 },
                    { 47, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1777), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1778), "Mũi", 4 },
                    { 48, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1780), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1780), "Răng", 4 },
                    { 49, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1783), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1783), "Họng", 4 },
                    { 50, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1786), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1786), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1788), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1789), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1811), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1811), "Ba lô", 5 },
                    { 53, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1815), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1815), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1817), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1818), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1820), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1820), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1822), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1822), "Quần dài", 5 },
                    { 57, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1824), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1824), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1826), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1827), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1829), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1829), "Giày", 5 },
                    { 60, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1831), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1832), "Quần short", 5 },
                    { 61, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1834), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1834), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1836), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1836), "Tất", 5 },
                    { 63, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1838), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1838), "Áo len", 5 },
                    { 64, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1840), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1841), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1843), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1843), "Áo phông", 5 },
                    { 66, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1845), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1846), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1877), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1878), "Màu đen", 6 },
                    { 68, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1880), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1880), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1882), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1883), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1885), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1885), "Màu cam", 6 },
                    { 71, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1887), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1887), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1889), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1890), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1892), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1892), "Màu tím", 6 },
                    { 74, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1894), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1895), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1896), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1897), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1916), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1917), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1919), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1919), "Tức giận", 7 },
                    { 78, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1921), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1921), "Chán nản", 7 },
                    { 79, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1923), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1924), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1926), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1926), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1928), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1928), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1930), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1930), "Đói", 7 },
                    { 83, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1933), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1933), "Đau", 7 },
                    { 84, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1935), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1935), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1938), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1939), "Buồn", 7 },
                    { 86, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1941), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1941), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1944), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1945), "Ốm", 7 },
                    { 88, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1946), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1947), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1952), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1953), "Khát", 7 },
                    { 90, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1954), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1955), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1957), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1957), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1959), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1959), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1961), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1961), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1984), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1984), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1986), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1987), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1989), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1989), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1991), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1991), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1993), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1994), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1995), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1996), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1998), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(1999), "Kem", 8 },
                    { 101, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2001), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2001), "Nước ép", 8 },
                    { 102, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2003), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2003), "Sữa", 8 },
                    { 103, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2005), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2005), "Pizza", 8 },
                    { 104, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2007), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2008), "Cơm", 8 },
                    { 105, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2009), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2010), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2012), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2012), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2015), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2015), "Súp", 8 },
                    { 108, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2017), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2018), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2020), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2020), "Trà", 8 },
                    { 110, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2022), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2022), "Nước", 8 },
                    { 111, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2024), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2024), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2046), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2047), "Táo", 9 },
                    { 113, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2049), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2049), "Bơ", 9 },
                    { 114, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2052), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2052), "Chuối", 9 },
                    { 115, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2054), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2054), "Thanh long", 9 },
                    { 116, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2056), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2057), "Nho", 9 },
                    { 117, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2059), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2059), "Ổi", 9 },
                    { 118, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2061), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2061), "Kiwi", 9 },
                    { 119, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2063), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2063), "Cam", 9 },
                    { 120, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2065), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2065), "Đào", 9 },
                    { 121, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2068), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2068), "Dứa", 9 },
                    { 122, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2070), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2071), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2072), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2073), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2092), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2093), "Một", 10 },
                    { 125, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2095), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2095), "Hai", 10 },
                    { 126, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2097), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2097), "Ba", 10 },
                    { 127, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2099), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2100), "Bốn", 10 },
                    { 128, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2102), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2102), "Năm", 10 },
                    { 129, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2104), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2104), "Sáu", 10 },
                    { 130, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2106), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2106), "Bảy", 10 },
                    { 131, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2109), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2109), "Tám", 10 },
                    { 132, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2111), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2111), "Chín", 10 },
                    { 133, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2113), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2113), "Mười", 10 },
                    { 134, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2141), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2142), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2144), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2144), "Em bé", 11 },
                    { 136, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2146), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2146), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2148), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2149), "Bố", 11 },
                    { 138, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2151), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2151), "Mọi người", 11 },
                    { 139, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2153), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2153), "Cô bé", 11 },
                    { 140, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2155), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2155), "Bà", 11 },
                    { 141, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2157), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2158), "Ông", 11 },
                    { 142, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2159), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2160), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2161), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2162), "Mẹ", 11 },
                    { 144, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2164), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2165), "Anh trai", 11 },
                    { 145, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2166), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2167), "Chị gái", 11 },
                    { 146, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2168), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2169), "Cái gì", 11 },
                    { 147, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2171), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2171), "Khi nào", 11 },
                    { 148, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2173), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2173), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2175), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2175), "Cái nào", 11 },
                    { 150, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2177), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2178), "Ai", 11 },
                    { 151, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2180), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2181), "Tại sao", 11 },
                    { 152, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2183), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2183), "Em trai", 11 },
                    { 153, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2185), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2185), "Em gái", 11 },
                    { 154, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2187), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2187), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2211), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2212), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2214), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2214), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2216), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2217), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2218), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2219), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2221), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2221), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2223), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2223), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2225), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2226), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2228), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2228), "Công viên", 12 },
                    { 163, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2231), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2231), "Trường học", 12 },
                    { 164, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2233), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2233), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2235), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2236), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2237), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2238), "Sở thú", 12 },
                    { 167, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2257), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2258), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2260), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2260), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2262), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2262), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2264), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2265), "Cái gì", 13 },
                    { 171, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2267), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2267), "Khi nào", 13 },
                    { 172, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2269), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2269), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2271), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2272), "Cái nào", 13 },
                    { 174, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2274), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2274), "Ai", 13 },
                    { 175, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2276), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2276), "Tại sao", 13 },
                    { 176, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2296), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2296), "Ở trên", 14 },
                    { 177, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2298), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2298), "Phía sau", 14 },
                    { 178, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2300), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2301), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2303), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2303), "Ít", 14 },
                    { 180, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2305), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2305), "Nặng", 14 },
                    { 181, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2307), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2307), "Cao", 14 },
                    { 182, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2309), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2309), "Phía trước", 14 },
                    { 183, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2311), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2312), "Ở trong", 14 },
                    { 184, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2314), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2314), "Lớn", 14 },
                    { 185, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2316), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2316), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2318), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2319), "Dài", 14 },
                    { 187, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2320), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2321), "Thấp", 14 },
                    { 188, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2323), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2324), "Nhiều", 14 },
                    { 189, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2326), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2326), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2328), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2328), "Ngắn", 14 },
                    { 191, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2330), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2330), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2332), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2333), "Dày", 14 },
                    { 193, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2335), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2335), "Mỏng", 14 },
                    { 194, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2357), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2357), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2359), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2360), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2361), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2362), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2364), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2364), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2366), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2366), "Một giờ", 15 },
                    { 199, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2368), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2368), "Mười phút", 15 },
                    { 200, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2370), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2371), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2373), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2374), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2375), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2376), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2378), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2378), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2403), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2403), "Bóng", 16 },
                    { 205, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2406), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2406), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2408), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2408), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2410), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2410), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2412), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2413), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2414), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2415), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2417), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2417), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2419), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2419), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2421), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2422), "Tô màu", 16 },
                    { 213, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2423), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2424), "Bút màu", 16 },
                    { 214, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2426), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2427), "Búp bê", 16 },
                    { 215, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2428), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2429), "Diều", 16 },
                    { 216, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2431), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2431), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2433), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2433), "Tivi", 16 },
                    { 218, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2435), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2435), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2458), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2458), "Máy bay", 17 },
                    { 220, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2460), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2460), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2462), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2462), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2464), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2465), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2467), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2467), "Xe máy", 17 },
                    { 224, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2469), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2469), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2486), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2487), "Ôm", 18 },
                    { 226, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2489), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2490), "Tôi không muốn", 18 },
                    { 227, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2493), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2493), "Tôi muốn", 18 },
                    { 228, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2495), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2495), "Không", 18 },
                    { 229, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2497), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2497), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2499), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2500), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2501), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 18, 10, 55, 47, 696, DateTimeKind.Local).AddTicks(2502), "Có", 18 }
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
