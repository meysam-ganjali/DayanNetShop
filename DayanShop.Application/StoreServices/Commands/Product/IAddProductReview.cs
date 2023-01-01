using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IAddProductReview
{
    Task<ResultDto> AddReviewAsync(IFormFile? img, ProductReviw review);
}

public class AddProductReview : IAddProductReview
{

    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public AddProductReview(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> AddReviewAsync(IFormFile? img, ProductReviw review)
    {
        ProductReviw productReviw = new ProductReviw();
        if (img != null)
        {
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(img, $@"assets\productReviw\");
            review.ImagePath = uploadedResult.FileNameAddress;
        }

        try
        {
            var result = _db.ProductReviws.Add(review);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"یک بررسی به محصول با موفقیت اضافه شد",
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