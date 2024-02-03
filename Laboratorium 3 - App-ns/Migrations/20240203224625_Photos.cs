using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorium_3___App_ns.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "INTEGER", maxLength: 12, nullable: false),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateTaken = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Camera = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Format = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "Id", "Author", "Camera", "DateTaken", "Description", "Format", "Location", "Resolution", "Title" },
                values: new object[] { 1, "Kamil Kowalski", "Sony", new DateTime(2018, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panorama Krakowa Nocą", "4:3", "Kraków", "1920x1080", "Kraków nocą" });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "Id", "Author", "Camera", "DateTaken", "Description", "Format", "Location", "Resolution", "Title" },
                values: new object[] { 2, "Krystian Kozłowski", "Sony", new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zdjęcie Wawelu", "4:3", "Kraków", "1920x1080", "Wawel" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "photos");
        }
    }
}
