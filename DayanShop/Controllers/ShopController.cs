using DayanShop.Application.FacadePattern.FSDShoping;
using DayanShop.Application.StoreServices.Queries.Shoping;
using DayanShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IFSDShoping _shopService;

        public ShopController(IFSDShoping shopService)
        {
            _shopService = shopService;
        }
        public IActionResult Index(Ordering ordering, string Searchkey, int? CatId = null, int page = 1, int pageSize = 2)
        {
            var result = _shopService.FetchProductWithFilter.Execute(ordering, Searchkey, page, pageSize, CatId);
            return View(result.Data);
        }
    }
}
