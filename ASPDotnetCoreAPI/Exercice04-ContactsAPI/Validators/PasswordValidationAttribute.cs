using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Exercice04_ContactsAPI.Validators
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Le mot de passe ne peut pas être null");

            string? stringValue = value.ToString();

            if (String.IsNullOrWhiteSpace(stringValue))
                return new ValidationResult("Le mot de passe ne peut pas être vide");

            //  Minimum 8 caractères
            if (stringValue.Length < 8)
                return new ValidationResult("Le mot de passe doit comporter au minimum 8 caractères");

            //  Maximum 15 caractères
            if (stringValue.Length > 15)
                return new ValidationResult("Le mot de passe doit comporter au maximum 15 caractères");

            //  Minimum 2 lettres majuscules
            if (!Regex.IsMatch(stringValue, @"[A-Z].*?[A-Z]"))
                return new ValidationResult("Le mot de passe doit comporter au minimum 2 lettres majuscules");

            //  Minimum 2 lettres minuscules
            if (!Regex.IsMatch(stringValue, @"[a-z].*?[a-z]"))
                return new ValidationResult("Le mot de passe doit comporter au minimum 2 lettres minuscules");

            //  Minimum 2 chiffres
            if (!Regex.IsMatch(stringValue, @"\d.*?\d"))
                return new ValidationResult("Le mot de passe doit comporter au minimum 2 chiffres");

            //  Minimum 2 caractères spéciaux parmi !@_-
            if (!Regex.IsMatch(stringValue, @"[!@_\-].*?[!@_\-]"))
                return new ValidationResult("Le mot de passe doit comporter au minimum 2 caractères spéciaux parmi !@_-");

            return ValidationResult.Success;
        }
    }
}
