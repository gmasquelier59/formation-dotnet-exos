using ASPDotnetCoreMVC_Exercice06_TodoList.Data;
using ASPDotnetCoreMVC_Exercice06_TodoList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private ApplicationDbContext _dbContext;

        public TasksRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TaskModel> GetAll()
        {
            return _dbContext.Tasks.ToList<TaskModel>();
        }

        public TaskModel? GetById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault<TaskModel>(m => m.Id == id);
        }

        public void Delete(TaskModel task)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public TaskModel Save(TaskModel task)
        {
            TaskModel taskFromDb = GetById(task.Id);

            if (taskFromDb == null)
                _dbContext.Set<TaskModel>().Add(task);
            else
            {
                taskFromDb.Title = task.Title;
                taskFromDb.Description = task.Description;
                taskFromDb.Status = task.Status;
            }

            _dbContext.SaveChanges();

            return task;
        }
    }
}
