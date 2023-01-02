using DayanShop.Application.FacadePattern.FSDCategoryAttr;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class CategoryAttributeController : Controller
    {
        private readonly IFSDCategoryAttribute _categoryAttr;

        public CategoryAttributeController(IFSDCategoryAttribute categoryAttr)
        {
            _categoryAttr = categoryAttr;
        }

        public async Task<IActionResult> Index(int id, string? searchKey) // id => Child Category Id For Show Attr
        {
            var result = await _categoryAttr.CategoryAttributeInformation.GetCategoryAttrAsync(id, searchKey);
            ViewBag.CategoryId = id;
            if (result.IsSuccess)
            {
                return View(result.Data);
            }

            TempData["error"] = result.Message;
            return Redirect($"/Admin/CategoryAttribute/Index/{id}");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAttr(CategoryAttribute attr, int ParentCatId)
        {
            var result = await _categoryAttr.CreateCategoryAttribute.CreateCategoryAttrAsync(attr);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Category/ChildList/{ParentCatId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Category/ChildList/{ParentCatId}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategoryAttr(int id)
        {
            var result = await _categoryAttr.RemoveCategoryAttribute.RemoveCategoryAttrAsync(id);
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
        public async Task<IActionResult> EditCategoryAttribute(CategoryAttribute categoryAttribute)
        {
            var result = await _categoryAttr.EditCategoryAttribute.EditCategoryAttrAsync(categoryAttribute);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/CategoryAttribute/Index/{categoryAttribute.ChildCategoryId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/CategoryAttribute/Index/{categoryAttribute.ChildCategoryId}");
            }
        }
    }
}
