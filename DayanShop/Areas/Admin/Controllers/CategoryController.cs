using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
