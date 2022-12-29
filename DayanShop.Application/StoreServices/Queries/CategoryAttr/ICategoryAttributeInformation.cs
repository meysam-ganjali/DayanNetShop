using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.CategoryAttr;

public interface ICategoryAttributeInformation
{
    Task<ResultDto<IEnumerable<CategoryAttribute>>> GetCategoryAttrAsync(int childCategoryId, string? searchKey);
}

public class CategoryAttributeInformation : ICategoryAttributeInformation
{
    private readonly DayanShopContext _db;

    public CategoryAttributeInformation(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<CategoryAttribute>>> GetCategoryAttrAsync(int childCategoryId, string? searchKey)
    {
        var getAttrCategory = _db.CategoryAttributes
            .Include(attr => attr.ChildCategory)
            .Where(attr => attr.ChildCategoryId.Equals(childCategoryId))
            .AsQueryable();
        if (getAttrCategory == null)
        {
            return new ResultDto<IEnumerable<CategoryAttribute>>()
            {
                Data = null,
                IsSuccess = false,
                Message = $"0 عدد ویژگی برای دسته به کد #{childCategoryId} یافت شد"
            };
        }
        if (!string.IsNullOrWhiteSpace(searchKey))
        {
            getAttrCategory = getAttrCategory
                .Where(c => c.AttributeTitle.Contains(searchKey)).AsQueryable();
        }

        return new ResultDto<IEnumerable<CategoryAttribute>>()
        {
            Message = "واکشی ویژگی موفقیت آمیز بود",
            Data = await getAttrCategory.ToListAsync(),
            IsSuccess = true
        };
    }
}