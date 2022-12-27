using DayanShop.Application.StoreServices.Commands.Category;
using DayanShop.Core.Data;

namespace DayanShop.Application.FacadePattern.FSDCategory;

public class FsdPatternCategory : IFSDPatternCategory
{
    private readonly DayanShopContext _db;

    public FsdPatternCategory(DayanShopContext db)
    {
        _db = db;
    }

    private ICreateParentCategory _createParentCategory;
    public ICreateParentCategory CreateParentCategory
    {
        get
        {
            return _createParentCategory = _createParentCategory ?? new CreateParentCategory(_db);
        }
    }
}