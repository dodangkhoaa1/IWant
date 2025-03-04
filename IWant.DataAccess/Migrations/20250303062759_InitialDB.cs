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
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, new DateOnly(2003, 11, 24), new DateOnly(1, 1, 1), null, null, null, "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", true, "Hồ Minh Nhật", true, "default-avatar.png", "http://localhost:5130/images/avatar/default-avatar.png", true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Name", "VideoUrl" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Dot Connection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Coloring", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "AAC", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Emotion Selection", "https://www.youtube.com/watch?v=ynJ_nraLqU4" },
                    { 5, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "Fruit Drop", "https://www.youtube.com/watch?v=ynJ_nraLqU4" }
                });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9495), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9495), "Hành Động" },
                    { 2, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9499), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9499), "Động Vật" },
                    { 3, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9501), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9502), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9503), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9504), "Quần Áo" },
                    { 5, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9505), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9506), "Màu Sắc" },
                    { 6, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9508), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9508), "Cảm Xúc" },
                    { 7, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9509), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9510), "Thức Ăn" },
                    { 8, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9511), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9512), "Trái Cây" },
                    { 9, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9513), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9514), "Con Số" },
                    { 10, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9515), "People", "images/wordCategories/People.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9516), "Con Người" },
                    { 11, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9518), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9518), "Địa Điểm" },
                    { 12, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9520), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9520), "Câu Hỏi" },
                    { 13, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9522), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9522), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9524), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9524), "Thời Gian" },
                    { 15, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9526), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9526), "Đồ Chơi" },
                    { 16, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9528), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9528), "Phương Tiện" },
                    { 17, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9530), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9530), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9563), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9564), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9566), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9566), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9568), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9569), "Đóng", 1 },
                    { 4, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9571), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9571), "Uống", 1 },
                    { 5, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9573), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9573), "Ăn", 1 },
                    { 6, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9575), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9575), "Nhìn", 1 },
                    { 7, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9577), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9578), "Tắt", 1 },
                    { 8, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9579), "On", "images/word/actions/On.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9580), "Bật", 1 },
                    { 9, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9582), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9582), "Mở", 1 },
                    { 10, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9584), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9584), "Chơi", 1 },
                    { 11, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9586), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9586), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9588), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9588), "Chạy", 1 },
                    { 13, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9590), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9591), "Ngồi", 1 },
                    { 14, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9593), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9594), "Ngủ", 1 },
                    { 15, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9595), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9596), "Đứng", 1 },
                    { 16, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9597), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9598), "Bơi", 1 },
                    { 17, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9600), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9600), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9602), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9602), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9604), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9605), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9606), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9607), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9608), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9609), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9636), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9637), "Ong", 2 },
                    { 23, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9639), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9639), "Chim", 2 },
                    { 24, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9641), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9641), "Bướm", 2 },
                    { 25, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9643), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9643), "Mèo", 2 },
                    { 26, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9646), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9647), "Gà", 2 },
                    { 27, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9648), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9649), "Bò", 2 },
                    { 28, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9650), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9651), "Chó", 2 },
                    { 29, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9652), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9653), "Vịt", 2 },
                    { 30, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9655), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9655), "Cá", 2 },
                    { 31, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9657), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9657), "Ngựa", 2 },
                    { 32, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9659), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9659), "Chuột", 2 },
                    { 33, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9661), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9661), "Heo", 2 },
                    { 34, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9681), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9682), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9684), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9684), "Lưng", 3 },
                    { 36, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9686), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9686), "Bụng", 3 },
                    { 37, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9688), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9688), "Mông", 3 },
                    { 38, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9690), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9691), "Tai", 3 },
                    { 39, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9693), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9694), "Mắt", 3 },
                    { 40, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9695), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9696), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9698), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9698), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9700), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9700), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9702), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9702), "Tóc", 3 },
                    { 44, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9704), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9705), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9706), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9707), "Chân", 3 },
                    { 46, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9709), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9709), "Môi", 3 },
                    { 47, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9711), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9711), "Mũi", 3 },
                    { 48, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9713), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9714), "Răng", 3 },
                    { 49, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9721), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9721), "Họng", 3 },
                    { 50, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9723), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9723), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9725), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9725), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9748), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9748), "Ba lô", 4 },
                    { 53, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9750), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9751), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9752), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9753), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9755), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9755), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9757), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9757), "Quần dài", 4 },
                    { 57, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9759), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9759), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9761), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9762), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9763), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9764), "Giày", 4 },
                    { 60, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9765), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9766), "Quần short", 4 },
                    { 61, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9768), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9768), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9770), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9770), "Tất", 4 },
                    { 63, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9772), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9772), "Áo len", 4 },
                    { 64, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9775), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9775), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9777), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9777), "Áo phông", 4 },
                    { 66, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9779), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9780), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9801), "Black", "images/word/color/Black.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9801), "Màu đen", 5 },
                    { 68, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9803), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9804), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9805), "Green", "images/word/color/Green.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9806), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9808), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9808), "Màu cam", 5 },
                    { 71, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9810), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9810), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9812), "Red", "images/word/color/Red.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9812), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9814), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9814), "Màu tím", 5 },
                    { 74, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9816), "White", "images/word/color/White.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9816), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9818), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9818), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9835), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9836), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9838), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9838), "Tức giận", 6 },
                    { 78, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9840), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9840), "Chán nản", 6 },
                    { 79, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9842), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9842), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9844), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9844), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9846), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9846), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9848), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9848), "Đói", 6 },
                    { 83, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9850), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9851), "Đau", 6 },
                    { 84, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9852), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9853), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9854), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9855), "Buồn", 6 },
                    { 86, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9857), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9857), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9859), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9859), "Ốm", 6 },
                    { 88, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9861), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9861), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9864), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9865), "Khát", 6 },
                    { 90, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9867), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9867), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9869), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9869), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9871), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9871), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9873), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9873), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9896), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9896), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9898), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9899), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9901), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9901), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9903), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9904), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9905), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9906), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9908), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9908), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9910), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9910), "Kem", 7 },
                    { 101, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9912), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9912), "Nước ép", 7 },
                    { 102, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9915), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9915), "Sữa", 7 },
                    { 103, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9917), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9917), "Pizza", 7 },
                    { 104, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9919), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9919), "Cơm", 7 },
                    { 105, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9921), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9922), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9923), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9924), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9925), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9926), "Súp", 7 },
                    { 108, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9928), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9928), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9930), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9930), "Trà", 7 },
                    { 110, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9932), "Water", "images/word/food/Water.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9932), "Nước", 7 },
                    { 111, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9934), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9934), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9956), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9956), "Táo", 8 },
                    { 113, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9958), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9958), "Bơ", 8 },
                    { 114, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9960), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9960), "Chuối", 8 },
                    { 115, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9962), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9963), "Thanh long", 8 },
                    { 116, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9964), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9965), "Nho", 8 },
                    { 117, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9966), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9967), "Ổi", 8 },
                    { 118, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9974), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9974), "Kiwi", 8 },
                    { 119, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9976), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9976), "Cam", 8 },
                    { 120, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9978), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9978), "Đào", 8 },
                    { 121, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9980), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9981), "Dứa", 8 },
                    { 122, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9982), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9983), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9984), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 873, DateTimeKind.Local).AddTicks(9985), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(3), "One", "images/word/number/One.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(4), "Một", 9 },
                    { 125, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(6), "Two", "images/word/number/Two.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(6), "Hai", 9 },
                    { 126, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(8), "Three", "images/word/number/Three.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(8), "Ba", 9 },
                    { 127, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(10), "Four", "images/word/number/Four.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(11), "Bốn", 9 },
                    { 128, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(13), "Five", "images/word/number/Five.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(13), "Năm", 9 },
                    { 129, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(15), "Six", "images/word/number/Six.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(16), "Sáu", 9 },
                    { 130, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(17), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(18), "Bảy", 9 },
                    { 131, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(20), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(20), "Tám", 9 },
                    { 132, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(22), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(22), "Chín", 9 },
                    { 133, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(24), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(24), "Mười", 9 },
                    { 134, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(43), "Again", "images/word/people/Again.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(44), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(46), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(46), "Em bé", 10 },
                    { 136, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(48), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(48), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(50), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(50), "Bố", 10 },
                    { 138, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(52), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(53), "Mọi người", 10 },
                    { 139, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(54), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(55), "Cô bé", 10 },
                    { 140, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(57), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(58), "Bà", 10 },
                    { 141, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(60), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(60), "Ông", 10 },
                    { 142, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(62), "How much", "images/word/people/How much.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(62), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(64), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(64), "Mẹ", 10 },
                    { 144, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(66), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(66), "Anh trai", 10 },
                    { 145, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(68), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(68), "Chị gái", 10 },
                    { 146, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(70), "What", "images/word/people/What.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(71), "Cái gì", 10 },
                    { 147, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(72), "When", "images/word/people/When.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(73), "Khi nào", 10 },
                    { 148, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(75), "Where", "images/word/people/Where.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(75), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(77), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(77), "Cái nào", 10 },
                    { 150, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(79), "Who", "images/word/people/Who.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(79), "Ai", 10 },
                    { 151, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(81), "Why", "images/word/people/Why.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(81), "Tại sao", 10 },
                    { 152, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(83), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(84), "Em trai", 10 },
                    { 153, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(86), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(86), "Em gái", 10 },
                    { 154, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(88), "What time", "images/word/people/What time.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(89), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(112), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(112), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(114), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(114), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(116), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(117), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(118), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(119), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(121), "House", "images/word/places/House.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(121), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(123), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(123), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(125), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(125), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(127), "Park", "images/word/places/Park.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(127), "Công viên", 11 },
                    { 163, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(129), "School", "images/word/places/School.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(130), "Trường học", 11 },
                    { 164, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(131), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(132), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(134), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(134), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(137), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(137), "Sở thú", 11 },
                    { 167, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(155), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(156), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(158), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(158), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(160), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(160), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(162), "What", "images/word/questions/What.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(162), "Cái gì", 12 },
                    { 171, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(164), "When", "images/word/questions/When.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(165), "Khi nào", 12 },
                    { 172, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(167), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(167), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(169), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(169), "Cái nào", 12 },
                    { 174, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(171), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(171), "Ai", 12 },
                    { 175, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(173), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(173), "Tại sao", 12 },
                    { 176, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(195), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(196), "Ở trên", 13 },
                    { 177, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(198), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(198), "Phía sau", 13 },
                    { 178, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(200), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(200), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(202), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(203), "Ít", 13 },
                    { 180, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(204), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(205), "Nặng", 13 },
                    { 181, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(207), "High", "images/word/relations/High.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(207), "Cao", 13 },
                    { 182, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(209), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(209), "Phía trước", 13 },
                    { 183, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(211), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(211), "Ở trong", 13 },
                    { 184, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(213), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(213), "Lớn", 13 },
                    { 185, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(215), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(216), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(217), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(218), "Dài", 13 },
                    { 187, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(219), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(220), "Thấp", 13 },
                    { 188, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(222), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(222), "Nhiều", 13 },
                    { 189, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(224), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(224), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(226), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(226), "Ngắn", 13 },
                    { 191, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(229), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(229), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(231), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(231), "Dày", 13 },
                    { 193, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(233), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(233), "Mỏng", 13 },
                    { 194, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(254), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(254), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(256), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(257), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(259), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(259), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(261), "Night", "images/word/time/Night.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(261), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(263), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(263), "Một giờ", 14 },
                    { 199, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(265), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(266), "Mười phút", 14 },
                    { 200, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(267), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(268), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(269), "Today", "images/word/time/Today.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(270), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(272), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(272), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(274), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(275), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(293), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(293), "Bóng", 15 },
                    { 205, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(295), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(296), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(297), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(298), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(300), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(300), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(302), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(302), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(304), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(304), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(306), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(306), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(308), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(308), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(310), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(311), "Tô màu", 15 },
                    { 213, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(312), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(313), "Bút màu", 15 },
                    { 214, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(314), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(315), "Búp bê", 15 },
                    { 215, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(317), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(317), "Diều", 15 },
                    { 216, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(320), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(320), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(322), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(322), "Tivi", 15 },
                    { 218, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(324), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(324), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(344), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(345), "Máy bay", 16 },
                    { 220, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(346), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(347), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(348), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(349), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(351), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(351), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(353), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(353), "Xe máy", 16 },
                    { 224, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(355), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(355), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(370), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(371), "Ôm", 17 },
                    { 226, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(372), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(373), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(375), "I want", "images/word/want/I want.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(375), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(378), "No", "images/word/want/No.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(378), "Không", 17 },
                    { 229, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(380), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(380), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(382), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(382), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(384), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 3, 3, 13, 27, 58, 874, DateTimeKind.Local).AddTicks(384), "Có", 17 }
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
