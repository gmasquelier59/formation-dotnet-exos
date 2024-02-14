using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exercice02_FormulairePersonne.Models
{
    public class Person
    {
        [Required]
        [MinLength(1, ErrorMessage = "Le nom doit avoir au minimum 1 caractère")]
        [MaxLength(50, ErrorMessage = "Le nom doit avoir au maximum 50 caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Le prénom doit avoir au minimum 1 caractère")]
        [MaxLength(50, ErrorMessage = "Le prénom doit avoir au maximum 50 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [MinLength(1, ErrorMessage = "L'adresse doit avoir au minimum 1 caractère")]
        [MaxLength(100, ErrorMessage = "L'adresse doit avoir au maximum 100 caractères")]
        [Display(Name = "Adresse")]
        public string? Address {  get; set; }

        [RegularExpression("^[0-9]{5}$", ErrorMessage = "Le code postal doit être composé de 5 chiffres")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Le code postal doit comporter 5 chiffres")]
        [Display(Name = "Code postal")]
        public string Zip {  get; set; }

        //[Required]
        //[MinLength(1, ErrorMessage = "La ville doit avoir au minimum 1 caractère")]
        //[MaxLength(50, ErrorMessage = "La ville doit avoir au maximum 50 caractères")]
        //public string City { get; set; }

        [Required]
        [Display(Name = "Date de naissance")]
        public DateTime Birthday { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Age")]
        public int Age { get => (int)(DateTime.Now - Birthday).TotalDays / 365; }

        [Display(Name = "Est marié(e)")]
        public bool IsMarried {  get; set; }

        [Required]
        [Display(Name = "Couleur favorite")]
        [Range(1,3, ErrorMessage = "La couleur favorite est obligatoire")]
        public Colors FavoriteColor { get; set; }
    }

    public enum Colors
    {
        [Display(Name = "(aucune)")]
        None = 0,
        [Display(Name = "Rouge")]
        Red = 1,
        [Display(Name = "Vert")]
        Green = 2,
        [Display(Name = "Bleu")]
        Blue = 3
    }
}
