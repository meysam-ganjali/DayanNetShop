using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface IEditParentCategory
{
    Task<ResultDto> EditParentCategoryAsync(ParentCategory parentCategory);
}

public class EditParentCategory : IEditParentCategory
{
    private readonly DayanShopContext _db;

    public EditParentCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> EditParentCategoryAsync(ParentCategory parentCategory)
    {
        var perentCategoryInDb = await _db.ParentCategories.FindAsync(parentCategory.Id);
        if (perentCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }

        perentCategoryInDb.ParentTitle = parentCategory.ParentTitle;
        perentCategoryInDb.ParentTitleSlug = parentCategory.ParentTitleSlug;
        perentCategoryInDb.DisplayOrder = parentCategory.DisplayOrder;
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"دسته بندی #{parentCategory.Id} با موفقیت ویرایش شد.",
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }
}