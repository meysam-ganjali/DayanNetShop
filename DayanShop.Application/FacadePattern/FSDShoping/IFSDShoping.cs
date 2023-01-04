using DayanShop.Application.StoreServices.CartService;
using DayanShop.Application.StoreServices.Queries.Shoping;

namespace DayanShop.Application.FacadePattern.FSDShoping;

public interface IFSDShoping
{
    IFetchProductWithFilter FetchProductWithFilter { get; }
    ICartService CartService { get; }
}