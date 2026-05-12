using System.ComponentModel.DataAnnotations;

namespace Ecom1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<OrderItem>? OrderItems { get; set; }
    }
}