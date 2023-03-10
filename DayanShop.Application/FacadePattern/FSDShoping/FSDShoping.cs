using DayanShop.Application.StoreServices.CartService;
using DayanShop.Application.StoreServices.Queries.Shoping;
using DayanShop.Core.Data;

namespace DayanShop.Application.FacadePattern.FSDShoping;

public class FSDShoping : IFSDShoping
{
    private readonly DayanShopContext _db;

    public FSDShoping(DayanShopContext db)
    {
        _db = db;
    }

    private IFetchProductWithFilter _fetchProductWithFilter;
    public IFetchProductWithFilter FetchProductWithFilter
    {
        get
        {
            return _fetchProductWithFilter = _fetchProductWithFilter ?? new FetchProductWithFilter(_db);
        }
    }


    ICartService _cartService;
    public ICartService CartService
    {
        get
        {
            return _cartService = _cartService ?? new CartService(_db);
        }
    }
}