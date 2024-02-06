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

        [Required, Display(Name = "Titre"), MaxLength(100)]
        public string Title { get; set; }

        [Required, Display(Name = "Description"), MaxLength(255)]
        public string Description { get; set; }

        [Required, Display(Name = "Statut")]
        public TaskStatus Status { get; set; }
    }
}
