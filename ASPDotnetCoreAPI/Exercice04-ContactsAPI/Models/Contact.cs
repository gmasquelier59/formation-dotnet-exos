using Exercice04_ContactsAPI.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercice04_ContactsAPI.Models
{
    [Table("contact")]
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("firstname"), Required, MaxLength(250), RegularExpression(@"^[a-zA-Z_\- ]+$", ErrorMessage = "Le prénom ne doit contenir que des lettres (minuscules et majuscules) et les caractères tirets, espaces, blancs soulignés")]
        public string Firstname { get; set; } = "";

        [Column("lastname"), Required, MaxLength(250), RegularExpression(@"^[A-Z_\- ]+$", ErrorMessage = "Le prénom ne doit contenir que des lettres majuscules et les caractères tirets, espaces, blancs soulignés")]
        public string Lastname { get; set; } = "";

        [Column("fullname"), MaxLength(501)]
        public string Fullname => Firstname + " " + Lastname;

        [Column("birthdate"), Required]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age => (DateTime.Now - BirthDate).Days / 365;

        [Column("gender"), Required]
        public ContactGenderEnum Gender { get; set; }

        [Column("avatarURL"), MaxLength(250)]
        public string? AvatarURL { get; set; }

        [PasswordValidation]
        public List<ContactsList> ContactsLists { get; set; }
    }
}
