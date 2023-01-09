using DayanShop.Application.FacadePattern.FSDCategory;
using Microsoft.AspNetCore.Mvc;

namespace DayanShop.ViewComponents;

public class MenuFeature: ViewComponent
{
    private readonly IFSDPatternCategory _cat;

    public MenuFeature(IFSDPatternCategory cat)
    {
        _cat = cat;
    }
     public async Task<IViewComponentResult> InvokeAsync()
     {
         var menuItem = await _cat.CategoryInformation.GetAllParentCategoryAsync(null);
            return View(viewName: "GetMenu", menuItem.Data);
        }

}