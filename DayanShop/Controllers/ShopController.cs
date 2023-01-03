using DayanShop.Application.FacadePattern.FSDProduct;
using DayanShop.Application.FacadePattern.FSDShoping;
using DayanShop.Application.StoreServices.Queries.Shoping;
using DayanShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IFSDShoping _shopService;
        private readonly IFSDProduct _product;

        public ShopController(IFSDShoping shopService, IFSDProduct product)
        {
            _shopService = shopService;
            _product = product;
        }
        public IActionResult Index(Ordering ordering, string Searchkey, int? CatId = null, int page = 1, int pageSize = 50)
        {
            var result = _shopService.FetchProductWithFilter.Execute(ordering, Searchkey, page, pageSize, CatId);
            return View(result.Data);
        }

        public async Task<IActionResult> ProductDetaile(int id)
        {
            var result = await _product.GetProductDetails.ProductDetailesAsync(id);
            return View(result.Data);
        }
    }
}
