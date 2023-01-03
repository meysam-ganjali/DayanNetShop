
using DayanShop.Application.StoreServices.Queries.Product;
using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;
using static DayanShop.Application.StoreServices.Queries.Shoping.FetchProductWithFilter;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace DayanShop.Application.StoreServices.Queries.Shoping;

public interface IFetchProductWithFilter
{
    ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page, int pageSize, int? CatId);
}

public class FetchProductWithFilter : IFetchProductWithFilter
{
    private readonly DayanShopContext _db;

    public FetchProductWithFilter(DayanShopContext db)
    {
        _db = db;
    }

    public ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page, int pageSize, int? CatId)
    {
        int totalRow = 0;
        var productQuery = _db.Products
            .Include(p => p.ProductImages)
            .Include(p=>p.ChildCategory)
            .ThenInclude(p=>p.ParentCategory)
            .ToPaged(Page, pageSize, out totalRow)
            .ToList();

        if (CatId != null)
        {
            productQuery = productQuery.Where(p => p.ChildCategoryId == CatId || p.ChildCategory.ParentCategoryId == CatId).ToList();
        }
        if (!string.IsNullOrWhiteSpace(SearchKey))
        {
            productQuery = productQuery.Where(p => p.Name.Contains(SearchKey) || p.Slug.Contains(SearchKey)).ToList();
        }

        switch (ordering)
        {
            case Ordering.NotOrder:
                productQuery = productQuery.OrderByDescending(p => p.Id).ToList();
                break;
            case Ordering.MostVisited:
                productQuery = productQuery.OrderByDescending(p => p.ShowCount).ToList();
                break;
            case Ordering.Bestselling:
                break;
            case Ordering.MostPopular:
                break;
            case Ordering.theNewest:
                productQuery = productQuery.OrderByDescending(p => p.Id).ToList();
                break;
            case Ordering.Cheapest:
                productQuery = productQuery.OrderBy(p => p.Price).ToList();
                break;
            case Ordering.theMostExpensive:
                productQuery = productQuery.OrderByDescending(p => p.Price).ToList();
                break;
            default:
                break;
        }

     

        Random rd = new Random();
        return new ResultDto<ResultProductForSiteDto>
        {
            Data = new ResultProductForSiteDto
            {
              RowCount = totalRow,
              CurrentPage = Page,
              PageSize = pageSize,
              Products = productQuery,
              ChildCategories = _db.ChildCategories.ToList()
            },
            IsSuccess = true,
        };
    }
}
public class ResultProductForSiteDto
{

    public List<Domains.Entities.Product> Products { get; set; }
    public List<ChildCategory> ChildCategories { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}
public enum Ordering
{

    NotOrder = 0,
    /// <summary>
    /// پربازدیدترین
    /// </summary>
    MostVisited = 1,
    /// <summary>
    /// پرفروشترین
    /// </summary>
    Bestselling = 2,
    /// <summary>
    /// محبوبترین
    /// </summary>
    MostPopular = 3,
    /// <summary>
    /// جدیدترین
    /// </summary>
    theNewest = 4,
    /// <summary>
    /// ارزانترین
    /// </summary>
    Cheapest = 5,
    /// <summary>
    /// گرانترین
    /// </summary>
    theMostExpensive = 6
}
