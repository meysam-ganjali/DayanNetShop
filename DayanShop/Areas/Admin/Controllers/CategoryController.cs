using DayanShop.Application.FacadePattern.FSDCategory;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ManagerRole)]
    public class CategoryController : Controller
    {
        private readonly IFSDPatternCategory _category;

        public CategoryController(IFSDPatternCategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index(string? searchKey)
        {
            var result = await _category.CategoryInformation.GetAllParentCategoryAsync(searchKey);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            TempData["error"] = result.Message;
            return Redirect("/Admin/Category/Index");
        }
        [HttpPost]
        public async Task<IActionResult> CreateParentCategory(ParentCategory parentCategory)
        {
            var result = await _category.CreateParentCategory.CreateCategoryAsync(parentCategory);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditParentCategory(ParentCategory parentCategory)
        {
            var result = await _category.EditParentCategory.EditParentCategoryAsync(parentCategory);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveParentCategory(int id)
        {
            var result = await _category.RemoveParentCategory.RemoveParentCategoryAsync(id);
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
        public async Task<IActionResult> CreateChildCategory(ChildCategory childCategory)
        {
            var result = await _category.CreateChildCategory.CreateChildCategoryAsync(childCategory);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect("/Admin/Category/Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChildList(int id, string? searchKey)// id => ParentCategory Id
        {
            ViewBag.ParentCat = id;
            var result = await _category.ChildCategoryInformation.GetChildCategoryAsync(id, searchKey);
            if (result.IsSuccess)
            {
                return View(result.Data);
            }
            TempData["error"] = result.Message;
            return Redirect("/Admin/Category/Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveChildCategory(int id)
        {
            var result = await _category.RemoveChildCategory.RemoveChildCategoryAsync(id);
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

        public async Task<IActionResult> EditChildCategory(ChildCategory childCategory)
        {
            var result = await _category.EditChildCatrgory.EditChildCategoryAsync(childCategory);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return Redirect($"/Admin/Category/ChildList/{childCategory.ParentCategoryId}");
            }
            else
            {
                TempData["error"] = result.Message;
                return Redirect($"/Admin/Category/ChildList/{childCategory.ParentCategoryId}");
            }
        }
    }
}
