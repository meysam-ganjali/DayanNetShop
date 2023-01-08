using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IOrderDetailes
{
    Task<ResultDto<Order>> GetAsync(int orderId);
}

public class OrderDetailes : IOrderDetailes
{
    private readonly DayanShopContext _db;

    public OrderDetailes(DayanShopContext db)
    {
        _db = db;
    }
    public async Task<ResultDto<Order>> GetAsync(int orderId)
    {
        var order = await _db.Orders
            .Include(p => p.OrderDetailes)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.ProductImages)
            .Include(p => p.ApplicationUser)
            .Include(p => p.RequestPay)
            .FirstOrDefaultAsync(p => p.Id.Equals(orderId));
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