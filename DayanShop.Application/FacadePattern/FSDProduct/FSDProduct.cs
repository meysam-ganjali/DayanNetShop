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
            return _removeProduct = _removeProduct ?? new RemoveProduct(_db,_environment);
        }
    }


    private IProductDetails _productDetails;
    public IProductDetails GetProductDetails
    {
        get
        {
            return _productDetails = _productDetails ?? new ProductDetails(_db);
        }
    }


    private IAddProductPicture _addProductPicture;
    public IAddProductPicture AddProductPicture
    {
        get
        {
            return _addProductPicture = _addProductPicture ?? new AddProductPicture(_db, _environment);
        }
    }


    private IAttributInfo _attributInfo;
    public IAttributInfo AttributeInfo
    {
        get
        {
            return _attributInfo = _attributInfo ?? new AttributInfo(_db);
        }
    }


    private IRemoveProductPicture _removeProductPicture;
    public IRemoveProductPicture RemoveProductPicture
    {
        get
        {
            return _removeProductPicture = _removeProductPicture ?? new RemoveProductPicture(_db,_environment);
        }
    }


    private IAddProductFeature _addProductFeature;
    public IAddProductFeature AddProductFeature
    {
        get
        {
            return _addProductFeature= _addProductFeature ?? new AddProductFeature(_db);
        }
    }


    private IAddProductReview _addProductReview;
    public IAddProductReview AddProductReview
    {
        get
        {
            return _addProductReview = _addProductReview ?? new AddProductReview(_db, _environment);
        }
    }
}