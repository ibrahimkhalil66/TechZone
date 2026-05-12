using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ecom1.Models;
namespace Ecom1.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; } = 1;
    }
}