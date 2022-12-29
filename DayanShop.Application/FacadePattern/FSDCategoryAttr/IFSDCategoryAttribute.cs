using DayanShop.Application.StoreServices.Commands.CategoryAttr;

namespace DayanShop.Application.FacadePattern.FSDCategoryAttr;

public interface IFSDCategoryAttribute
{
    ICreateCategoryAttribute CreateCategoryAttribute { get; }
}