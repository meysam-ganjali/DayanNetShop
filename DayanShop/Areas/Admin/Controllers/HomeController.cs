using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
