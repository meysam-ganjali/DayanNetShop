using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IAddNewOrder
{
    Task<ResultDto> CreateAsync(RequestAddNewOrderSericeDto request);
}

public class AddNewOrder : IAddNewOrder
{
    private readonly DayanShopContext _db;

    public AddNewOrder(DayanShopContext db)
    {
        _db = db;
    }
    public async Task<ResultDto> CreateAsync(RequestAddNewOrderSericeDto request)
    {
        var user = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Id == request.UserId);

        var requestPay = _db.RequestPays.Find(request.RequestPayId);

        var cart = _db.Carts
            .Include(p => p.CartItems)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(p => p.Id == request.CartId);


        requestPay.IsPay = true;
        requestPay.PayDate = DateTime.Now;

        cart.Finished = true;

        Order order = new Order()
        {
            Address = "",
            OrderState = OrderState.Processing,
            RequestPay = requestPay,
            ApplicationUser = user,
            CreatedDate = DateTime.Now,
            TootalAmount = cart.SumAmount,

        };
         _db.Orders.Add(order);

        List<OrderDetaile> orderDetails = new List<OrderDetaile>();
        foreach (var item in cart.CartItems)
        {

            OrderDetaile orderDetail = new OrderDetaile()
            {
                ProductCount = item.Count,
                Order = order,
                ProductPrice = item.Product.Price,
                Product = item.Product,
                TotalRow = item.Product.Price * item.Count
            };
            orderDetails.Add(orderDetail);

            var product = item.Product;
            product.Count -= item.Count;
        }


        _db.OrderDetailes.AddRange(orderDetails);

       await  _db.SaveChangesAsync();

        return new ResultDto()
        {
            IsSuccess = true,
            Message = "",
        };
    }
}
public class RequestAddNewOrderSericeDto
{
    public long CartId { get; set; }
    public int RequestPayId { get; set; }
    public string UserId { get; set; }
}