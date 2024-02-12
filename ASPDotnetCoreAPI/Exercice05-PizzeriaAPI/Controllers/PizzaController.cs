using Exercice05_PizzeriaAPI.Models;
using Exercice05_PizzeriaAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercice05_PizzeriaAPI.Controllers
{
    [Route("/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaRepository _repository;

        public PizzaController(PizzaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            Pizza pizzaCreated = _repository.Create(pizza);

            if (pizzaCreated == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
        }

        [HttpPost("add-toping/{pizzaId")]
        public ActionResult AddTopping(int pizzaId, [FromBody] Ingredient ingredient)
        {
            Pizza? pizza = _repository.GetById(pizzaId);

            if (pizza == null)
                return NotFound();

            return Ok(_repository.AddIngredientToPizza(ingredient, pizza));
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Pizza? pizza = _repository.GetById(id);

            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }

        [HttpGet("/menu")]
        public ActionResult<List<Pizza>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Pizza? pizza = _repository.GetById(id);

            if (pizza == null)
                return NotFound();

            _repository.Delete(pizza);

            return Ok();
        }
    }
}
