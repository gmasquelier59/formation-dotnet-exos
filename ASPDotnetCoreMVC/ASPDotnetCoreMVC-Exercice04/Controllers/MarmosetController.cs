using ASPDotnetCoreMVC_Exercice04.Data;
using ASPDotnetCoreMVC_Exercice04.Models;
using ASPDotnetCoreMVC_Exercice04.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotnetCoreMVC_Exercice04.Controllers
{
    public class MarmosetController : Controller
    {
        private readonly MarmosetsRepository _repository;

        public MarmosetController(ApplicationDbContext dbContext)
        {
            _repository = new MarmosetsRepository(dbContext);
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult Details(int id)
        {
            MarmosetModel? marmoset = _repository.GetById(id);

            return View(marmoset);
        }

        public IActionResult CreateRandom()
        {
            MarmosetModel marmoset = MarmosetModel.New();
            marmoset = _repository.Save(marmoset);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            MarmosetModel marmoset = _repository.GetById(id);

            _repository.Delete(marmoset);

            return RedirectToAction(nameof(Index));
        }
    }
}
