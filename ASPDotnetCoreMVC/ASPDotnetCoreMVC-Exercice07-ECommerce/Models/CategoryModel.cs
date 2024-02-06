using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASPDotnetCoreMVC_Exercice07_ECommerce.Models
{
    [Table("category")]
    public class CategoryModel
    {
        [Required, Column("id"), Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Required, MaxLength(100), Column("name"), Display(Name = "Nom")]
        public string Name { get; set; }

        [Required, Display(Name = "Produits associés")]
        public List<ProductModel> Products { get; set; }
    }
}
