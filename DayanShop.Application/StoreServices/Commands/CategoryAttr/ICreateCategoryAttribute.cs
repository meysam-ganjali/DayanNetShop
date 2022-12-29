using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.CategoryAttr;

public interface ICreateCategoryAttribute
{
    Task<ResultDto> CreateCategoryAttrAsync(CategoryAttribute categoryAttr);
}

public class CreateCategoryAttribute : ICreateCategoryAttribute
{
    private readonly DayanShopContext _db;

    public CreateCategoryAttribute(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto> CreateCategoryAttrAsync(CategoryAttribute categoryAttr)
    {
        var attrIsExist =
            await _db.CategoryAttributes.FirstOrDefaultAsync(a => a.AttributeTitle.Equals(categoryAttr.AttributeTitle));
        if (attrIsExist != null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "این ویژگی را قبلا ثبت کرده اید."
            };
        }

        var result = _db.CategoryAttributes.Add(categoryAttr);
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"ویژگی {categoryAttr.AttributeTitle} با موفقیت ثبت گردید."
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }
}