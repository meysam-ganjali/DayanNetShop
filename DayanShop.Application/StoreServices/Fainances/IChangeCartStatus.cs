using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IChangeCartStatus
{
    Task<ResultDto> ChangeAsync(long cartId,bool isPay);
}

public class ChangeCartStatus : IChangeCartStatus
{
    private readonly DayanShopContext _db;

    public ChangeCartStatus(DayanShopContext db)
    {
        _db = db;
    }
    public async Task<ResultDto> ChangeAsync(long cartId, bool isPay)
    {
        var cart = await _db.Carts.FindAsync(cartId);
        if (cart == null)
        {
            return new ResultDto
            {
                Message = "سبد یافت نشد",
                IsSuccess = false
            };
        }

        if (isPay)
        {
            cart.Finished = true;
            await _db.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "وضعیت سبد خرید با اتمام تغییر کرد"
            };
        }
        else
        {
            return new ResultDto
            {
                Message = "Error",
                IsSuccess = false
            };
        }

        
    }
}