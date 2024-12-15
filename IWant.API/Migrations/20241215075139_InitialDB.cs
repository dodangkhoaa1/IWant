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
                    nameEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nameVi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
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
                    textEn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    textVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                columns: new[] { "id", "createdAt", "imagePath", "nameEn", "nameVi", "status", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(557), "", "Subject", "Chủ từ", true, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(783) },
                    { 2, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(1334), "", "Verb", "Động từ", true, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(1335) }
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "id", "createdAt", "imagePath", "status", "textEn", "textVi", "updatedAt", "wordCategoryId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3615), "", true, "Want", "Muốn", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3617), null },
                    { 1, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(2738), "", true, "I", "Con", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(2921), 1 },
                    { 3, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3621), "", true, "Eat", "Ăn", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3621), 2 },
                    { 4, new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3623), "", true, "Drink", "Uống", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3624), 2 }
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
