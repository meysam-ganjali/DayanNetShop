using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace DayanShop.Application.StoreServices.CartService;

public interface ICartService
{
    Task<ResultDto>  AddToCart(int ProductId, Guid BrowserId,int count, string userId);
    Task<ResultDto>  RemoveFromCart(int cartitemId,string userId);
    Task<ResultDto<Cart>>  GetMyCart(Guid BrowserId, string UserId);
    Task<ResultDto> RemoveCart(string userId, long CartId);
    Task<ResultDto>  Add(long CartItemId);
    Task<ResultDto>  LowOff(long CartItemId);
}

public class CartService : ICartService
{
    private readonly DayanShopContext _db;

    public CartService(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> AddToCart(int ProductId, Guid BrowserId,int count, string userId)
    {
        var cart = await _db.Carts.FirstOrDefaultAsync(p => p.UserId==userId && p.Finished == false);
        if (cart == null)
        {
            Cart newCart = new Cart()
            {
                Finished = false,
                BrowserId = BrowserId,
                UserId = userId
            };
            _db.Carts.Add(newCart);
           await _db.SaveChangesAsync();
            cart = newCart;
        }
        var product = await _db.Products.FindAsync(ProductId);

        var cartItem = await _db.CartItems.FirstOrDefaultAsync(p => p.ProductId == ProductId && p.CartId == cart.Id);
        if (cartItem != null)
        {
            cartItem.Count += count;
            await _db.SaveChangesAsync();
        }
        else
        {
            CartItem newCartItem = new CartItem()
            {
                Cart = cart,
                Count = count,
                Price = product.Price,
                Product = product,

            };
            _db.CartItems.Add(newCartItem);
            await _db.SaveChangesAsync();
        }

        return new ResultDto()
        {
            IsSuccess = true,
            Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
        };
    }

    public async Task<ResultDto> RemoveFromCart(int cartitemId,string userId)
    {
        var cartitem = await _db.CartItems.FirstOrDefaultAsync(p => p.Cart.UserId == userId && p.Id == cartitemId);
        if (cartitem != null)
        {
           
            _db.CartItems.Remove(cartitem);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول از سبد خرید شما حذف شد"
            };

        }
        else
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
    }

    public async Task<ResultDto<Cart>> GetMyCart(Guid BrowserId, string UserId)
    {
        var cart =  await _db.Carts
            .Include(p => p.CartItems)
            .ThenInclude(p => p.Product)
            .ThenInclude(p=>p.ProductImages)
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.UserId == UserId);
        if (cart == null)
        {
            return new ResultDto<Cart>
            {
                IsSuccess = false,
                Data = null,
                Message = "سبد یافت نشد"
            };
        }

        return new ResultDto<Cart>()
        {
            
            IsSuccess = true,
            Data = cart
        };
    }

    public async Task<ResultDto> RemoveCart(string userId, long CartId)
    {
        var cart = await _db.Carts
            .Include(p=>p.CartItems)
            .Include(p=>p.User).FirstOrDefaultAsync(p => p.UserId.Equals(userId) && p.Id.Equals(CartId));
        if (cart == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "سبد یافت نشد"
            };
        }

        if (cart.CartItems.Any())
        {
            foreach (var item in cart.CartItems)
            {
                _db.CartItems.Remove(item);
            }
        }
        var res = _db.Carts.Remove(cart);
        await _db.SaveChangesAsync();
        return new ResultDto
        {
            IsSuccess = true,
            Message = $"{cart.User.FirstName + " " + cart.User.LastName} محترم سبد شما خلی گردید!"
        };
    }

    public async Task<ResultDto> Add(long CartItemId)
    {
       var cartItem = await _db.CartItems.FindAsync(CartItemId);
         cartItem.Count++;
        _db.SaveChangesAsync();
        return new ResultDto()
        {
            IsSuccess = true,
        };
    }

    public async Task<ResultDto> LowOff(long CartItemId)
    {
        var cartItem = await _db.CartItems.FindAsync(CartItemId);

        if (cartItem.Count <= 1)
        {
            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
        cartItem.Count--;
        await _db.SaveChangesAsync();
        return new ResultDto()
        {
            IsSuccess = true,
        };
    }
}
//public class CartDto
//{
//    public int ProductCount { get; set; }
//    public long CartID { get; set; }
//    public int SumAmount { get; set; }
//    public List<CartItemDto> CartItems { get; set; }
//}

//public class CartItemDto
//{
//    public long Id { get; set; }
//    public string Product { get; set; }
//    public string Images { get; set; }
//    public int Count { get; set; }
//    public long Price { get; set; }
//}