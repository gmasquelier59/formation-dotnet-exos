using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice05_PizzeriaAPI.Models
{
    [Table("ingredient_pizza")]
    public class IngredientPizza
    {
        public int IngredientId { get; set; }
        //public Ingredient Ingredient { get; set; }
        public int PizzaId {  get; set; }
        //public Pizza Pizza { get; set; }
    }
}
