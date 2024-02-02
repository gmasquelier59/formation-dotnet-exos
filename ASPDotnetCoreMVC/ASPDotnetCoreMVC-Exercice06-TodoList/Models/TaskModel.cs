using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC_Exercice06_TodoList.Models
{
    public enum TaskStatus
    {
        [Display(Name = "En cours")]
        Opened = 1,

        [Display(Name = "Terminé")]
        Closed = 2
    }

    public class TaskModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Display(Name = "Titre")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Statut")]
        [Required]
        public TaskStatus Status { get; set; }
    }
}
