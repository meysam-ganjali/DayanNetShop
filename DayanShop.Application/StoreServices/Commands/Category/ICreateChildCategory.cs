using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Category;

public interface ICreateChildCategory
{
    Task<ResultDto> CreateChildCategoryAsync(ChildCategory childCategory);
}

public class CreateChildCategory : ICreateChildCategory
{
    private readonly DayanShopContext _db;

    public CreateChildCategory(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> CreateChildCategoryAsync(ChildCategory childCategory)
    {
        var categoryIsExist = await _db.ChildCategories.FirstOrDefaultAsync(c =>
            c.ChildTitle.Equals(childCategory.ChildTitle));
        if (categoryIsExist != null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "دسته بندی با این نام در سیستم موجود می باشد لطفا عنوان دیگری انتخاب کنید"
            };
        }

        try
        {
            var result = _db.ChildCategories.Add(childCategory);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"تبریک دسته {childCategory.ChildTitle} با موفقیت اضافه شد",
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