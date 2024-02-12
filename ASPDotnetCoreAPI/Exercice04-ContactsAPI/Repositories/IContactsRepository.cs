using Exercice04_ContactsAPI.Models;
using System.Linq.Expressions;

namespace Exercice04_ContactsAPI.Repositories
{
    public interface IContactsRepository
    {
        Contact Add(Contact contact);

        public Contact? GetById(int id);

        List<Contact> GetAll();

        List<Contact> GetAll(Expression<Func<Contact, bool>> predicate);

        public Contact GetOneByName(string name);

        bool Update(int id, Contact contact);

        bool Delete(int id);
    }
}
