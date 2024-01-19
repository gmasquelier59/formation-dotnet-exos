using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersoNage.Migrations
{
    public partial class Personnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pseudo = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    PointsVie = table.Column<int>(type: "int", nullable: false),
                    PointsArmure = table.Column<int>(type: "int", nullable: false),
                    Degats = table.Column<int>(type: "int", nullable: false),
                    NombrePersonnagesTues = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personnages",
                columns: new[] { "Id", "DateCreation", "Degats", "NombrePersonnagesTues", "PointsArmure", "PointsVie", "Pseudo" },
                values: new object[] { 1, new DateTime(2024, 1, 19, 9, 34, 49, 458, DateTimeKind.Local).AddTicks(6588), 10, 0, 20, 50, "Guillausaure" });

            migrationBuilder.InsertData(
                table: "Personnages",
                columns: new[] { "Id", "DateCreation", "Degats", "NombrePersonnagesTues", "PointsArmure", "PointsVie", "Pseudo" },
                values: new object[] { 2, new DateTime(2024, 1, 19, 9, 34, 49, 458, DateTimeKind.Local).AddTicks(6647), 5, 0, 10, 30, "Uno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnages");
        }
    }
}
