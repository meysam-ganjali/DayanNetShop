using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IEditProductReview
{
    Task<ResultDto> EditAsync(IFormFile? img, ProductReviw review);
}

public class EditProductReview : IEditProductReview
{
    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public EditProductReview(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> EditAsync(IFormFile? img, ProductReviw review)
    {
        var reviewInDb = await _db.ProductReviws
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == review.Id);
        if (reviewInDb == null)
        {
            return new ResultDto
            {
                Message = "بررسی یافت نشد",
                IsSuccess = false
            };
        }

        if (img != null)
        {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, reviewInDb.ImagePath.TrimStart('\\'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(img, $@"assets\productReviw\");
            reviewInDb.ImagePath = uploadedResult.FileNameAddress;
        }

        reviewInDb.Description = review.Description;
        reviewInDb.Height = review.Height;
        reviewInDb.Title = review.Title;
        reviewInDb.width = review.width;
        try
        {
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = "عملیات با موفقیت به پایان رسید",
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