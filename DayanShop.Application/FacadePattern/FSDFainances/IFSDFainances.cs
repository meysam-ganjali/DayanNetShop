using DayanShop.Application.StoreServices.Fainances;

namespace DayanShop.Application.FacadePattern.FSDFainances;

public interface IFSDFainances
{
    IAddNewOrder AddNewOrder { get; }
    IAddRequestPay AddRequestPay { get; }
    IGetRequestPay GetRequestPay { get; }
    IEditRequestPay EditRequestPay { get; }
    IChangeCartStatus ChangeCartStatus { get; }
    IUserOrderInfo UserOrderInfo { get; }
    IOrdersInformation OrdersInfo { get; }
    IOrderDelivery OrderDelivery { get; }
}