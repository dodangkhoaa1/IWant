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
                    { 1, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8528), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8529), "Hành Động" },
                    { 2, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8531), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8532), "Động Vật" },
                    { 3, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8534), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8534), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8536), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8536), "Quần Áo" },
                    { 5, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8538), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8539), "Màu Sắc" },
                    { 6, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8541), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8541), "Cảm Xúc" },
                    { 7, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8543), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8543), "Thức Ăn" },
                    { 8, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8545), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8546), "Trái Cây" },
                    { 9, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8547), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8548), "Con Số" },
                    { 10, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8549), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8550), "Con Người" },
                    { 11, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8551), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8552), "Địa Điểm" },
                    { 12, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8554), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8554), "Câu Hỏi" },
                    { 13, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8556), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8556), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8558), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8559), "Thời Gian" },
                    { 15, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8560), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8561), "Đồ Chơi" },
                    { 16, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8563), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8563), "Phương Tiện" },
                    { 17, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8565), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8565), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8603), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8604), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8606), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8607), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8609), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8609), "Đóng", 1 },
                    { 4, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8611), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8611), "Uống", 1 },
                    { 5, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8613), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8613), "Ăn", 1 },
                    { 6, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8615), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8616), "Nhìn", 1 },
                    { 7, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8618), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8618), "Tắt", 1 },
                    { 8, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8620), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8620), "Bật", 1 },
                    { 9, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8622), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8622), "Mở", 1 },
                    { 10, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8624), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8625), "Chơi", 1 },
                    { 11, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8627), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8627), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8630), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8630), "Chạy", 1 },
                    { 13, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8632), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8632), "Ngồi", 1 },
                    { 14, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8634), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8635), "Ngủ", 1 },
                    { 15, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8636), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8637), "Đứng", 1 },
                    { 16, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8639), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8639), "Bơi", 1 },
                    { 17, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8641), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8641), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8643), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8643), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8645), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8645), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8647), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8648), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8649), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8650), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8687), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8688), "Ong", 2 },
                    { 23, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8690), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8690), "Chim", 2 },
                    { 24, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8695), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8695), "Bướm", 2 },
                    { 25, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8697), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8697), "Mèo", 2 },
                    { 26, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8699), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8700), "Gà", 2 },
                    { 27, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8701), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8702), "Bò", 2 },
                    { 28, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8703), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8704), "Chó", 2 },
                    { 29, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8706), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8706), "Vịt", 2 },
                    { 30, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8708), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8708), "Cá", 2 },
                    { 31, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8710), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8710), "Ngựa", 2 },
                    { 32, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8712), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8712), "Chuột", 2 },
                    { 33, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8714), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8715), "Heo", 2 },
                    { 34, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8738), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8739), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8740), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8741), "Lưng", 3 },
                    { 36, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8742), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8743), "Bụng", 3 },
                    { 37, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8745), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8746), "Mông", 3 },
                    { 38, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8747), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8748), "Tai", 3 },
                    { 39, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8750), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8750), "Mắt", 3 },
                    { 40, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8752), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8752), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8754), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8754), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8756), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8756), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8758), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8759), "Tóc", 3 },
                    { 44, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8760), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8761), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8763), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8763), "Chân", 3 },
                    { 46, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8766), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8767), "Môi", 3 },
                    { 47, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8769), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8769), "Mũi", 3 },
                    { 48, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8771), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8771), "Răng", 3 },
                    { 49, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8774), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8774), "Họng", 3 },
                    { 50, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8776), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8776), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8778), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8779), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8801), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8802), "Ba lô", 4 },
                    { 53, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8804), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8804), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8807), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8807), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8809), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8809), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8811), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8811), "Quần dài", 4 },
                    { 57, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8814), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8814), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8816), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8816), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8818), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8818), "Giày", 4 },
                    { 60, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8822), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8822), "Quần short", 4 },
                    { 61, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8824), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8824), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8826), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8826), "Tất", 4 },
                    { 63, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8829), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8829), "Áo len", 4 },
                    { 64, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8831), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8832), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8833), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8834), "Áo phông", 4 },
                    { 66, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8836), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8836), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8863), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8864), "Màu đen", 5 },
                    { 68, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8866), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8867), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8868), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8869), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8871), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8871), "Màu cam", 5 },
                    { 71, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8873), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8873), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8875), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8875), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8877), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8877), "Màu tím", 5 },
                    { 74, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8879), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8880), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8882), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8883), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8909), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8910), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8912), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8912), "Tức giận", 6 },
                    { 78, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8914), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8914), "Chán nản", 6 },
                    { 79, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8916), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8917), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8919), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8919), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8921), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8922), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8923), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8924), "Đói", 6 },
                    { 83, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8926), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8926), "Đau", 6 },
                    { 84, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8928), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8928), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8930), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8931), "Buồn", 6 },
                    { 86, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8932), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8933), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8935), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8935), "Ốm", 6 },
                    { 88, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8937), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8937), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8939), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8940), "Khát", 6 },
                    { 90, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8942), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8942), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8944), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8944), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8946), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8947), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8949), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8949), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8972), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8973), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8975), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8975), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8977), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8977), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8979), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8979), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8981), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8982), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8983), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8984), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8985), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8987), "Kem", 7 },
                    { 101, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8988), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8989), "Nước ép", 7 },
                    { 102, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8990), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8991), "Sữa", 7 },
                    { 103, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8993), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8993), "Pizza", 7 },
                    { 104, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8995), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8995), "Cơm", 7 },
                    { 105, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8997), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(8998), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9000), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9000), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9002), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9002), "Súp", 7 },
                    { 108, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9004), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9004), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9006), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9007), "Trà", 7 },
                    { 110, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9009), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9009), "Nước", 7 },
                    { 111, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9011), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9011), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9035), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9035), "Táo", 8 },
                    { 113, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9038), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9038), "Bơ", 8 },
                    { 114, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9040), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9040), "Chuối", 8 },
                    { 115, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9042), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9043), "Thanh long", 8 },
                    { 116, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9044), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9045), "Nho", 8 },
                    { 117, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9049), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9049), "Ổi", 8 },
                    { 118, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9051), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9051), "Kiwi", 8 },
                    { 119, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9053), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9053), "Cam", 8 },
                    { 120, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9055), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9056), "Đào", 8 },
                    { 121, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9057), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9058), "Dứa", 8 },
                    { 122, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9059), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9060), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9062), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9062), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9083), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9083), "Một", 9 },
                    { 125, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9085), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9085), "Hai", 9 },
                    { 126, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9088), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9088), "Ba", 9 },
                    { 127, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9090), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9091), "Bốn", 9 },
                    { 128, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9093), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9093), "Năm", 9 },
                    { 129, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9095), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9095), "Sáu", 9 },
                    { 130, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9098), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9098), "Bảy", 9 },
                    { 131, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9100), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9100), "Tám", 9 },
                    { 132, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9102), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9102), "Chín", 9 },
                    { 133, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9104), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9105), "Mười", 9 },
                    { 134, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9126), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9127), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9129), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9129), "Em bé", 10 },
                    { 136, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9137), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9137), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9139), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9139), "Bố", 10 },
                    { 138, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9145), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9145), "Mọi người", 10 },
                    { 139, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9147), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9147), "Cô bé", 10 },
                    { 140, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9149), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9150), "Bà", 10 },
                    { 141, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9152), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9152), "Ông", 10 },
                    { 142, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9153), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9154), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9156), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9156), "Mẹ", 10 },
                    { 144, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9158), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9158), "Anh trai", 10 },
                    { 145, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9160), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9160), "Chị gái", 10 },
                    { 146, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9162), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9162), "Cái gì", 10 },
                    { 147, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9164), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9164), "Khi nào", 10 },
                    { 148, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9166), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9166), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9168), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9169), "Cái nào", 10 },
                    { 150, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9171), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9171), "Ai", 10 },
                    { 151, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9173), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9174), "Tại sao", 10 },
                    { 152, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9176), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9176), "Em trai", 10 },
                    { 153, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9178), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9179), "Em gái", 10 },
                    { 154, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9180), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9181), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9206), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9206), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9208), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9209), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9210), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9211), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9213), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9213), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9215), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9215), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9217), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9217), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9219), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9220), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9221), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9222), "Công viên", 11 },
                    { 163, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9223), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9224), "Trường học", 11 },
                    { 164, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9226), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9227), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9228), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9229), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9231), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9231), "Sở thú", 11 },
                    { 167, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9251), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9252), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9254), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9254), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9256), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9256), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9259), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9260), "Cái gì", 12 },
                    { 171, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9261), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9262), "Khi nào", 12 },
                    { 172, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9264), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9264), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9266), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9266), "Cái nào", 12 },
                    { 174, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9268), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9268), "Ai", 12 },
                    { 175, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9270), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9271), "Tại sao", 12 },
                    { 176, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9290), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9291), "Ở trên", 13 },
                    { 177, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9293), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9293), "Phía sau", 13 },
                    { 178, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9295), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9296), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9298), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9298), "Ít", 13 },
                    { 180, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9300), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9300), "Nặng", 13 },
                    { 181, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9302), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9302), "Cao", 13 },
                    { 182, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9304), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9305), "Phía trước", 13 },
                    { 183, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9306), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9307), "Ở trong", 13 },
                    { 184, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9309), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9309), "Lớn", 13 },
                    { 185, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9311), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9311), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9313), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9313), "Dài", 13 },
                    { 187, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9315), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9315), "Thấp", 13 },
                    { 188, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9317), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9318), "Nhiều", 13 },
                    { 189, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9320), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9320), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9322), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9322), "Ngắn", 13 },
                    { 191, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9324), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9324), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9326), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9326), "Dày", 13 },
                    { 193, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9328), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9329), "Mỏng", 13 },
                    { 194, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9352), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9353), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9354), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9355), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9357), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9357), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9359), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9359), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9361), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9361), "Một giờ", 14 },
                    { 199, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9364), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9364), "Mười phút", 14 },
                    { 200, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9366), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9366), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9368), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9368), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9371), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9371), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9373), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9373), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9393), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9393), "Bóng", 15 },
                    { 205, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9395), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9395), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9397), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9398), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9399), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9400), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9402), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9402), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9404), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9404), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9406), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9406), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9408), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9408), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9410), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9411), "Tô màu", 15 },
                    { 213, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9412), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9413), "Bút màu", 15 },
                    { 214, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9415), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9415), "Búp bê", 15 },
                    { 215, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9417), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9418), "Diều", 15 },
                    { 216, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9419), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9420), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9422), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9422), "Tivi", 15 },
                    { 218, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9430), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9430), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9453), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9453), "Máy bay", 16 },
                    { 220, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9455), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9456), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9458), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9458), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9460), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9460), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9462), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9462), "Xe máy", 16 },
                    { 224, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9464), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9464), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9483), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9484), "Ôm", 17 },
                    { 226, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9486), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9486), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9488), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9489), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9490), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9491), "Không", 17 },
                    { 229, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9493), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9493), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9495), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9495), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9497), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 17, 13, 56, 19, 274, DateTimeKind.Local).AddTicks(9497), "Có", 17 }
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
