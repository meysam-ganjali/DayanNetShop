using DayanShop.Application.FacadePattern.FSDCategory;
using DayanShop.Application.FacadePattern.FSDProduct;
using DayanShop.Application.StoreServices.Queries.Product;
using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IFSDProduct _productService;
        private readonly IHostingEnvironment _environment;

        public ProductController(IFSDProduct productService, IHostingEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }

        public async Task<IActionResult> Index(string? searchKey, int pageSize  = 50, int page = 1)
        {
            var products =  _productService.GetAllProduct.GetAllProductAsync(new RequestGetProductDto
            {
                Page = page,
                PageSize = pageSize,
                SearchKey = searchKey
            });
            return View(products);
        }

        public async Task<IActionResult> CreateProduct()
        {
            var category = await _productService.GetChildCategory.GetAllChildCategoryAsync();
            ViewBag.Category =
                new SelectList(category.Data, "Id", "ChildTitle");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = await _productService.CreateProduct.CreateProductAsync(product);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Product/Index");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Product/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var result = await _productService.RemoveProduct.RemoveProductAsync(id);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Json(result);
            }
            else
            {
                TempData["error"] = result.Message;
                return Json(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var result = await _productService.GetProductDetails.ProductDetailesAsync(id);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Product/Index");
            }
        }
    }
}
