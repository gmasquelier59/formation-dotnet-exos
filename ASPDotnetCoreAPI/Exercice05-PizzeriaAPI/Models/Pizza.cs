using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice05_PizzeriaAPI.Models
{
    [Table("pizza")]
    public class Pizza
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name"), MaxLength(255), Required]
        public string Name { get; set; }

        [Column("description"), MaxLength(255)]
        public string Description { get; set; }

        [Column("price", TypeName = "decimal(5,2)"), Required, Range(0.0, 50.0)]
        public double Price {  get; set; }

        [Column("picture"), MaxLength(255), Required]
        public string Picture {  get; set; }

        [Column("type"), Required]
        public PizzaTypes Type {  get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public List<IngredientPizza> IngredientPizzas { get; set; } = new List<IngredientPizza>();
    }
}
