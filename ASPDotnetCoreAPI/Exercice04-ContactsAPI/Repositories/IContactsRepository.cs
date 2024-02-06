using Exercice04_ContactsAPI.Models;
using System.Linq.Expressions;

namespace Exercice04_ContactsAPI.Repositories
{
    public interface IContactsRepository
    {
        ContactModel Add(ContactModel contact);

        public ContactModel? GetById(int id);

        List<ContactModel> GetAll();

        List<ContactModel> GetAll(Expression<Func<ContactModel, bool>> predicate);

        public ContactModel GetOneByName(string name);

        bool Update(int id, ContactModel contact);

        bool Delete(int id);
    }
}
