using DayanShop.Core.Data;
using DayanShop.Domains.Entities.Common;
using DayanShop.Utilities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Slider;

public interface IShowSlider
{
    Task<ResultDto<IEnumerable<Domains.Entities.Common.Slider>>>
        GetAsync(SliderPossition? possition, string? searchKey);
}

public class ShowSlider : IShowSlider
{
    private readonly DayanShopContext _db;

    public ShowSlider(DayanShopContext db)
    {
        _db = db;
    }

    public async Task<ResultDto<IEnumerable<Domains.Entities.Common.Slider>>> GetAsync(SliderPossition? possition, string? searchKey)
    {
        var sliders =  _db.Sliders.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchKey))
        {
            sliders = sliders.Where(p => p.Title.Contains(searchKey) || p.Description.Contains(searchKey))
                .AsQueryable();
        }

        if (possition != null)
        {
            sliders = sliders.Where(p => p.Possition == possition).AsQueryable();
        }

        if (sliders == null)
        {
            return new ResultDto<IEnumerable<Domains.Entities.Common.Slider>>
            {
                Data = null,
                IsSuccess = false,
                Message = "اسلایدری برای نمایش یافت نشد"
            };
        }

        return new ResultDto<IEnumerable<Domains.Entities.Common.Slider>>
        {
            Data = await sliders.ToListAsync(),
            IsSuccess = true
        };
    }
}