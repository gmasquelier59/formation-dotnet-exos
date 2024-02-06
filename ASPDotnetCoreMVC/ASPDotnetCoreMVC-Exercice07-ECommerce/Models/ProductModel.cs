using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPDotnetCoreMVC_Exercice07_ECommerce.Models
{
    [Table("product")]
    public class ProductModel
    {
        [Required, Column("id"), Display(Name = "Numéro de produit")]
        public int Id { get; set; }

        [Required, MaxLength(100), Column("name"), Display(Name = "Nom")]
        public string Name { get; set; }

        [Required, MaxLength(255), Column("description"), Display(Name = "Description")]
        public string Description { get; set; }

        [Required, Range(1, 50000), Column("price", TypeName = "DECIMAL(10, 2)"), Display(Name = "Prix")]
        public decimal Price { get; set; }

        [Required, Range(0,10000), Column("stock"), Display(Name = "Quantité en stock")]
        public int Stock {  get; set; }

        [Required, MaxLength(255), Column("picture_path"), Display(Name = "Photo")]
        public string PicturePath {  get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        
        [Required, Column("category"), Display(Name = "Catégorie"), ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }
    }
}
