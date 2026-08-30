using Microsoft.AspNetCore.Mvc;
using Project01.Data;
using Project01.Models;

namespace Project01.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Catalog()
        {
            IEnumerable<Product> products = _context.Products;

            return View(products);
        }
    }
}
