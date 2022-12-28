using DayanShop.Application.StoreServices.Commands.Category;
using DayanShop.Application.StoreServices.Queries.Category;
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
    

    private IParentCategoryInformation _parentCategoryInformation;
    public IParentCategoryInformation CategoryInformation
    {
        get
        {
            return _parentCategoryInformation = _parentCategoryInformation ?? new ParentCategoryInformation(_db);
        }
    }


    private IEditParentCategory _editParentCategory;
    public IEditParentCategory EditParentCategory
    {
        get
        {
            return _editParentCategory = _editParentCategory ?? new EditParentCategory(_db);
        }
    }


    private IRemoveParentCategory _removeParentCategory;
    public IRemoveParentCategory RemoveParentCategory
    {
        get
        {
            return _removeParentCategory = _removeParentCategory ?? new RemoveParentCategory(_db);
        }
    }


    private ICreateChildCategory _createChildCategory;
    public ICreateChildCategory CreateChildCategory
    {
        get
        {
            return _createChildCategory = _createChildCategory ?? new CreateChildCategory(_db);
        }
    }


    private IChildCategoryInformation _childCategoryInformation;
    public IChildCategoryInformation ChildCategoryInformation
    {
        get
        {
            return _childCategoryInformation = _childCategoryInformation ?? new ChildCategoryInformation(_db);
        }
    }
}