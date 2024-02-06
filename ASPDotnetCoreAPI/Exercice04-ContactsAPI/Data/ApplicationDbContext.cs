using Exercice04_ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Exercice04_ContactsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactModel>().HasData(
                new ContactModel
                {
                    Id = 1,
                    Lastname = "DUPONT",
                    Firstname = "Jean",
                    Gender = ContactGenders.Male,
                    BirthDate = new DateTime(1981, 01, 23),
                    AvatarURL = ""
                },
                new ContactModel
                {
                    Id = 2,
                    Lastname = "SMITH",
                    Firstname = "Jane",
                    Gender = ContactGenders.Female,
                    BirthDate = new DateTime(1993, 07, 02),
                    AvatarURL = ""
                }
            );
        }
    }
}
