using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Hosting;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IRemoveProductPicture
{
    Task<ResultDto> DeleteAsync(int id);
}

public class RemoveProductPicture : IRemoveProductPicture
{
    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public RemoveProductPicture(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> DeleteAsync(int id)
    {
        var imageInDb = await _db.ProductImages.FindAsync(id);
        if (imageInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "تصویر یافت نشد"
            };
        }

        try
        {
            var result = _db.ProductImages.Remove(imageInDb);
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, imageInDb.ImagePath.TrimStart('\\'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"تصویر از سیستم حذف گردید.",
                IsSuccess = true
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
