using Exercice03_PizzeriaOnLine.Models;

namespace Exercice03_PizzeriaOnLine.Services
{
    public class PizzaService : IPizzaService
    {
        public List<Pizza> GetAll()
        {
            return InitialPizza.completePizzas.OrderBy(p => p.IsMostOrdered == false).ToList<Pizza>();
        }

        public void Add(Pizza pizza)
        {
            InitialPizza.completePizzas.Add(pizza);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return InitialPizza.ingredients;
        }

        public Dictionary<int, string> GetAllIngredientsIds()
        {
            Dictionary<int, string> list = new Dictionary<int, string>();
            foreach(Ingredient ingredient in InitialPizza.ingredients)
                list.Add(ingredient.Id, ingredient.Name);
            return list;
        }
    }
}
