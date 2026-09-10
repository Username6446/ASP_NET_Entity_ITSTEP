using Microsoft.AspNetCore.Mvc;
using Project01.Data;
using Project01.Models;
using Project01.ViewModels;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM viewModel)
        {
            var product = new Product
            {
                Name = viewModel.Name!,
                Price = viewModel.Price ?? 0,
                Description = viewModel.Description,
                Image = viewModel.Image,
                Amount = viewModel.Amount ?? 0,
                CategoryId = 1

            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Catalog");
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Catalog");
            }
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Catalog");
            }
            var viewModel = new ProductUpdateVM
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                Amount = product.Amount,
                CategoryId = product.CategoryId
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProductUpdateVM viewModel)
        {
            var product = new Product
            {
                Id = viewModel.Id,
                Image = viewModel.Image,
                Name = viewModel.Name!,
                Price = viewModel.Price ?? 0,
                Description = viewModel.Description,
                Amount = viewModel.Amount ?? 0,
                CategoryId = viewModel.CategoryId ?? 1
            };

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Catalog");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Catalog");
        }
    }
}
