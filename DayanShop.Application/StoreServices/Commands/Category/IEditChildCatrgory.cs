using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface IEditChildCatrgory
{
    Task<ResultDto> EditChildCategoryAsync(ChildCategory childCategory);
}

public class EditChildCatrgory : IEditChildCatrgory
{
    private readonly DayanShopContext _db;

    public EditChildCatrgory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> EditChildCategoryAsync(ChildCategory childCategory)
    {
        var childCategoryInDb = await _db.ChildCategories.FindAsync(childCategory.Id);
        if (childCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }

        childCategoryInDb.ChildTitle = childCategory.ChildTitle;
        childCategoryInDb.ChildTitleSlug = childCategory.ChildTitleSlug;
        childCategoryInDb.DisplayOrder = childCategory.DisplayOrder;
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"دسته بندی #{childCategory.Id} با موفقیت ویرایش شد.",
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