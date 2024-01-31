using ASPDotnetCoreMVC_Exercice04.Data;
using ASPDotnetCoreMVC_Exercice04.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotnetCoreMVC_Exercice04.Controllers
{
    public class MarmosetController : Controller
    {
        private readonly MarmosetsFakeDb _db;

        public MarmosetController(MarmosetsFakeDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetAll());
        }

        public IActionResult Details(int id)
        {
            MarmosetModel marmoset = _db.GetById(id);

            return View(marmoset);
        }

        public IActionResult CreateRandom()
        {
            MarmosetModel marmoset = new MarmosetModel();
            marmoset = _db.Save(marmoset);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            MarmosetModel marmoset = _db.GetById(id);

            _db.Delete(marmoset);

            return RedirectToAction(nameof(Index));
        }
    }
}
