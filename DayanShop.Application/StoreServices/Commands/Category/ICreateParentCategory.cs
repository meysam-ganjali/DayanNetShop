using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface ICreateParentCategory
{
    Task<ResultDto> CreateCategoryAsync(ParentCategory parentCategory);
}

public  class CreateParentCategory : ICreateParentCategory
{
    private readonly DayanShopContext _db;

    public CreateParentCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> CreateCategoryAsync(ParentCategory parentCategory)
    {
        var categoryIsExist = await _db.ParentCategories.FirstOrDefaultAsync(c =>
            c.ParentTitle.Equals(parentCategory.ParentTitle));
        if (categoryIsExist != null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی با این نام در سیستم موجود می باشد لطفا عتنوان دیگری انتخاب کنید"
            };
        }

        try
        {
            var result = _db.ParentCategories.Add(parentCategory);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"تبریک دسته {parentCategory.ParentTitle} با موفقیت اضافه شد",
                IsSuccess = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }
}