using DayanShop.Application.StoreServices.Commands.CategoryAttr;
using DayanShop.Application.StoreServices.Queries.CategoryAttr;

namespace DayanShop.Application.FacadePattern.FSDCategoryAttr;

public interface IFSDCategoryAttribute
{
    ICreateCategoryAttribute CreateCategoryAttribute { get; }
    ICategoryAttributeInformation CategoryAttributeInformation { get; }
    IRemoveCategoryAttribute RemoveCategoryAttribute { get; }
}