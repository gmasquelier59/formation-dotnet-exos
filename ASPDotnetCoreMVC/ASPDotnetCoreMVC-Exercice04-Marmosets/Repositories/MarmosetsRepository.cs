using ASPDotnetCoreMVC_Exercice04.Data;
using ASPDotnetCoreMVC_Exercice04.Models;

namespace ASPDotnetCoreMVC_Exercice04.Repositories
{
    public class MarmosetsRepository : IMarmosetsRepository
    {
        private ApplicationDbContext _dbContext;

        public MarmosetsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MarmosetModel> GetAll()
        {
            return _dbContext.Marmosets.ToList<MarmosetModel>();
        }

        public MarmosetModel? GetById(int id)
        {
            return _dbContext.Marmosets.FirstOrDefault<MarmosetModel>(m => m.Id == id);
        }

        public void Delete(MarmosetModel marmoset)
        {
            _dbContext.Marmosets.Remove(marmoset);
            _dbContext.SaveChanges();
        }

        public MarmosetModel Save(MarmosetModel marmoset)
        {
            _dbContext.Set<MarmosetModel>().Update(marmoset);
            _dbContext.SaveChanges();

            return marmoset;
        }
    }
}
