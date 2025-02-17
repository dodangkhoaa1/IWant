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
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8928), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8929), "Hành Động" },
                    { 2, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8931), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8931), "Động Vật" },
                    { 3, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8933), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8933), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8935), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8935), "Quần Áo" },
                    { 5, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8937), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8937), "Màu Sắc" },
                    { 6, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8939), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8940), "Cảm Xúc" },
                    { 7, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8941), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8942), "Thức Ăn" },
                    { 8, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8943), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8943), "Trái Cây" },
                    { 9, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8946), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8946), "Con Số" },
                    { 10, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8948), "People", "images/wordCategories/People.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8948), "Con Người" },
                    { 11, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8950), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8950), "Địa Điểm" },
                    { 12, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8952), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8952), "Câu Hỏi" },
                    { 13, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8954), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8954), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8956), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8956), "Thời Gian" },
                    { 15, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8958), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8958), "Đồ Chơi" },
                    { 16, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8960), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8960), "Phương Tiện" },
                    { 17, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8962), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(8962), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9006), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9007), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9009), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9009), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9011), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9012), "Đóng", 1 },
                    { 4, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9013), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9014), "Uống", 1 },
                    { 5, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9016), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9016), "Ăn", 1 },
                    { 6, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9019), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9019), "Nhìn", 1 },
                    { 7, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9021), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9021), "Tắt", 1 },
                    { 8, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9023), "On", "images/word/actions/On.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9023), "Bật", 1 },
                    { 9, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9025), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9025), "Mở", 1 },
                    { 10, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9027), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9027), "Chơi", 1 },
                    { 11, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9029), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9030), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9031), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9032), "Chạy", 1 },
                    { 13, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9033), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9034), "Ngồi", 1 },
                    { 14, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9035), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9036), "Ngủ", 1 },
                    { 15, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9038), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9038), "Đứng", 1 },
                    { 16, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9040), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9040), "Bơi", 1 },
                    { 17, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9042), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9042), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9044), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9044), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9047), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9047), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9049), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9049), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9051), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9052), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9082), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9082), "Ong", 2 },
                    { 23, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9084), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9084), "Chim", 2 },
                    { 24, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9087), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9087), "Bướm", 2 },
                    { 25, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9089), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9089), "Mèo", 2 },
                    { 26, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9091), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9091), "Gà", 2 },
                    { 27, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9093), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9093), "Bò", 2 },
                    { 28, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9095), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9095), "Chó", 2 },
                    { 29, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9097), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9097), "Vịt", 2 },
                    { 30, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9099), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9100), "Cá", 2 },
                    { 31, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9101), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9102), "Ngựa", 2 },
                    { 32, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9104), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9105), "Chuột", 2 },
                    { 33, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9106), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9107), "Heo", 2 },
                    { 34, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9129), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9130), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9131), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9132), "Lưng", 3 },
                    { 36, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9134), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9134), "Bụng", 3 },
                    { 37, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9136), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9137), "Mông", 3 },
                    { 38, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9144), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9144), "Tai", 3 },
                    { 39, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9147), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9147), "Mắt", 3 },
                    { 40, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9151), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9151), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9153), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9154), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9157), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9158), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9159), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9160), "Tóc", 3 },
                    { 44, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9162), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9162), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9164), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9164), "Chân", 3 },
                    { 46, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9166), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9166), "Môi", 3 },
                    { 47, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9168), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9168), "Mũi", 3 },
                    { 48, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9170), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9170), "Răng", 3 },
                    { 49, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9172), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9172), "Họng", 3 },
                    { 50, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9174), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9175), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9176), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9177), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9199), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9199), "Ba lô", 4 },
                    { 53, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9201), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9201), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9203), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9204), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9206), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9206), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9208), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9208), "Quần dài", 4 },
                    { 57, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9211), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9211), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9213), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9213), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9215), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9215), "Giày", 4 },
                    { 60, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9217), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9217), "Quần short", 4 },
                    { 61, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9219), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9219), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9221), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9223), "Tất", 4 },
                    { 63, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9224), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9225), "Áo len", 4 },
                    { 64, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9226), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9227), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9228), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9229), "Áo phông", 4 },
                    { 66, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9230), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9231), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9259), "Black", "images/word/color/Black.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9260), "Màu đen", 5 },
                    { 68, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9262), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9262), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9264), "Green", "images/word/color/Green.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9264), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9267), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9267), "Màu cam", 5 },
                    { 71, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9269), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9269), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9271), "Red", "images/word/color/Red.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9271), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9273), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9273), "Màu tím", 5 },
                    { 74, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9275), "White", "images/word/color/White.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9275), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9277), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9278), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9297), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9297), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9299), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9299), "Tức giận", 6 },
                    { 78, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9301), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9301), "Chán nản", 6 },
                    { 79, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9303), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9303), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9305), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9305), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9307), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9308), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9310), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9311), "Đói", 6 },
                    { 83, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9312), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9313), "Đau", 6 },
                    { 84, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9314), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9315), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9316), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9317), "Buồn", 6 },
                    { 86, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9318), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9319), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9321), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9321), "Ốm", 6 },
                    { 88, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9323), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9324), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9326), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9327), "Khát", 6 },
                    { 90, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9328), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9329), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9330), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9331), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9333), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9334), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9336), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9336), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9360), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9360), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9363), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9363), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9365), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9366), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9368), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9368), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9371), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9372), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9379), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9380), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9382), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9383), "Kem", 7 },
                    { 101, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9385), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9385), "Nước ép", 7 },
                    { 102, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9387), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9387), "Sữa", 7 },
                    { 103, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9389), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9389), "Pizza", 7 },
                    { 104, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9391), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9391), "Cơm", 7 },
                    { 105, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9393), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9393), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9395), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9395), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9399), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9399), "Súp", 7 },
                    { 108, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9402), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9402), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9405), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9406), "Trà", 7 },
                    { 110, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9407), "Water", "images/word/food/Water.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9408), "Nước", 7 },
                    { 111, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9410), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9410), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9432), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9433), "Táo", 8 },
                    { 113, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9435), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9436), "Bơ", 8 },
                    { 114, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9438), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9438), "Chuối", 8 },
                    { 115, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9441), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9441), "Thanh long", 8 },
                    { 116, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9444), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9444), "Nho", 8 },
                    { 117, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9447), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9447), "Ổi", 8 },
                    { 118, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9449), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9450), "Kiwi", 8 },
                    { 119, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9452), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9452), "Cam", 8 },
                    { 120, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9456), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9456), "Đào", 8 },
                    { 121, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9458), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9458), "Dứa", 8 },
                    { 122, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9460), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9460), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9463), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9463), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9485), "One", "images/word/number/One.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9486), "Một", 9 },
                    { 125, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9488), "Two", "images/word/number/Two.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9489), "Hai", 9 },
                    { 126, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9493), "Three", "images/word/number/Three.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9493), "Ba", 9 },
                    { 127, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9496), "Four", "images/word/number/Four.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9496), "Bốn", 9 },
                    { 128, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9498), "Five", "images/word/number/Five.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9498), "Năm", 9 },
                    { 129, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9502), "Six", "images/word/number/Six.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9502), "Sáu", 9 },
                    { 130, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9505), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9505), "Bảy", 9 },
                    { 131, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9507), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9507), "Tám", 9 },
                    { 132, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9509), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9509), "Chín", 9 },
                    { 133, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9512), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9513), "Mười", 9 },
                    { 134, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9538), "Again", "images/word/people/Again.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9538), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9540), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9540), "Em bé", 10 },
                    { 136, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9542), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9542), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9544), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9544), "Bố", 10 },
                    { 138, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9546), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9546), "Mọi người", 10 },
                    { 139, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9548), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9548), "Cô bé", 10 },
                    { 140, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9550), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9551), "Bà", 10 },
                    { 141, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9552), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9553), "Ông", 10 },
                    { 142, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9555), "How much", "images/word/people/How much.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9555), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9557), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9558), "Mẹ", 10 },
                    { 144, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9559), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9560), "Anh trai", 10 },
                    { 145, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9562), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9562), "Chị gái", 10 },
                    { 146, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9564), "What", "images/word/people/What.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9564), "Cái gì", 10 },
                    { 147, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9566), "When", "images/word/people/When.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9566), "Khi nào", 10 },
                    { 148, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9568), "Where", "images/word/people/Where.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9568), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9570), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9570), "Cái nào", 10 },
                    { 150, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9572), "Who", "images/word/people/Who.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9572), "Ai", 10 },
                    { 151, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9574), "Why", "images/word/people/Why.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9574), "Tại sao", 10 },
                    { 152, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9576), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9576), "Em trai", 10 },
                    { 153, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9578), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9579), "Em gái", 10 },
                    { 154, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9580), "What time", "images/word/people/What time.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9581), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9605), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9605), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9607), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9608), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9609), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9610), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9612), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9612), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9614), "House", "images/word/places/House.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9614), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9616), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9616), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9618), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9618), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9620), "Park", "images/word/places/Park.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9621), "Công viên", 11 },
                    { 163, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9622), "School", "images/word/places/School.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9623), "Trường học", 11 },
                    { 164, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9624), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9625), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9626), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9627), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9629), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9629), "Sở thú", 11 },
                    { 167, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9650), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9650), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9652), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9652), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9655), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9657), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9659), "What", "images/word/questions/What.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9659), "Cái gì", 12 },
                    { 171, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9661), "When", "images/word/questions/When.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9661), "Khi nào", 12 },
                    { 172, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9663), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9663), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9666), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9666), "Cái nào", 12 },
                    { 174, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9668), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9668), "Ai", 12 },
                    { 175, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9670), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9670), "Tại sao", 12 },
                    { 176, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9688), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9688), "Ở trên", 13 },
                    { 177, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9690), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9691), "Phía sau", 13 },
                    { 178, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9692), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9693), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9695), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9695), "Ít", 13 },
                    { 180, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9697), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9697), "Nặng", 13 },
                    { 181, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9699), "High", "images/word/relations/High.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9699), "Cao", 13 },
                    { 182, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9701), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9701), "Phía trước", 13 },
                    { 183, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9703), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9704), "Ở trong", 13 },
                    { 184, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9706), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9706), "Lớn", 13 },
                    { 185, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9708), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9708), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9710), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9710), "Dài", 13 },
                    { 187, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9712), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9713), "Thấp", 13 },
                    { 188, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9714), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9715), "Nhiều", 13 },
                    { 189, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9716), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9717), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9719), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9719), "Ngắn", 13 },
                    { 191, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9721), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9721), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9723), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9723), "Dày", 13 },
                    { 193, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9725), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9725), "Mỏng", 13 },
                    { 194, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9750), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9750), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9752), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9753), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9754), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9755), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9756), "Night", "images/word/time/Night.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9757), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9758), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9759), "Một giờ", 14 },
                    { 199, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9761), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9761), "Mười phút", 14 },
                    { 200, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9763), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9763), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9765), "Today", "images/word/time/Today.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9765), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9768), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9768), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9771), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9771), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9790), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9791), "Bóng", 15 },
                    { 205, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9792), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9793), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9795), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9795), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9797), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9797), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9799), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9799), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9802), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9803), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9804), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9805), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9807), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9807), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9809), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9809), "Tô màu", 15 },
                    { 213, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9811), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9812), "Bút màu", 15 },
                    { 214, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9813), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9814), "Búp bê", 15 },
                    { 215, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9815), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9816), "Diều", 15 },
                    { 216, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9818), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9818), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9820), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9820), "Tivi", 15 },
                    { 218, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9822), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9822), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9843), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9843), "Máy bay", 16 },
                    { 220, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9845), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9846), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9847), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9848), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9850), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9850), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9852), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9852), "Xe máy", 16 },
                    { 224, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9854), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9854), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9871), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9871), "Ôm", 17 },
                    { 226, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9873), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9873), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9876), "I want", "images/word/want/I want.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9876), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9879), "No", "images/word/want/No.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9879), "Không", 17 },
                    { 229, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9881), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9881), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9883), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9884), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9885), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 2, 12, 13, 34, 10, 806, DateTimeKind.Local).AddTicks(9886), "Có", 17 }
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
