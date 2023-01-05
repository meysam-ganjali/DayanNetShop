using DayanShop.Application.StoreServices.Fainances;
using DayanShop.Core.Data;

namespace DayanShop.Application.FacadePattern.FSDFainances;

public class FSDFainances : IFSDFainances
{
    private readonly DayanShopContext _db;

    public FSDFainances(DayanShopContext db)
    {
        _db = db;
    }

    private IAddNewOrder _addNewOrder;
    public IAddNewOrder AddNewOrder
    {
        get
        {
            return _addNewOrder = _addNewOrder ?? new AddNewOrder(_db);
        }
    }


    private IAddRequestPay _addRequestPay;
    public IAddRequestPay AddRequestPay
    {
        get
        {
            return _addRequestPay = _addRequestPay ?? new AddRequestPay(_db);
        }
    }


    IGetRequestPay _getGetRequestPay;
    public IGetRequestPay GetRequestPay
    {
        get
        {
            return _getGetRequestPay = _getGetRequestPay ?? new GetRequestPay(_db);
        }
    }
}