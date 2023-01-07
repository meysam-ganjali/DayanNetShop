using DayanShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DayanShop.Application.FacadePattern.FSDSlider;

namespace DayanShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFSDSlider _slider;

        public HomeController(IFSDSlider slider)
        {
            _slider = slider;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            var slider = await _slider.ShowSlider.GetAsync(null, null);
            model.SliderLst = slider.Data;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}