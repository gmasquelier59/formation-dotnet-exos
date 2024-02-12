using Exercice04_ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Exercice04_ContactsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
#nullable disable
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactsList> ContactsLists { get; set; }
#nullable enable

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactContactsList>()
                .ToTable("contact_contacts_list")
                .HasKey(c => new { c.ContactId, c.ContactsListId });

            //
            // CONTACTS
            //

            Contact contact1 = new Contact
            {
                Id = 1,
                Lastname = "DUPONT",
                Firstname = "Jean",
                Gender = ContactGenderEnum.Male,
                BirthDate = new DateTime(1981, 01, 23),
                AvatarURL = ""
            };

            Contact contact2 = new Contact
            {
                Id = 2,
                Lastname = "SMITH",
                Firstname = "Jane",
                Gender = ContactGenderEnum.Female,
                BirthDate = new DateTime(1993, 07, 02),
                AvatarURL = ""
            };

            modelBuilder.Entity<Contact>().HasData(
                contact1,
                contact2
            );

            //
            // LISTES DE CONTACTS
            //

            ContactsList friendsList = new ContactsList
            {
                Id = 1,
                Name = "Mes amis",
            };

            ContactsList colleguesList = new ContactsList
            {
                Id = 2,
                Name = "Mes collègues",
            };

            modelBuilder.Entity<ContactsList>().HasData(
                friendsList,
                colleguesList
            );

            //
            // AJOUT DES CONTACTS DANS LES LISTES
            //

            modelBuilder.Entity<ContactContactsList>()
                .HasData(
                    new ContactContactsList
                    {
                        ContactId = contact1.Id,
                        ContactsListId = friendsList.Id
                    },
                    new ContactContactsList
                    {
                        ContactId = contact1.Id,
                        ContactsListId = colleguesList.Id
                    },
                    new ContactContactsList
                    {
                        ContactId = contact2.Id,
                        ContactsListId = colleguesList.Id
                    }
            );
        }
    }
}
