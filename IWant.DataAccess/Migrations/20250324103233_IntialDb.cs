using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IntialDb : Migration
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
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ImageLocalPath = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "DATE", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    ChildName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ChildNickName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ChildBirthday = table.Column<DateOnly>(type: "DATE", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ImageLocalPath = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CitedImage = table.Column<string>(type: "nvarchar(100)", nullable: true),
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
                    CreateAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
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
                    EnglishText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    WordCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_WordCategories_WordCategoryId",
                        column: x => x.WordCategoryId,
                        principalTable: "WordCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingStar = table.Column<byte>(type: "TINYINT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rates_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 750, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ToRoomId = table.Column<int>(type: "int", nullable: false),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", "0888408052", false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" },
                    { "15ccf7a4-8f9f-4127-b046-69723542fc06", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "6700c857-a9e8-4b79-89cc-a04964be9e8d", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhunhce170053@fpt.edu.vn", true, "Nguyễn Huỳnh Như", false, "avatar/default-avatar.png", "/images/avatar/default-avatar.png", true, null, "NHUNHCE170053@FPT.EDU.VN", "NHUNHCE170053@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0888408052", false, "68a25bf1-a27d-4e80-9640-d0701333b175", true, false, null, "nhunhce170053@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "4194eb1e-3bf1-4d48-97df-f4c3b3b79504", null, "khoaddce170883@fpt.edu.vn", true, "Đỗ Đăng Khoa", true, "avatar/default-avatar.png", "/images/avatar/default-avatar.png", true, null, "KHOADDCE170883@FPT.EDU.VN", "KHOADDCE170883@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "f6fcdf3a-e9d7-489a-b438-1ddd6981c4c5", true, false, null, "khoaddce170883@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5013", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "15341f46-ef6f-4a25-83fe-a812a7648e02", null, "nhutvmce171686@fpt.edu.vn", true, "Võ Minh Nhựt", true, "avatar/default-avatar.png", "/images/avatar/default-avatar.png", true, null, "NHUTVMCE171686@FPT.EDU.VN", "NHUTVMCE171686@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "728f6d78-aa9e-4066-87bb-2c59a3c7626d", true, false, null, "nhutvmce171686@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5014", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "2d522511-c94d-453f-aaa9-33ce2fde9215", null, "thanhnttce170901@fpt.edu.vn", true, "Nguyễn Trần Trung Thành", true, "avatar/default-avatar.png", "/images/avatar/default-avatar.png", true, null, "THANHNTTCE170901@FPT.EDU.VN", "THANHNTTCE170901@FPT.EDU.VN", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "b484d364-2ad7-4a8c-899d-259ef5281194", true, false, null, "thanhnttce170901@fpt.edu.vn" },
                    { "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5019", 0, new DateOnly(2003, 7, 16), new DateOnly(1, 1, 1), null, null, null, "50675754-27e0-451b-9c82-8db93e202a76", null, "test@gmail.com", true, "Nguyễn Tester", true, "avatar/default-avatar.png", "/images/avatar/default-avatar.png", true, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEGr/htC0131/1iKNmo0AiuzyeRytHJQHIlsbvYWIBvnsI+YxSX4LkDwooyxR+8P55g==", "0784419071", false, "b7054ef1-e296-48b8-b353-aedd8f2e9dca", true, false, null, "test@gmail.com" }
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
                    { 1, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4974), "Personal Words", "images/wordCategories/Personal.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4975), "Từ Cá Nhân" },
                    { 2, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4977), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4978), "Hành Động" },
                    { 3, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4981), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4981), "Động Vật" },
                    { 4, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4983), "Body Parts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4983), "Bộ Phận Cơ Thể" },
                    { 5, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4985), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4986), "Quần Áo" },
                    { 6, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4987), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4988), "Màu Sắc" },
                    { 7, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4990), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4990), "Cảm Xúc" },
                    { 8, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4992), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4992), "Thức Ăn" },
                    { 9, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4994), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4994), "Trái Cây" },
                    { 10, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4996), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4996), "Con Số" },
                    { 11, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4998), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(4999), "Con Người" },
                    { 12, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5000), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5001), "Địa Điểm" },
                    { 13, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5002), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5003), "Câu Hỏi" },
                    { 14, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5004), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5005), "Mối Quan Hệ" },
                    { 15, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5006), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5007), "Thời Gian" },
                    { 16, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5009), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5009), "Đồ Chơi" },
                    { 17, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5011), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5011), "Phương Tiện" },
                    { 18, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5013), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5014), "Mong Muốn" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d19bb620-77b5-414e-865a-1894fbcbb689", "0bcbb4f7-72f9-435f-9cb3-1621b4503974" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "15ccf7a4-8f9f-4127-b046-69723542fc06" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5012" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5013" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5014" },
                    { "fbd6a6c8-27eb-4171-bb75-50e97adffebb", "6b7f56a9-4fd5-47b7-8454-0aa5a7ab5019" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CitedImage", "Content", "CreatedAt", "ImageLocalPath", "ImageUrl", "Status", "Title", "UpdatedAt", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, "Sưu tầm", "<p style=\"text-align: justify; \"><strong>Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Cha mẹ nào cũng muốn con cái chia sẻ, tâm sự mọi chuyện. Nhưng không phải lúc nào trẻ cũng sẵn sàng mở lòng. Làm sao để con cảm thấy thoải mái khi trò chuyện, tránh xa khoảng cách thế hệ và thực sự kết nối với cha mẹ? Hãy cùng tìm hiểu cách giao tiếp cởi mở với con một cách tự nhiên nhất!</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Vì sao giao tiếp cởi mở với con lại quan trọng?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trẻ nhỏ, đặc biệt là lứa tuổi dậy thì, rất cần một người lắng nghe và thấu hiểu. Khi cha mẹ tạo ra không gian an toàn, trẻ sẽ dễ dàng chia sẻ suy nghĩ, cảm xúc của mình hơn. Điều này không chỉ giúp gắn kết tình cảm gia đình mà còn giúp trẻ tự tin hơn trong cuộc sống.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Một số lợi ích của việc trò chuyện cởi mở với con:</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ cảm thấy được yêu thương và tôn trọng.</li>\r\n                        <li style=\"text-align: justify;\">Giúp cha mẹ hiểu rõ những vấn đề mà con đang gặp phải.</li>\r\n                        <li style=\"text-align: justify;\">Tạo nền tảng cho sự phát triển tâm lý lành mạnh.</li>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ học cách diễn đạt suy nghĩ và cảm xúc một cách rõ ràng.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Cách nói chuyện cởi mở với con</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Chọn thời điểm phù hợp</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Hãy trò chuyện với con vào lúc cả hai đều thoải mái. Đừng ép con nói chuyện khi con đang mệt mỏi, căng thẳng hoặc bị phân tâm bởi điện thoại, TV.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Lắng nghe thay vì phán xét</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nhiều bậc cha mẹ có xu hướng đưa ra lời khuyên hoặc phán xét ngay khi con nói. Tuy nhiên, trẻ cần cảm giác được lắng nghe hơn là bị chỉ trích. Thay vì nói “Con không nên làm vậy!”, hãy thử hỏi “Con nghĩ sao về điều đó?” để khuyến khích con chia sẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Đặt câu hỏi mở</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Tránh những câu hỏi “Có” hoặc “Không” vì chúng dễ làm cuộc trò chuyện đi vào ngõ cụt. Thay vào đó, hãy đặt câu hỏi mở để kích thích con suy nghĩ và diễn đạt nhiều hơn, ví dụ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Hôm nay ở trường có chuyện gì thú vị không?</li>\r\n                        <li style=\"text-align: justify;\">Con cảm thấy thế nào về điều đó?</li>\r\n                        <li style=\"text-align: justify;\">Nếu được làm lại, con sẽ làm khác đi như thế nào?</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Tạo không gian thoải mái</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Không phải lúc nào cũng cần ngồi nghiêm túc để nói chuyện. Những lúc cùng con nấu ăn, đi dạo hay trên đường đi học cũng là cơ hội tốt để bắt đầu cuộc trò chuyện.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Thể hiện sự đồng cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Khi con gặp vấn đề, hãy đặt mình vào vị trí của con. Thay vì nói \"Chuyện này không có gì to tát\", hãy thử nói \"Mẹ hiểu tại sao con cảm thấy như vậy\". Điều này giúp con cảm nhận được sự thấu hiểu từ cha mẹ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Những điều cần tránh khi trò chuyện với con</strong></p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Không áp đặt suy nghĩ:</strong> Tránh những câu như “Con phải làm thế này mới đúng!” vì trẻ cần có không gian để tự quyết định.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không so sánh con với người khác:</strong> Câu nói “Sao con không giỏi như bạn A?” chỉ khiến trẻ tự ti và xa cách cha mẹ hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không chỉ trích hoặc quát mắng:</strong> Khi trẻ mắc lỗi, thay vì trách mắng, hãy giúp con hiểu vấn đề và tìm hướng giải quyết.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không đặt câu hỏi quá dồn dập:</strong> Điều này có thể làm con cảm thấy như đang bị tra khảo thay vì được tâm sự.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trò chuyện với con không phải là một nhiệm vụ khó khăn, quan trọng là cha mẹ biết cách lắng nghe, thấu hiểu và tôn trọng con. Khi cha mẹ thực sự quan tâm và đồng hành, con sẽ tự nhiên mở lòng, giúp mối quan hệ gia đình ngày càng gắn kết hơn.</p>", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\1.svg", "/images/blog/1.svg", true, "Bí Quyết Trò Chuyện Cởi Mở Với Con – Hiểu Để Gần Hơn", new DateTime(2025, 3, 10, 12, 30, 42, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 2, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp</strong></p>\r\n                    <p style=\"text-align: justify;\">Ngày nay, mạng xã hội đã trở thành một phần không thể thiếu trong cuộc sống, đặc biệt là đối với giới trẻ. Tuy nhiên, việc sử dụng mạng xã hội quá mức có thể gây ra nhiều tác động tiêu cực đến tâm lý và sự phát triển của trẻ em, thậm chí làm gia tăng nguy cơ rối loạn tâm trí.</p>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>1. Trẻ em nghiện mạng xã hội: Thực trạng đáng lo ngại</strong></p>\r\n                    <p style=\"text-align: justify;\">Với sự phát triển của công nghệ, trẻ em ngày càng tiếp cận sớm với điện thoại, máy tính bảng và các nền tảng mạng xã hội như Facebook, TikTok, Instagram...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tác hại của việc nghiện mạng xã hội</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn tâm lý:</strong> Việc tiếp xúc với quá nhiều nội dung tiêu cực...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Rối loạn giấc ngủ:</strong> Trẻ thường xuyên sử dụng điện thoại...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Suy giảm khả năng tập trung:</strong> Sử dụng mạng xã hội quá mức...</li>\r\n                    </ul>\r\n                    \r\n                    <p style=\"text-align: justify;\"><strong>3. Nguyên nhân khiến trẻ nghiện mạng xã hội</strong></p>\r\n                    <p style=\"text-align: justify;\">Có nhiều yếu tố dẫn đến tình trạng này, bao gồm...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách giúp trẻ sử dụng mạng xã hội một cách lành mạnh</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Đặt giới hạn thời gian sử dụng:</strong> Thiết lập quy tắc rõ ràng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giám sát nội dung trẻ tiếp cận:</strong> Sử dụng các công cụ kiểm soát...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trở thành tấm gương tốt:</strong> Cha mẹ cũng nên hạn chế sử dụng điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Mạng xã hội mang lại nhiều lợi ích nhưng cũng tiềm ẩn nhiều rủi ro...</p>", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\2.svg", "/images/blog/2.svg", true, "Trẻ Nghiện Mạng Xã Hội: Nguy Cơ Rối Loạn Tâm Trí Và Giải Pháp", new DateTime(2025, 3, 22, 12, 35, 48, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 3, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC (Augmentative and Alternative Communication) là một hệ thống giao tiếp bổ trợ và thay thế giúp những người gặp khó khăn trong giao tiếp bằng lời nói, đặc biệt là trẻ tự kỷ...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. AAC là gì?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC bao gồm nhiều phương pháp khác nhau nhằm hỗ trợ hoặc thay thế ngôn ngữ nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Vì sao AAC quan trọng đối với trẻ tự kỷ?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp trẻ thể hiện nhu cầu:</strong> Hạn chế căng thẳng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Phát triển kỹ năng giao tiếp:</strong> Hỗ trợ trẻ học cách tương tác...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Các phương pháp AAC phổ biến</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>PECS:</strong> Hệ thống giao tiếp bằng tranh ảnh...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ứng dụng hỗ trợ giao tiếp:</strong> Một số ứng dụng trên điện thoại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Khi nào nên áp dụng AAC?</strong></p>\r\n                    <p style=\"text-align: justify;\">AAC có thể được áp dụng cho trẻ tự kỷ ngay từ khi phát hiện trẻ có dấu hiệu chậm nói...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. Lưu ý khi sử dụng AAC</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Chọn phương pháp phù hợp:</strong> Mỗi trẻ có khả năng khác nhau...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và luyện tập:</strong> Cha mẹ và giáo viên cần hướng dẫn...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Phương pháp AAC là một công cụ hỗ trợ hiệu quả giúp trẻ tự kỷ cải thiện kỹ năng giao tiếp...</p>", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\3.svg", "/images/blog/3.svg", true, "Phương pháp AAC – Hỗ trợ giao tiếp cho trẻ tự kỷ", new DateTime(2025, 3, 28, 12, 38, 23, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 1 },
                    { 4, "Sưu tầm", "<p style=\"text-align: justify;\"><strong>Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống</strong></p>\r\n                    <p style=\"text-align: justify;\">Tự kỷ không phải là một căn bệnh, mà là một dạng rối loạn phát triển ảnh hưởng đến khả năng giao tiếp...</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Dấu hiệu nhận biết trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Hạn chế giao tiếp bằng mắt:</strong> Trẻ ít hoặc không duy trì giao tiếp bằng mắt khi trò chuyện.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Không phản ứng khi được gọi tên:</strong> Nhiều trẻ không quay lại...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tại sao cần phát hiện và can thiệp sớm?</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Cải thiện khả năng ngôn ngữ và giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\">Giảm thiểu các hành vi tiêu cực...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Những phương pháp can thiệp hiệu quả</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp ngôn ngữ:</strong> Giúp trẻ cải thiện khả năng giao tiếp...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp hành vi (ABA):</strong> Dạy trẻ cách phản ứng phù hợp...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Vai trò của gia đình trong việc hỗ trợ trẻ tự kỷ</strong></p>\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Kiên nhẫn và thấu hiểu:</strong> Mỗi trẻ tự kỷ đều có thế mạnh riêng...</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tạo môi trường giao tiếp tích cực:</strong> Thường xuyên trò chuyện...</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n                    <p style=\"text-align: justify;\">Trẻ tự kỷ có thể phát triển và hòa nhập xã hội nếu được phát hiện sớm và can thiệp đúng cách...</p>", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\4.svg", "/images/blog/4.svg", true, "Phát Hiện Sớm Trẻ Tự Kỷ – Chìa Khóa Giúp Con Hòa Nhập Cuộc Sống", new DateTime(2025, 3, 29, 12, 42, 5, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0 },
                    { 5, "Internet", "<p style=\"text-align: justify; \">Trẻ hiếu động, mất tập trung có phải là do nghịch ngợm hay lười biếng? Nhiều bậc phụ huynh lo lắng khi con mình không thể ngồi yên, dễ bị phân tâm và thường xuyên quên mất việc cần làm. Trên thực tế, đây có thể là dấu hiệu của rối loạn tăng động giảm chú ý (ADHD) – một tình trạng ảnh hưởng đến sự phát triển và khả năng học tập của trẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. ADHD là gì?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD (Attention Deficit Hyperactivity Disorder) là một rối loạn phát triển thần kinh thường gặp ở trẻ em, gây ảnh hưởng đến khả năng tập trung, kiểm soát hành vi và mức độ hiếu động. Đây không phải do trẻ cố tình nghịch ngợm hay thiếu kỷ luật, mà là một tình trạng có liên quan đến hoạt động của não bộ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Dấu hiệu nhận biết ADHD ở trẻ</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Không phải trẻ nào hiếu động, nghịch ngợm cũng mắc ADHD. Tuy nhiên, nếu trẻ có những biểu hiện dưới đây trong thời gian dài và ảnh hưởng đến sinh hoạt hàng ngày, cha mẹ nên lưu ý:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Dễ mất tập trung:</strong> Trẻ khó duy trì sự chú ý, dễ bị phân tâm, thường quên làm bài tập hoặc làm việc mà không hoàn thành.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tăng động:</strong> Trẻ không thể ngồi yên, liên tục di chuyển, leo trèo, chạy nhảy ngay cả khi không phù hợp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Bốc đồng:</strong> Trẻ có thể nói chen ngang, khó chờ đến lượt, thường xuyên hành động mà không suy nghĩ trước.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Nguyên nhân gây ra ADHD</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Hiện nay, các nhà khoa học chưa xác định chính xác nguyên nhân gây ADHD, nhưng có một số yếu tố có thể liên quan đến tình trạng này:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Di truyền:</strong> Nếu cha mẹ hoặc người thân trong gia đình mắc ADHD, nguy cơ trẻ bị rối loạn này cao hơn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Não bộ phát triển khác biệt:</strong> Một số nghiên cứu chỉ ra rằng vùng não kiểm soát sự tập trung và kiểm soát hành vi ở trẻ ADHD hoạt động khác so với trẻ bình thường.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Yếu tố môi trường:</strong> Trẻ sinh non, thiếu cân hoặc tiếp xúc với chất độc hại như chì trong giai đoạn phát triển có thể tăng nguy cơ mắc ADHD.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. ADHD ảnh hưởng đến trẻ như thế nào?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Nếu không được hỗ trợ đúng cách, ADHD có thể gây ra nhiều khó khăn trong cuộc sống hàng ngày của trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Trong học tập:</strong> Trẻ gặp khó khăn trong việc tập trung trên lớp, dễ bỏ lỡ bài giảng, dẫn đến kết quả học tập kém.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trong giao tiếp:</strong> Trẻ có thể bị hiểu lầm là vô ý tứ, thiếu kiên nhẫn, gây khó khăn trong việc kết bạn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Trong gia đình:</strong> Cha mẹ thường phải nhắc nhở liên tục, dễ dẫn đến căng thẳng giữa các thành viên.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>5. ADHD có thể điều trị được không?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD không thể chữa khỏi hoàn toàn, nhưng có thể kiểm soát bằng nhiều phương pháp phù hợp với từng trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp hành vi:</strong> Giúp trẻ học cách kiểm soát cảm xúc, tập trung và làm việc có tổ chức.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Can thiệp giáo dục:</strong> Giáo viên có thể hỗ trợ trẻ bằng cách tạo môi trường học tập phù hợp, giảm yếu tố gây xao nhãng.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Dùng thuốc:</strong> Trong một số trường hợp, bác sĩ có thể kê đơn thuốc giúp kiểm soát các triệu chứng ADHD.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>6. Cha mẹ có thể làm gì để giúp con?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Cha mẹ đóng vai trò quan trọng trong việc hỗ trợ trẻ ADHD. Một số cách giúp con kiểm soát tốt hơn:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Thiết lập thời gian biểu rõ ràng để trẻ dễ dàng theo dõi và thực hiện.</li>\r\n                        <li style=\"text-align: justify;\">Hướng dẫn trẻ hoàn thành công việc từng bước nhỏ thay vì yêu cầu một lúc quá nhiều.</li>\r\n                        <li style=\"text-align: justify;\">Giúp trẻ giải phóng năng lượng bằng cách khuyến khích các hoạt động thể thao, vui chơi ngoài trời.</li>\r\n                        <li style=\"text-align: justify;\">Thường xuyên động viên, khen ngợi những tiến bộ nhỏ để trẻ cảm thấy tự tin.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">ADHD không phải là một `căn bệnh`, mà là một đặc điểm của sự phát triển thần kinh. Khi được hướng dẫn và hỗ trợ đúng cách, trẻ ADHD hoàn toàn có thể phát triển bình thường, thậm chí có nhiều thế mạnh riêng. Điều quan trọng nhất là cha mẹ luôn đồng hành, kiên nhẫn và giúp con phát huy tối đa tiềm năng của mình.</p>", new DateTime(2025, 4, 3, 19, 30, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\5.svg", "/images/blog/5.svg", true, "ADHD Ở Trẻ Em – Hiểu Để Đồng Hành Cùng Con", new DateTime(2025, 4, 3, 19, 30, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 40 },
                    { 6, "Internet", "<p style=\"text-align: justify; \">Trong cuộc sống hiện đại, không khó để bắt gặp hình ảnh trẻ nhỏ chăm chú vào màn hình điện thoại, trong khi cha mẹ tranh thủ làm việc hoặc nghỉ ngơi. Nhiều bậc phụ huynh sử dụng điện thoại như một \"công cụ trấn an\" giúp con ngồi yên, bớt quấy khóc. Tuy nhiên, việc lạm dụng điện thoại có thể để lại những hậu quả nghiêm trọng đối với sự phát triển của trẻ.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Tại sao cha mẹ thường cho con dùng điện thoại?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Có nhiều lý do khiến cha mẹ dễ dàng đưa điện thoại cho con khi con quấy khóc hoặc không chịu ăn:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Giúp con ngồi yên:</strong> Điện thoại có thể khiến trẻ tập trung vào màn hình, giảm thiểu sự hiếu động hoặc mè nheo.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Cha mẹ bận rộn:</strong> Khi có nhiều công việc, phụ huynh thường chọn cách nhanh nhất để giữ con bận rộn.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Thói quen phổ biến:</strong> Ngày nay, điện thoại trở thành một phần không thể thiếu trong cuộc sống, nhiều phụ huynh cũng xem đó là chuyện bình thường.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Tác hại của việc cho trẻ dùng điện thoại quá sớm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Việc tiếp xúc với màn hình quá nhiều có thể ảnh hưởng tiêu cực đến sự phát triển của trẻ:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến sự phát triển não bộ:</strong> Trẻ em dưới 3 tuổi có bộ não đang phát triển mạnh mẽ. Việc tiếp xúc quá nhiều với màn hình có thể làm suy giảm khả năng tập trung, tư duy sáng tạo và kỹ năng giao tiếp.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Gây rối loạn giấc ngủ:</strong> Ánh sáng xanh từ điện thoại có thể ức chế việc sản sinh melatonin, gây khó ngủ và ảnh hưởng đến chất lượng giấc ngủ của trẻ.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giảm tương tác xã hội:</strong> Khi dành quá nhiều thời gian cho điện thoại, trẻ ít giao tiếp với cha mẹ và bạn bè, làm giảm kỹ năng ngôn ngữ và khả năng kết nối cảm xúc.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Gia tăng nguy cơ béo phì:</strong> Ngồi lâu trước màn hình khiến trẻ ít vận động, làm tăng nguy cơ béo phì và các vấn đề sức khỏe khác.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hình thành thói quen xấu:</strong> Nếu trẻ quen với việc chỉ cần khóc là được đưa điện thoại, điều này có thể tạo thành một cơ chế \"phần thưởng sai lệch\", khiến trẻ phụ thuộc vào thiết bị điện tử để giải tỏa cảm xúc.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Khi nào trẻ có thể sử dụng thiết bị điện tử?</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Theo khuyến nghị của các chuyên gia:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\">Trẻ dưới <strong>18 tháng</strong>: Không nên tiếp xúc với màn hình, trừ khi sử dụng để gọi video với người thân.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>18 - 24 tháng</strong>: Có thể tiếp xúc với nội dung chất lượng cao nhưng cần có sự giám sát của cha mẹ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>2 - 5 tuổi</strong>: Hạn chế tối đa thời gian sử dụng, không quá 1 giờ mỗi ngày và nên có sự tham gia của cha mẹ.</li>\r\n                        <li style=\"text-align: justify;\">Trẻ từ <strong>6 tuổi trở lên</strong>: Cần xây dựng thói quen sử dụng công nghệ hợp lý, cân bằng giữa thời gian online và các hoạt động khác.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Cách giúp trẻ tránh phụ thuộc vào điện thoại</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Để giảm thiểu việc trẻ dựa dẫm vào điện thoại, cha mẹ có thể áp dụng những biện pháp sau:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Tạo môi trường giàu hoạt động:</strong> Khuyến khích trẻ chơi các trò chơi sáng tạo, vận động ngoài trời và tham gia các hoạt động nghệ thuật.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Đặt quy tắc sử dụng điện thoại:</strong> Quy định thời gian sử dụng thiết bị và chỉ cho phép trẻ dùng trong những khung giờ nhất định.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Làm gương cho con:</strong> Cha mẹ cũng cần hạn chế sử dụng điện thoại trước mặt con để tạo thói quen tốt.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Khuyến khích trẻ giao tiếp:</strong> Dành nhiều thời gian trò chuyện cùng con, giúp con phát triển kỹ năng giao tiếp và tương tác xã hội.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Điện thoại không xấu, nhưng nếu sử dụng không đúng cách, nó có thể ảnh hưởng tiêu cực đến sự phát triển của trẻ. Cha mẹ cần kiểm soát thời gian và nội dung mà trẻ tiếp xúc, đồng thời tạo ra những hoạt động bổ ích khác để trẻ phát triển một cách toàn diện.</p>", new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\6.svg", "/images/blog/6.svg", true, "Đừng Đưa Điện Thoại Cho Con Chỉ Để Con Ngồi Yên", new DateTime(2025, 4, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 10 },
                    { 7, "Sưu Tầm", "<p style=\"text-align: justify; \">Trầm cảm ngày càng trở thành một vấn đề đáng lo ngại trên toàn thế giới, trong đó có Việt Nam. Dù không dễ nhận diện ngay từ đầu, nhưng nếu không được phát hiện và điều trị kịp thời, trầm cảm có thể gây ảnh hưởng nghiêm trọng đến sức khỏe tinh thần và chất lượng cuộc sống của người mắc.</p>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>1. Tình trạng trầm cảm tại Việt Nam</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Theo các nghiên cứu gần đây, số người mắc trầm cảm ở Việt Nam có xu hướng gia tăng, đặc biệt trong bối cảnh áp lực cuộc sống ngày càng lớn. Các yếu tố như công việc căng thẳng, áp lực tài chính, vấn đề gia đình hay những biến cố bất ngờ trong cuộc sống đều có thể trở thành nguyên nhân gây ra trầm cảm.</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Đối tượng bị ảnh hưởng:</strong> Trầm cảm không phân biệt độ tuổi hay giới tính, nhưng thường gặp nhất ở thanh thiếu niên, người trưởng thành và người cao tuổi.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Những dấu hiệu thường gặp:</strong> Người mắc trầm cảm có thể cảm thấy buồn bã kéo dài, mất hứng thú với các hoạt động thường ngày, dễ cáu gắt, mất ngủ hoặc ngủ quá nhiều, giảm tập trung và có suy nghĩ tiêu cực.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến xã hội:</strong> Trầm cảm không chỉ tác động đến cá nhân mà còn ảnh hưởng đến gia đình, công việc và các mối quan hệ xã hội.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>2. Nguyên nhân dẫn đến trầm cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm có thể xuất phát từ nhiều yếu tố khác nhau, bao gồm:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Áp lực cuộc sống:</strong> Các vấn đề tài chính, công việc, học tập hay mâu thuẫn gia đình có thể khiến một người rơi vào trạng thái căng thẳng kéo dài.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Mất mát và tổn thương tâm lý:</strong> Việc mất đi người thân, đổ vỡ trong tình cảm hoặc những biến cố lớn trong cuộc sống có thể là nguyên nhân dẫn đến trầm cảm.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Yếu tố sinh học:</strong> Rối loạn về chất dẫn truyền thần kinh trong não bộ có thể ảnh hưởng đến cảm xúc và hành vi, góp phần gây ra trầm cảm.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng từ môi trường:</strong> Việc sống trong môi trường tiêu cực, bị bạo lực gia đình hoặc chịu áp lực xã hội cũng có thể làm gia tăng nguy cơ mắc trầm cảm.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>3. Hậu quả của trầm cảm nếu không được điều trị</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm kéo dài mà không có biện pháp can thiệp có thể gây ra nhiều hệ lụy:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Ảnh hưởng đến sức khỏe:</strong> Người mắc trầm cảm có nguy cơ cao bị suy giảm miễn dịch, rối loạn giấc ngủ, mất cảm giác ngon miệng và suy nhược cơ thể.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Giảm hiệu suất làm việc và học tập:</strong> Trầm cảm khiến người bệnh mất tập trung, giảm khả năng giải quyết vấn đề và làm việc kém hiệu quả.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Tăng nguy cơ tự tử:</strong> Những suy nghĩ tiêu cực kéo dài có thể khiến người bệnh tìm đến những hành động nguy hiểm nếu không được hỗ trợ kịp thời.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>4. Giải pháp hỗ trợ và điều trị trầm cảm</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Việc phát hiện sớm và can thiệp kịp thời là yếu tố quan trọng giúp người mắc trầm cảm hồi phục. Một số biện pháp có thể hỗ trợ điều trị bao gồm:</p>\r\n\r\n                    <ul>\r\n                        <li style=\"text-align: justify;\"><strong>Liệu pháp tâm lý:</strong> Tư vấn tâm lý và trị liệu giúp người bệnh kiểm soát cảm xúc, giảm căng thẳng và tìm ra giải pháp cho các vấn đề trong cuộc sống.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Điều trị bằng thuốc:</strong> Trong một số trường hợp, bác sĩ có thể chỉ định thuốc chống trầm cảm để điều chỉnh hoạt động của hệ thần kinh.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Thay đổi lối sống:</strong> Luyện tập thể dục, duy trì chế độ ăn uống lành mạnh và tham gia các hoạt động tích cực giúp cải thiện tinh thần.</li>\r\n                        <li style=\"text-align: justify;\"><strong>Hỗ trợ từ gia đình và bạn bè:</strong> Sự quan tâm và chia sẻ từ những người xung quanh đóng vai trò quan trọng trong quá trình hồi phục của người bệnh.</li>\r\n                    </ul>\r\n\r\n                    <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                    <p style=\"text-align: justify;\">Trầm cảm không phải là một vấn đề có thể xem nhẹ, nhưng hoàn toàn có thể được điều trị nếu phát hiện kịp thời. Mỗi người cần nâng cao nhận thức về sức khỏe tinh thần, đồng thời chủ động tìm kiếm sự giúp đỡ khi cảm thấy không ổn. Xã hội và gia đình cũng cần đóng vai trò tích cực trong việc hỗ trợ và tạo ra một môi trường sống lành mạnh để giúp người mắc trầm cảm sớm vượt qua khó khăn.</p>", new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\7.svg", "/images/blog/7.svg", true, "Thực Trạng Trầm Cảm Ở Việt Nam Hiện Nay", new DateTime(2025, 4, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 14 },
                    { 8, "Internet", "<p style=\"text-align: justify; \">Trẻ em có tốc độ phát triển ngôn ngữ khác nhau, nhưng nếu một đứa trẻ chậm nói hơn nhiều so với bạn bè cùng trang lứa, đó có thể là dấu hiệu của chậm phát triển ngôn ngữ. Việc phát hiện sớm và can thiệp kịp thời đóng vai trò quan trọng trong việc giúp trẻ cải thiện khả năng giao tiếp.</p>\r\n\r\n                            <p style=\"text-align: justify;\"><strong>1. Thế nào là chậm phát triển ngôn ngữ?</strong></p>\r\n\r\n                            <p style=\"text-align: justify;\">Chậm phát triển ngôn ngữ là tình trạng trẻ gặp khó khăn trong việc học và sử dụng ngôn ngữ so với độ tuổi của mình. Điều này có thể biểu hiện qua việc trẻ nói ít từ, phát âm không rõ ràng hoặc không thể diễn đạt ý muốn bằng lời nói.</p>\r\n\r\n                            <p style=\"text-align: justify;\">Trẻ chậm phát triển ngôn ngữ có thể có các biểu hiện như:</p>\r\n                            <ul>\r\n                                <li style=\"text-align: justify;\">Không bập bẹ hoặc ít phát ra âm thanh khi còn nhỏ.</li>\r\n                                <li style=\"text-align: justify;\">Đến 2 tuổi nhưng vẫn chưa nói được câu có hai từ.</li>\r\n                                <li style=\"text-align: justify;\">Khó hiểu lời nói của người khác hoặc không phản ứng với lời gọi.</li>\r\n                                <li style=\"text-align: justify;\">Gặp khó khăn trong việc kết nối từ để tạo thành câu hoàn chỉnh.</li>\r\n                            </ul>\r\n\r\n                            <p style=\"text-align: justify;\"><strong>2. Nguyên nhân khiến trẻ chậm phát triển ngôn ngữ</strong></p>\r\n\r\n                            <p style=\"text-align: justify;\">Có nhiều yếu tố ảnh hưởng đến sự phát triển ngôn ngữ của trẻ, bao gồm:</p>\r\n                            <ul>\r\n                                <li style=\"text-align: justify;\"><strong>Yếu tố sinh học:</strong> Một số trẻ có vấn đề về thính giác, hệ thần kinh hoặc di truyền có thể ảnh hưởng đến khả năng nói.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Môi trường giao tiếp hạn chế:</strong> Trẻ ít được nói chuyện, đọc sách hoặc tiếp xúc với ngôn ngữ có thể bị chậm phát triển ngôn ngữ.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Vấn đề tâm lý:</strong> Trẻ mắc chứng tự kỷ hoặc rối loạn phát triển cũng có nguy cơ chậm nói.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Ảnh hưởng từ công nghệ:</strong> Việc trẻ tiếp xúc nhiều với màn hình điện thoại, tivi mà ít tương tác trực tiếp với người xung quanh cũng có thể khiến khả năng ngôn ngữ bị trì trệ.</li>\r\n                            </ul>\r\n\r\n                            <p style=\"text-align: justify;\"><strong>3. Khi nào nên đưa trẻ đi khám?</strong></p>\r\n\r\n                            <p style=\"text-align: justify;\">Nếu trẻ có những dấu hiệu sau, cha mẹ nên đưa trẻ đến gặp chuyên gia để được đánh giá và tư vấn:</p>\r\n                            <ul>\r\n                                <li style=\"text-align: justify;\">Trẻ không có phản ứng khi được gọi tên.</li>\r\n                                <li style=\"text-align: justify;\">Trẻ 18 tháng tuổi nhưng chưa nói được từ đơn.</li>\r\n                                <li style=\"text-align: justify;\">Trẻ 2 tuổi nhưng chưa nói được cụm từ hai từ.</li>\r\n                                <li style=\"text-align: justify;\">Trẻ không thể giao tiếp bằng lời nói hoặc cử chỉ.</li>\r\n                                <li style=\"text-align: justify;\">Trẻ có dấu hiệu mất khả năng ngôn ngữ sau một thời gian phát triển bình thường.</li>\r\n                            </ul>\r\n\r\n                            <p style=\"text-align: justify;\"><strong>4. Cách hỗ trợ trẻ chậm phát triển ngôn ngữ</strong></p>\r\n\r\n                            <p style=\"text-align: justify;\">Việc can thiệp sớm sẽ giúp trẻ cải thiện khả năng ngôn ngữ và giao tiếp. Một số phương pháp có thể áp dụng bao gồm:</p>\r\n\r\n                            <ul>\r\n                                <li style=\"text-align: justify;\"><strong>Tăng cường giao tiếp với trẻ:</strong> Nói chuyện với trẻ nhiều hơn, đặt câu hỏi và khuyến khích trẻ diễn đạt suy nghĩ.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Đọc sách cùng trẻ:</strong> Sử dụng tranh ảnh, sách truyện để giúp trẻ tiếp thu từ vựng và cách diễn đạt.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Hạn chế thời gian sử dụng thiết bị điện tử:</strong> Thay vào đó, khuyến khích trẻ tham gia các hoạt động vui chơi có tính tương tác.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Áp dụng các bài tập luyện ngôn ngữ:</strong> Chơi trò chơi với âm thanh, tập phát âm từ đơn giản đến phức tạp hơn.</li>\r\n                                <li style=\"text-align: justify;\"><strong>Tham khảo ý kiến chuyên gia:</strong> Nếu trẻ có dấu hiệu chậm nói rõ rệt, cần đưa trẻ đến gặp bác sĩ hoặc chuyên gia ngôn ngữ trị liệu để có phương pháp can thiệp phù hợp.</li>\r\n                            </ul>\r\n\r\n                            <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                            <p style=\"text-align: justify;\">Chậm phát triển ngôn ngữ không phải là vấn đề hiếm gặp, nhưng nếu không được can thiệp sớm, trẻ có thể gặp khó khăn trong học tập và giao tiếp sau này. Cha mẹ cần quan sát, đồng hành và hỗ trợ trẻ trong quá trình phát triển ngôn ngữ để giúp con có một nền tảng vững chắc trong tương lai.</p>", new DateTime(2025, 4, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\8.svg", "/images/blog/8.svg", true, "Trẻ Chậm Phát Triển Ngôn Ngữ: Nguyên Nhân, Dấu Hiệu Và Cách Hỗ Trợ", new DateTime(2025, 4, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 24 },
                    { 9, "Sưu Tầm", "<p style=\"text-align: justify; \">FPT Cần Thơ là một trong những cơ sở đào tạo uy tín tại khu vực Đồng bằng Sông Cửu Long, cung cấp chương trình giáo dục hiện đại, gắn liền với thực tiễn doanh nghiệp. Trường đào tạo đa dạng các ngành từ công nghệ, kinh tế đến truyền thông, giúp sinh viên phát triển toàn diện và sẵn sàng bước vào thị trường lao động.</p>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>1. Công Nghệ Thông Tin (CNTT)</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Ngành CNTT tại FPT Cần Thơ được thiết kế theo xu hướng công nghệ mới nhất, đảm bảo sinh viên có kiến thức vững vàng và kỹ năng thực hành chuyên sâu. Sinh viên có thể lựa chọn các chuyên ngành sau:</p>\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Kỹ thuật phần mềm:</strong> Tập trung vào phát triển ứng dụng, lập trình phần mềm, xây dựng hệ thống công nghệ.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Trí tuệ nhân tạo (AI):</strong> Nghiên cứu về máy học, dữ liệu lớn và các ứng dụng thông minh.</li>\r\n                            <li style=\"text-align: justify;\"><strong>An toàn thông tin:</strong> Đào tạo về bảo mật mạng, phòng chống tấn công mạng và an ninh dữ liệu.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>2. Quản Trị Kinh Doanh</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Ngành Quản trị kinh doanh trang bị cho sinh viên kiến thức về quản lý, tài chính, chiến lược kinh doanh và khởi nghiệp. Một số chuyên ngành tiêu biểu:</p>\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Quản trị doanh nghiệp:</strong> Học về vận hành, quản lý doanh nghiệp và phát triển kinh doanh.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Marketing số:</strong> Tập trung vào tiếp thị trực tuyến, quảng cáo kỹ thuật số và xây dựng thương hiệu.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Quản trị chuỗi cung ứng:</strong> Phát triển kỹ năng về logistics, quản lý kho vận và vận hành chuỗi cung ứng.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>3. Truyền Thông Đa Phương Tiện</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Đây là ngành học kết hợp giữa công nghệ, sáng tạo và truyền thông. Sinh viên được học về thiết kế đồ họa, sản xuất nội dung số, dựng phim và marketing truyền thông.</p>\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Thiết kế đồ họa:</strong> Chuyên sâu về thiết kế nhận diện thương hiệu, sáng tạo nội dung trực quan.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Quay dựng video:</strong> Học về sản xuất video, dựng phim và sáng tạo nội dung truyền thông.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Quảng cáo &amp; truyền thông số:</strong> Kết hợp công nghệ và sáng tạo trong chiến lược truyền thông.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>4. Ngôn Ngữ Anh</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Chương trình Ngôn ngữ Anh tại FPT Cần Thơ không chỉ giúp sinh viên thành thạo tiếng Anh mà còn trang bị kỹ năng làm việc trong môi trường quốc tế.</p>\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Tiếng Anh thương mại:</strong> Ứng dụng tiếng Anh trong lĩnh vực kinh doanh, đàm phán và giao tiếp.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Tiếng Anh giảng dạy:</strong> Đào tạo kỹ năng giảng dạy tiếng Anh và phương pháp truyền đạt hiệu quả.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>5. Thiết Kế Mỹ Thuật Số</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Ngành học dành cho những ai đam mê sáng tạo, kết hợp nghệ thuật và công nghệ trong thiết kế đa phương tiện.</p>\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Thiết kế đồ họa:</strong> Học về UI/UX, sáng tạo hình ảnh và truyền thông thị giác.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Hoạt hình kỹ thuật số:</strong> Sản xuất phim hoạt hình, mô hình 3D và hiệu ứng kỹ thuật số.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">FPT Cần Thơ mang đến chương trình đào tạo chất lượng cao, giúp sinh viên có được nền tảng kiến thức vững chắc và kỹ năng thực hành chuyên sâu. Với sự kết hợp giữa lý thuyết và thực tế, sinh viên sẽ có nhiều cơ hội nghề nghiệp rộng mở ngay sau khi tốt nghiệp.</p>", new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\9.svg", "/images/blog/9.svg", true, "Các Ngành Đào Tạo Tại FPT Cần Thơ – Cơ Hội Học Tập Và Phát Triển Nghề Nghiệp", new DateTime(2025, 5, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 10 },
                    { 10, "Sưu Tầm", "<p style=\"text-align: justify; \">Giao tiếp là một phần quan trọng trong cuộc sống, nhưng không phải ai cũng có thể diễn đạt ý muốn bằng lời nói. Đối với trẻ tự kỷ và những người gặp khó khăn về ngôn ngữ, phương pháp AAC (Augmentative and Alternative Communication) đã trở thành một công cụ hỗ trợ hiệu quả. Đó chính là lý do vì sao ứng dụng <strong>I Want</strong> ra đời – một ứng dụng kết hợp giữa công nghệ hỗ trợ giao tiếp và trò chơi giáo dục, giúp trẻ vừa học vừa chơi một cách tự nhiên.</p>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>1. I Want là gì?</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>I Want</strong> là một ứng dụng trò chơi được thiết kế đặc biệt dành cho trẻ tự kỷ và những người gặp khó khăn trong giao tiếp. Ứng dụng tích hợp phương pháp AAC giúp trẻ sử dụng hình ảnh và thẻ từ để tạo câu, đồng thời cung cấp nhiều trò chơi hấp dẫn giúp phát triển tư duy và kỹ năng vận động.</p>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>2. Các tính năng nổi bật của I Want</strong></p>\r\n\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Hỗ trợ giao tiếp bằng thẻ từ:</strong> Trẻ có thể chọn các từ được hiển thị dưới dạng hình ảnh để ghép thành câu hoàn chỉnh.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Chức năng đọc to:</strong> Khi hoàn thành một câu, ứng dụng sẽ đọc to nội dung, giúp trẻ cải thiện khả năng phát âm và giao tiếp.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Trò chơi giáo dục:</strong> Bao gồm các trò chơi như kéo thả đồ vật, nối điểm, tô màu, xếp tháp và thả hoa quả, giúp trẻ phát triển tư duy logic và kỹ năng vận động.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Giao diện thân thiện:</strong> Thiết kế đơn giản, dễ sử dụng với màu sắc sinh động phù hợp với trẻ nhỏ.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>3. Vì sao I Want đặc biệt?</strong></p>\r\n\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Kết hợp giao tiếp và giải trí:</strong> Không chỉ là một công cụ AAC, ứng dụng còn mang đến trải nghiệm học tập thông qua các trò chơi thú vị.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Giúp trẻ tự tin hơn:</strong> Khi có thể diễn đạt suy nghĩ, trẻ sẽ cảm thấy tự tin hơn trong giao tiếp hàng ngày.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Phù hợp với nhiều đối tượng:</strong> Không chỉ dành cho trẻ tự kỷ, ứng dụng còn hữu ích cho những người gặp khó khăn trong ngôn ngữ do các vấn đề về phát triển.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>4. Công nghệ sử dụng trong I Want</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\">Ứng dụng được phát triển dựa trên các công nghệ tiên tiến:</p>\r\n\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>ASP .NET Core (.NET 8):</strong> Hỗ trợ xây dựng API mạnh mẽ, đảm bảo hiệu suất và bảo mật cao.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Unity:</strong> Công cụ phát triển trò chơi mạnh mẽ giúp tạo ra trải nghiệm sinh động và hấp dẫn.</li>\r\n                            <li style=\"text-align: justify;\"><strong>SQL Server 2022:</strong> Quản lý dữ liệu người dùng, đảm bảo tính ổn định và bảo mật.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>5. Ai có thể sử dụng I Want?</strong></p>\r\n\r\n                        <ul>\r\n                            <li style=\"text-align: justify;\"><strong>Trẻ tự kỷ và trẻ gặp khó khăn về ngôn ngữ:</strong> Ứng dụng giúp trẻ học cách giao tiếp thông qua hình ảnh và âm thanh.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Phụ huynh:</strong> Công cụ hỗ trợ cha mẹ trong việc giúp con phát triển kỹ năng giao tiếp.</li>\r\n                            <li style=\"text-align: justify;\"><strong>Giáo viên và chuyên gia trị liệu:</strong> Có thể sử dụng ứng dụng như một công cụ bổ trợ trong quá trình giảng dạy và trị liệu.</li>\r\n                        </ul>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>Kết luận</strong></p>\r\n\r\n                        <p style=\"text-align: justify;\"><strong>I Want</strong> không chỉ là một ứng dụng giải trí mà còn là một công cụ hỗ trợ giáo dục và giao tiếp hiệu quả cho trẻ tự kỷ. Với sự kết hợp giữa phương pháp AAC và các trò chơi tương tác, ứng dụng này mang đến cho trẻ một cách học tập mới mẻ, giúp trẻ phát triển kỹ năng ngôn ngữ một cách tự nhiên và thú vị.</p>", new DateTime(2025, 5, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), "wwwroot\\images\\blog\\10.png", "/images/blog/10.png", true, "I Want – Ứng Dụng Hỗ Trợ Giao Tiếp Cho Trẻ Tự Kỷ Thông Qua AAC", new DateTime(2025, 5, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 17 }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "UserId", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5051), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5051), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chải Tóc", 2 },
                    { 2, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5053), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5054), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đánh Răng", 2 },
                    { 3, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5056), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5056), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đóng", 2 },
                    { 4, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5058), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5059), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Uống", 2 },
                    { 5, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5061), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5061), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ăn", 2 },
                    { 6, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5063), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5063), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhìn", 2 },
                    { 7, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5065), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5066), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tắt", 2 },
                    { 8, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5068), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5068), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bật", 2 },
                    { 9, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5070), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5071), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mở", 2 },
                    { 10, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5072), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5073), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chơi", 2 },
                    { 11, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5075), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5075), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mặc Vào", 2 },
                    { 12, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5077), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5077), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chạy", 2 },
                    { 13, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5079), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5080), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngồi", 2 },
                    { 14, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5081), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5082), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngủ", 2 },
                    { 15, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5084), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5084), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đứng", 2 },
                    { 16, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5086), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5086), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bơi", 2 },
                    { 17, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5095), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5096), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cởi Ra", 2 },
                    { 18, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5098), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5098), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nói Chuyện", 2 },
                    { 19, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5100), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5100), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Thức Dậy", 2 },
                    { 20, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5102), "Go", "images/word/actions/Go.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5103), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đi", 2 },
                    { 21, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5104), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5105), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Rửa Tay", 2 },
                    { 22, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5137), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5137), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ong", 3 },
                    { 23, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5139), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5139), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chim", 3 },
                    { 24, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5141), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5142), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bướm", 3 },
                    { 25, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5143), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5144), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mèo", 3 },
                    { 26, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5146), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5146), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Gà", 3 },
                    { 27, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5148), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5149), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bò", 3 },
                    { 28, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5150), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5151), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chó", 3 },
                    { 29, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5153), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5153), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Vịt", 3 },
                    { 30, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5155), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5155), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cá", 3 },
                    { 31, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5157), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5158), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngựa", 3 },
                    { 32, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5159), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5160), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chuột", 3 },
                    { 33, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5162), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5162), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Heo", 3 },
                    { 34, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5188), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5188), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cánh tay", 4 },
                    { 35, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5190), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5191), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Lưng", 4 },
                    { 36, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5193), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5194), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bụng", 4 },
                    { 37, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5196), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5196), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mông", 4 },
                    { 38, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5198), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5198), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tai", 4 },
                    { 39, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5200), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5200), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mắt", 4 },
                    { 40, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5202), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5203), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khuôn mặt", 4 },
                    { 41, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5205), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5205), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngón tay", 4 },
                    { 42, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5207), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5208), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bàn chân", 4 },
                    { 43, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5210), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5210), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tóc", 4 },
                    { 44, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5212), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5212), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bàn tay", 4 },
                    { 45, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5214), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5214), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chân", 4 },
                    { 46, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5216), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5217), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Môi", 4 },
                    { 47, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5218), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5219), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mũi", 4 },
                    { 48, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5221), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5221), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Răng", 4 },
                    { 49, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5223), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5223), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Họng", 4 },
                    { 50, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5226), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5226), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngón chân", 4 },
                    { 51, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5228), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5228), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Lưỡi", 4 },
                    { 52, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5253), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5253), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ba lô", 5 },
                    { 53, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5255), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5256), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mũ lưỡi trai", 5 },
                    { 54, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5257), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5258), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Áo khoác", 5 },
                    { 55, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5259), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5260), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồ ngủ", 5 },
                    { 56, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5262), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5262), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Quần dài", 5 },
                    { 57, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5264), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5264), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khăn quàng cổ", 5 },
                    { 58, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5266), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5266), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Áo sơ mi", 5 },
                    { 59, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5268), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5268), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Giày", 5 },
                    { 60, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5270), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5271), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Quần short", 5 },
                    { 61, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5272), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5273), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Váy ngắn", 5 },
                    { 62, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5275), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5276), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tất", 5 },
                    { 63, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5277), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5278), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Áo len", 5 },
                    { 64, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5280), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5280), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồ bơi", 5 },
                    { 65, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5282), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5282), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Áo phông", 5 },
                    { 66, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5284), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5284), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồ lót", 5 },
                    { 67, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5316), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5316), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu đen", 6 },
                    { 68, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5318), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5318), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu xanh dương", 6 },
                    { 69, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5320), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5321), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu xanh lá", 6 },
                    { 70, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5322), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5323), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu cam", 6 },
                    { 71, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5325), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5325), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu hồng", 6 },
                    { 72, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5327), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5327), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu đỏ", 6 },
                    { 73, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5329), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5329), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu tím", 6 },
                    { 74, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5331), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5332), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu trắng", 6 },
                    { 75, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5334), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5334), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Màu vàng", 6 },
                    { 76, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5355), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5355), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồng ý", 7 },
                    { 77, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5357), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5357), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tức giận", 7 },
                    { 78, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5359), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5360), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chán nản", 7 },
                    { 79, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5361), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5362), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Không đồng ý", 7 },
                    { 80, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5364), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5364), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xấu hổ", 7 },
                    { 81, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5366), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5366), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Vui vẻ", 7 },
                    { 82, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5368), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5368), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đói", 7 },
                    { 83, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5370), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5371), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đau", 7 },
                    { 84, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5372), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5373), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Không hiểu", 7 },
                    { 85, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5374), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5375), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Buồn", 7 },
                    { 86, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5377), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5377), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sợ hãi", 7 },
                    { 87, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5379), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5379), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ốm", 7 },
                    { 88, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5382), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5382), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Buồn ngủ", 7 },
                    { 89, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5384), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5384), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khát", 7 },
                    { 90, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5386), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5387), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mệt mỏi", 7 },
                    { 91, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5393), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5393), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nôn mửa", 7 },
                    { 92, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5395), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5395), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ghê tởm", 7 },
                    { 93, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5397), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5397), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngon miệng", 7 },
                    { 94, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5422), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5423), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bánh mì", 8 },
                    { 95, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5424), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5425), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bánh kem", 8 },
                    { 96, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5427), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5427), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sô cô la", 8 },
                    { 97, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5429), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5429), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bánh quy", 8 },
                    { 98, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5431), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5432), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Kẹo cao su", 8 },
                    { 99, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5433), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5434), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bánh hamburger", 8 },
                    { 100, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5436), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5436), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Kem", 8 },
                    { 101, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5439), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5439), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nước ép", 8 },
                    { 102, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5441), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5441), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sữa", 8 },
                    { 103, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5443), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5444), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Pizza", 8 },
                    { 104, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5445), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5446), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cơm", 8 },
                    { 105, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5448), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5448), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bánh sandwich", 8 },
                    { 106, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5450), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5450), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồ ăn vặt", 8 },
                    { 107, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5452), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5452), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Súp", 8 },
                    { 108, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5454), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5454), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mì Ý", 8 },
                    { 109, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5456), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5457), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Trà", 8 },
                    { 110, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5458), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5459), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nước", 8 },
                    { 111, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5460), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5461), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sữa chua", 8 },
                    { 112, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5486), "Apple", "images/word/fruits/Apple.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5487), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Táo", 9 },
                    { 113, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5488), "Avocado", "images/word/fruits/Avocado.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5489), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bơ", 9 },
                    { 114, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5491), "Banana", "images/word/fruits/Banana.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5491), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chuối", 9 },
                    { 115, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5493), "Dragon Fruit", "images/word/fruits/Dragon Fruit.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5493), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Thanh long", 9 },
                    { 116, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5495), "Grape", "images/word/fruits/Grape.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5495), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nho", 9 },
                    { 117, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5497), "Guava", "images/word/fruits/Guava.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5498), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ổi", 9 },
                    { 118, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5499), "Kiwi", "images/word/fruits/Kiwi.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5500), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Kiwi", 9 },
                    { 119, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5501), "Orange", "images/word/fruits/Orange.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5502), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cam", 9 },
                    { 120, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5504), "Peach", "images/word/fruits/Peace.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5504), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đào", 9 },
                    { 121, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5506), "Pineapple", "images/word/fruits/Pineapple.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5506), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Dứa", 9 },
                    { 122, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5508), "Strawberry", "images/word/fruits/Strawberry.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5509), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Dâu tây", 9 },
                    { 123, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5510), "Watermelon", "images/word/fruits/Watermelon.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5511), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Dưa hấu", 9 },
                    { 124, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5533), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5533), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Một", 10 },
                    { 125, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5535), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5536), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Hai", 10 },
                    { 126, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5538), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5539), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ba", 10 },
                    { 127, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5540), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5541), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bốn", 10 },
                    { 128, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5553), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5553), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Năm", 10 },
                    { 129, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5555), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5556), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sáu", 10 },
                    { 130, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5557), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5558), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bảy", 10 },
                    { 131, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5560), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5560), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tám", 10 },
                    { 132, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5562), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5562), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chín", 10 },
                    { 133, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5564), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5564), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mười", 10 },
                    { 134, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5588), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5588), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Lại lần nữa", 11 },
                    { 135, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5590), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5591), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Em bé", 11 },
                    { 136, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5593), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5593), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cậu bé", 11 },
                    { 137, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5595), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5595), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bố", 11 },
                    { 138, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5597), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5597), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mọi người", 11 },
                    { 139, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5600), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5600), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cô bé", 11 },
                    { 140, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5602), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5603), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bà", 11 },
                    { 141, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5604), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5605), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ông", 11 },
                    { 142, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5606), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5607), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bao nhiêu tiền", 11 },
                    { 143, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5609), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5609), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mẹ", 11 },
                    { 144, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5611), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5611), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Anh trai", 11 },
                    { 145, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5613), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5613), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Chị gái", 11 },
                    { 146, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5615), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5615), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cái gì", 11 },
                    { 147, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5617), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5618), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khi nào", 11 },
                    { 148, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5619), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5620), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ở đâu", 11 },
                    { 149, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5621), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5622), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cái nào", 11 },
                    { 150, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5624), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5624), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ai", 11 },
                    { 151, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5626), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5627), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tại sao", 11 },
                    { 152, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5628), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5629), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Em trai", 11 },
                    { 153, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5630), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5631), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Em gái", 11 },
                    { 154, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5633), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5633), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mấy giờ", 11 },
                    { 155, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5660), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5660), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Thủy cung", 12 },
                    { 156, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5662), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5663), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Phòng tắm", 12 },
                    { 157, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5664), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5665), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Phòng ngủ", 12 },
                    { 158, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5667), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5667), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bệnh viện", 12 },
                    { 159, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5669), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5669), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngôi nhà", 12 },
                    { 160, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5671), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5671), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhà bếp", 12 },
                    { 161, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5673), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5673), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Phòng khách", 12 },
                    { 162, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5675), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5675), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Công viên", 12 },
                    { 163, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5677), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5678), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Trường học", 12 },
                    { 164, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5679), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5680), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Siêu thị", 12 },
                    { 165, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5686), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5686), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhà vệ sinh", 12 },
                    { 166, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5688), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5688), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Sở thú", 12 },
                    { 167, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5709), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5710), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Lại lần nữa", 13 },
                    { 168, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5712), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5712), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bao nhiêu tiền", 13 },
                    { 169, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5714), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5714), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mấy giờ", 13 },
                    { 170, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5716), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5716), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cái gì", 13 },
                    { 171, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5718), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5719), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khi nào", 13 },
                    { 172, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5721), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5721), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ở đâu", 13 },
                    { 173, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5723), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5724), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cái nào", 13 },
                    { 174, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5726), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5726), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ai", 13 },
                    { 175, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5728), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5729), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tại sao", 13 },
                    { 176, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5752), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5752), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ở trên", 14 },
                    { 177, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5755), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 298, DateTimeKind.Local).AddTicks(5756), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Phía sau", 14 },
                    { 178, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3855), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3855), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ở dưới", 14 },
                    { 179, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3862), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3862), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ít", 14 },
                    { 180, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3864), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3865), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nặng", 14 },
                    { 181, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3867), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3867), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cao", 14 },
                    { 182, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3876), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3877), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Phía trước", 14 },
                    { 183, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3879), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3879), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ở trong", 14 },
                    { 184, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3881), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3881), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Lớn", 14 },
                    { 185, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3883), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3884), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhẹ", 14 },
                    { 186, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3885), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3886), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Dài", 14 },
                    { 187, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3888), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3888), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Thấp", 14 },
                    { 188, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3890), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3890), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhiều", 14 },
                    { 189, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3892), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3893), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bên ngoài", 14 },
                    { 190, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3896), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3896), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngắn", 14 },
                    { 191, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3898), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3899), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Nhỏ", 14 },
                    { 192, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3900), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3901), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Dày", 14 },
                    { 193, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3903), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(3903), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mỏng", 14 },
                    { 194, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4067), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4068), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Buổi chiều", 15 },
                    { 195, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4070), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4071), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Buổi tối", 15 },
                    { 196, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4072), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4073), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Buổi sáng", 15 },
                    { 197, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4075), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4075), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ban đêm", 15 },
                    { 198, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4077), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4077), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Một giờ", 15 },
                    { 199, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4079), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4079), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Mười phút", 15 },
                    { 200, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4081), "Thirty Minutes", "images/word/time/Thirdty Minutes.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4082), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ba mươi phút", 15 },
                    { 201, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4083), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4084), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Hôm nay", 15 },
                    { 202, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4085), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4086), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ngày mai", 15 },
                    { 203, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4088), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4089), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Hôm qua", 15 },
                    { 204, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4112), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4112), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bóng", 16 },
                    { 205, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4114), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4114), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bóng bay", 16 },
                    { 206, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4116), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4117), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Gấu bông", 16 },
                    { 207, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4119), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4119), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Khối xếp hình", 16 },
                    { 208, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4121), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4122), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cờ bàn", 16 },
                    { 209, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4123), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4124), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bong bóng xà phòng", 16 },
                    { 210, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4125), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4126), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xe hơi", 16 },
                    { 211, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4128), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4128), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đất nặn", 16 },
                    { 212, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4130), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4130), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tô màu", 16 },
                    { 213, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4132), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4132), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Bút màu", 16 },
                    { 214, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4134), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4135), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Búp bê", 16 },
                    { 215, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4136), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4137), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Diều", 16 },
                    { 216, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4139), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4140), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Trò chơi ghép hình", 16 },
                    { 217, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4141), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4142), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tivi", 16 },
                    { 218, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4144), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4144), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Đồ chơi", 16 },
                    { 219, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4169), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4169), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Máy bay", 17 },
                    { 220, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4172), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4172), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xe đạp", 17 },
                    { 221, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4174), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4174), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xe buýt", 17 },
                    { 222, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4176), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4176), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xe hơi", 17 },
                    { 223, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4178), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4179), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xe máy", 17 },
                    { 224, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4181), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4181), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Tàu thủy", 17 },
                    { 225, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4200), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4200), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Ôm", 18 },
                    { 226, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4202), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4203), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Con không muốn", 18 },
                    { 227, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4204), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4205), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Con muốn", 18 },
                    { 228, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4207), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4207), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Không", 18 },
                    { 229, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4209), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4209), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xin lỗi", 18 },
                    { 230, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4211), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4211), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Cảm ơn", 18 },
                    { 231, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4213), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4214), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Có", 18 },
                    { 232, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4233), "Mango", "images/word/fruits/Mango.png", true, new DateTime(2025, 3, 24, 17, 32, 32, 302, DateTimeKind.Local).AddTicks(4234), "0bcbb4f7-72f9-435f-9cb3-1621b4503974", "Xoài", 9 }
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
                name: "IX_Feedbacks_BlogId",
                table: "Feedbacks",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
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
                name: "IX_Rates_BlogId",
                table: "Rates",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_UserId",
                table: "Rates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_UserId",
                table: "Words",
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
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Messages");

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
