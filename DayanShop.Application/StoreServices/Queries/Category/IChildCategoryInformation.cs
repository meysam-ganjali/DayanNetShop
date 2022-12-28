using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Category;

public interface IChildCategoryInformation
{
    Task<ResultDto<IEnumerable<ChildCategory>>> GetChildCategoryAsync(int parentId, string? searchKey);
}

public class ChildCategoryInformation : IChildCategoryInformation
{
    private readonly DayanShopContext _db;

    public ChildCategoryInformation(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<ChildCategory>>> GetChildCategoryAsync(int parentId, string? searchKey)
    {
        var getChildCategory = _db.ChildCategories.Include(i => i.ParentCategory)
            .Where(c => c.ParentCategoryId.Equals(parentId))
            .AsQueryable();
        if (getChildCategory == null)
        {
            return new ResultDto<IEnumerable<ChildCategory>>
            {
                Data = null,
                IsSuccess = false,
                Message = $"زیردسته ای برای دسته فوق وجود ندارد"
            };
        }
        if (!string.IsNullOrWhiteSpace(searchKey))
        {
            getChildCategory = getChildCategory
                .Where(c => c.ChildTitle.Contains(searchKey) || c.ChildTitleSlug.Contains(searchKey)).AsQueryable();
        }

        return new ResultDto<IEnumerable<ChildCategory>>
        {
            Message = "واکشی دسته بندی والد موفقیت آمیز بود",
            Data = await getChildCategory.ToListAsync(),
            IsSuccess = true
        };
    }
}