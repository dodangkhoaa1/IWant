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
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Status = table.Column<bool>(type: "bit", nullable: false),
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
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Birthday", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, "avatar1.png", new DateOnly(2003, 11, 24), "bd591428-5d71-49ee-abd2-c1740ff5f70c", null, "nhathm2411@gmail.com", false, "Hồ Minh Nhật", true, true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, null, "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6763), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6764), "Hành Động" },
                    { 2, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6766), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6767), "Động Vật" },
                    { 3, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6769), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6769), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6771), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6771), "Quần Áo" },
                    { 5, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6773), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6774), "Màu Sắc" },
                    { 6, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6775), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6776), "Cảm Xúc" },
                    { 7, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6778), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6778), "Thức Ăn" },
                    { 8, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6780), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6780), "Trái Cây" },
                    { 9, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6783), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6783), "Con Số" },
                    { 10, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6785), "People", "images/wordCategories/People.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6785), "Con Người" },
                    { 11, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6787), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6788), "Địa Điểm" },
                    { 12, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6789), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6790), "Câu Hỏi" },
                    { 13, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6791), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6792), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6794), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6794), "Thời Gian" },
                    { 15, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6796), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6796), "Đồ Chơi" },
                    { 16, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6798), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6798), "Phương Tiện" },
                    { 17, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6800), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6800), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6837), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6837), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6840), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6841), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6843), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6844), "Đóng", 1 },
                    { 4, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6846), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6846), "Uống", 1 },
                    { 5, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6849), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6849), "Ăn", 1 },
                    { 6, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6851), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6851), "Nhìn", 1 },
                    { 7, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6853), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6853), "Tắt", 1 },
                    { 8, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6855), "On", "images/word/actions/On.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6856), "Bật", 1 },
                    { 9, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6865), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6866), "Mở", 1 },
                    { 10, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6868), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6868), "Chơi", 1 },
                    { 11, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6870), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6870), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6872), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6873), "Chạy", 1 },
                    { 13, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6875), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6875), "Ngồi", 1 },
                    { 14, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6877), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6877), "Ngủ", 1 },
                    { 15, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6879), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6880), "Đứng", 1 },
                    { 16, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6881), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6882), "Bơi", 1 },
                    { 17, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6884), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6884), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6886), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6886), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6889), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6890), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6892), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6892), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6894), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6894), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6935), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6936), "Ong", 2 },
                    { 23, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6938), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6938), "Chim", 2 },
                    { 24, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6940), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6941), "Bướm", 2 },
                    { 25, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6943), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6943), "Mèo", 2 },
                    { 26, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6945), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6945), "Gà", 2 },
                    { 27, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6947), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6948), "Bò", 2 },
                    { 28, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6950), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6950), "Chó", 2 },
                    { 29, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6952), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6952), "Vịt", 2 },
                    { 30, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6954), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6955), "Cá", 2 },
                    { 31, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6957), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6957), "Ngựa", 2 },
                    { 32, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6960), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6960), "Chuột", 2 },
                    { 33, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6962), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6962), "Heo", 2 },
                    { 34, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6985), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6986), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6988), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6988), "Lưng", 3 },
                    { 36, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6990), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6990), "Bụng", 3 },
                    { 37, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6992), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6993), "Mông", 3 },
                    { 38, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6995), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6995), "Tai", 3 },
                    { 39, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6997), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(6997), "Mắt", 3 },
                    { 40, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7000), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7000), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7002), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7002), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7004), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7005), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7007), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7007), "Tóc", 3 },
                    { 44, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7009), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7010), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7011), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7012), "Chân", 3 },
                    { 46, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7014), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7014), "Môi", 3 },
                    { 47, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7016), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7016), "Mũi", 3 },
                    { 48, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7019), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7019), "Răng", 3 },
                    { 49, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7021), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7021), "Họng", 3 },
                    { 50, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7023), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7024), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7025), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7026), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7051), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7051), "Ba lô", 4 },
                    { 53, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7053), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7054), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7056), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7056), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7058), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7058), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7060), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7061), "Quần dài", 4 },
                    { 57, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7064), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7064), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7066), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7066), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7068), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7069), "Giày", 4 },
                    { 60, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7070), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7071), "Quần short", 4 },
                    { 61, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7073), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7073), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7075), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7075), "Tất", 4 },
                    { 63, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7077), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7078), "Áo len", 4 },
                    { 64, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7080), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7080), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7082), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7083), "Áo phông", 4 },
                    { 66, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7084), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7085), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7108), "Black", "images/word/color/Black.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7109), "Màu đen", 5 },
                    { 68, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7116), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7116), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7118), "Green", "images/word/color/Green.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7119), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7121), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7122), "Màu cam", 5 },
                    { 71, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7123), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7124), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7126), "Red", "images/word/color/Red.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7126), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7128), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7129), "Màu tím", 5 },
                    { 74, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7130), "White", "images/word/color/White.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7131), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7133), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7133), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7153), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7153), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7155), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7156), "Tức giận", 6 },
                    { 78, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7158), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7158), "Chán nản", 6 },
                    { 79, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7160), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7160), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7163), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7164), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7166), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7166), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7168), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7169), "Đói", 6 },
                    { 83, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7170), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7171), "Đau", 6 },
                    { 84, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7173), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7173), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7175), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7175), "Buồn", 6 },
                    { 86, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7177), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7178), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7180), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7180), "Ốm", 6 },
                    { 88, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7182), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7182), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7184), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7185), "Khát", 6 },
                    { 90, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7186), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7187), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7189), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7189), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7191), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7191), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7193), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7194), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7218), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7218), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7221), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7221), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7223), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7223), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7225), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7226), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7228), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7228), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7230), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7230), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7232), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7233), "Kem", 7 },
                    { 101, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7235), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7235), "Nước ép", 7 },
                    { 102, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7237), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7237), "Sữa", 7 },
                    { 103, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7239), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7240), "Pizza", 7 },
                    { 104, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7242), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7242), "Cơm", 7 },
                    { 105, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7244), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7244), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7246), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7247), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7249), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7249), "Súp", 7 },
                    { 108, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7252), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7252), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7254), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7254), "Trà", 7 },
                    { 110, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7256), "Water", "images/word/food/Water.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7257), "Nước", 7 },
                    { 111, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7259), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7259), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7283), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7283), "Táo", 8 },
                    { 113, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7285), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7286), "Bơ", 8 },
                    { 114, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7288), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7288), "Chuối", 8 },
                    { 115, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7290), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7290), "Thanh long", 8 },
                    { 116, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7292), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7293), "Nho", 8 },
                    { 117, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7294), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7295), "Ổi", 8 },
                    { 118, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7297), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7297), "Kiwi", 8 },
                    { 119, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7299), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7299), "Cam", 8 },
                    { 120, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7302), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7303), "Đào", 8 },
                    { 121, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7305), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7305), "Dứa", 8 },
                    { 122, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7307), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7307), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7309), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7310), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7332), "One", "images/word/number/One.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7332), "Một", 9 },
                    { 125, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7334), "Two", "images/word/number/Two.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7335), "Hai", 9 },
                    { 126, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7337), "Three", "images/word/number/Three.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7337), "Ba", 9 },
                    { 127, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7339), "Four", "images/word/number/Four.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7340), "Bốn", 9 },
                    { 128, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7342), "Five", "images/word/number/Five.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7342), "Năm", 9 },
                    { 129, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7344), "Six", "images/word/number/Six.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7344), "Sáu", 9 },
                    { 130, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7346), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7347), "Bảy", 9 },
                    { 131, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7349), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7349), "Tám", 9 },
                    { 132, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7351), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7352), "Chín", 9 },
                    { 133, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7355), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7355), "Mười", 9 },
                    { 134, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7384), "Again", "images/word/people/Again.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7385), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7387), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7388), "Em bé", 10 },
                    { 136, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7390), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7390), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7392), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7392), "Bố", 10 },
                    { 138, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7394), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7395), "Mọi người", 10 },
                    { 139, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7397), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7397), "Cô bé", 10 },
                    { 140, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7399), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7399), "Bà", 10 },
                    { 141, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7401), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7402), "Ông", 10 },
                    { 142, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7404), "How much", "images/word/people/How much.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7404), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7406), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7406), "Mẹ", 10 },
                    { 144, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7408), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7409), "Anh trai", 10 },
                    { 145, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7410), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7411), "Chị gái", 10 },
                    { 146, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7414), "What", "images/word/people/What.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7414), "Cái gì", 10 },
                    { 147, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7416), "When", "images/word/people/When.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7416), "Khi nào", 10 },
                    { 148, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7418), "Where", "images/word/people/Where.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7418), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7420), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7421), "Cái nào", 10 },
                    { 150, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7423), "Who", "images/word/people/Who.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7423), "Ai", 10 },
                    { 151, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7425), "Why", "images/word/people/Why.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7426), "Tại sao", 10 },
                    { 152, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7428), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7428), "Em trai", 10 },
                    { 153, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7430), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7430), "Em gái", 10 },
                    { 154, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7432), "What time", "images/word/people/What time.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7433), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7457), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7458), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7460), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7460), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7462), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7462), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7465), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7466), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7468), "House", "images/word/places/House.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7468), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7470), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7470), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7472), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7473), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7475), "Park", "images/word/places/Park.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7476), "Công viên", 11 },
                    { 163, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7477), "School", "images/word/places/School.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7478), "Trường học", 11 },
                    { 164, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7480), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7480), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7482), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7482), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7484), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7485), "Sở thú", 11 },
                    { 167, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7507), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7507), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7509), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7509), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7511), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7512), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7514), "What", "images/word/questions/What.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7514), "Cái gì", 12 },
                    { 171, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7516), "When", "images/word/questions/When.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7517), "Khi nào", 12 },
                    { 172, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7519), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7519), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7521), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7521), "Cái nào", 12 },
                    { 174, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7523), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7524), "Ai", 12 },
                    { 175, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7526), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7526), "Tại sao", 12 },
                    { 176, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7545), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7546), "Ở trên", 13 },
                    { 177, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7548), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7548), "Phía sau", 13 },
                    { 178, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7550), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7550), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7552), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7553), "Ít", 13 },
                    { 180, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7554), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7555), "Nặng", 13 },
                    { 181, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7557), "High", "images/word/relations/High.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7557), "Cao", 13 },
                    { 182, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7559), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7560), "Phía trước", 13 },
                    { 183, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7562), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7563), "Ở trong", 13 },
                    { 184, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7565), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7565), "Lớn", 13 },
                    { 185, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7567), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7567), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7569), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7570), "Dài", 13 },
                    { 187, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7572), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7572), "Thấp", 13 },
                    { 188, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7574), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7574), "Nhiều", 13 },
                    { 189, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7576), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7577), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7578), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7579), "Ngắn", 13 },
                    { 191, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7581), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7581), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7583), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7583), "Dày", 13 },
                    { 193, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7585), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7586), "Mỏng", 13 },
                    { 194, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7610), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7611), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7613), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7613), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7615), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7616), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7618), "Night", "images/word/time/Night.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7618), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7620), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7620), "Một giờ", 14 },
                    { 199, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7622), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7623), "Mười phút", 14 },
                    { 200, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7624), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7625), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7627), "Today", "images/word/time/Today.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7627), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7630), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7630), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7632), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7632), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7653), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7653), "Bóng", 15 },
                    { 205, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7655), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7656), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7663), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7664), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7666), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7666), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7668), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7669), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7672), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7672), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7674), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7674), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7676), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7677), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7679), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7679), "Tô màu", 15 },
                    { 213, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7681), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7681), "Bút màu", 15 },
                    { 214, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7683), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7684), "Búp bê", 15 },
                    { 215, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7685), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7686), "Diều", 15 },
                    { 216, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7688), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7688), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7690), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7690), "Tivi", 15 },
                    { 218, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7692), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7693), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7715), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7715), "Máy bay", 16 },
                    { 220, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7717), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7718), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7720), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7720), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7722), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7722), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7724), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7725), "Xe máy", 16 },
                    { 224, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7727), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7727), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7746), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7746), "Ôm", 17 },
                    { 226, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7749), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7749), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7751), "I want", "images/word/want/I want.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7751), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7753), "No", "images/word/want/No.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7754), "Không", 17 },
                    { 229, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7756), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7756), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7758), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7758), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7760), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 1, 16, 15, 55, 1, 172, DateTimeKind.Local).AddTicks(7761), "Có", 17 }
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
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

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
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropTable(
                name: "WordCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
