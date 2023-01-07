using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IUserOrderInfo
{
    Task<ResultDto<Order>> GetAsync(string userId, int requestId);
}

public class UserOrderInfo : IUserOrderInfo
{
    private readonly DayanShopContext _db;

    public UserOrderInfo(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<Order>> GetAsync(string userId,int requestId)
    {
        var order = await _db.Orders
            .Include(p => p.OrderDetailes)
            .ThenInclude(p=>p.Product)
            .ThenInclude(p=>p.ProductImages)
            .Include(p => p.ApplicationUser)
            .Include(p=>p.RequestPay)
            .FirstOrDefaultAsync(p =>  p.UserId == userId &&  p.RequestPay.IsPay == true &&p.RequestPayId == requestId);
        if (order == null)
        {
            return new ResultDto<Order>
            {
                Data = null,
                IsSuccess = false,
                Message = "فاکتوری برای نمایش وجود ندارد"
            };
        }

        return new ResultDto<Order>
        {
            Data = order,
            IsSuccess = true
        };
    }
}