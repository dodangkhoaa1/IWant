using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IWant.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WordCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    imagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    wordCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.id);
                    table.ForeignKey(
                        name: "FK_Words_WordCategories_wordCategoryId",
                        column: x => x.wordCategoryId,
                        principalTable: "WordCategories",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "id", "password", "score", "username" },
                values: new object[] { 1, "admin", 0, "admin" });

            migrationBuilder.InsertData(
                table: "WordCategories",
                columns: new[] { "id", "createdAt", "imagePath", "name", "status", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 13, 15, 8, 9, 629, DateTimeKind.Local).AddTicks(9871), "", "Chủ từ", true, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(119) },
                    { 2, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(737), "", "Động từ", true, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(738) }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "id", "createdAt", "imagePath", "status", "text", "updatedAt", "wordCategoryId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3248), "", true, "Muốn", new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3250), null },
                    { 1, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(2293), "", true, "Con", new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(2494), 1 },
                    { 3, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3254), "", true, "Ăn", new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3254), 2 },
                    { 4, new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3256), "", true, "Uống", new DateTime(2024, 12, 13, 15, 8, 9, 630, DateTimeKind.Local).AddTicks(3257), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_username",
                table: "Players",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_wordCategoryId",
                table: "Words",
                column: "wordCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "WordCategories");
        }
    }
}
