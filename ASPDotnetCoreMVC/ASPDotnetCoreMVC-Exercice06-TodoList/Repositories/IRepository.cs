using ASPDotnetCoreMVC_Exercice06_TodoList.Models;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity Save(TEntity entity);
    }
}