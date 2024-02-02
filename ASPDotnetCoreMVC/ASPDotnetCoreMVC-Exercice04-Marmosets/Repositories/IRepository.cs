using ASPDotnetCoreMVC_Exercice04.Models;

namespace ASPDotnetCoreMVC_Exercice04.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        TEntity Save(TEntity entity);
    }
}