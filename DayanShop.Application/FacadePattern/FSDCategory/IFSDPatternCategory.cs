using DayanShop.Application.StoreServices.Commands.Category;

namespace DayanShop.Application.FacadePattern.FSDCategory;

public interface IFSDPatternCategory
{
    ICreateParentCategory CreateParentCategory { get; }
}