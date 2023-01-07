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


    IEditRequestPay _editRequestPay;
    public IEditRequestPay EditRequestPay
    {
        get
        {
            return _editRequestPay= _editRequestPay ?? new EditRequestPay(_db);
        }
    }


     IChangeCartStatus _changeCartStatus;
    public IChangeCartStatus ChangeCartStatus
    {
        get
        {
            return _changeCartStatus= _changeCartStatus ?? new ChangeCartStatus(_db);
        }
    }


    IUserOrderInfo _userOrderInfo;
    public IUserOrderInfo UserOrderInfo
    {
        get
        {
            return _userOrderInfo= _userOrderInfo ?? new UserOrderInfo(_db);
        }
    }
}