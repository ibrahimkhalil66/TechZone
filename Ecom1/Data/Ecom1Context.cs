using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecom1.Models;

namespace Ecom1.Data
{
    public class Ecom1Context : IdentityDbContext
    {
        public Ecom1Context(DbContextOptions<Ecom1Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<CartItem> CartItems { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderItem> OrderItems { get; set; } = default!;
    }
}