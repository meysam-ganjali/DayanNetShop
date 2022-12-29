using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.CategoryAttr;

public interface IEditCategoryAttribute
{
    Task<ResultDto> EditCategoryAttrAsync(CategoryAttribute categoryAttr);
}

public class EditCategoryAttribute : IEditCategoryAttribute
{
    private readonly DayanShopContext _db;

    public EditCategoryAttribute(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> EditCategoryAttrAsync(CategoryAttribute categoryAttr)
    {
        var attrCategoryInDb = await _db.CategoryAttributes.FindAsync(categoryAttr.Id);
        if (attrCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = " ویژگی یافت نشد"
            };
        }

        attrCategoryInDb.AttributeTitle = categoryAttr.AttributeTitle;
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"ویژگی #{attrCategoryInDb.Id} با موفقیت ویرایش شد.",
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