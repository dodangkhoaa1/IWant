using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InittialDB : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    CitedImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_AspNetUsers_UserId",
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                values: new object[,]
                {
                    { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" },
                    { "15ccf7a4-8f9f-4127-b046-69723542fc06", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhathmce170171@fpt.edu.vn", true, "Nguyễn Huỳnh Như", false, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHMCE170171@FPT.EDU.VN", "NHATHMCE170171@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathmce170171@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "4209a34d-673a-423b-bf3b-f9e180f4a012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ddkhoaa1@gmail.com", true, "Đỗ Đăng Khoa", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "DDKHOAA1@GMAIL.COM", "DDKHOAA1@GMAIL.COM", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "ZBIKDBKDV6SC53SMC5UX6ASTZB3G55FE", true, false, null, "ddkhoaa1@gmail.com" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5019", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "25e504e9-f958-4691-ba6b-c62e080a9dfd", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test@gmail.com", true, "Nguyễn Tester", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "5bbb3f71-c72b-4287-8be3-92f8b84c4caa", true, false, null, "test@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Dot Connection is a fun and addictive puzzle game where you connect dots of the same color to overcome challenges. With relaxing gameplay, a variety of levels, and an intuitive design, it offers a light yet engaging entertainment experience. Conquer the levels and secure your spot on the leaderboard!", "Dot Connection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 2, "Coloring is an engaging and interactive game designed for children, offering a wide selection of drawings, vibrant colors, and user-friendly tools. Perfect for all ages, it provides a relaxing and educational experience that keeps young artists entertained for hours!", "Coloring", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 3, "AAC is an assistive communication app designed for individuals with speech challenges. Through picture cards and easy touch interactions, it enables users to express their thoughts and needs more effortlessly. AAC surely makes communication more intuitive and accessible for all!", "AAC", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 4, "Emotion Selection is a fun and interactive game that teaches children about human emotions through matching gameplay. With a visually appealing design, it challenges players to think fast and act quickly to earn high scores and climb the leaderboard! ", "Emotion Selection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 5, "Fruit Drop is a fun and addictive puzzle game where players merge matching fruits to create bigger ones. With multiple difficulty levels, stunning graphics, and a competitive leaderboard, challenge yourself to score high and stay on top! ", "Fruit Drop", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 6, "Tower Building is a fun and challenging game where you stack blocks to build the tallest tower possible. With simple controls and physics-based mechanics, precision and timing are key to reaching new heights. Stay tuned—the game is launching soon!", "Tower Build", "https://www.youtube.com/watch?v=ynJ_nraLqU4" }
                });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6404), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6405), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6409), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6410), "Hành Động" },
                    { 3, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6412), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6412), "Động Vật" },
                    { 4, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6414), "Body Parts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6415), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6416), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6417), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6419), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6419), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6421), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6421), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6423), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6423), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6425), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6425), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6427), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6427), "Con Số" },
                    { 11, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6429), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6430), "Con Người" },
                    { 12, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6431), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6432), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6433), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6434), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6436), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6436), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6438), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6438), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6440), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6440), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6443), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6443), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6445), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6445), "Mong Muốn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d19bb620-77b5-414e-865a-1894fbcbb689", "0bcbb4f7-72f9-435f-9cb3-1621b4503974" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "15ccf7a4-8f9f-4127-b046-69723542fc06" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5019" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CitedImage", "Content", "CreatedAt", "ImageLocalPath", "ImageUrl", "Status", "Title", "UpdatedAt", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Sưu tầm", "<p style=\"text-align: justify; \"><strong>Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Cha mẹ nào cũng muốn con cái chia sẻ, tâm sự mọi chuyện. Nhưng không phải lúc nào trẻ cũng sẵn sàng mở lòng. Làm sao để con cảm thấy thoải mái khi trò chuyện, tránh xa khoảng cách thế hệ và thực sự kết nối với cha mẹ? Hãy cùng tìm hiểu cách giao tiếp cởi mở với con một cách tự nhiên nhất!</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Vì sao giao tiếp cởi mở với con lại quan trọng?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trẻ nhỏ, đặc biệt là lứa tuổi dậy thì, rất cần một người lắng nghe và thấu hiểu. Khi cha mẹ tạo ra không gian an toàn, trẻ sẽ dễ dàng chia sẻ suy nghĩ, cảm xúc của mình hơn. Điều này không chỉ giúp gắn kết tình cảm gia đình mà còn giúp trẻ tự tin hơn trong cuộc sống.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Một số lợi ích của việc trò chuyện cởi mở với con:</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ cảm thấy được yêu thương và tôn trọng.</li>\r\n                        <li style=\"text-align: justify;\">Giúp cha mẹ hiểu rõ những vấn đề mà con đang gặp phải.</li>\r\n                        <li style=\"text-align: justify;\">Tạo nền tảng cho sự phát triển tâm lý lành mạnh.</li>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ học cách diễn đạt suy nghĩ và cảm xúc một cách rõ ràng.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Cách nói chuyện cởi mở với con</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Chọn thời điểm phù hợp</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Hãy trò chuyện với con vào lúc cả hai đều thoải mái. Đừng ép con nói chuyện khi con đang mệt mỏi, căng thẳng hoặc bị phân tâm bởi điện thoại, TV.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Lắng nghe thay vì phán xét</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nhiều bậc cha mẹ có xu hướng đưa ra lời khuyên hoặc phán xét ngay khi con nói. Tuy nhiên, trẻ cần cảm giác được lắng nghe hơn là bị chỉ trích. Thay vì nói “Con không nên làm vậy!”, hãy thử hỏi “Con nghĩ sao về điều đó?” để khuyến khích con chia sẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Đặt câu hỏi mở</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Tránh những câu hỏi “Có” hoặc “Không” vì chúng dễ làm cuộc trò chuyện đi vào ngõ cụt. Thay vào đó, hãy đặt câu hỏi mở để kích thích con suy nghĩ và diễn đạt nhiều hơn, ví dụ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Hôm nay ở trường có chuyện gì thú vị không?</li>\r\n                        <li style=\"text-align: justify;\">Con cảm thấy thế nào về điều đó?</li>\r\n                        <li style=\"text-align: justify;\">Nếu được làm lại, con sẽ làm khác đi như thế nào?</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Tạo không gian thoải mái</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Không phải lúc nào cũng cần ngồi nghiêm túc để nói chuyện. Những lúc cùng con nấu ăn, đi dạo hay trên đường đi học cũng là cơ hội tốt để bắt đầu cuộc trò chuyện.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Thể hiện sự đồng cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Khi con gặp vấn đề, hãy đặt mình vào vị trí của con. Thay vì nói \"Chuyện này không có gì to tát\", hãy thử nói \"Mẹ hiểu tại sao con cảm thấy như vậy\". Điều này giúp con cảm nhận được sự thấu hiểu từ cha mẹ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Những điều cần tránh khi trò chuyện với con</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Không áp đặt suy nghĩ:</strong> Tránh những câu như “Con phải làm thế này mới đúng!” vì trẻ cần có không gian để tự quyết định.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không so sánh con với người khác:</strong> Câu nói “Sao con không giỏi như bạn A?” chỉ khiến trẻ tự ti và xa cách cha mẹ hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không chỉ trích hoặc quát mắng:</strong> Khi trẻ mắc lỗi, thay vì trách mắng, hãy giúp con hiểu vấn đề và tìm hướng giải quyết.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không đặt câu hỏi quá dồn dập:</strong> Điều này có thể làm con cảm thấy như đang bị tra khảo thay vì được tâm sự.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trò chuyện với con không phải là một nhiệm vụ khó khăn, quan trọng là cha mẹ biết cách lắng nghe, thấu hiểu và tôn trọng con. Khi cha mẹ thực sự quan tâm và đồng hành, con sẽ tự nhiên mở lòng, giúp mối quan hệ gia đình ngày càng gắn kết hơn.</p>", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "blog\\1.svg", "http://localhost:5130/images/blog/1.svg", true, "Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 2, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp</strong></p>\r\n                    <p style=\"text-align: justify;\">Ngày nay, mạng xã hội đã trở thành một phần không thể thiếu trong cuộc sống, đặc biệt là đối với giới trẻ. Tuy nhiên, việc sử dụng mạng xã hội quá mức có thể gây ra nhiều tác động tiêu cực đến tâm lý và sự phát triển của trẻ em, thậm chí làm gia tăng nguy cơ rối loạn tâm trí.</p>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>1. Trẻ em nghiện mạng xã hội: Thực trạng đáng lo ngại</strong></p>\r\n                    <p style=\"text-align: justify;\">Với sự phát triển của công nghệ, trẻ em ngày càng tiếp cận sớm với điện thoại, máy tính bảng và các nền tảng mạng xã hội như Facebook, TikTok, Instagram...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tác hại của việc nghiện mạng xã hội</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn tâm lý:</strong> Việc tiếp xúc với quá nhiều nội dung tiêu cực...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn giấc ngủ:</strong> Trẻ thường xuyên sử dụng điện thoại...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Suy giảm khả năng tập trung:</strong> Sử dụng mạng xã hội quá mức...</li>\r\n                    </ul>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>3. Nguyên nhân khiến trẻ nghiện mạng xã hội</strong></p>\r\n                    <p style=\"text-align: justify;\">Có nhiều yếu tố dẫn đến tình trạng này, bao gồm...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách giúp trẻ sử dụng mạng xã hội một cách lành mạnh</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Đặt giới hạn thời gian sử dụng:</strong> Thiết lập quy tắc rõ ràng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giám sát nội dung trẻ tiếp cận:</strong> Sử dụng các công cụ kiểm soát...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trở thành tấm gương tốt:</strong> Cha mẹ cũng nên hạn chế sử dụng điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Mạng xã hội mang lại nhiều lợi ích nhưng cũng tiềm ẩn nhiều rủi ro...</p>", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "blog\\2.svg", "http://localhost:5130/images/blog/2.svg", true, "Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 3, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC (Augmentative and Alternative Communication) là một hệ thống giao tiếp bổ trợ và thay thế giúp những người gặp khó khăn trong giao tiếp bằng lời nói, đặc biệt là trẻ tự kỷ...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. AAC là gì?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC bao gồm nhiều phương pháp khác nhau nhằm hỗ trợ hoặc thay thế ngôn ngữ nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Vì sao AAC quan trọng đối với trẻ tự kỷ?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp trẻ thể hiện nhu cầu:</strong> Hạn chế căng thẳng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Phát triển kỹ năng giao tiếp:</strong> Hỗ trợ trẻ học cách tương tác...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Các phương pháp AAC phổ biến</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>PECS:</strong> Hệ thống giao tiếp bằng tranh ảnh...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ứng dụng hỗ trợ giao tiếp:</strong> Một số ứng dụng trên điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Khi nào nên áp dụng AAC?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC có thể được áp dụng cho trẻ tự kỷ ngay từ khi phát hiện trẻ có dấu hiệu chậm nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. Lưu ý khi sử dụng AAC</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Chọn phương pháp phù hợp:</strong> Mỗi trẻ có khả năng khác nhau...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và luyện tập:</strong> Cha mẹ và giáo viên cần hướng dẫn...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC là một công cụ hỗ trợ hiệu quả giúp trẻ tự kỷ cải thiện kỹ năng giao tiếp...</p>", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "blog\\3.svg", "http://localhost:5130/images/blog/3.svg", true, "Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 4, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống</strong></p>\r\n                    <p style=\"text-align: justify;\">Tự kỷ không phải là một căn bệnh, mà là một dạng rối loạn phát triển ảnh hưởng đến khả năng giao tiếp...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Dấu hiệu nhận biết trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Hạn chế giao tiếp bằng mắt:</strong> Trẻ ít hoặc không duy trì giao tiếp bằng mắt khi trò chuyện.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không phản ứng khi được gọi tên:</strong> Nhiều trẻ không quay lại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tại sao cần phát hiện và can thiệp sớm?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Cải thiện khả năng ngôn ngữ và giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\">Giảm thiểu các hành vi tiêu cực...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Những phương pháp can thiệp hiệu quả</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp ngôn ngữ:</strong> Giúp trẻ cải thiện khả năng giao tiếp...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp hành vi (ABA):</strong> Dạy trẻ cách phản ứng phù hợp...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Vai trò của gia đình trong việc hỗ trợ trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và thấu hiểu:</strong> Mỗi trẻ tự kỷ đều có thế mạnh riêng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tạo môi trường giao tiếp tích cực:</strong> Thường xuyên trò chuyện...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Trẻ tự kỷ có thể phát triển và hòa nhập xã hội nếu được phát hiện sớm và can thiệp đúng cách...</p>", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "blog\\4.svg", "http://localhost:5130/images/blog/4.svg", true, "Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0 },
                    { 5, "Internet", "<p style=\"text-align: justify; \">Trẻ hiếu động, mất tập trung có phải là do nghịch ngợm hay lười biếng? Nhiều bậc phụ huynh lo lắng khi con mình không thể ngồi yên, dễ bị phân tâm và thường xuyên quên mất việc cần làm. Trên thực tế, đây có thể là dấu hiệu của rối loạn tăng động giảm chú ý (ADHD) – một tình trạng ảnh hưởng đến sự phát triển và khả năng học tập của trẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. ADHD là gì?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD (Attention Deficit Hyperactivity Disorder) là một rối loạn phát triển thần kinh thường gặp ở trẻ em, gây ảnh hưởng đến khả năng tập trung, kiểm soát hành vi và mức độ hiếu động. Đây không phải do trẻ cố tình nghịch ngợm hay thiếu kỷ luật, mà là một tình trạng có liên quan đến hoạt động của não bộ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Dấu hiệu nhận biết ADHD ở trẻ</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Không phải trẻ nào hiếu động, nghịch ngợm cũng mắc ADHD. Tuy nhiên, nếu trẻ có những biểu hiện dưới đây trong thời gian dài và ảnh hưởng đến sinh hoạt hàng ngày, cha mẹ nên lưu ý:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Dễ mất tập trung:</strong> Trẻ khó duy trì sự chú ý, dễ bị phân tâm, thường quên làm bài tập hoặc làm việc mà không hoàn thành.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tăng động:</strong> Trẻ không thể ngồi yên, liên tục di chuyển, leo trèo, chạy nhảy ngay cả khi không phù hợp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Bốc đồng:</strong> Trẻ có thể nói chen ngang, khó chờ đến lượt, thường xuyên hành động mà không suy nghĩ trước.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Nguyên nhân gây ra ADHD</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Hiện nay, các nhà khoa học chưa xác định chính xác nguyên nhân gây ADHD, nhưng có một số yếu tố có thể liên quan đến tình trạng này:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Di truyền:</strong> Nếu cha mẹ hoặc người thân trong gia đình mắc ADHD, nguy cơ trẻ bị rối loạn này cao hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Não bộ phát triển khác biệt:</strong> Một số nghiên cứu chỉ ra rằng vùng não kiểm soát sự tập trung và kiểm soát hành vi ở trẻ ADHD hoạt động khác so với trẻ bình thường.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Yếu tố môi trường:</strong> Trẻ sinh non, thiếu cân hoặc tiếp xúc với chất độc hại như chì trong giai đoạn phát triển có thể tăng nguy cơ mắc ADHD.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. ADHD ảnh hưởng đến trẻ như thế nào?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nếu không được hỗ trợ đúng cách, ADHD có thể gây ra nhiều khó khăn trong cuộc sống hàng ngày của trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Trong học tập:</strong> Trẻ gặp khó khăn trong việc tập trung trên lớp, dễ bỏ lỡ bài giảng, dẫn đến kết quả học tập kém.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trong giao tiếp:</strong> Trẻ có thể bị hiểu lầm là vô ý tứ, thiếu kiên nhẫn, gây khó khăn trong việc kết bạn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trong gia đình:</strong> Cha mẹ thường phải nhắc nhở liên tục, dễ dẫn đến căng thẳng giữa các thành viên.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. ADHD có thể điều trị được không?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD không thể chữa khỏi hoàn toàn, nhưng có thể kiểm soát bằng nhiều phương pháp phù hợp với từng trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp hành vi:</strong> Giúp trẻ học cách kiểm soát cảm xúc, tập trung và làm việc có tổ chức.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Can thiệp giáo dục:</strong> Giáo viên có thể hỗ trợ trẻ bằng cách tạo môi trường học tập phù hợp, giảm yếu tố gây xao nhãng.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Dùng thuốc:</strong> Trong một số trường hợp, bác sĩ có thể kê đơn thuốc giúp kiểm soát các triệu chứng ADHD.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>6. Cha mẹ có thể làm gì để giúp con?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Cha mẹ đóng vai trò quan trọng trong việc hỗ trợ trẻ ADHD. Một số cách giúp con kiểm soát tốt hơn:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Thiết lập thời gian biểu rõ ràng để trẻ dễ dàng theo dõi và thực hiện.</li>\r\n                        <li style=\"text-align: justify;\">Hướng dẫn trẻ hoàn thành công việc từng bước nhỏ thay vì yêu cầu một lúc quá nhiều.</li>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ giải phóng năng lượng bằng cách khuyến khích các hoạt động thể thao, vui chơi ngoài trời.</li>\r\n                        <li style=\"text-align: justify;\">Thường xuyên động viên, khen ngợi những tiến bộ nhỏ để trẻ cảm thấy tự tin.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD không phải là một `căn bệnh`, mà là một đặc điểm của sự phát triển thần kinh. Khi được hướng dẫn và hỗ trợ đúng cách, trẻ ADHD hoàn toàn có thể phát triển bình thường, thậm chí có nhiều thế mạnh riêng. Điều quan trọng nhất là cha mẹ luôn đồng hành, kiên nhẫn và giúp con phát huy tối đa tiềm năng của mình.</p>", new DateTime(2025, 4, 3, 19, 30, 0, 0, DateTimeKind.Unspecified), "blog\\5.svg", "http://localhost:5130/images/blog/5.svg", true, "ADHD Ở Trẻ Em – Hiểu Để Đồng Hành Cùng Con", new DateTime(2025, 4, 3, 19, 30, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 40 },
                    { 6, "Internet", "<p style=\"text-align: justify; \">Trong cuộc sống hiện đại, không khó để bắt gặp hình ảnh trẻ nhỏ chăm chú vào màn hình điện thoại, trong khi cha mẹ tranh thủ làm việc hoặc nghỉ ngơi. Nhiều bậc phụ huynh sử dụng điện thoại như một \"công cụ trấn an\" giúp con ngồi yên, bớt quấy khóc. Tuy nhiên, việc lạm dụng điện thoại có thể để lại những hậu quả nghiêm trọng đối với sự phát triển của trẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Tại sao cha mẹ thường cho con dùng điện thoại?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Có nhiều lý do khiến cha mẹ dễ dàng đưa điện thoại cho con khi con quấy khóc hoặc không chịu ăn:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp con ngồi yên:</strong> Điện thoại có thể khiến trẻ tập trung vào màn hình, giảm thiểu sự hiếu động hoặc mè nheo.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Cha mẹ bận rộn:</strong> Khi có nhiều công việc, phụ huynh thường chọn cách nhanh nhất để giữ con bận rộn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Thói quen phổ biến:</strong> Ngày nay, điện thoại trở thành một phần không thể thiếu trong cuộc sống, nhiều phụ huynh cũng xem đó là chuyện bình thường.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tác hại của việc cho trẻ dùng điện thoại quá sớm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Việc tiếp xúc với màn hình quá nhiều có thể ảnh hưởng tiêu cực đến sự phát triển của trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến sự phát triển não bộ:</strong> Trẻ em dưới 3 tuổi có bộ não đang phát triển mạnh mẽ. Việc tiếp xúc quá nhiều với màn hình có thể làm suy giảm khả năng tập trung, tư duy sáng tạo và kỹ năng giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Gây rối loạn giấc ngủ:</strong> Ánh sáng xanh từ điện thoại có thể ức chế việc sản sinh melatonin, gây khó ngủ và ảnh hưởng đến chất lượng giấc ngủ của trẻ.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giảm tương tác xã hội:</strong> Khi dành quá nhiều thời gian cho điện thoại, trẻ ít giao tiếp với cha mẹ và bạn bè, làm giảm kỹ năng ngôn ngữ và khả năng kết nối cảm xúc.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Gia tăng nguy cơ béo phì:</strong> Ngồi lâu trước màn hình khiến trẻ ít vận động, làm tăng nguy cơ béo phì và các vấn đề sức khỏe khác.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hình thành thói quen xấu:</strong> Nếu trẻ quen với việc chỉ cần khóc là được đưa điện thoại, điều này có thể tạo thành một cơ chế \"phần thưởng sai lệch\", khiến trẻ phụ thuộc vào thiết bị điện tử để giải tỏa cảm xúc.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Khi nào trẻ có thể sử dụng thiết bị điện tử?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Theo khuyến nghị của các chuyên gia:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Trẻ dưới <strong>18 tháng</strong>: Không nên tiếp xúc với màn hình, trừ khi sử dụng để gọi video với người thân.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>18 - 24 tháng</strong>: Có thể tiếp xúc với nội dung chất lượng cao nhưng cần có sự giám sát của cha mẹ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>2 - 5 tuổi</strong>: Hạn chế tối đa thời gian sử dụng, không quá 1 giờ mỗi ngày và nên có sự tham gia của cha mẹ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>6 tuổi trở lên</strong>: Cần xây dựng thói quen sử dụng công nghệ hợp lý, cân bằng giữa thời gian online và các hoạt động khác.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách giúp trẻ tránh phụ thuộc vào điện thoại</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Để giảm thiểu việc trẻ dựa dẫm vào điện thoại, cha mẹ có thể áp dụng những biện pháp sau:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Tạo môi trường giàu hoạt động:</strong> Khuyến khích trẻ chơi các trò chơi sáng tạo, vận động ngoài trời và tham gia các hoạt động nghệ thuật.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Đặt quy tắc sử dụng điện thoại:</strong> Quy định thời gian sử dụng thiết bị và chỉ cho phép trẻ dùng trong những khung giờ nhất định.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Làm gương cho con:</strong> Cha mẹ cũng cần hạn chế sử dụng điện thoại trước mặt con để tạo thói quen tốt.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Khuyến khích trẻ giao tiếp:</strong> Dành nhiều thời gian trò chuyện cùng con, giúp con phát triển kỹ năng giao tiếp và tương tác xã hội.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Điện thoại không xấu, nhưng nếu sử dụng không đúng cách, nó có thể ảnh hưởng tiêu cực đến sự phát triển của trẻ. Cha mẹ cần kiểm soát thời gian và nội dung mà trẻ tiếp xúc, đồng thời tạo ra những hoạt động bổ ích khác để trẻ phát triển một cách toàn diện.</p>", new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "blog\\6.svg", "http://localhost:5130/images/blog/6.svg", true, "Đừng Đưa Điện Thoại Cho Con Chỉ Để Con Ngồi Yên", new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 10 },
                    { 7, "Sưu Tầm", "<p style=\"text-align: justify; \">Trầm cảm ngày càng trở thành một vấn đề đáng lo ngại trên toàn thế giới, trong đó có Việt Nam. Dù không dễ nhận diện ngay từ đầu, nhưng nếu không được phát hiện và điều trị kịp thời, trầm cảm có thể gây ảnh hưởng nghiêm trọng đến sức khỏe tinh thần và chất lượng cuộc sống của người mắc.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Tình trạng trầm cảm tại Việt Nam</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Theo các nghiên cứu gần đây, số người mắc trầm cảm ở Việt Nam có xu hướng gia tăng, đặc biệt trong bối cảnh áp lực cuộc sống ngày càng lớn. Các yếu tố như công việc căng thẳng, áp lực tài chính, vấn đề gia đình hay những biến cố bất ngờ trong cuộc sống đều có thể trở thành nguyên nhân gây ra trầm cảm.</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Đối tượng bị ảnh hưởng:</strong> Trầm cảm không phân biệt độ tuổi hay giới tính, nhưng thường gặp nhất ở thanh thiếu niên, người trưởng thành và người cao tuổi.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Những dấu hiệu thường gặp:</strong> Người mắc trầm cảm có thể cảm thấy buồn bã kéo dài, mất hứng thú với các hoạt động thường ngày, dễ cáu gắt, mất ngủ hoặc ngủ quá nhiều, giảm tập trung và có suy nghĩ tiêu cực.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến xã hội:</strong> Trầm cảm không chỉ tác động đến cá nhân mà còn ảnh hưởng đến gia đình, công việc và các mối quan hệ xã hội.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Nguyên nhân dẫn đến trầm cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm có thể xuất phát từ nhiều yếu tố khác nhau, bao gồm:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Áp lực cuộc sống:</strong> Các vấn đề tài chính, công việc, học tập hay mâu thuẫn gia đình có thể khiến một người rơi vào trạng thái căng thẳng kéo dài.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Mất mát và tổn thương tâm lý:</strong> Việc mất đi người thân, đổ vỡ trong tình cảm hoặc những biến cố lớn trong cuộc sống có thể là nguyên nhân dẫn đến trầm cảm.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Yếu tố sinh học:</strong> Rối loạn về chất dẫn truyền thần kinh trong não bộ có thể ảnh hưởng đến cảm xúc và hành vi, góp phần gây ra trầm cảm.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng từ môi trường:</strong> Việc sống trong môi trường tiêu cực, bị bạo lực gia đình hoặc chịu áp lực xã hội cũng có thể làm gia tăng nguy cơ mắc trầm cảm.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Hậu quả của trầm cảm nếu không được điều trị</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm kéo dài mà không có biện pháp can thiệp có thể gây ra nhiều hệ lụy:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến sức khỏe:</strong> Người mắc trầm cảm có nguy cơ cao bị suy giảm miễn dịch, rối loạn giấc ngủ, mất cảm giác ngon miệng và suy nhược cơ thể.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giảm hiệu suất làm việc và học tập:</strong> Trầm cảm khiến người bệnh mất tập trung, giảm khả năng giải quyết vấn đề và làm việc kém hiệu quả.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tăng nguy cơ tự tử:</strong> Những suy nghĩ tiêu cực kéo dài có thể khiến người bệnh tìm đến những hành động nguy hiểm nếu không được hỗ trợ kịp thời.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Giải pháp hỗ trợ và điều trị trầm cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Việc phát hiện sớm và can thiệp kịp thời là yếu tố quan trọng giúp người mắc trầm cảm hồi phục. Một số biện pháp có thể hỗ trợ điều trị bao gồm:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp tâm lý:</strong> Tư vấn tâm lý và trị liệu giúp người bệnh kiểm soát cảm xúc, giảm căng thẳng và tìm ra giải pháp cho các vấn đề trong cuộc sống.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Điều trị bằng thuốc:</strong> Trong một số trường hợp, bác sĩ có thể chỉ định thuốc chống trầm cảm để điều chỉnh hoạt động của hệ thần kinh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Thay đổi lối sống:</strong> Luyện tập thể dục, duy trì chế độ ăn uống lành mạnh và tham gia các hoạt động tích cực giúp cải thiện tinh thần.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hỗ trợ từ gia đình và bạn bè:</strong> Sự quan tâm và chia sẻ từ những người xung quanh đóng vai trò quan trọng trong quá trình hồi phục của người bệnh.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm không phải là một vấn đề có thể xem nhẹ, nhưng hoàn toàn có thể được điều trị nếu phát hiện kịp thời. Mỗi người cần nâng cao nhận thức về sức khỏe tinh thần, đồng thời chủ động tìm kiếm sự giúp đỡ khi cảm thấy không ổn. Xã hội và gia đình cũng cần đóng vai trò tích cực trong việc hỗ trợ và tạo ra một môi trường sống lành mạnh để giúp người mắc trầm cảm sớm vượt qua khó khăn.</p>", new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), "blog\\7.svg", "http://localhost:5130/images/blog/7.svg", true, "Thực Trạng Trầm Cảm Ở Việt Nam Hiện Nay", new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 14 },
                    { 8, "Internet", "<p style=\"text-align: justify; \">Trẻ em có tốc độ phát triển ngôn ngữ khác nhau, nhưng nếu một đứa trẻ chậm nói hơn nhiều so với bạn bè cùng trang lứa, đó có thể là dấu hiệu của chậm phát triển ngôn ngữ. Việc phát hiện sớm và can thiệp kịp thời đóng vai trò quan trọng trong việc giúp trẻ cải thiện khả năng giao tiếp.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Thế nào là chậm phát triển ngôn ngữ?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Chậm phát triển ngôn ngữ là tình trạng trẻ gặp khó khăn trong việc học và sử dụng ngôn ngữ so với độ tuổi của mình. Điều này có thể biểu hiện qua việc trẻ nói ít từ, phát âm không rõ ràng hoặc không thể diễn đạt ý muốn bằng lời nói.</p>\r\n\r\n                    <p style=\"text-align: justify;\">Trẻ chậm phát triển ngôn ngữ có thể có các biểu hiện như:</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Không bập bẹ hoặc ít phát ra âm thanh khi còn nhỏ.</li>\r\n                        <li style=\"text-align: justify;\">Đến 2 tuổi nhưng vẫn chưa nói được câu có hai từ.</li>\r\n                        <li style=\"text-align: justify;\">Khó hiểu lời nói của người khác hoặc không phản ứng với lời gọi.</li>\r\n                        <li style=\"text-align: justify;\">Gặp khó khăn trong việc kết nối từ để tạo thành câu hoàn chỉnh.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Nguyên nhân khiến trẻ chậm phát triển ngôn ngữ</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Có nhiều yếu tố ảnh hưởng đến sự phát triển ngôn ngữ của trẻ, bao gồm:</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Yếu tố sinh học:</strong> Một số trẻ có vấn đề về thính giác, hệ thần kinh hoặc di truyền có thể ảnh hưởng đến khả năng nói.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Môi trường giao tiếp hạn chế:</strong> Trẻ ít được nói chuyện, đọc sách hoặc tiếp xúc với ngôn ngữ có thể bị chậm phát triển ngôn ngữ.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Vấn đề tâm lý:</strong> Trẻ mắc chứng tự kỷ hoặc rối loạn phát triển cũng có nguy cơ chậm nói.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng từ công nghệ:</strong> Việc trẻ tiếp xúc nhiều với màn hình điện thoại, tivi mà ít tương tác trực tiếp với người xung quanh cũng có thể khiến khả năng ngôn ngữ bị trì trệ.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Khi nào nên đưa trẻ đi khám?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nếu trẻ có những dấu hiệu sau, cha mẹ nên đưa trẻ đến gặp chuyên gia để được đánh giá và tư vấn:</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Trẻ không có phản ứng khi được gọi tên.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ 18 tháng tuổi nhưng chưa nói được từ đơn.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ 2 tuổi nhưng chưa nói được cụm từ hai từ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ không thể giao tiếp bằng lời nói hoặc cử chỉ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ có dấu hiệu mất khả năng ngôn ngữ sau một thời gian phát triển bình thường.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách hỗ trợ trẻ chậm phát triển ngôn ngữ</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Việc can thiệp sớm sẽ giúp trẻ cải thiện khả năng ngôn ngữ và giao tiếp. Một số phương pháp có thể áp dụng bao gồm:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Tăng cường giao tiếp với trẻ:</strong> Nói chuyện với trẻ nhiều hơn, đặt câu hỏi và khuyến khích trẻ diễn đạt suy nghĩ.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Đọc sách cùng trẻ:</strong> Sử dụng tranh ảnh, sách truyện để giúp trẻ tiếp thu từ vựng và cách diễn đạt.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hạn chế thời gian sử dụng thiết bị điện tử:</strong> Thay vào đó, khuyến khích trẻ tham gia các hoạt động vui chơi có tính tương tác.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Áp dụng các bài tập luyện ngôn ngữ:</strong> Chơi trò chơi với âm thanh, tập phát âm từ đơn giản đến phức tạp hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tham khảo ý kiến chuyên gia:</strong> Nếu trẻ có dấu hiệu chậm nói rõ rệt, cần đưa trẻ đến gặp bác sĩ hoặc chuyên gia ngôn ngữ trị liệu để có phương pháp can thiệp phù hợp.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Chậm phát triển ngôn ngữ không phải là vấn đề hiếm gặp, nhưng nếu không được can thiệp sớm, trẻ có thể gặp khó khăn trong học tập và giao tiếp sau này. Cha mẹ cần quan sát, đồng hành và hỗ trợ trẻ trong quá trình phát triển ngôn ngữ để giúp con có một nền tảng vững chắc trong tương lai.</p>", new DateTime(2025, 4, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), "blog\\8.svg", "http://localhost:5130/images/blog/8.svg", true, "Trẻ Chậm Phát Triển Ngôn Ngữ: Nguyên Nhân, Dấu Hiệu Và Cách Hỗ Trợ", new DateTime(2025, 4, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 24 },
                    { 9, "Sưu Tầm", "<p style=\"text-align: justify; \">FPT Cần Thơ là một trong những cơ sở đào tạo uy tín tại khu vực Đồng bằng Sông Cửu Long, cung cấp chương trình giáo dục hiện đại, gắn liền với thực tiễn doanh nghiệp. Trường đào tạo đa dạng các ngành từ công nghệ, kinh tế đến truyền thông, giúp sinh viên phát triển toàn diện và sẵn sàng bước vào thị trường lao động.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Công Nghệ Thông Tin (CNTT)</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Ngành CNTT tại FPT Cần Thơ được thiết kế theo xu hướng công nghệ mới nhất, đảm bảo sinh viên có kiến thức vững vàng và kỹ năng thực hành chuyên sâu. Sinh viên có thể lựa chọn các chuyên ngành sau:</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Kỹ thuật phần mềm:</strong> Tập trung vào phát triển ứng dụng, lập trình phần mềm, xây dựng hệ thống công nghệ.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trí tuệ nhân tạo (AI):</strong> Nghiên cứu về máy học, dữ liệu lớn và các ứng dụng thông minh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>An toàn thông tin:</strong> Đào tạo về bảo mật mạng, phòng chống tấn công mạng và an ninh dữ liệu.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Quản Trị Kinh Doanh</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Ngành Quản trị kinh doanh trang bị cho sinh viên kiến thức về quản lý, tài chính, chiến lược kinh doanh và khởi nghiệp. Một số chuyên ngành tiêu biểu:</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Quản trị doanh nghiệp:</strong> Học về vận hành, quản lý doanh nghiệp và phát triển kinh doanh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Marketing số:</strong> Tập trung vào tiếp thị trực tuyến, quảng cáo kỹ thuật số và xây dựng thương hiệu.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Quản trị chuỗi cung ứng:</strong> Phát triển kỹ năng về logistics, quản lý kho vận và vận hành chuỗi cung ứng.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Truyền Thông Đa Phương Tiện</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Đây là ngành học kết hợp giữa công nghệ, sáng tạo và truyền thông. Sinh viên được học về thiết kế đồ họa, sản xuất nội dung số, dựng phim và marketing truyền thông.</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Thiết kế đồ họa:</strong> Chuyên sâu về thiết kế nhận diện thương hiệu, sáng tạo nội dung trực quan.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Quay dựng video:</strong> Học về sản xuất video, dựng phim và sáng tạo nội dung truyền thông.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Quảng cáo &amp; truyền thông số:</strong> Kết hợp công nghệ và sáng tạo trong chiến lược truyền thông.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Ngôn Ngữ Anh</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Chương trình Ngôn ngữ Anh tại FPT Cần Thơ không chỉ giúp sinh viên thành thạo tiếng Anh mà còn trang bị kỹ năng làm việc trong môi trường quốc tế.</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Tiếng Anh thương mại:</strong> Ứng dụng tiếng Anh trong lĩnh vực kinh doanh, đàm phán và giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tiếng Anh giảng dạy:</strong> Đào tạo kỹ năng giảng dạy tiếng Anh và phương pháp truyền đạt hiệu quả.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. Thiết Kế Mỹ Thuật Số</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Ngành học dành cho những ai đam mê sáng tạo, kết hợp nghệ thuật và công nghệ trong thiết kế đa phương tiện.</p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Thiết kế đồ họa:</strong> Học về UI/UX, sáng tạo hình ảnh và truyền thông thị giác.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hoạt hình kỹ thuật số:</strong> Sản xuất phim hoạt hình, mô hình 3D và hiệu ứng kỹ thuật số.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">FPT Cần Thơ mang đến chương trình đào tạo chất lượng cao, giúp sinh viên có được nền tảng kiến thức vững chắc và kỹ năng thực hành chuyên sâu. Với sự kết hợp giữa lý thuyết và thực tế, sinh viên sẽ có nhiều cơ hội nghề nghiệp rộng mở ngay sau khi tốt nghiệp.</p>", new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "blog\\9.svg", "http://localhost:5130/images/blog/9.svg", true, "Các Ngành Đào Tạo Tại FPT Cần Thơ – Cơ Hội Học Tập Và Phát Triển Nghề Nghiệp", new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 10 },
                    { 10, "Sưu Tầm", "<p style=\"text-align: justify; \">Giao tiếp là một phần quan trọng trong cuộc sống, nhưng không phải ai cũng có thể diễn đạt ý muốn bằng lời nói. Đối với trẻ tự kỷ và những người gặp khó khăn về ngôn ngữ, phương pháp AAC (Augmentative and Alternative Communication) đã trở thành một công cụ hỗ trợ hiệu quả. Đó chính là lý do vì sao ứng dụng <strong>I Want</strong> ra đời – một ứng dụng kết hợp giữa công nghệ hỗ trợ giao tiếp và trò chơi giáo dục, giúp trẻ vừa học vừa chơi một cách tự nhiên.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. I Want là gì?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>I Want</strong> là một ứng dụng trò chơi được thiết kế đặc biệt dành cho trẻ tự kỷ và những người gặp khó khăn trong giao tiếp. Ứng dụng tích hợp phương pháp AAC giúp trẻ sử dụng hình ảnh và thẻ từ để tạo câu, đồng thời cung cấp nhiều trò chơi hấp dẫn giúp phát triển tư duy và kỹ năng vận động.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Các tính năng nổi bật của I Want</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Hỗ trợ giao tiếp bằng thẻ từ:</strong> Trẻ có thể chọn các từ được hiển thị dưới dạng hình ảnh để ghép thành câu hoàn chỉnh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Chức năng đọc to:</strong> Khi hoàn thành một câu, ứng dụng sẽ đọc to nội dung, giúp trẻ cải thiện khả năng phát âm và giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trò chơi giáo dục:</strong> Bao gồm các trò chơi như kéo thả đồ vật, nối điểm, tô màu, xếp tháp và thả hoa quả, giúp trẻ phát triển tư duy logic và kỹ năng vận động.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giao diện thân thiện:</strong> Thiết kế đơn giản, dễ sử dụng với màu sắc sinh động phù hợp với trẻ nhỏ.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Vì sao I Want đặc biệt?</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Kết hợp giao tiếp và giải trí:</strong> Không chỉ là một công cụ AAC, ứng dụng còn mang đến trải nghiệm học tập thông qua các trò chơi thú vị.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp trẻ tự tin hơn:</strong> Khi có thể diễn đạt suy nghĩ, trẻ sẽ cảm thấy tự tin hơn trong giao tiếp hàng ngày.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Phù hợp với nhiều đối tượng:</strong> Không chỉ dành cho trẻ tự kỷ, ứng dụng còn hữu ích cho những người gặp khó khăn trong ngôn ngữ do các vấn đề về phát triển.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Công nghệ sử dụng trong I Want</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Ứng dụng được phát triển dựa trên các công nghệ tiên tiến:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>ASP .NET Core (.NET 8):</strong> Hỗ trợ xây dựng API mạnh mẽ, đảm bảo hiệu suất và bảo mật cao.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Unity:</strong> Công cụ phát triển trò chơi mạnh mẽ giúp tạo ra trải nghiệm sinh động và hấp dẫn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>SQL Server 2022:</strong> Quản lý dữ liệu người dùng, đảm bảo tính ổn định và bảo mật.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. Ai có thể sử dụng I Want?</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Trẻ tự kỷ và trẻ gặp khó khăn về ngôn ngữ:</strong> Ứng dụng giúp trẻ học cách giao tiếp thông qua hình ảnh và âm thanh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Phụ huynh:</strong> Công cụ hỗ trợ cha mẹ trong việc giúp con phát triển kỹ năng giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giáo viên và chuyên gia trị liệu:</strong> Có thể sử dụng ứng dụng như một công cụ bổ trợ trong quá trình giảng dạy và trị liệu.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>I Want</strong> không chỉ là một ứng dụng giải trí mà còn là một công cụ hỗ trợ giáo dục và giao tiếp hiệu quả cho trẻ tự kỷ. Với sự kết hợp giữa phương pháp AAC và các trò chơi tương tác, ứng dụng này mang đến cho trẻ một cách học tập mới mẻ, giúp trẻ phát triển kỹ năng ngôn ngữ một cách tự nhiên và thú vị.</p>", new DateTime(2025, 5, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), "blog\\10.png", "http://localhost:5130/images/blog/10.png", true, "I Want – Ứng Dụng Hỗ Trợ Giao Tiếp Cho Trẻ Tự Kỷ Thông Qua AAC", new DateTime(2025, 5, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 17 }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6481), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6481), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6484), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6484), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6486), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6487), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6489), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6489), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6491), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6491), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6493), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6494), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6496), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6496), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6498), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6498), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6500), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6501), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6502), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6503), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6505), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6505), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6507), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6507), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6510), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6511), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6513), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6513), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6515), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6516), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6518), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6518), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6520), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6520), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6522), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6522), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6524), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6525), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6526), "Go", "images/word/actions/Go.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6527), "Đi", 2 },
                    { 21, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6529), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6529), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6559), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6560), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6562), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6562), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6564), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6564), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6566), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6567), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6568), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6569), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6571), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6572), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6574), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6574), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6576), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6576), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6578), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6579), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6580), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6581), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6583), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6583), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6585), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6585), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6607), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6608), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6610), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6610), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6612), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6613), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6622), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6622), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6624), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6625), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6626), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6627), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6629), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6629), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6632), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6632), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6634), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6634), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6636), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6637), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6638), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6639), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6641), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6641), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6643), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6643), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6645), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6645), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6647), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6648), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6649), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6650), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6652), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6652), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6654), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6654), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6678), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6679), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6680), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6681), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6683), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6683), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6685), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6685), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6687), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6688), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6689), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6690), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6691), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6692), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6694), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6694), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6696), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6696), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6698), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6698), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6700), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6701), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6702), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6703), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6705), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6705), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6707), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6707), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6709), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6709), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6732), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6732), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6734), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6735), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6737), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6737), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6739), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6739), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6741), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6742), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6743), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6744), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6745), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6746), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6748), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6748), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6750), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6750), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6769), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6769), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6771), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6772), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6774), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6774), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6776), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6776), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6778), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6778), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6780), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6781), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6785), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6786), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6787), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6788), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6790), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6790), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6792), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6792), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6794), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6794), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6796), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6797), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6798), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6799), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6801), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6801), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6803), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6803), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6805), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6806), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6807), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6808), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6810), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6810), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6833), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6834), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6836), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6836), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6967), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6968), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6970), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6970), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6978), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6978), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6980), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6980), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6982), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6983), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6985), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6985), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6987), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6987), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6989), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6990), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6992), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6992), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6994), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6994), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6996), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6997), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6999), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(6999), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7001), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7001), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7003), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7004), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7006), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7007), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7009), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7009), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7033), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7034), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7036), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7036), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7038), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7039), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7040), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7041), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7043), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7043), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7045), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7045), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7047), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7047), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7049), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7050), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7051), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7052), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7054), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7054), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7056), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7056), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7058), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7058), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7078), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7079), "Một", 10 },
                    { 125, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7080), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7081), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7083), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7083), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7085), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7086), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7087), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7088), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7090), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7090), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7093), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7093), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7095), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7095), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7097), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7097), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7099), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7100), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7121), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7121), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7123), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7124), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7125), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7126), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7128), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7128), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7131), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7131), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7133), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7133), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7135), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7136), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7137), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7138), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7140), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7140), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7142), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7142), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7144), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7144), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7146), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7147), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7148), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7149), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7150), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7151), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7153), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7153), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7155), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7155), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7157), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7157), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7167), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7167), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7170), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7170), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7172), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7173), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7174), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7175), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7200), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7200), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7202), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7203), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7204), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7205), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7208), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7208), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7210), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7210), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7212), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7212), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7214), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7215), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7216), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7217), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7219), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7219), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7221), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7221), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7223), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7223), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7226), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7226), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7248), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7248), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7250), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7250), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7252), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7253), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7254), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7255), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7257), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7257), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7259), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7259), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7261), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7261), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7263), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7264), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7266), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7266), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7287), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7287), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7289), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7290), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7291), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7292), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7293), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7295), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7297), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7297), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7299), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7299), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7301), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7301), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7303), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7304), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7305), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7306), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7308), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7308), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7310), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7310), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7312), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7312), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7314), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7314), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7316), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7317), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7318), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7319), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7321), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7321), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7323), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7323), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7325), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7325), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7350), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7350), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7352), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7353), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7355), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7355), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7357), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7357), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7359), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7359), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7361), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7362), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7363), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7364), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7366), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7366), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7368), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7368), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7370), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7370), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7390), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7390), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7392), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7393), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7394), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7395), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7397), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7397), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7399), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7399), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7401), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7402), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7403), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7404), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7406), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7406), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7408), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7409), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7410), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7411), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7413), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7413), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7415), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7415), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7417), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7418), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7419), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7420), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7422), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7422), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7451), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7452), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7454), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7454), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7456), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7456), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7458), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7459), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7460), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7461), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7463), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7463), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7480), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7480), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7482), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7483), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7484), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7485), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7487), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7487), "Không", 18 },
                    { 229, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7489), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7489), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7491), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7492), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7493), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 18, 21, 51, 34, 925, DateTimeKind.Local).AddTicks(7494), "Có", 18 }
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
