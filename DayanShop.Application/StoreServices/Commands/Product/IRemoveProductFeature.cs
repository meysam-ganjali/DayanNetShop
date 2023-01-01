using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;
using System;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IRemoveProductFeature
{
    Task<ResultDto> RemoveAsync(int id);
}

public class RemoveProductFeature : IRemoveProductFeature
{
    private readonly DayanShopContext _db;

    public RemoveProductFeature(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> RemoveAsync(int id)
    {
        var productAttrInDb = await _db.ProductAttributes
            .Include(p => p.CategoryAttribute)
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (productAttrInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "نتوانستم چیزی پیدا کنم"
            };
        }

        try
        {
            var result = _db.ProductAttributes.Remove(productAttrInDb);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"ویژگی {productAttrInDb.CategoryAttribute.AttributeTitle} از لیست مشخصات محصول {productAttrInDb.Product.Name} حذف شد",
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