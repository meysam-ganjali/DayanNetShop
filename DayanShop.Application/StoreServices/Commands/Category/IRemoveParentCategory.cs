using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

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
        var parentCategoryInDb = await _db.ParentCategories
            .Include(p => p.ChildCategories)
            .ThenInclude(p => p.CategoryAttributes)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (parentCategoryInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی یافت نشد"
            };
        }

        try
        {
            //if (parentCategoryInDb.ChildCategories.Any())
            //{
            //    foreach (var child in parentCategoryInDb.ChildCategories)
            //    {
            //        if (child.CategoryAttributes)
            //        {
                        
            //        }
            //        _db.ChildCategories.Remove(child);
            //    }
            //}
            var result = _db.ParentCategories.Remove(parentCategoryInDb);

            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"دسته بندی #{parentCategoryInDb.Id} از سیستم حذف گردید.",
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