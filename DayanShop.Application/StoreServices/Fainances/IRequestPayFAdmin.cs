using DayanShop.Core.Data;
using DayanShop.Domains.Entities;
using DayanShop.Utilities.DTOs;
using DayanShop.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DayanShop.Application.StoreServices.Fainances;

public interface IRequestPayFAdmin
{
  ReslutPayDto GetAsync(RequestRequestPayDto req);
}

public class RequestPayFAdmin : IRequestPayFAdmin
{
    private readonly DayanShopContext _db;

    public RequestPayFAdmin(DayanShopContext db)
    {
        _db = db;
    }

    public  ReslutPayDto GetAsync(RequestRequestPayDto req)
    {
        int rowsCount = req.PageSize;
        var requestPay =  _db.RequestPays
            .Include(p=>p.User)
            .Include(p=>p.Orders)
            .ToPaged(req.Page, req.PageSize, out rowsCount)
            .ToList();

            return new ReslutPayDto()
            {
               PageSize = req.PageSize,
               RowCount = rowsCount,
               CurrentPage = req.Page,
               RequestPayLst = requestPay.ToList()
            };
        
        
    }
}
public class RequestRequestPayDto
{
    public string SearchKey { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
public class ReslutPayDto
{
    public IEnumerable<RequestPay> RequestPayLst { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}