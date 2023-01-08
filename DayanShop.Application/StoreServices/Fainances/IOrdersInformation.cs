
using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IOrdersInformation
{
    ReslutGetOrderDto GetAsync(RequestGetOrderDto request);
}

public class OrdersInformation : IOrdersInformation
{
    private readonly DayanShopContext _db;

    public OrdersInformation(DayanShopContext db)
    {
        _db = db;
    }

    public ReslutGetOrderDto GetAsync(RequestGetOrderDto request)
    {
        int rowsCount = request.PageSize;

        var orderInDb = _db.Orders
            .Include(p => p.ApplicationUser)
            .Include(p => p.OrderDetailes)
            .ThenInclude(p => p.Product)
            .ThenInclude(p => p.ProductImages)
            .Include(p => p.RequestPay)
            .ToPaged(request.Page, request.PageSize, out rowsCount)
            .ToList();
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            orderInDb = orderInDb.Where(p => p.RequestPay.PayDate.ToString().Contains(request.SearchKey) || p.TootalAmount.ToString().Contains(request.SearchKey)).ToList();
        }

        if (request.OrderState != null)
        {
            switch (request.OrderState)
            {
                case OrderState.Processing:
                    {
                        orderInDb = orderInDb.Where(p => p.OrderState == OrderState.Processing).ToList();
                        break;
                    }
                case OrderState.Canceled:
                    {
                        orderInDb = orderInDb.Where(p => p.OrderState == OrderState.Canceled).ToList();
                        break;
                    }
                case OrderState.Delivered:
                    {
                        orderInDb = orderInDb.Where(p => p.OrderState == OrderState.Delivered).ToList();
                        break;
                    }
            }
        }

        return new ReslutGetOrderDto()
        {
            RowCount = rowsCount,
            PageSize = request.PageSize,
            CurrentPage = request.Page,
            OrderLst = orderInDb.ToList()
        };
    }
}

public class RequestGetOrderDto
{
    public string SearchKey { get; set; }
    public OrderState? OrderState { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
public class ReslutGetOrderDto
{
    public IEnumerable<Order> OrderLst { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}