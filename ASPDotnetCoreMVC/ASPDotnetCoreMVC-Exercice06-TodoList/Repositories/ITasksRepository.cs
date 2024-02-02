using ASPDotnetCoreMVC_Exercice06_TodoList.Models;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Repositories
{
    public interface ITasksRepository : IRepository<TaskModel>
    {
        void Delete(TaskModel marmoset);
        List<TaskModel> GetAll();
        TaskModel? GetById(int id);
        TaskModel Save(TaskModel marmoset);
    }
}