using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Product;

public interface IProductDetails
{
    Task<ResultDto<Domains.Entities.Product>> ProductDetailesAsync(int id);
}

public class ProductDetails : IProductDetails
{
    private readonly DayanShopContext _db;

    public ProductDetails(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<Domains.Entities.Product>> ProductDetailesAsync(int id)
    {
        var getProduct =await _db.Products
            .Include(p => p.ProductImages)
            .Include(p => p.ChildCategory)
            .ThenInclude(p => p.ParentCategory)
            .Include(p => p.ProductReviws)
            .Include(p => p.ProductAttributes)
            .ThenInclude(p => p.CategoryAttribute)
            .FirstOrDefaultAsync(p=>p.Id == id);
          
      

        return new ResultDto<Domains.Entities.Product>
        {
            Message = "واکشی جزئیات موفقیت آمیز بود",
            Data =  getProduct,
            IsSuccess = true
        };
    }
}