using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ecom1.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(100)]
        public string NameProduct { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceProduct { get; set; }
        public string? Description { get; set; }

        public int Quantity { get; set; }

        public string? ImageUrl { get; set; }
    }
}