using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project01.Data;
using Project01.Models;
using Project01.ViewModels;

namespace Project01.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Catalog()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var viewModel = new ProductCreateVM
            {
                Categories = new SelectList(categories, "Id", "Name")
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM viewModel)
        {
            int finalCategoryId;

            // 1. Якщо користувач обрав категорію і вона існує в БД:
            if (viewModel.CategoryId.HasValue &&
                await _context.Categories.AnyAsync(c => c.Id == viewModel.CategoryId.Value))
            {
                finalCategoryId = viewModel.CategoryId.Value;
            }
            else
            {
                // 2. Інакше беремо або створюємо "Без категорії"
                var defaultCategory = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Name == "Без категорії");

                if (defaultCategory == null)
                {
                    defaultCategory = new Category { Name = "Без категорії" };
                    await _context.Categories.AddAsync(defaultCategory);
                    await _context.SaveChangesAsync();
                }

                finalCategoryId = defaultCategory.Id;
            }

            var product = new Product
            {
                Name = viewModel.Name ?? "Без назви",
                Price = viewModel.Price ?? 0,
                Description = viewModel.Description,
                Image = viewModel.Image,
                Amount = viewModel.Amount ?? 0,
                CategoryId = finalCategoryId
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Catalog");
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
