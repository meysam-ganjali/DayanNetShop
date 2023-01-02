using DayanShop.Application.StoreServices.Commands.Product;
using DayanShop.Application.StoreServices.Queries.Category;
using DayanShop.Application.StoreServices.Queries.Product;

namespace DayanShop.Application.FacadePattern.FSDProduct;

public interface IFSDProduct
{
    ICreateProduct CreateProduct { get; }
    IGetAllChildCategory GetChildCategory { get; }
    IProductInformation GetAllProduct { get; }
    IRemoveProduct RemoveProduct { get; }
    IProductDetails GetProductDetails { get; }
    IAddProductPicture AddProductPicture { get; }
    IAttributInfo AttributeInfo { get; }
    IRemoveProductPicture RemoveProductPicture { get; } 
    IAddProductFeature AddProductFeature { get; }
    IAddProductReview AddProductReview { get; }
    IEditProductAttribute EditProductAttribute { get; }
    IRemoveProductFeature RemoveProductFeature { get; }
    IRemoveProductReview RemoveProductReview { get; }
    IEditProductReview EditProductReview { get; }
    IEditProduct  EditProduct { get; }
    IGetProduct    GetProduct { get; }
}