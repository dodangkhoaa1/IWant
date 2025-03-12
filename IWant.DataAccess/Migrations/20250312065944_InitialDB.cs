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
                    { "15ccf7a4-8f9f-4127-b046-69723542fc06", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathmce170171@fpt.edu.vn", true, "Nguyễn Huỳnh Như", false, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHMCE170171@FPT.EDU.VN", "NHATHMCE170171@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathmce170171@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "4209a34d-673a-423b-bf3b-f9e180f4a012", null, "ddkhoaa1@gmail.com", true, "Đỗ Đăng Khoa", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "DDKHOAA1@GMAIL.COM", "DDKHOAA1@GMAIL.COM", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "ZBIKDBKDV6SC53SMC5UX6ASTZB3G55FE", true, false, null, "ddkhoaa1@gmail.com" }
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
                    { 1, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(160), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(160), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(162), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(163), "Hành Động" },
                    { 3, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(165), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(165), "Động Vật" },
                    { 4, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(167), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(167), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(169), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(170), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(171), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(172), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(173), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(174), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(176), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(176), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(178), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(178), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(180), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(180), "Con Số" },
                    { 11, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(182), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(182), "Con Người" },
                    { 12, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(184), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(185), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(186), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(187), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(189), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(189), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(191), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(191), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(193), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(193), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(195), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(195), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(199), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(199), "Mong Muốn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d19bb620-77b5-414e-865a-1894fbcbb689", "0bcbb4f7-72f9-435f-9cb3-1621b4503974" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "15ccf7a4-8f9f-4127-b046-69723542fc06" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CitedImage", "Content", "CreatedAt", "ImageLocalPath", "ImageUrl", "Status", "Title", "UpdatedAt", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Sưu tầm", "<p style=\"text-align: justify; \"><strong>Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Cha mẹ nào cũng muốn con cái chia sẻ, tâm sự mọi chuyện. Nhưng không phải lúc nào trẻ cũng sẵn sàng mở lòng. Làm sao để con cảm thấy thoải mái khi trò chuyện, tránh xa khoảng cách thế hệ và thực sự kết nối với cha mẹ? Hãy cùng tìm hiểu cách giao tiếp cởi mở với con một cách tự nhiên nhất!</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Vì sao giao tiếp cởi mở với con lại quan trọng?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trẻ nhỏ, đặc biệt là lứa tuổi dậy thì, rất cần một người lắng nghe và thấu hiểu. Khi cha mẹ tạo ra không gian an toàn, trẻ sẽ dễ dàng chia sẻ suy nghĩ, cảm xúc của mình hơn. Điều này không chỉ giúp gắn kết tình cảm gia đình mà còn giúp trẻ tự tin hơn trong cuộc sống.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Một số lợi ích của việc trò chuyện cởi mở với con:</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ cảm thấy được yêu thương và tôn trọng.</li>\r\n                        <li style=\"text-align: justify;\">Giúp cha mẹ hiểu rõ những vấn đề mà con đang gặp phải.</li>\r\n                        <li style=\"text-align: justify;\">Tạo nền tảng cho sự phát triển tâm lý lành mạnh.</li>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ học cách diễn đạt suy nghĩ và cảm xúc một cách rõ ràng.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Cách nói chuyện cởi mở với con</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Chọn thời điểm phù hợp</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Hãy trò chuyện với con vào lúc cả hai đều thoải mái. Đừng ép con nói chuyện khi con đang mệt mỏi, căng thẳng hoặc bị phân tâm bởi điện thoại, TV.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Lắng nghe thay vì phán xét</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nhiều bậc cha mẹ có xu hướng đưa ra lời khuyên hoặc phán xét ngay khi con nói. Tuy nhiên, trẻ cần cảm giác được lắng nghe hơn là bị chỉ trích. Thay vì nói “Con không nên làm vậy!”, hãy thử hỏi “Con nghĩ sao về điều đó?” để khuyến khích con chia sẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Đặt câu hỏi mở</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Tránh những câu hỏi “Có” hoặc “Không” vì chúng dễ làm cuộc trò chuyện đi vào ngõ cụt. Thay vào đó, hãy đặt câu hỏi mở để kích thích con suy nghĩ và diễn đạt nhiều hơn, ví dụ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Hôm nay ở trường có chuyện gì thú vị không?</li>\r\n                        <li style=\"text-align: justify;\">Con cảm thấy thế nào về điều đó?</li>\r\n                        <li style=\"text-align: justify;\">Nếu được làm lại, con sẽ làm khác đi như thế nào?</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Tạo không gian thoải mái</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Không phải lúc nào cũng cần ngồi nghiêm túc để nói chuyện. Những lúc cùng con nấu ăn, đi dạo hay trên đường đi học cũng là cơ hội tốt để bắt đầu cuộc trò chuyện.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Thể hiện sự đồng cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Khi con gặp vấn đề, hãy đặt mình vào vị trí của con. Thay vì nói \"Chuyện này không có gì to tát\", hãy thử nói \"Mẹ hiểu tại sao con cảm thấy như vậy\". Điều này giúp con cảm nhận được sự thấu hiểu từ cha mẹ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Những điều cần tránh khi trò chuyện với con</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Không áp đặt suy nghĩ:</strong> Tránh những câu như “Con phải làm thế này mới đúng!” vì trẻ cần có không gian để tự quyết định.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không so sánh con với người khác:</strong> Câu nói “Sao con không giỏi như bạn A?” chỉ khiến trẻ tự ti và xa cách cha mẹ hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không chỉ trích hoặc quát mắng:</strong> Khi trẻ mắc lỗi, thay vì trách mắng, hãy giúp con hiểu vấn đề và tìm hướng giải quyết.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không đặt câu hỏi quá dồn dập:</strong> Điều này có thể làm con cảm thấy như đang bị tra khảo thay vì được tâm sự.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trò chuyện với con không phải là một nhiệm vụ khó khăn, quan trọng là cha mẹ biết cách lắng nghe, thấu hiểu và tôn trọng con. Khi cha mẹ thực sự quan tâm và đồng hành, con sẽ tự nhiên mở lòng, giúp mối quan hệ gia đình ngày càng gắn kết hơn.</p>", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "blog\\1.svg", "http://localhost:5130/images/blog/1.svg", true, "Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 2, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp</strong></p>\r\n                    <p style=\"text-align: justify;\">Ngày nay, mạng xã hội đã trở thành một phần không thể thiếu trong cuộc sống, đặc biệt là đối với giới trẻ. Tuy nhiên, việc sử dụng mạng xã hội quá mức có thể gây ra nhiều tác động tiêu cực đến tâm lý và sự phát triển của trẻ em, thậm chí làm gia tăng nguy cơ rối loạn tâm trí.</p>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>1. Trẻ em nghiện mạng xã hội: Thực trạng đáng lo ngại</strong></p>\r\n                    <p style=\"text-align: justify;\">Với sự phát triển của công nghệ, trẻ em ngày càng tiếp cận sớm với điện thoại, máy tính bảng và các nền tảng mạng xã hội như Facebook, TikTok, Instagram...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tác hại của việc nghiện mạng xã hội</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn tâm lý:</strong> Việc tiếp xúc với quá nhiều nội dung tiêu cực...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn giấc ngủ:</strong> Trẻ thường xuyên sử dụng điện thoại...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Suy giảm khả năng tập trung:</strong> Sử dụng mạng xã hội quá mức...</li>\r\n                    </ul>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>3. Nguyên nhân khiến trẻ nghiện mạng xã hội</strong></p>\r\n                    <p style=\"text-align: justify;\">Có nhiều yếu tố dẫn đến tình trạng này, bao gồm...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách giúp trẻ sử dụng mạng xã hội một cách lành mạnh</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Đặt giới hạn thời gian sử dụng:</strong> Thiết lập quy tắc rõ ràng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giám sát nội dung trẻ tiếp cận:</strong> Sử dụng các công cụ kiểm soát...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trở thành tấm gương tốt:</strong> Cha mẹ cũng nên hạn chế sử dụng điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Mạng xã hội mang lại nhiều lợi ích nhưng cũng tiềm ẩn nhiều rủi ro...</p>", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "blog\\2.svg", "http://localhost:5130/images/blog/2.svg", true, "Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 3, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC (Augmentative and Alternative Communication) là một hệ thống giao tiếp bổ trợ và thay thế giúp những người gặp khó khăn trong giao tiếp bằng lời nói, đặc biệt là trẻ tự kỷ...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. AAC là gì?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC bao gồm nhiều phương pháp khác nhau nhằm hỗ trợ hoặc thay thế ngôn ngữ nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Vì sao AAC quan trọng đối với trẻ tự kỷ?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp trẻ thể hiện nhu cầu:</strong> Hạn chế căng thẳng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Phát triển kỹ năng giao tiếp:</strong> Hỗ trợ trẻ học cách tương tác...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Các phương pháp AAC phổ biến</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>PECS:</strong> Hệ thống giao tiếp bằng tranh ảnh...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ứng dụng hỗ trợ giao tiếp:</strong> Một số ứng dụng trên điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Khi nào nên áp dụng AAC?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC có thể được áp dụng cho trẻ tự kỷ ngay từ khi phát hiện trẻ có dấu hiệu chậm nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. Lưu ý khi sử dụng AAC</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Chọn phương pháp phù hợp:</strong> Mỗi trẻ có khả năng khác nhau...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và luyện tập:</strong> Cha mẹ và giáo viên cần hướng dẫn...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC là một công cụ hỗ trợ hiệu quả giúp trẻ tự kỷ cải thiện kỹ năng giao tiếp...</p>", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "blog\\3.svg", "http://localhost:5130/images/blog/3.svg", true, "Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 4, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống</strong></p>\r\n                    <p style=\"text-align: justify;\">Tự kỷ không phải là một căn bệnh, mà là một dạng rối loạn phát triển ảnh hưởng đến khả năng giao tiếp...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Dấu hiệu nhận biết trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Hạn chế giao tiếp bằng mắt:</strong> Trẻ ít hoặc không duy trì giao tiếp bằng mắt khi trò chuyện.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không phản ứng khi được gọi tên:</strong> Nhiều trẻ không quay lại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tại sao cần phát hiện và can thiệp sớm?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Cải thiện khả năng ngôn ngữ và giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\">Giảm thiểu các hành vi tiêu cực...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Những phương pháp can thiệp hiệu quả</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp ngôn ngữ:</strong> Giúp trẻ cải thiện khả năng giao tiếp...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp hành vi (ABA):</strong> Dạy trẻ cách phản ứng phù hợp...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Vai trò của gia đình trong việc hỗ trợ trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và thấu hiểu:</strong> Mỗi trẻ tự kỷ đều có thế mạnh riêng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tạo môi trường giao tiếp tích cực:</strong> Thường xuyên trò chuyện...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Trẻ tự kỷ có thể phát triển và hòa nhập xã hội nếu được phát hiện sớm và can thiệp đúng cách...</p>", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "blog\\4.svg", "http://localhost:5130/images/blog/4.svg", true, "Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0 }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(233), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(233), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(236), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(236), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(238), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(238), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(240), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(240), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(242), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(243), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(244), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(245), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(246), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(247), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(249), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(249), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(251), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(251), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(253), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(253), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(255), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(255), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(257), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(257), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(259), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(259), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(262), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(262), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(264), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(264), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(266), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(267), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(268), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(269), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(270), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(271), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(272), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(273), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(274), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(275), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(277), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(277), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(308), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(309), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(311), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(311), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(313), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(313), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(315), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(315), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(317), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(317), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(319), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(319), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(322), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(322), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(324), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(324), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(326), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(326), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(328), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(328), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(330), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(330), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(332), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(332), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(360), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(361), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(362), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(363), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(365), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(365), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(367), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(367), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(369), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(369), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(371), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(371), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(373), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(373), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(375), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(375), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(378), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(378), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(380), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(380), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(382), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(382), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(384), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(384), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(386), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(386), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(388), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(388), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(390), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(390), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(392), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(392), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(394), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(394), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(396), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(396), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(422), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(422), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(424), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(424), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(426), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(427), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(428), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(429), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(434), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(434), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(436), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(436), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(438), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(438), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(440), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(440), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(442), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(442), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(444), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(444), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(446), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(446), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(448), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(448), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(450), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(450), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(452), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(452), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(454), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(454), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(478), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(479), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(480), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(481), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(482), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(483), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(485), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(486), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(488), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(488), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(490), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(490), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(492), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(492), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(494), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(494), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(496), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(496), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(515), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(516), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(517), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(518), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(519), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(520), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(522), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(522), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(524), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(524), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(526), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(526), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(528), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(528), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(530), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(530), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(533), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(533), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(535), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(535), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(537), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(537), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(539), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(539), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(541), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(541), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(543), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(543), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(545), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(545), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(547), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(547), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(549), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(549), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(551), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(551), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(581), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(582), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(584), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(584), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(586), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(586), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(588), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(589), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(590), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(591), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(592), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(593), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(594), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(595), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(596), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(597), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(598), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(599), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(600), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(601), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(602), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(603), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(604), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(605), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(606), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(607), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(608), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(609), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(610), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(611), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(612), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(613), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(614), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(615), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(616), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(617), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(642), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(642), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(644), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(645), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(647), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(647), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(649), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(649), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(651), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(651), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(653), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(653), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(655), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(655), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(657), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(657), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(659), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(659), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(661), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(661), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(663), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(663), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(665), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(665), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(685), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(685), "Một", 10 },
                    { 125, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(687), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(687), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(689), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(689), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(691), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(691), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(693), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(693), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(695), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(695), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(697), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(697), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(699), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(700), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(701), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(702), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(703), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(703), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(724), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(724), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(726), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(726), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(728), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(728), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(730), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(730), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(732), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(732), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(735), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(735), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(737), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(737), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(739), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(739), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(741), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(741), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(743), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(743), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(745), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(745), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(747), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(747), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(749), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(749), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(756), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(757), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(758), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(759), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(760), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(761), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(762), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(763), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(764), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(765), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(766), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(767), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(768), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(770), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(771), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(772), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(798), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(798), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(800), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(800), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(802), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(803), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(804), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(805), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(807), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(807), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(809), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(809), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(811), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(811), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(813), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(813), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(815), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(815), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(817), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(817), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(819), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(819), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(821), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(821), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(843), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(843), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(845), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(845), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(847), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(847), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(849), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(849), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(851), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(851), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(853), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(853), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(855), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(855), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(857), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(858), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(859), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(860), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(877), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(878), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(880), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(880), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(882), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(882), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(884), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(884), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(886), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(886), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(889), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(889), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(891), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(891), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(893), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(893), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(895), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(895), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(897), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(897), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(899), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(899), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(901), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(901), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(903), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(904), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(905), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(906), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(907), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(908), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(909), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(910), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(911), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(912), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(913), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(914), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(937), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(938), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(939), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(940), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(941), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(942), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(943), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(944), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(946), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(946), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(948), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(948), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(950), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(950), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(952), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(952), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(954), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(954), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(956), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(956), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(976), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(976), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(978), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(978), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(980), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(981), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(982), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(983), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(984), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(985), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(987), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(988), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(989), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(990), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(991), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(992), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(993), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(994), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(995), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(996), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(997), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(998), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1005), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1005), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1007), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1007), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1009), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1009), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1011), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1011), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1032), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1032), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1034), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1034), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1036), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1037), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1038), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1039), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1040), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1041), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1042), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1043), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1060), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1060), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1062), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1062), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1064), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1065), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1066), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1067), "Không", 18 },
                    { 229, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1068), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1069), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1070), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1071), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1072), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 12, 13, 59, 43, 623, DateTimeKind.Local).AddTicks(1073), "Có", 18 }
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
