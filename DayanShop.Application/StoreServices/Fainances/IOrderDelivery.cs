using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IOrderDelivery
{
    Task<ResultDto> DeliveryASync(int orderId);
}

public class OrderDelivery : IOrderDelivery
{
    private readonly DayanShopContext _db;

    public OrderDelivery(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> DeliveryASync(int orderId)
    {
        var orderInDb = await _db.Orders.FirstOrDefaultAsync(o => o.Id.Equals(orderId) && o.OrderState.Equals(OrderState.Processing));
        if (orderInDb == null)
        {
            return new ResultDto()
            {
                IsSuccess = false,
                Message = $"فاکتور شماره {orderId} یافت نشد"
            };
        }

        try
        {
            orderInDb.OrderState = OrderState.Delivered;
            await _db.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"فاکتور شماره {orderId} آماده تحویل می باشد"
            };
        }
        catch (Exception e)
        {
            return new ResultDto()
            {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }
}