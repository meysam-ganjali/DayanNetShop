using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IEditProductAttribute
{
    Task<ResultDto> UpdataAttrValueasync(ProductAttribute attr);
}

public class EditProductAttribute : IEditProductAttribute
{
    private readonly DayanShopContext _db;

    public EditProductAttribute(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> UpdataAttrValueasync(ProductAttribute attr)
    {
        var productAttrInDb = await _db.ProductAttributes
            .Include(p => p.Product)
            .Include(p=>p.CategoryAttribute)
            .FirstOrDefaultAsync(p => p.Id == attr.Id);
        if (productAttrInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = $"محصول {attr.Product.Name} فاقد این ویژگی می باشد"
            };
        }

        productAttrInDb.AttrVal = attr.AttrVal;


        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"مقدار ویژگی {productAttrInDb.CategoryAttribute.AttributeTitle} برای محصول {productAttrInDb.Product.Name}بروز شد",
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