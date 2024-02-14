using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice05_PizzeriaAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pizza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    picture = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredient_pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizza",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ingredient_pizza",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_pizza", x => new { x.IngredientId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_ingredient_pizza_pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ingredient",
                columns: new[] { "Id", "description", "name", "PizzaId" },
                values: new object[,]
                {
                    { 1, "", "Coulis de tomate", null },
                    { 2, "", "Oignons", null },
                    { 3, "", "Olives", null },
                    { 4, "", "Poivrons", null },
                    { 5, "", "Mozzarella veggie", null },
                    { 6, "", "Mozzarella", null },
                    { 7, "", "Haché de boeuf Label Rouge", null },
                    { 8, "", "Lardons fumés", null },
                    { 9, "", "Oeuf", null }
                });

            migrationBuilder.InsertData(
                table: "pizza",
                columns: new[] { "id", "description", "name", "picture", "price", "type" },
                values: new object[,]
                {
                    { 1, "Une pizza qu'elle est bonne avec plein de bons légumes congelés", "4 saisons", "https://commons.wikimedia.org/wiki/File:Pizza_Quattro_Stagioni.jpg", 12m, 1 },
                    { 2, "Une pizza qu'elle est très très avec plein de viande morte", "Carnivore", "https://commons.wikimedia.org/wiki/File:P_20230902_191843_1.jpg", 15m, 2 }
                });

            migrationBuilder.InsertData(
                table: "ingredient_pizza",
                columns: new[] { "IngredientId", "PizzaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_PizzaId",
                table: "ingredient",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_pizza_PizzaId",
                table: "ingredient_pizza",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient");

            migrationBuilder.DropTable(
                name: "ingredient_pizza");

            migrationBuilder.DropTable(
                name: "pizza");
        }
    }
}
