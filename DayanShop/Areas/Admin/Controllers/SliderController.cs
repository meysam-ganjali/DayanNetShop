using DayanShop.Application.FacadePattern.FSDSlider;
using DayanShop.Domains.Entities.Common;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class SliderController : Controller
    {
        private readonly IFSDSlider _slider;

        public SliderController(IFSDSlider slider)
        {
            _slider = slider;
        }
        public async Task<IActionResult> Index(SliderPossition? possition, string? searchKey)
        {
            var result = await _slider.ShowSlider.GetAsync(possition, searchKey);
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(Slider slider)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();
            var result = await _slider.CreateSlider.CreateAsync(file, slider);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Slider/Index");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Slider/Index");
            }
        }
    }
}
