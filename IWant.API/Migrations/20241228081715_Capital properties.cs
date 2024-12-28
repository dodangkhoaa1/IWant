using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IWant.API.Migrations
{
    /// <inheritdoc />
    public partial class Capitalproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordCategories_wordCategoryId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "nameEn",
                table: "WordCategories");

            migrationBuilder.RenameColumn(
                name: "wordCategoryId",
                table: "Words",
                newName: "WordCategoryId");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Words",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Words",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "imagePath",
                table: "Words",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Words",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Words",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "textVi",
                table: "Words",
                newName: "VietnameseText");

            migrationBuilder.RenameColumn(
                name: "textEn",
                table: "Words",
                newName: "EnglishText");

            migrationBuilder.RenameIndex(
                name: "IX_Words_wordCategoryId",
                table: "Words",
                newName: "IX_Words_WordCategoryId");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "WordCategories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "WordCategories",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "imagePath",
                table: "WordCategories",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "WordCategories",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WordCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nameVi",
                table: "WordCategories",
                newName: "VietnameseName");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Players",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "Players",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Players",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Players",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Players_username",
                table: "Players",
                newName: "IX_Players_Username");

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "WordCategories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Players",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "WordCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EnglishName", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(3316), "Subject", new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "WordCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EnglishName", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(4116), "Verb", new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(5604), new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(5798) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6513), new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6519), new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6519) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6522), new DateTime(2024, 12, 28, 15, 17, 13, 123, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordCategories_WordCategoryId",
                table: "Words",
                column: "WordCategoryId",
                principalTable: "WordCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_WordCategories_WordCategoryId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "WordCategories");

            migrationBuilder.RenameColumn(
                name: "WordCategoryId",
                table: "Words",
                newName: "wordCategoryId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Words",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Words",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Words",
                newName: "imagePath");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Words",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Words",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VietnameseText",
                table: "Words",
                newName: "textVi");

            migrationBuilder.RenameColumn(
                name: "EnglishText",
                table: "Words",
                newName: "textEn");

            migrationBuilder.RenameIndex(
                name: "IX_Words_WordCategoryId",
                table: "Words",
                newName: "IX_Words_wordCategoryId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "WordCategories",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "WordCategories",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "WordCategories",
                newName: "imagePath");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "WordCategories",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WordCategories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VietnameseName",
                table: "WordCategories",
                newName: "nameVi");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Players",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Players",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Players",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Players_Username",
                table: "Players",
                newName: "IX_Players_username");

            migrationBuilder.AddColumn<string>(
                name: "nameEn",
                table: "WordCategories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Players",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "WordCategories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "nameEn", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(557), "Subject", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(783) });

            migrationBuilder.UpdateData(
                table: "WordCategories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "nameEn", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(1334), "Verb", new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(2738), new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3615), new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3617) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3621), new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3621) });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "createdAt", "updatedAt" },
                values: new object[] { new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3623), new DateTime(2024, 12, 15, 14, 51, 38, 400, DateTimeKind.Local).AddTicks(3624) });

            migrationBuilder.AddForeignKey(
                name: "FK_Words_WordCategories_wordCategoryId",
                table: "Words",
                column: "wordCategoryId",
                principalTable: "WordCategories",
                principalColumn: "id");
        }
    }
}
