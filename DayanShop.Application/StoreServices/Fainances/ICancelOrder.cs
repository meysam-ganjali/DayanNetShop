using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface ICancelOrder
{
    Task<ResultDto> CancelASync(int orderId);
}

public class CancelOrder : ICancelOrder
{
    private readonly DayanShopContext _db;

    public CancelOrder(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> CancelASync(int orderId)
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
            orderInDb.OrderState = OrderState.Canceled;
            await _db.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"فاکتور شماره {orderId} کنسل شد می باشد"
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