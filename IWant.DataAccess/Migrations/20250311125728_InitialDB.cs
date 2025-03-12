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
                    CitedImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                values: new object[,]
                {
                    { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "bad5ee40-cb79-4c90-b117-e5afb3a8ddf8", null, "ddkhoaa1@gmail.com", true, "Đỗ Đăng Khoa", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "DDKHOAA1@GMAIL.COM", "DDKHOAA1@GMAIL.COM", "AQAAAAIAAYagAAAAEFQdX/kgMdnRNxkiz08sS25fZ8X7nVeW0J1FD+NAct6FHfkleCYGZ3nGLFx08yj9sg==", "0784419071", false, "NL2EDELTGI4XD4IAZJAM2UDPVUDSUZSM", true, false, null, "ddkhoaa1@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Dot Connection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 2, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Coloring", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 3, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "AAC", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 4, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Emotion Selection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 5, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque.", "Fruit Drop", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 6, "Duis arcu risus, mattis sed est ac, molestie malesuada metus. Fusce vel ante nisl. Morbi consequat augue libero. Fusce nisi nisi, lobortis vel pellentesque eu, mattis eget dui. Cras cursus ornare nibh, in varius nibh egestas id. Sed sed massa at mauris aliquam consequat. Praesent porta eu arcu quis scelerisque. (Comming Soon!)", "Tower Build", "https://www.youtube.com/watch?v=ynJ_nraLqU4" }
                });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5392), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5393), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5396), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5396), "Hành Động" },
                    { 3, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5406), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5407), "Động Vật" },
                    { 4, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5409), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5409), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5411), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5412), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5414), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5441), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5443), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5445), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5447), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5447), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5449), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5450), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5451), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5452), "Con Số" },
                    { 11, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5454), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5454), "Con Người" },
                    { 12, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5456), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5456), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5458), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5458), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5460), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5460), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5462), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5463), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5464), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5465), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5467), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5467), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5469), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5469), "Mong Muốn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d19bb620-77b5-414e-865a-1894fbcbb689", "0bcbb4f7-72f9-435f-9cb3-1621b4503974" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5512), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5514), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5517), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5517), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5520), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5520), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5522), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5522), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5524), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5525), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5527), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5527), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5529), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5529), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5531), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5532), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5534), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5534), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5536), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5536), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5538), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5539), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5541), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5541), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5543), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5543), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5545), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5547), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5549), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5549), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5551), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5551), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5553), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5554), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5555), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5556), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5558), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5558), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5560), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5560), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5562), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5563), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5594), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5594), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5596), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5596), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5598), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5599), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5601), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5601), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5603), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5603), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5605), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5606), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5609), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5609), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5611), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5611), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5613), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5613), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5615), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5616), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5617), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5618), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5620), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5620), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5644), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5644), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5646), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5647), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5649), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5649), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5651), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5652), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5654), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5654), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5656), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5656), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5658), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5659), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5660), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5661), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5665), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5666), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5668), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5668), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5670), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5670), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5672), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5673), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5681), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5682), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5683), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5684), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5686), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5686), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5688), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5688), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5690), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5691), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5693), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5693), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5717), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5717), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5719), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5720), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5722), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5722), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5724), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5725), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5728), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5728), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5730), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5730), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5732), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5733), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5734), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5735), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5737), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5737), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5739), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5739), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5741), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5742), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5743), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5744), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5746), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5746), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5748), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5748), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5750), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5751), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5776), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5776), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5778), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5779), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5781), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5781), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5784), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5785), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5787), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5787), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5789), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5790), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5791), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5792), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5794), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5794), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5796), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5796), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5817), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5817), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5819), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5820), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5821), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5822), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5824), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5824), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5826), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5826), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5828), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5829), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5830), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5831), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5833), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5833), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5836), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5836), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5838), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5838), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5840), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5841), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5842), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5843), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5844), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5845), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5847), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5847), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5849), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5849), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5851), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5851), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5853), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5854), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5855), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5856), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5881), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5881), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5883), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5884), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5885), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5886), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5888), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5888), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5891), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5891), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5893), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5893), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5895), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5896), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5898), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5898), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5900), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5900), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5902), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5902), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5904), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5905), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5906), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5907), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5909), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5909), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5919), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5919), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5921), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5921), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5923), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5924), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5925), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5926), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5928), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5928), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5955), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5955), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5957), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5957), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5959), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5960), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5962), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5962), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5964), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5964), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5966), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5967), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5968), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5969), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5971), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5971), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5973), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5973), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5975), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5975), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5977), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5978), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5979), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(5980), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6000), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6000), "Một", 10 },
                    { 125, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6002), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6003), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6005), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6005), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6007), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6007), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6009), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6010), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6012), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6012), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6014), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6014), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6016), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6017), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6018), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6019), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6021), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6021), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6046), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6046), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6048), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6049), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6051), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6051), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6053), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6053), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6055), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6056), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6058), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6059), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6061), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6061), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6063), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6063), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6065), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6066), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6067), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6068), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6071), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6071), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6073), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6073), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6075), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6076), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6078), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6078), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6080), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6080), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6082), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6082), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6084), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6085), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6087), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6087), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6089), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6089), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6091), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6091), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6095), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6095), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6121), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6122), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6124), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6124), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6132), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6133), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6135), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6135), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6137), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6137), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6139), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6139), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6141), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6142), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6143), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6144), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6146), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6146), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6149), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6149), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6151), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6152), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6154), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6154), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6179), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6180), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6182), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6182), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6184), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6185), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6187), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6188), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6190), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6190), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6193), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6193), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6195), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6196), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6198), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6199), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6201), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6201), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6231), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6232), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6235), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6236), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6238), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6238), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6241), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6241), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6243), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6244), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6247), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6247), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6250), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6250), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6252), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6253), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6255), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6255), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6257), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6258), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6260), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6260), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6262), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6263), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6265), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6266), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6268), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6269), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6271), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6271), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6273), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6274), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6276), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6276), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6279), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6279), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6316), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6317), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6319), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6320), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6322), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6323), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6325), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6326), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6328), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6328), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6330), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6331), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6333), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6334), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6336), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6336), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6339), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6339), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6341), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6342), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6370), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6371), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6373), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6374), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6376), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6377), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6379), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6379), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6384), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6385), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6389), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6389), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6392), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6392), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6395), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6395), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6397), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6398), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6400), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6401), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6403), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6403), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6405), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6406), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6408), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6409), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6411), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6411), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6414), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6414), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6449), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6450), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6453), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6453), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6456), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6456), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6461), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6462), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6464), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6464), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6467), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6467), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6498), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6499), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6501), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6502), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6504), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6504), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6506), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6506), "Không", 18 },
                    { 229, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6508), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6509), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6510), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6511), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6513), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 11, 19, 57, 27, 384, DateTimeKind.Local).AddTicks(6513), "Có", 18 }
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
