using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IAddProductFeature
{
    Task<ResultDto> AddFeatureAsync(ProductAttribute feautre);
}

public class AddProductFeature : IAddProductFeature
{
    private readonly DayanShopContext _db;

    public AddProductFeature(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> AddFeatureAsync(ProductAttribute feautre)
    {

        try
        {
            var result = _db.ProductAttributes.Add(feautre);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"مشخصه  با موفقیت اضافه شد",
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }
}