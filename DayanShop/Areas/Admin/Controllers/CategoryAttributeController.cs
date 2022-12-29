using DayanShop.Application.FacadePattern.FSDCategoryAttr;
using DayanShop.Domains.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryAttributeController : Controller
    {
        private readonly IFSDCategoryAttribute _categoryAttr;

        public CategoryAttributeController(IFSDCategoryAttribute categoryAttr)
        {
            _categoryAttr = categoryAttr;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAttr(CategoryAttribute attr,int ParentCatId)
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
    }
}
