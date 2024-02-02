using ASPDotnetCoreMVC_Exercice06_TodoList.Models;
using ASPDotnetCoreMVC_Exercice06_TodoList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Controllers
{
    public class TasksController : Controller
    {
        private ITasksRepository _repository;

        public TasksController(ITasksRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult ChangeStatus(int id, ASPDotnetCoreMVC_Exercice06_TodoList.Models.TaskStatus status)
        {
            TaskModel task = _repository.GetById(id);

            if (task != null)
            {
                task.Status = status;
                _repository.Save(task);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            TaskModel task = _repository.GetById(id);

            if (task != null)
            {
                _repository.Delete(task);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateForm(int id)
        {
            TaskModel task = id > 0 ? _repository.GetById(id) : null;

            if (task == null)
                return View();

            return View(task);
        }

        public IActionResult Create(TaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(CreateForm), model);
            }

            _repository.Save(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
