using Microsoft.AspNetCore.Mvc;

namespace Project01_DZ.Controllers
{
    public class PlanetController : Controller
    {
        public IActionResult BestPlaces()
        {
            return View();
        }
    }
}
