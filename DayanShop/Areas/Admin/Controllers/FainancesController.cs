using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.ManagerRole)]
    public class FainancesController : Controller
    {
        public async Task<IActionResult> OrderList()
        {
            return View();
        }
    }
}
