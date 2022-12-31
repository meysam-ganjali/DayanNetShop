using DayanShop.Application.StoreServices.Commands.Product;
using DayanShop.Application.StoreServices.Queries.Category;
using DayanShop.Application.StoreServices.Queries.Product;
using DayanShop.Core.Data;
using Microsoft.AspNetCore.Hosting;

namespace DayanShop.Application.FacadePattern.FSDProduct;

public class FSDProduct : IFSDProduct
{
    private readonly DayanShopContext _db;
    private readonly IHostingEnvironment _environment;

    public FSDProduct(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    private ICreateProduct _createProduct;
    public ICreateProduct CreateProduct
    {
        get
        {
            return _createProduct = _createProduct ?? new CreateProduct(_db);
        }
    }


    private IGetAllChildCategory _getAllChildCategpry;
    public IGetAllChildCategory GetChildCategory
    {
        get
        {
            return _getAllChildCategpry = _getAllChildCategpry ?? new GetAllChildCategory(_db);
        }
    }


    private IProductInformation _productInformation;
    public IProductInformation GetAllProduct
    {
        get
        {
            return _productInformation = _productInformation ?? new ProductInformation(_db);
        }
    }


    private IRemoveProduct _removeProduct;
    public IRemoveProduct RemoveProduct
    {
        get
        {
            return _removeProduct = _removeProduct ?? new RemoveProduct(_db);
        }
    }
}