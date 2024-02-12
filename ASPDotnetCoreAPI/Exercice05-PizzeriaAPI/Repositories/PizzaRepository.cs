using Exercice05_PizzeriaAPI.Data;
using Exercice05_PizzeriaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice05_PizzeriaAPI.Repositories
{
    public class PizzaRepository
    {
        private readonly AppDbContext _db;

        public PizzaRepository(AppDbContext db)
        {
            _db = db;
        }

        public List<Pizza> GetAll()
        {
            return _db.Pizzas.Include(pizza => pizza.Ingredients).ToList<Pizza>();
        }

        public Pizza? GetById(int id)
        {
            return _db.Pizzas.FirstOrDefault<Pizza>(p => p.Id == id);
        }

        public Pizza? Create(Pizza pizza)
        {
            var entity = _db.Pizzas.Add(pizza);
            _db.SaveChanges();

            if (entity.Entity != null && entity.Entity.Id > 0)
                return (Pizza)entity.Entity;

            return null;
        }

        public Pizza AddIngredientToPizza(Ingredient ingredient, Pizza pizza)
        {
            Ingredient? ingredientFromDb = _db.Ingredients.FirstOrDefault<Ingredient>(i => i.Id == ingredient.Id);

            if (ingredientFromDb == null)
                ingredientFromDb = (Ingredient)_db.Ingredients.Add(ingredient).Entity;

            pizza.Ingredients.Add(ingredientFromDb);
            _db.SaveChanges();

            return pizza;
        }

        public void Delete(Pizza pizza)
        {
            _db.Pizzas.Remove(pizza);
            _db.SaveChanges();
        }
    }
}
