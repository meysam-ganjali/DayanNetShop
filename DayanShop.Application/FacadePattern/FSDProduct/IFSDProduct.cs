using DayanShop.Application.StoreServices.Commands.Product;
using DayanShop.Application.StoreServices.Queries.Category;

namespace DayanShop.Application.FacadePattern.FSDProduct;

public interface IFSDProduct
{
    ICreateProduct CreateProduct { get; }
    IGetAllChildCategory GetChildCategory { get; }
}