using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Category;

public class ParentCategoryInformation : IParentCategoryInformation
{
    private readonly DayanShopContext _db;

    public ParentCategoryInformation(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<ParentCategory>>> GetAllParentCategoryAsync(string? searchKey)
    {
        var getCategory = _db.ParentCategories.Include(i => i.ChildCategories).AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchKey))
        {
            getCategory = getCategory
                .Where(c => c.ParentTitle.Contains(searchKey) || c.ParentTitleSlug.Contains(searchKey)).AsQueryable();
        }

        return new ResultDto<IEnumerable<ParentCategory>>
        {
            Message = "واکشی دسته بندی والد موفقیت آمیز بود",
            Data = await getCategory.ToListAsync(),
            IsSuccess = true
        };
    }
}