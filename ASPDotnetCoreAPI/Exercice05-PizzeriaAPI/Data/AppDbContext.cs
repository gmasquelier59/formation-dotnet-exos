using Exercice05_PizzeriaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Exercice05_PizzeriaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Pizza>()
            //    .HasMany<Ingredient>(e => e.Ingredients)
            //    .WithMany(e => e.Pizzas)
            //    .UsingEntity<IngredientPizza>();

            modelBuilder.Entity<IngredientPizza>().
                HasKey("IngredientId", "PizzaId");

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "4 saisons",
                    Description = "Une pizza qu'elle est bonne avec plein de bons légumes congelés",
                    Type = PizzaTypes.Veggie,
                    Price = 12.00,
                    Picture = "https://commons.wikimedia.org/wiki/File:Pizza_Quattro_Stagioni.jpg"
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Carnivore",
                    Description = "Une pizza qu'elle est très très avec plein de viande morte",
                    Type = PizzaTypes.Spicy,
                    Price = 15.00,
                    Picture = "https://commons.wikimedia.org/wiki/File:P_20230902_191843_1.jpg"
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Coulis de tomate", Description = ""},
                new Ingredient { Id = 2, Name = "Oignons", Description = "" },
                new Ingredient { Id = 3, Name = "Olives", Description = "" },
                new Ingredient { Id = 4, Name = "Poivrons", Description = "" },
                new Ingredient { Id = 5, Name = "Mozzarella veggie", Description = "" },
                new Ingredient { Id = 6, Name = "Mozzarella", Description = "" },
                new Ingredient { Id = 7, Name = "Haché de boeuf Label Rouge", Description = "" },
                new Ingredient { Id = 8, Name = "Lardons fumés", Description = "" },
                new Ingredient { Id = 9, Name = "Oeuf", Description = "" }
            );

            modelBuilder.Entity<IngredientPizza>().HasData(
                new IngredientPizza { PizzaId = 1, IngredientId = 1 },
                new IngredientPizza { PizzaId = 1, IngredientId = 2 },
                new IngredientPizza { PizzaId = 1, IngredientId = 3 },
                new IngredientPizza { PizzaId = 1, IngredientId = 4 },
                new IngredientPizza { PizzaId = 1, IngredientId = 5 },

                new IngredientPizza { PizzaId = 2, IngredientId = 1 },
                new IngredientPizza { PizzaId = 2, IngredientId = 2 },
                new IngredientPizza { PizzaId = 2, IngredientId = 3 },
                new IngredientPizza { PizzaId = 2, IngredientId = 6 },
                new IngredientPizza { PizzaId = 2, IngredientId = 7 },
                new IngredientPizza { PizzaId = 2, IngredientId = 8 },
                new IngredientPizza { PizzaId = 2, IngredientId = 9 }

            );
        }
    }
}
