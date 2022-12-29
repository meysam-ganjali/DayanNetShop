using DayanShop.Application.StoreServices.Commands.CategoryAttr;
using DayanShop.Application.StoreServices.Queries.CategoryAttr;
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


    private ICategoryAttributeInformation _categoryAttributeInformation;
    public ICategoryAttributeInformation CategoryAttributeInformation
    {
        get
        {
            return _categoryAttributeInformation =
                _categoryAttributeInformation ?? new CategoryAttributeInformation(_db);
        }
    }


    private IRemoveCategoryAttribute _removeCategoryAttribute;
    public IRemoveCategoryAttribute RemoveCategoryAttribute
    {
        get
        {
            return _removeCategoryAttribute = _removeCategoryAttribute ?? new RemoveCategoryAttribute(_db);
        }
    }


    private IEditCategoryAttribute _editCategoryAttribute;
    public IEditCategoryAttribute EditCategoryAttribute
    {
        get
        {
            return _editCategoryAttribute = _editCategoryAttribute ?? new EditCategoryAttribute(_db);
        }
    }
}