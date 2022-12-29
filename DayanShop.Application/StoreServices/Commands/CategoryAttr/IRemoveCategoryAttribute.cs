using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.CategoryAttr;

public interface IRemoveCategoryAttribute
{
    Task<ResultDto> RemoveCategoryAttrAsync(int id);
}

public class RemoveCategoryAttribute : IRemoveCategoryAttribute
{
    private readonly DayanShopContext _db;

    public RemoveCategoryAttribute(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> RemoveCategoryAttrAsync(int id)
    {
        var attrCategoryInDb = await _db.CategoryAttributes
            .Include(a=>a.ChildCategory)
            .FirstOrDefaultAsync(c=>c.Id.Equals(id));
        if (attrCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"ویژگی با کد {id} یافت نشد"
            };
        }

        try
        {
            var result = _db.CategoryAttributes.Remove(attrCategoryInDb);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"ویژگی با عنوان {attrCategoryInDb.AttributeTitle} مربوط به دسته بندی {attrCategoryInDb.ChildCategory.ChildTitle} از سیستم حذف گردید",
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