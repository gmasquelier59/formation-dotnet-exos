using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice05_PizzeriaAPI.Models
{
    [Table("ingredient")]
    public class Ingredient
    {
        public int Id {  get; set; }

        [Column("name"), MaxLength(255), Required]
        public string Name { get; set; }

        [Column("description"), MaxLength(255), Required]
        public string Description { get; set; }

        //public virtual List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        //public virtual List<IngredientPizza> IngredientPizzas { get; set; } = new List<IngredientPizza>();
    }
}
