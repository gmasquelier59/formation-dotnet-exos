using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[] { 1, "Préparer la venue de belle-maman", 1, "Rangement" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "Status", "Title" },
                values: new object[] { 2, "Promener Médor et faire attention à la voisine !", 2, "Promenade" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
