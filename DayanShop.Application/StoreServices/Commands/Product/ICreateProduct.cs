using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface ICreateProduct
{
    Task<ResultDto> CreateProductAsync(Domains.Entities.Product product);
}

public class CreateProduct : ICreateProduct
{
    private readonly DayanShopContext _db;

    public CreateProduct(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> CreateProductAsync(Domains.Entities.Product product)
    {
        try
        {
            var result = _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"کالای {product.Name} با موفقیت ثبت شد"
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