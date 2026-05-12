using Ecom1.Data;
using Ecom1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom1.Controllers
{
    public class CartController : Controller
    {
        private readonly Ecom1Context _context;

        public CartController(Ecom1Context context)
        {
            _context = context;
        }

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .ToListAsync();

            return View(cartItems);
        }

        // GET: /Cart/AddToCart/5
        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == id);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = id,
                    Quantity = 1
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
                _context.CartItems.Update(cartItem);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: /Cart/Remove/5
        public async Task<IActionResult> Remove(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}