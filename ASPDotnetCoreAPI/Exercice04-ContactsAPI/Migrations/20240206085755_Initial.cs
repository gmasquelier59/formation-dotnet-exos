using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04_ContactsAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    avatarURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "firstname", "gender", "lastname" },
                values: new object[] { 1, "", new DateTime(1981, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean", 1, "DUPONT" });

            migrationBuilder.InsertData(
                table: "contact",
                columns: new[] { "id", "avatarURL", "birthdate", "firstname", "gender", "lastname" },
                values: new object[] { 2, "", new DateTime(1993, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", 2, "SMITH" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact");
        }
    }
}
