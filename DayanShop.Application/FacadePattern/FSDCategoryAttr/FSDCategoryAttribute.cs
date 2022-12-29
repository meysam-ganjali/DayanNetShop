using DayanShop.Application.StoreServices.Commands.CategoryAttr;
using DayanShop.Core.Data;

namespace DayanShop.Application.FacadePattern.FSDCategoryAttr;

public class FSDCategoryAttribute : IFSDCategoryAttribute
{
    private readonly DayanShopContext _db;

    public FSDCategoryAttribute(DayanShopContext db)
    {
        _db = db;
    }

    private ICreateCategoryAttribute _createCategoryAttribute;
    public ICreateCategoryAttribute CreateCategoryAttribute
    {
        get
        {
            return _createCategoryAttribute = _createCategoryAttribute ?? new CreateCategoryAttribute(_db);
        }
    }
}