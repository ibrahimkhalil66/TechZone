using Ecom1.Data;
using Ecom1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Ecom1Context _context;

        public OrdersController(Ecom1Context context)
        {
            _context = context;
        }

        // GET: /Orders/Checkout
        public async Task<IActionResult> Checkout()
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }

        // POST: /Orders/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            order.CreatedAt = DateTime.Now;
            order.TotalPrice = cartItems.Sum(c => (decimal)(c.Product!.PriceProduct ?? 0) * c.Quantity);

            order.OrderItems = cartItems.Select(c => new OrderItem
            {
                ProductId = c.ProductId,
                Quantity = c.Quantity,
                Price = (decimal)(c.Product!.PriceProduct ?? 0)
            }).ToList();

            _context.Orders.Add(order);

            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}