using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Queries.Product;

public interface IGetProduct
{
    Task<ResultDto<Domains.Entities.Product>> GetAsync(int id);
}

public class GetProduct : IGetProduct
{
    private readonly DayanShopContext _db;

    public GetProduct(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<Domains.Entities.Product>> GetAsync(int id)
    {
        var producInDb = await _db.Products.FindAsync(id);

        if (producInDb == null)
        {
            return new ResultDto<Domains.Entities.Product>()
            {
                IsSuccess = false,
                Message = $"محصول یافت نشد",
                Data=null
            };
        }

        return new ResultDto<Domains.Entities.Product>
        {
            Data = producInDb,
            IsSuccess = true
        };
    }
}