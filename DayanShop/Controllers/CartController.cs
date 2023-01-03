using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult CartList(int id)
        {
            return View();
        }
    }
}
