using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IEditProduct
{
    Task<ResultDto> EditAsync(Domains.Entities.Product product);
}

public class EditProduct : IEditProduct
{
    private readonly DayanShopContext _db;

    public EditProduct(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> EditAsync(Domains.Entities.Product product)
    {
        var producInDb = await _db.Products.FindAsync(product.Id);

        if (producInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"محصول یافت نشد"
            };
        }
        producInDb.Name = product.Name;
        producInDb.Slug = product.Slug;
        producInDb.OldPrice = product.OldPrice;
        producInDb.Price = product.Price;
        producInDb.ShowDiscountLable = product.ShowDiscountLable;
        producInDb.Percentage = product.Percentage;
        producInDb.ProductSpecial = product.ProductSpecial;
        producInDb.Count = product.Count;
        producInDb.ModelName = product.ModelName;
        producInDb.Description = product.Description;
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"عملیات بروزرسانی محصول با موفقیت به اتمام رسید"
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