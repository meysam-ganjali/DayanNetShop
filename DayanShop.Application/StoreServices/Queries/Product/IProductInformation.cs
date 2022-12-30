using DayanShop.Core.Data;
using DayanShop.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Queries.Product;

public interface IProductInformation
{
    ReslutGetProductDto GetAllProductAsync(RequestGetProductDto request);

}

public class ProductInformation : IProductInformation
{
    private readonly DayanShopContext _db;

    public ProductInformation(DayanShopContext db)
    {
        _db = db;
    }

    public ReslutGetProductDto GetAllProductAsync(RequestGetProductDto request)
    {
        int rowsCount = request.PageSize;

        var product = _db.Products
            .Include(p => p.ProductImages)
            .Include(p => p.ChildCategory)
            .ThenInclude(p => p.ParentCategory)
            .ToPaged(request.Page, request.PageSize, out rowsCount)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            product = product.Where(p => p.Name.Contains(request.SearchKey) || p.Slug.Contains(request.SearchKey)).AsQueryable();
        }


        return new ReslutGetProductDto()
        {
            RowCount = rowsCount,
            PageSize = request.PageSize,
            CurrentPage = request.Page,
            Products =  product.ToList()
        };
    }
}
public class RequestGetProductDto
{
    public string SearchKey { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
public class ReslutGetProductDto
{
    public IEnumerable<Domains.Entities.Product> Products { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}