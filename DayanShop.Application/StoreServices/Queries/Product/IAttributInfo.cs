using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Product;

public interface IAttributInfo
{
    Task<ResultDto<IEnumerable<CategoryAttribute>>> GetProductAttrAsync(int Pid);
}

public class AttributInfo : IAttributInfo
{
    private readonly DayanShopContext _db;

    public AttributInfo(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<CategoryAttribute>>> GetProductAttrAsync(int Pid)
    {
        var product = await _db.Products.FindAsync(Pid);
        var res = await _db.CategoryAttributes.Where(p=>p.ChildCategoryId == product.ChildCategoryId).ToListAsync();
        return new ResultDto<IEnumerable<CategoryAttribute>>
        {
            Data = res
        };
    }
}