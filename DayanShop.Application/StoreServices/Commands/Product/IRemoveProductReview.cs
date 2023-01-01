using DayanShop.Core.Data;
using DayanShop.Utilities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Commands.Product;

public interface IRemoveProductReview
{
    Task<ResultDto> RemoveAsync(int id);
}

public class RemoveProductReview : IRemoveProductReview
{
    private readonly DayanShopContext _db;
    private IHostingEnvironment _environment;

    public RemoveProductReview(DayanShopContext db, IHostingEnvironment environment)
    {
        _db = db;
        _environment = environment;
    }

    public async Task<ResultDto> RemoveAsync(int id)
    {

        var reviewInDb = await _db.ProductReviws
            .Include(p => p.Product)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (reviewInDb == null)
        {
            return new ResultDto
            {
                IsSuccess = false,
                Message = "بررسی یافت نشد"
            };
        }

        try
        {
            var result = _db.ProductReviws.Remove(reviewInDb);
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, reviewInDb.ImagePath.TrimStart('\\'));
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }
            await _db.SaveChangesAsync();
            return new ResultDto
            {
                Message = $"بررسی فوق از لیست بررسی محصول {reviewInDb.Product.Name} حذف شد",
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