using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface IRemoveChildCategory
{
    Task<ResultDto> RemoveChildCategoryAsync(int id);
}

public class RemoveChildCategory : IRemoveChildCategory
{
    private readonly DayanShopContext _db;

    public RemoveChildCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> RemoveChildCategoryAsync(int id)
    {
        var childCategoryInDb = await _db.ChildCategories.FindAsync(id);
        if (childCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }

        try
        {
            var result = _db.ChildCategories.Remove(childCategoryInDb);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"دسته بندی #{childCategoryInDb.Id} از سیستم حذف گردید.",
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