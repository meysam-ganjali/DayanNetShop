using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IRemoveProduct
{
    Task<ResultDto> RemoveProductAsync(int id);
}

public class RemoveProduct : IRemoveProduct
{
    private readonly DayanShopContext _db;

    public RemoveProduct(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> RemoveProductAsync(int id)
    {
        var productInDb = await _db.Products.FindAsync(id);
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