using Exercice04_ContactsAPI.Models;
using Exercice04_ContactsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04_ContactsAPI.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository _repository;

        public ContactsController(IContactsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            contact = _repository.Add(contact);

            return CreatedAtAction(nameof(GetById), new { id = 1 }, contact);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? name = "")
        {
            if (string.IsNullOrEmpty(name))
                return Ok(_repository.GetAll());

            return Ok(_repository.GetAll(c => c.Lastname.ToLower().StartsWith(name.ToLower())));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ContactModel? contact = _repository.GetById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetOneByName(string name)
        {
            ContactModel contact = _repository.GetOneByName(name);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ContactModel contact)
        {
            if (!_repository.Update(id, contact))
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.GetById(id) == null)
                return NotFound();

            if (!_repository.Delete(id))
                return BadRequest();

            return Ok();
        }
    }
}
