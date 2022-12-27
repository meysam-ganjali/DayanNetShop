﻿using DayanShop.Application.FacadePattern.FSDCategory;
using DayanShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IFSDPatternCategory _category;

        public CategoryController(IFSDPatternCategory category)
        {
            _category = category;
        }
        public async Task<IActionResult> Index()
        {
            return View();
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
    }
}
