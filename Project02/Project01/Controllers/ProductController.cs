using Microsoft.AspNetCore.Mvc;

namespace Project01.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }
    }
}
