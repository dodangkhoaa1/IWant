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
                    { 1, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9735), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9736), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9738), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9739), "Hành Động" },
                    { 3, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9748), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9749), "Động Vật" },
                    { 4, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9751), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9751), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9753), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9754), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9756), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9756), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9758), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9759), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9761), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9761), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9763), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9763), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9765), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9766), "Con Số" },
                    { 11, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9768), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9768), "Con Người" },
                    { 12, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9770), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9771), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9773), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9773), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9775), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9776), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9779), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9779), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9781), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9782), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9784), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9784), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9786), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9787), "Mong Muốn" }
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
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9824), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9824), "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9827), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9828), "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9830), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9830), "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9832), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9833), "Uống", 2 },
                    { 5, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9835), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9835), "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9837), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9837), "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9839), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9840), "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9841), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9842), "Bật", 2 },
                    { 9, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9844), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9844), "Mở", 2 },
                    { 10, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9846), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9847), "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9849), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9850), "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9852), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9852), "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9854), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9854), "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9856), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9857), "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9859), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9859), "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9861), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9861), "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9863), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9864), "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9866), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9866), "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9868), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9868), "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9870), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9871), "Đi Bộ", 2 },
                    { 21, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9872), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9873), "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9903), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9904), "Ong", 3 },
                    { 23, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9906), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9906), "Chim", 3 },
                    { 24, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9908), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9909), "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9911), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9912), "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9914), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9914), "Gà", 3 },
                    { 27, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9916), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9916), "Bò", 3 },
                    { 28, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9919), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9919), "Chó", 3 },
                    { 29, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9921), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9921), "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9923), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9923), "Cá", 3 },
                    { 31, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9925), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9926), "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9927), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9928), "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9930), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9930), "Heo", 3 },
                    { 34, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9955), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9955), "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9958), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9958), "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9960), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9960), "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9962), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9963), "Mông", 4 },
                    { 38, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9964), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9965), "Tai", 4 },
                    { 39, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9968), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9968), "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9970), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9971), "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9973), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9973), "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9975), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9975), "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9977), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9978), "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9979), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9980), "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9982), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9982), "Chân", 4 },
                    { 46, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9989), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9990), "Môi", 4 },
                    { 47, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9992), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9992), "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9994), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9994), "Răng", 4 },
                    { 49, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9996), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9997), "Họng", 4 },
                    { 50, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9998), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 40, DateTimeKind.Local).AddTicks(9999), "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(1), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(1), "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(25), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(26), "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(28), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(28), "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(30), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(30), "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(32), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(33), "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(34), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(35), "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(37), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(37), "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(39), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(39), "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(41), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(42), "Giày", 5 },
                    { 60, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(44), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(44), "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(46), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(46), "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(48), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(49), "Tất", 5 },
                    { 63, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(50), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(51), "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(53), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(53), "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(55), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(55), "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(57), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(58), "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(80), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(81), "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(83), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(84), "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(85), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(87), "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(89), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(89), "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(91), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(92), "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(94), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(94), "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(96), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(96), "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(98), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(99), "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(100), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(101), "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(121), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(121), "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(123), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(124), "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(126), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(126), "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(128), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(128), "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(130), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(131), "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(134), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(134), "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(136), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(136), "Đói", 7 },
                    { 83, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(138), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(139), "Đau", 7 },
                    { 84, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(141), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(141), "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(143), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(143), "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(145), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(146), "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(147), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(148), "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(150), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(150), "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(152), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(153), "Khát", 7 },
                    { 90, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(155), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(155), "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(157), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(158), "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(159), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(160), "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(162), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(162), "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(187), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(187), "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(189), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(190), "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(192), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(192), "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(194), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(195), "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(196), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(197), "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(199), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(199), "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(201), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(202), "Kem", 8 },
                    { 101, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(204), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(204), "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(206), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(207), "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(208), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(209), "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(211), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(211), "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(213), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(213), "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(215), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(216), "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(223), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(224), "Súp", 8 },
                    { 108, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(225), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(226), "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(228), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(228), "Trà", 8 },
                    { 110, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(230), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(230), "Nước", 8 },
                    { 111, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(232), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(233), "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(258), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(259), "Táo", 9 },
                    { 113, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(261), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(261), "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(263), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(263), "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(265), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(266), "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(268), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(268), "Nho", 9 },
                    { 117, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(270), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(270), "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(272), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(273), "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(274), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(275), "Cam", 9 },
                    { 120, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(277), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(277), "Đào", 9 },
                    { 121, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(279), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(280), "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(282), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(282), "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(285), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(285), "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(307), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(307), "Một", 10 },
                    { 125, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(309), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(309), "Hai", 10 },
                    { 126, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(311), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(312), "Ba", 10 },
                    { 127, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(314), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(314), "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(316), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(316), "Năm", 10 },
                    { 129, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(318), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(318), "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(320), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(321), "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(323), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(323), "Tám", 10 },
                    { 132, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(325), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(325), "Chín", 10 },
                    { 133, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(327), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(328), "Mười", 10 },
                    { 134, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(349), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(350), "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(352), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(352), "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(354), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(355), "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(357), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(357), "Bố", 11 },
                    { 138, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(359), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(359), "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(361), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(361), "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(363), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(364), "Bà", 11 },
                    { 141, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(366), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(366), "Ông", 11 },
                    { 142, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(368), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(368), "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(370), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(370), "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(372), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(373), "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(374), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(375), "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(377), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(377), "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(379), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(379), "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(381), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(382), "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(383), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(384), "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(386), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(386), "Ai", 11 },
                    { 151, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(389), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(389), "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(391), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(391), "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(393), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(394), "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(395), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(396), "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(422), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(423), "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(425), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(425), "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(432), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(433), "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(435), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(435), "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(437), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(438), "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(440), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(440), "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(442), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(442), "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(444), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(445), "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(447), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(447), "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(449), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(449), "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(452), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(452), "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(454), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(455), "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(476), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(476), "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(478), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(479), "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(481), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(481), "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(483), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(483), "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(485), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(486), "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(487), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(488), "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(490), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(490), "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(492), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(493), "Ai", 13 },
                    { 175, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(494), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(495), "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(516), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(516), "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(518), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(519), "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(521), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(521), "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(523), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(523), "Ít", 14 },
                    { 180, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(525), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(526), "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(528), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(528), "Cao", 14 },
                    { 182, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(530), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(530), "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(532), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(533), "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(535), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(535), "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(537), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(537), "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(539), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(540), "Dài", 14 },
                    { 187, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(542), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(542), "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(544), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(544), "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(546), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(547), "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(548), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(549), "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(551), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(551), "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(553), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(554), "Dày", 14 },
                    { 193, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(556), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(556), "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(580), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(581), "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(582), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(583), "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(585), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(585), "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(587), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(588), "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(589), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(590), "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(592), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(592), "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(594), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(594), "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(596), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(597), "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(598), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(599), "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(601), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(601), "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(620), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(621), "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(623), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(623), "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(625), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(626), "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(628), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(628), "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(630), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(631), "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(632), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(633), "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(635), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(635), "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(637), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(637), "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(639), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(640), "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(641), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(642), "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(644), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(644), "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(646), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(646), "Diều", 16 },
                    { 216, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(648), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(649), "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(651), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(651), "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(653), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(653), "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(677), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(677), "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(679), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(680), "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(682), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(682), "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(684), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(685), "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(686), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(687), "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(689), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(689), "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(712), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(712), "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(714), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(715), "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(717), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(717), "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(719), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(719), "Không", 18 },
                    { 229, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(721), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(722), "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(724), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(724), "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(726), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 12, 13, 24, 11, 41, DateTimeKind.Local).AddTicks(726), "Có", 18 }
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
