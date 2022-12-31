using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Hosting;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IRemoveProduct
{
    Task<ResultDto> RemoveProductAsync(int id);
}

public class RemoveProduct : IRemoveProduct
{
    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public RemoveProduct(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> RemoveProductAsync(int id)
    {
        var productInDb = await _db.Products
            .Include(p => p.ProductAttributes)
            .Include(p => p.ProductImages)
            .Include(p => p.ProductReviws)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (productInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }

        try
        {
            if (productInDb.ProductImages.Any())
            {
                string webRootPath = _environment.WebRootPath;
                foreach (var image in productInDb.ProductImages)
                {
                    var oldImagePath = Path.Combine(webRootPath, image.ImagePath.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                        _db.ProductImages.Remove(image);
                    }
                }
            }

            if (productInDb.ProductAttributes.Any())
            {
                foreach (var productAttr in productInDb.ProductAttributes)
                {
                    _db.ProductAttributes.Remove(productAttr);
                }
            }
            if (productInDb.ProductReviws.Any())
            {
                foreach (var review in productInDb.ProductReviws)
                {
                    _db.ProductReviws.Remove(review);
                }
            }
            var result = _db.Products.Remove(productInDb);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"محصول #{productInDb.Id} از سیستم حذف گردید.",
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