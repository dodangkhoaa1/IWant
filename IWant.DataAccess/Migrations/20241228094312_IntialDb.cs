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

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "Id", "CreatedAt", "EnglishName", "ImagePath", "Status", "UpdatedAt", "VietnameseName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6431), "Subject", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6432), "Chủ từ" },
                    { 2, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6434), "Verb", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6435), "Động từ" }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "Id", "CreatedAt", "EnglishText", "ImagePath", "Status", "UpdatedAt", "VietnameseText", "WordCategoryId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6466), "Want To", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6467), "Muốn", null },
                    { 1, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6463), "I", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6464), "Con", 1 },
                    { 3, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6477), "Eat", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6477), "Ăn", 2 },
                    { 4, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6479), "Drink", "", true, new DateTime(2024, 12, 28, 16, 43, 12, 43, DateTimeKind.Local).AddTicks(6479), "Uống", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Words_WordCategoryId",
                table: "Words",
                column: "WordCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordCategories");
        }
    }
}
