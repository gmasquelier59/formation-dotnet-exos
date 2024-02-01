using ASPDotnetCoreMVC_Exercice04.Models;

namespace ASPDotnetCoreMVC_Exercice04.Repositories
{
    public interface IMarmosetsRepository : IRepository<MarmosetModel>
    {
        void Delete(MarmosetModel marmoset);
        List<MarmosetModel> GetAll();
        MarmosetModel? GetById(int id);
        MarmosetModel Save(MarmosetModel marmoset);
    }
}