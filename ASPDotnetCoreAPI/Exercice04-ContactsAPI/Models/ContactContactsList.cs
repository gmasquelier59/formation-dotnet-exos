using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice04_ContactsAPI.Models
{
    public class ContactContactsList
    {
        [Column("contact_id")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [Column("contacts_list_id")]
        public int ContactsListId { get; set; }

        public ContactsList ContactsList { get; set; }
    }
}
