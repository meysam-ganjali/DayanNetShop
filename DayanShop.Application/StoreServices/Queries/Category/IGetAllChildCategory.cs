using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Category;

public interface IGetAllChildCategory
{
    Task<ResultDto<IEnumerable<ChildCategory>>> GetAllChildCategoryAsync();
}

public class GetAllChildCategory : IGetAllChildCategory
{
    private readonly DayanShopContext _db;

    public GetAllChildCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<ChildCategory>>> GetAllChildCategoryAsync()
    {
        var result = await _db.ChildCategories.Include(c => c.ParentCategory).ToListAsync();
        return new ResultDto<IEnumerable<ChildCategory>>
        {
            Message = "",
            Data = result,
            IsSuccess = true
        };
    }
}