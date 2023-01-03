using DayanShop.Application.StoreServices.Queries.Shoping;

namespace DayanShop.Application.FacadePattern.FSDShoping;

public interface IFSDShoping
{
    IFetchProductWithFilter FetchProductWithFilter { get; }
}