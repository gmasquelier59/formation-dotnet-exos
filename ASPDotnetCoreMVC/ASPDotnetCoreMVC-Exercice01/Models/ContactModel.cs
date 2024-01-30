using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC_Exercice01.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Résumé")]
        public string Resume { get; set; }
        public string Photo { get; set; }
    }
}
