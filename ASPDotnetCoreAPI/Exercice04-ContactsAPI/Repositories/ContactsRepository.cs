using Exercice04_ContactsAPI.Data;
using Exercice04_ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exercice04_ContactsAPI.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactModel Add(ContactModel contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

            return contact;
        }

        public List<ContactModel> GetAll()
        {
            return _dbContext.Contacts.ToList<ContactModel>();
        }

        public List<ContactModel> GetAll(Expression<Func<ContactModel, bool>> predicate)
        {
            return _dbContext.Contacts.Where(predicate).ToList();
        }

        public ContactModel? GetById(int id)
        {
            return _dbContext.Contacts.FirstOrDefault<ContactModel>(c => c.Id == id);
        }

        public ContactModel? GetOneByName(string name)
        {
            return _dbContext.Contacts.FirstOrDefault<ContactModel>(c => c.Lastname.ToLower() == name.ToLower());
        }

        public bool Update(int id, ContactModel contact)
        {
            ContactModel? contactFromDb = GetById(id);

            if (contactFromDb == null)
                return false;

            if (contactFromDb.Lastname != contact.Lastname)
                contactFromDb.Lastname = contact.Lastname;

            if (contactFromDb.Firstname != contact.Firstname)
                contactFromDb.Firstname = contact.Firstname;

            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;

            if (contactFromDb.Gender != contact.Gender)
                contactFromDb.Gender = contact.Gender;

            if (contactFromDb.AvatarURL != contact.AvatarURL)
                contactFromDb.AvatarURL = contact.AvatarURL;

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            ContactModel? contact = GetById(id);
            
            if (contact == null)
                return false;

            _dbContext.Contacts.Remove(contact);

            return _dbContext.SaveChanges() > 0;
        }
    }
}
