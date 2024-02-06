using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice04_ContactsAPI.Models
{
    [Table("contact")]
    public class ContactModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname"), Required, MaxLength(250)]
        public string Firstname { get; set; } = "";

        [Column("lastname"), Required, MaxLength(250)]
        public string Lastname { get; set; } = "";

        [Column("fullname"), MaxLength(501)]
        public string Fullname { get => Firstname + " " + Lastname; }

        [Column("birthdate"), Required]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age { get => (DateTime.Now - BirthDate).Days / 365 ; }

        [Column("gender"), Required]
        public ContactGenders Gender { get; set; }

        [Column("avatarURL"), MaxLength(250)]
        public string? AvatarURL { get; set; }
    }
}
