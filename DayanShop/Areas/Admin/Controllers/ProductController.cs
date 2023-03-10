using DayanShop.Application.FacadePattern.FSDCategory;
using DayanShop.Application.FacadePattern.FSDProduct;
using DayanShop.Application.StoreServices.Queries.Product;
using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
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
            var attr = await _productService.AttributeInfo.GetProductAttrAsync(id);
            ViewBag.attr = new SelectList(attr.Data, "Id", "AttributeTitle");

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

        [HttpPost]
        public async Task<IActionResult> CreateImage(ProductImage productImage)
        {
            var file = HttpContext.Request.Form.Files.FirstOrDefault();
            var result = await _productService.AddProductPicture.AddPictureAsync(productImage,file);
            if (result.IsSuccess)
            {
                return Redirect($"/Admin/Product/ProductDetails/{productImage.ProductId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{productImage.ProductId}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductPicture(int id)
        {
            var result = await _productService.RemoveProductPicture.DeleteAsync(id);
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

        [HttpPost]
        public async Task<IActionResult> AddProductAttribute(ProductAttribute attr)
        {

            var result = await _productService.AddProductFeature.AddFeatureAsync(attr);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{attr.ProductId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{attr.ProductId}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductReview(ProductReviw review)
        {
            var review_file = HttpContext.Request.Form.Files.FirstOrDefault();
            var result = await _productService.AddProductReview.AddReviewAsync(review_file, review);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{review.ProductId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{review.ProductId}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProductFeatureValue(ProductAttribute attr)
        {

            var result = await _productService.EditProductAttribute.UpdataAttrValueasync(attr);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{attr.ProductId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{attr.ProductId}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductAttr(int id)
        {
            var result = await _productService.RemoveProductFeature.RemoveAsync(id);
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
        [HttpPost]
        public async Task<IActionResult> RemoveProductReview(int id)
        {
            var result = await _productService.RemoveProductReview.RemoveAsync(id);
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
        [HttpPost]
        public async Task<IActionResult> EditProductReviw(ProductReviw review)
        {
            var edit_review_file = HttpContext.Request.Form.Files.FirstOrDefault();
            var result = await _productService.EditProductReview.EditAsync(edit_review_file, review);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{review.ProductId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{review.ProductId}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            var productModel = await _productService.GetProduct.GetAsync(id);
            if (productModel.IsSuccess)
            {

                return View(productModel.Data);
            }
            else
            {
                TempData["error"] = productModel.Message;
                return Redirect($"/Admin/Product/ProductDetails/{id}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            var result = await _productService.EditProduct.EditAsync(product);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{product.Id}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Product/ProductDetails/{product.Id}");
            }
        }
    }
}
