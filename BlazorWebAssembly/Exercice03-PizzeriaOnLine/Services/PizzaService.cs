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
            if (pizza.Id == 0)
                InitialPizza.completePizzas.Add(pizza);
            else
            {
                Pizza pizzaToUpdate = GetPizzaById(pizza.Id);

                pizzaToUpdate.Name = pizza.Name;
                pizzaToUpdate.Price = pizza.Price;
                pizzaToUpdate.IsMostOrdered = pizza.IsMostOrdered;
                pizzaToUpdate.Ingredients = pizza.Ingredients;
                pizzaToUpdate.ImageLink = pizza.ImageLink;

                pizzaToUpdate = pizza;
            }
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

        public Ingredient? GetIngredientById(int id)
        {
            return InitialPizza.ingredients.FirstOrDefault(i => i.Id == id);
        }

        public Pizza? GetPizzaById(int id)
        {
            return InitialPizza.completePizzas.FirstOrDefault(i => i.Id == id);
        }

        public void DeletePizza(Pizza pizza)
        {
            Pizza pizzaToDelete = GetPizzaById(pizza.Id);
            InitialPizza.completePizzas.Remove(pizzaToDelete);
        }
    }
}
