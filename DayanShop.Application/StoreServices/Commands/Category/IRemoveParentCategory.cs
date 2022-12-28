using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface IRemoveParentCategory
{
    Task<ResultDto> RemoveParentCategoryAsync(int id);
}

public class RemoveParentCategory : IRemoveParentCategory
{
    private readonly DayanShopContext _db;

    public RemoveParentCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> RemoveParentCategoryAsync(int id)
    {
        var perentCategoryInDb = await _db.ParentCategories.FindAsync(id);
        if (perentCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }

        try
        {
            var result = _db.ParentCategories.Remove(perentCategoryInDb);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"دسته بندی #{perentCategoryInDb.Id} از سیستم حذف گردید.",
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