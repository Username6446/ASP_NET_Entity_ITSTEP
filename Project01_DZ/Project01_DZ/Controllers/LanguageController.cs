using Microsoft.AspNetCore.Mvc;

namespace Project01_DZ.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Favorite()
        {
            return View();
        }
    }
}
