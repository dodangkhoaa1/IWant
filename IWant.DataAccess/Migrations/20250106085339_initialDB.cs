using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
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
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
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
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Birthday", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "0bcbb4f7-72f9-435f-9cb3-1621b4503974", 0, "", new DateOnly(2003, 11, 24), "bd591428-5d71-49ee-abd2-c1740ff5f70c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "nhathm2411@gmail.com", false, "Hồ Minh Nhật", true, true, null, "NHATHM2411@GMAIL.COM", "NHATHM2411@GMAIL.COM", "AQAAAAIAAYagAAAAEJbJ5Wbc5Ukymbc73mgTlipOMojxe5yqV9bB5aymAnvaiaoaNOdfqdNTi++md7JOUQ==", null, false, "4ROV5G3THUAAZ5C5NDWOBZ76P4VKU6RY", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhathm2411@gmail.com" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5764), "Actions", "images/wordCategories/Actions.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5765), "Hành Động" },
                    { 2, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5768), "Animals", "images/wordCategories/Animals.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5768), "Động Vật" },
                    { 3, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5770), "BodyParts", "images/wordCategories/BodyParts.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5771), "Bộ Phận Cơ Thể" },
                    { 4, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5772), "Clothes", "images/wordCategories/Clothes.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5773), "Quần Áo" },
                    { 5, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5775), "Colors", "images/wordCategories/Colors.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5775), "Màu Sắc" },
                    { 6, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5777), "Feeling", "images/wordCategories/Feeling.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5777), "Cảm Xúc" },
                    { 7, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5779), "Food", "images/wordCategories/Food.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5780), "Thức Ăn" },
                    { 8, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5781), "Fruits", "images/wordCategories/Fruits.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5782), "Trái Cây" },
                    { 9, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5784), "Numbers", "images/wordCategories/Numbers.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5784), "Con Số" },
                    { 10, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5786), "People", "images/wordCategories/People.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5786), "Con Người" },
                    { 11, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5788), "Places", "images/wordCategories/Places.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5789), "Địa Điểm" },
                    { 12, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5790), "Questions", "images/wordCategories/Questions.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5791), "Câu Hỏi" },
                    { 13, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5793), "Relations", "images/wordCategories/Relations.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5797), "Mối Quan Hệ" },
                    { 14, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5799), "Time", "images/wordCategories/Time.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5799), "Thời Gian" },
                    { 15, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5801), "Toys", "images/wordCategories/Toys.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5801), "Đồ Chơi" },
                    { 16, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5803), "Vehicles", "images/wordCategories/Vehicles.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5804), "Phương Tiện" },
                    { 17, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5805), "Want", "images/wordCategories/Want.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5806), "Mong Muốn" }
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
                    { 1, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5845), "Brush Hair", "images/word/actions/Brush hair.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5846), "Chải Tóc", 1 },
                    { 2, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5849), "Brush Teeth", "images/word/actions/Brush teeth.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5849), "Đánh Răng", 1 },
                    { 3, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5851), "Close", "images/word/actions/Close.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5852), "Đóng", 1 },
                    { 4, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5854), "Drink", "images/word/actions/Drink.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5854), "Uống", 1 },
                    { 5, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5856), "Eat", "images/word/actions/Eat.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5856), "Ăn", 1 },
                    { 6, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5858), "Look", "images/word/actions/Look.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5858), "Nhìn", 1 },
                    { 7, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5860), "Off", "images/word/actions/Off.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5861), "Tắt", 1 },
                    { 8, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5871), "On", "images/word/actions/On.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5871), "Bật", 1 },
                    { 9, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5873), "Open", "images/word/actions/Open.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5873), "Mở", 1 },
                    { 10, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5878), "Play", "images/word/actions/Play.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5878), "Chơi", 1 },
                    { 11, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5880), "Put On", "images/word/actions/Put on.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5881), "Mặc Vào", 1 },
                    { 12, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5882), "Run", "images/word/actions/Run.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5883), "Chạy", 1 },
                    { 13, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5885), "Sit", "images/word/actions/Sit.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5885), "Ngồi", 1 },
                    { 14, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5887), "Sleep", "images/word/actions/Sleep.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5887), "Ngủ", 1 },
                    { 15, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5889), "Stand", "images/word/actions/Stand.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5890), "Đứng", 1 },
                    { 16, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5891), "Swim", "images/word/actions/Swim.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5892), "Bơi", 1 },
                    { 17, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5894), "Take Off", "images/word/actions/Take off.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5894), "Cởi Ra", 1 },
                    { 18, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5896), "Talk", "images/word/actions/Talk.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5896), "Nói Chuyện", 1 },
                    { 19, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5898), "Wake Up", "images/word/actions/Wake up.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5899), "Thức Dậy", 1 },
                    { 20, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5900), "Walk", "images/word/actions/Walk.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5901), "Đi Bộ", 1 },
                    { 21, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5903), "Wash", "images/word/actions/Wash.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5903), "Rửa Tay", 1 },
                    { 22, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5935), "Bee", "images/word/animals/Bee.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5936), "Ong", 2 },
                    { 23, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5938), "Bird", "images/word/animals/Bird.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5938), "Chim", 2 },
                    { 24, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5940), "Butterfly", "images/word/animals/Butterfly.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5941), "Bướm", 2 },
                    { 25, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5943), "Cat", "images/word/animals/Cat.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5943), "Mèo", 2 },
                    { 26, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5945), "Chicken", "images/word/animals/Chicken.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5945), "Gà", 2 },
                    { 27, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5947), "Cow", "images/word/animals/Cow.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5948), "Bò", 2 },
                    { 28, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5949), "Dog", "images/word/animals/Dog.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5950), "Chó", 2 },
                    { 29, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5952), "Duck", "images/word/animals/Duck.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5952), "Vịt", 2 },
                    { 30, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5954), "Fish", "images/word/animals/Fish.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5954), "Cá", 2 },
                    { 31, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5956), "Horse", "images/word/animals/Horse.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5956), "Ngựa", 2 },
                    { 32, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5958), "Mouse", "images/word/animals/Mouse.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5959), "Chuột", 2 },
                    { 33, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5961), "Pig", "images/word/animals/Pig.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5961), "Heo", 2 },
                    { 34, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5984), "Arm", "images/word/bodyParts/Arm.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5984), "Cánh tay", 3 },
                    { 35, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5986), "Back", "images/word/bodyParts/Back.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5987), "Lưng", 3 },
                    { 36, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5988), "Belly", "images/word/bodyParts/Belly.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5989), "Bụng", 3 },
                    { 37, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5991), "Bottom", "images/word/bodyParts/Bottom.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5991), "Mông", 3 },
                    { 38, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5993), "Ear", "images/word/bodyParts/Ear.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5993), "Tai", 3 },
                    { 39, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5995), "Eye", "images/word/bodyParts/Eye.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5996), "Mắt", 3 },
                    { 40, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5997), "Face", "images/word/bodyParts/Face.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(5998), "Khuôn mặt", 3 },
                    { 41, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6000), "Finger", "images/word/bodyParts/Finger.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6000), "Ngón tay", 3 },
                    { 42, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6002), "Foot", "images/word/bodyParts/Foot.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6003), "Bàn chân", 3 },
                    { 43, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6004), "Hair", "images/word/bodyParts/Hair.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6005), "Tóc", 3 },
                    { 44, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6007), "Hand", "images/word/bodyParts/Hand.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6007), "Bàn tay", 3 },
                    { 45, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6009), "Leg", "images/word/bodyParts/Leg.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6009), "Chân", 3 },
                    { 46, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6011), "Lips", "images/word/bodyParts/Lips.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6011), "Môi", 3 },
                    { 47, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6013), "Nose", "images/word/bodyParts/Nose.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6014), "Mũi", 3 },
                    { 48, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6016), "Teeth", "images/word/bodyParts/Teeth.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6016), "Răng", 3 },
                    { 49, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6018), "Throat", "images/word/bodyParts/Throat.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6019), "Họng", 3 },
                    { 50, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6020), "Toe", "images/word/bodyParts/Toe.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6021), "Ngón chân", 3 },
                    { 51, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6023), "Tongue", "images/word/bodyParts/Tongue.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6023), "Lưỡi", 3 },
                    { 52, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6047), "Backpack", "images/word/clothes/Backpack.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6047), "Ba lô", 4 },
                    { 53, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6049), "Cap", "images/word/clothes/Cap.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6050), "Mũ lưỡi trai", 4 },
                    { 54, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6052), "Jacket", "images/word/clothes/Jacket.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6052), "Áo khoác", 4 },
                    { 55, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6054), "Pajamas", "images/word/clothes/Pajamas.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6054), "Đồ ngủ", 4 },
                    { 56, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6056), "Pants", "images/word/clothes/Pants.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6057), "Quần dài", 4 },
                    { 57, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6058), "Scarf", "images/word/clothes/Scarf.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6059), "Khăn quàng cổ", 4 },
                    { 58, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6061), "Shirt", "images/word/clothes/Shirt.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6061), "Áo sơ mi", 4 },
                    { 59, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6063), "Shoes", "images/word/clothes/Shoes.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6063), "Giày", 4 },
                    { 60, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6065), "Shorts", "images/word/clothes/Short.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6066), "Quần short", 4 },
                    { 61, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6071), "Skirt", "images/word/clothes/Skirt.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6072), "Váy ngắn", 4 },
                    { 62, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6074), "Socks", "images/word/clothes/Socks.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6074), "Tất", 4 },
                    { 63, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6076), "Sweater", "images/word/clothes/Sweater.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6076), "Áo len", 4 },
                    { 64, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6078), "Swimsuit", "images/word/clothes/Swimsuit.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6078), "Đồ bơi", 4 },
                    { 65, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6080), "T-Shirt", "images/word/clothes/T-Shirt.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6081), "Áo phông", 4 },
                    { 66, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6083), "Underwear", "images/word/clothes/Underwear.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6083), "Đồ lót", 4 },
                    { 67, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6113), "Black", "images/word/color/Black.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6114), "Màu đen", 5 },
                    { 68, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6116), "Blue", "images/word/color/Blue.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6116), "Màu xanh dương", 5 },
                    { 69, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6118), "Green", "images/word/color/Green.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6118), "Màu xanh lá", 5 },
                    { 70, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6120), "Orange", "images/word/color/Orange.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6121), "Màu cam", 5 },
                    { 71, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6122), "Pink", "images/word/color/Pink.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6123), "Màu hồng", 5 },
                    { 72, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6125), "Red", "images/word/color/Red.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6125), "Màu đỏ", 5 },
                    { 73, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6128), "Violet", "images/word/color/Violet.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6128), "Màu tím", 5 },
                    { 74, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6130), "White", "images/word/color/White.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6130), "Màu trắng", 5 },
                    { 75, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6132), "Yellow", "images/word/color/Yellow.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6132), "Màu vàng", 5 },
                    { 76, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6152), "Agree", "images/word/feeling/Agree.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6152), "Đồng ý", 6 },
                    { 77, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6154), "Angry", "images/word/feeling/Angry.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6154), "Tức giận", 6 },
                    { 78, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6156), "Bored", "images/word/feeling/Bored.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6157), "Chán nản", 6 },
                    { 79, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6158), "Disagree", "images/word/feeling/Disagree.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6159), "Không đồng ý", 6 },
                    { 80, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6161), "Embarrassing", "images/word/feeling/Embarrassing.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6161), "Xấu hổ", 6 },
                    { 81, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6163), "Happy", "images/word/feeling/Happy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6163), "Vui vẻ", 6 },
                    { 82, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6165), "Hungry", "images/word/feeling/Hungry.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6166), "Đói", 6 },
                    { 83, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6168), "Hurt", "images/word/feeling/Hurt.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6168), "Đau", 6 },
                    { 84, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6170), "Not understand", "images/word/feeling/Not understand.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6170), "Không hiểu", 6 },
                    { 85, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6172), "Sad", "images/word/feeling/Sad.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6172), "Buồn", 6 },
                    { 86, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6175), "Scared", "images/word/feeling/Scared.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6175), "Sợ hãi", 6 },
                    { 87, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6177), "Sick", "images/word/feeling/Sick.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6178), "Ốm", 6 },
                    { 88, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6179), "Sleepy", "images/word/feeling/Sleepy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6180), "Buồn ngủ", 6 },
                    { 89, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6182), "Thirsty", "images/word/feeling/Thirsty.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6182), "Khát", 6 },
                    { 90, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6184), "Tired", "images/word/feeling/Tired.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6184), "Mệt mỏi", 6 },
                    { 91, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6186), "Vomit", "images/word/feeling/Vomited.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6186), "Nôn mửa", 6 },
                    { 92, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6188), "Yucky", "images/word/feeling/Yucky.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6189), "Ghê tởm", 6 },
                    { 93, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6190), "Yummy", "images/word/feeling/Yummy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6191), "Ngon miệng", 6 },
                    { 94, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6214), "Bread", "images/word/food/Bread.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6214), "Bánh mì", 7 },
                    { 95, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6217), "Cake", "images/word/food/Cake.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6217), "Bánh kem", 7 },
                    { 96, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6219), "Chocolate", "images/word/food/Chocolate.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6219), "Sô cô la", 7 },
                    { 97, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6221), "Cookie", "images/word/food/Cookie.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6222), "Bánh quy", 7 },
                    { 98, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6224), "Gum", "images/word/food/Gum.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6225), "Kẹo cao su", 7 },
                    { 99, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6227), "Hamburger", "images/word/food/Hambuger.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6227), "Bánh hamburger", 7 },
                    { 100, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6229), "Ice Cream", "images/word/food/IceCream.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6229), "Kem", 7 },
                    { 101, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6231), "Juice", "images/word/food/Juice.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6232), "Nước ép", 7 },
                    { 102, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6233), "Milk", "images/word/food/Milk.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6234), "Sữa", 7 },
                    { 103, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6236), "Pizza", "images/word/food/Pizza.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6236), "Pizza", 7 },
                    { 104, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6238), "Rice", "images/word/food/Rice.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6239), "Cơm", 7 },
                    { 105, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6240), "Sandwich", "images/word/food/Sandwich.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6241), "Bánh sandwich", 7 },
                    { 106, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6243), "Snack", "images/word/food/Snack.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6243), "Đồ ăn vặt", 7 },
                    { 107, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6245), "Soup", "images/word/food/Soup.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6245), "Súp", 7 },
                    { 108, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6247), "Spaghetti", "images/word/food/Spagetti.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6248), "Mì Ý", 7 },
                    { 109, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6250), "Tea", "images/word/food/Tea.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6250), "Trà", 7 },
                    { 110, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6252), "Water", "images/word/food/Water.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6252), "Nước", 7 },
                    { 111, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6254), "Yogurt", "images/word/food/Yogurt.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6255), "Sữa chua", 7 },
                    { 112, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6279), "Apple", "images/word/fruit/Apple.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6279), "Táo", 8 },
                    { 113, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6281), "Avocado", "images/word/fruit/Avocado.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6281), "Bơ", 8 },
                    { 114, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6284), "Banana", "images/word/fruit/Banana.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6284), "Chuối", 8 },
                    { 115, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6286), "Dragon Fruit", "images/word/fruit/Dragon Fruit.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6286), "Thanh long", 8 },
                    { 116, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6288), "Grape", "images/word/fruit/Grape.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6289), "Nho", 8 },
                    { 117, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6290), "Guava", "images/word/fruit/Guava.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6291), "Ổi", 8 },
                    { 118, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6293), "Kiwi", "images/word/fruit/Kiwi.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6293), "Kiwi", 8 },
                    { 119, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6295), "Orange", "images/word/fruit/Orange.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6296), "Cam", 8 },
                    { 120, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6297), "Peach", "images/word/fruit/Peace.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6298), "Đào", 8 },
                    { 121, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6300), "Pineapple", "images/word/fruit/Pineapple.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6300), "Dứa", 8 },
                    { 122, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6302), "Strawberry", "images/word/fruit/Strawberry.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6303), "Dâu tây", 8 },
                    { 123, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6304), "Watermelon", "images/word/fruit/Watermelon.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6305), "Dưa hấu", 8 },
                    { 124, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6327), "One", "images/word/number/One.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6328), "Một", 9 },
                    { 125, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6330), "Two", "images/word/number/Two.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6330), "Hai", 9 },
                    { 126, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6332), "Three", "images/word/number/Three.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6333), "Ba", 9 },
                    { 127, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6334), "Four", "images/word/number/Four.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6335), "Bốn", 9 },
                    { 128, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6337), "Five", "images/word/number/Five.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6337), "Năm", 9 },
                    { 129, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6339), "Six", "images/word/number/Six.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6340), "Sáu", 9 },
                    { 130, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6341), "Seven", "images/word/number/Seven.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6342), "Bảy", 9 },
                    { 131, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6344), "Eight", "images/word/number/Eight.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6344), "Tám", 9 },
                    { 132, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6346), "Nine", "images/word/number/Nine.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6346), "Chín", 9 },
                    { 133, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6348), "Ten", "images/word/number/Ten.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6348), "Mười", 9 },
                    { 134, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6377), "Again", "images/word/people/Again.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6377), "Lại lần nữa", 10 },
                    { 135, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6379), "Baby", "images/word/people/Baby.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6380), "Em bé", 10 },
                    { 136, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6382), "Boy", "images/word/people/Boy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6383), "Cậu bé", 10 },
                    { 137, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6385), "Dad", "images/word/people/Dad.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6385), "Bố", 10 },
                    { 138, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6387), "Everyone", "images/word/people/Everyone.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6387), "Mọi người", 10 },
                    { 139, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6389), "Girl", "images/word/people/Girl.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6389), "Cô bé", 10 },
                    { 140, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6391), "Grandma", "images/word/people/Grandma.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6392), "Bà", 10 },
                    { 141, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6394), "Grandpa", "images/word/people/Grandpa.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6394), "Ông", 10 },
                    { 142, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6396), "How much", "images/word/people/How much.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6396), "Bao nhiêu tiền", 10 },
                    { 143, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6398), "Mom", "images/word/people/Mom.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6398), "Mẹ", 10 },
                    { 144, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6400), "Older brother", "images/word/people/Older brother.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6400), "Anh trai", 10 },
                    { 145, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6402), "Older sister", "images/word/people/Older sister.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6403), "Chị gái", 10 },
                    { 146, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6404), "What", "images/word/people/What.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6405), "Cái gì", 10 },
                    { 147, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6406), "When", "images/word/people/When.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6407), "Khi nào", 10 },
                    { 148, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6409), "Where", "images/word/people/Where.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6409), "Ở đâu", 10 },
                    { 149, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6412), "Which one", "images/word/people/Which one.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6412), "Cái nào", 10 },
                    { 150, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6414), "Who", "images/word/people/Who.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6414), "Ai", 10 },
                    { 151, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6416), "Why", "images/word/people/Why.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6417), "Tại sao", 10 },
                    { 152, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6419), "Younger brother", "images/word/people/Younger brother.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6419), "Em trai", 10 },
                    { 153, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6421), "Younger sister", "images/word/people/Younger sister.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6421), "Em gái", 10 },
                    { 154, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6423), "What time", "images/word/people/What time.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6424), "Mấy giờ", 10 },
                    { 155, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6449), "Aquarium", "images/word/places/Aquarium.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6449), "Thủy cung", 11 },
                    { 156, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6451), "Bathroom", "images/word/places/Bathroom.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6452), "Phòng tắm", 11 },
                    { 157, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6454), "Bedroom", "images/word/places/Bedroom.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6454), "Phòng ngủ", 11 },
                    { 158, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6456), "Hospital", "images/word/places/Hospital.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6456), "Bệnh viện", 11 },
                    { 159, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6458), "House", "images/word/places/House.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6459), "Ngôi nhà", 11 },
                    { 160, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6460), "Kitchen", "images/word/places/Kitchen.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6461), "Nhà bếp", 11 },
                    { 161, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6463), "Living room", "images/word/places/Living room.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6463), "Phòng khách", 11 },
                    { 162, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6466), "Park", "images/word/places/Park.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6466), "Công viên", 11 },
                    { 163, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6468), "School", "images/word/places/School.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6469), "Trường học", 11 },
                    { 164, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6470), "Supermarket", "images/word/places/Supermarket.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6471), "Siêu thị", 11 },
                    { 165, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6472), "Toilet", "images/word/places/Toilet.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6473), "Nhà vệ sinh", 11 },
                    { 166, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6475), "Zoo", "images/word/places/Zoo.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6475), "Sở thú", 11 },
                    { 167, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6496), "Again", "images/word/questions/Again.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6497), "Lại lần nữa", 12 },
                    { 168, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6499), "How much", "images/word/questions/How much.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6499), "Bao nhiêu tiền", 12 },
                    { 169, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6501), "What time", "images/word/questions/WHat time.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6501), "Mấy giờ", 12 },
                    { 170, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6503), "What", "images/word/questions/What.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6503), "Cái gì", 12 },
                    { 171, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6505), "When", "images/word/questions/When.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6506), "Khi nào", 12 },
                    { 172, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6508), "Where", "images/word/questions/Where.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6508), "Ở đâu", 12 },
                    { 173, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6510), "Which one", "images/word/questions/Which one.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6510), "Cái nào", 12 },
                    { 174, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6512), "Who", "images/word/questions/Who.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6513), "Ai", 12 },
                    { 175, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6515), "Why", "images/word/questions/Why.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6516), "Tại sao", 12 },
                    { 176, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6535), "Above", "images/word/relations/Above.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6535), "Ở trên", 13 },
                    { 177, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6537), "Behind", "images/word/relations/Behind.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6538), "Phía sau", 13 },
                    { 178, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6540), "Below", "images/word/relations/Below.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6540), "Ở dưới", 13 },
                    { 179, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6542), "Few", "images/word/relations/Few.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6542), "Ít", 13 },
                    { 180, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6544), "Heavy", "images/word/relations/Heavy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6545), "Nặng", 13 },
                    { 181, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6546), "High", "images/word/relations/High.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6547), "Cao", 13 },
                    { 182, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6549), "In front", "images/word/relations/In front.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6549), "Phía trước", 13 },
                    { 183, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6551), "Inside", "images/word/relations/Inside.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6551), "Ở trong", 13 },
                    { 184, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6553), "Large", "images/word/relations/Large.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6554), "Lớn", 13 },
                    { 185, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6555), "Light", "images/word/relations/Light.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6556), "Nhẹ", 13 },
                    { 186, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6558), "Long", "images/word/relations/Long.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6558), "Dài", 13 },
                    { 187, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6561), "Low", "images/word/relations/Low.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6561), "Thấp", 13 },
                    { 188, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6563), "Many", "images/word/relations/Many.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6564), "Nhiều", 13 },
                    { 189, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6566), "Outside", "images/word/relations/Outside.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6566), "Bên ngoài", 13 },
                    { 190, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6568), "Short", "images/word/relations/Short.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6568), "Ngắn", 13 },
                    { 191, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6570), "Small", "images/word/relations/Small.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6570), "Nhỏ", 13 },
                    { 192, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6572), "Thick", "images/word/relations/Thick.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6573), "Dày", 13 },
                    { 193, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6574), "Thin", "images/word/relations/Thin.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6575), "Mỏng", 13 },
                    { 194, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6598), "Afternoon", "images/word/time/Afternoon.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6598), "Buổi chiều", 14 },
                    { 195, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6600), "Evening", "images/word/time/Evening.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6600), "Buổi tối", 14 },
                    { 196, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6602), "Morning", "images/word/time/Morning.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6603), "Buổi sáng", 14 },
                    { 197, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6605), "Night", "images/word/time/Night.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6605), "Ban đêm", 14 },
                    { 198, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6607), "One Hour", "images/word/time/One Hour.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6607), "Một giờ", 14 },
                    { 199, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6609), "Ten Minutes", "images/word/time/Ten Minutes.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6609), "Mười phút", 14 },
                    { 200, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6612), "Thirty Minutes", "images/word/time/Thidy Minutes.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6613), "Ba mươi phút", 14 },
                    { 201, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6614), "Today", "images/word/time/Today.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6615), "Hôm nay", 14 },
                    { 202, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6617), "Tomorrow", "images/word/time/Tomorrow.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6618), "Ngày mai", 14 },
                    { 203, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6619), "Yesterday", "images/word/time/Yesterday.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6620), "Hôm qua", 14 },
                    { 204, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6639), "Ball", "images/word/toys/Ball.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6640), "Bóng", 15 },
                    { 205, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6647), "Balloon", "images/word/toys/Ballon.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6648), "Bóng bay", 15 },
                    { 206, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6650), "Bear", "images/word/toys/Bear.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6650), "Gấu bông", 15 },
                    { 207, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6652), "Block", "images/word/toys/Block.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6653), "Khối xếp hình", 15 },
                    { 208, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6654), "Board Game", "images/word/toys/BoardGame.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6655), "Cờ bàn", 15 },
                    { 209, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6657), "Bubble", "images/word/toys/Bubble.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6658), "Bong bóng xà phòng", 15 },
                    { 210, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6659), "Car", "images/word/toys/Car.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6660), "Xe hơi", 15 },
                    { 211, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6662), "Clay", "images/word/toys/Clay.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6662), "Đất nặn", 15 },
                    { 212, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6665), "Coloring", "images/word/toys/Coloring.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6665), "Tô màu", 15 },
                    { 213, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6667), "Crayon", "images/word/toys/Crayon.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6667), "Bút màu", 15 },
                    { 214, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6669), "Doll", "images/word/toys/Doll.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6670), "Búp bê", 15 },
                    { 215, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6671), "Kite", "images/word/toys/Kite.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6672), "Diều", 15 },
                    { 216, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6674), "Puzzle", "images/word/toys/Puzzle.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6674), "Trò chơi ghép hình", 15 },
                    { 217, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6676), "Television", "images/word/toys/Television.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6676), "Tivi", 15 },
                    { 218, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6678), "Toy", "images/word/toys/Toy.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6679), "Đồ chơi", 15 },
                    { 219, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6700), "Airplane", "images/word/vehicles/Airplane.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6701), "Máy bay", 16 },
                    { 220, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6703), "Bike", "images/word/vehicles/Bike.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6703), "Xe đạp", 16 },
                    { 221, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6705), "Bus", "images/word/vehicles/Bus.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6705), "Xe buýt", 16 },
                    { 222, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6707), "Car", "images/word/vehicles/Car.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6708), "Xe hơi", 16 },
                    { 223, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6710), "Motorbike", "images/word/vehicles/Motorbike.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6710), "Xe máy", 16 },
                    { 224, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6712), "Ship", "images/word/vehicles/Ship.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6712), "Tàu thủy", 16 },
                    { 225, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6730), "Hug", "images/word/want/Hug.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6730), "Ôm", 17 },
                    { 226, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6732), "I don't want", "images/word/want/I don't want.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6732), "Tôi không muốn", 17 },
                    { 227, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6734), "I want", "images/word/want/I want.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6735), "Tôi muốn", 17 },
                    { 228, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6737), "No", "images/word/want/No.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6737), "Không", 17 },
                    { 229, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6739), "Sorry", "images/word/want/Sorry.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6740), "Xin lỗi", 17 },
                    { 230, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6741), "Thank you", "images/word/want/Thank you.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6742), "Cảm ơn", 17 },
                    { 231, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6744), "Yes", "images/word/want/Yes.png", true, new DateTime(2025, 1, 6, 15, 53, 39, 23, DateTimeKind.Local).AddTicks(6744), "Có", 17 }
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
