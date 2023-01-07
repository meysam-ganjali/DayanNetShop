using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DayanShop.Application.StoreServices.Commands.Slider;

public interface ICreateSlider
{
    Task<ResultDto> CreateAsync(IFormFile img, Domains.Entities.Common.Slider slider);
}

public class CreateSlider : ICreateSlider
{
    private readonly DayanShopContext _db;
    private readonly IHostingEnvironment _environment;

    public CreateSlider(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> CreateAsync(IFormFile img, Domains.Entities.Common.Slider slider)
    {
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(img, $@"assets\slider\");
        try
        {
            slider.ImagePath = uploadedResult.FileNameAddress;
            var result = _db.Sliders.Add(slider);
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"اسلادر با عنوان {slider.Title} به لیست الایدرها افزوده شد",
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