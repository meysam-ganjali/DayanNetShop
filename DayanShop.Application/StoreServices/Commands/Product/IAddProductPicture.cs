using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IAddProductPicture
{
    Task<ResultDto> AddPictureAsync(ProductImage productImage,IFormFile img);
}

public class AddProductPicture : IAddProductPicture
{
    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public AddProductPicture(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public  async Task<ResultDto> AddPictureAsync(ProductImage productImage, IFormFile img)
    {
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(img, $@"assets\product\");
        ProductImage image = new ProductImage()
        {
            AltAttr = productImage.AltAttr,
            Height = productImage.Height,
            ImagePath = uploadedResult.FileNameAddress,
            ProductId = productImage.ProductId,
            TitleAttr = productImage.TitleAttr,
            width = productImage.width
        };
        try
        {
            var result = _db.ProductImages.Add(image);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"تصویر به گالری محصول {productImage.ProductId} افزوده شد",
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