using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecom1.Data;

namespace Ecom1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Ecom1Context _context;

        public ProductsController(Ecom1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.IdProduct == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}