using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercice04_ContactsAPI.Models
{
    [Table("contacts_list")]
    public class ContactsList
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name"), Required, MaxLength(250)]
        public string Name { get; set; } = "";

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
