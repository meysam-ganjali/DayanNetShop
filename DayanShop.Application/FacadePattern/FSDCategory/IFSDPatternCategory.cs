using DayanShop.Application.StoreServices.Commands.Category;
using DayanShop.Application.StoreServices.Queries.Category;

namespace DayanShop.Application.FacadePattern.FSDCategory;

public interface IFSDPatternCategory
{
    ICreateParentCategory CreateParentCategory { get; }
    IParentCategoryInformation CategoryInformation { get; }
}