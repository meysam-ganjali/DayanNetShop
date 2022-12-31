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
}